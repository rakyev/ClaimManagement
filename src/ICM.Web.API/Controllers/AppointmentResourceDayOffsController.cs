using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ICM.Data;
using ICM.Data.Business.BusinessObject;

namespace ICM.Web.API.Controllers
{
    public class AppointmentResourceDayOffsController : ApiController
    {
        private AppointmentResourceDayOffBO db = new AppointmentResourceDayOffBO();

        // GET: api/AppointmentResourceDayOffs
        public IQueryable<AppointmentResourceDayOff> Get()
        {
            return db.GetAll();
        }

        // GET: api/AppointmentResourceDayOffs/5
        [ResponseType(typeof(AppointmentResourceDayOff))]
        public IHttpActionResult Get(long id)
        {
            AppointmentResourceDayOff appointmentResourceDayOff = db.GetByKey(id);
            if (appointmentResourceDayOff == null)
            {
                return NotFound();
            }

            return Ok(appointmentResourceDayOff);
        }

        // PUT: api/AppointmentResourceDayOffs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, AppointmentResourceDayOff appointmentResourceDayOff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointmentResourceDayOff.AppointmentResourceDayOffID)
            {
                return BadRequest();
            }

            

            try
            {
                db.Update(appointmentResourceDayOff);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentResourceDayOffExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AppointmentResourceDayOffs
        [ResponseType(typeof(AppointmentResourceDayOff))]
        public IHttpActionResult Post(AppointmentResourceDayOff appointmentResourceDayOff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(appointmentResourceDayOff);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = appointmentResourceDayOff.AppointmentResourceDayOffID }, appointmentResourceDayOff);
        }

        // DELETE: api/AppointmentResourceDayOffs/5
        [ResponseType(typeof(AppointmentResourceDayOff))]
        public IHttpActionResult Delete(long id)
        {
            AppointmentResourceDayOff appointmentResourceDayOff = db.GetByKey(id);
            if (appointmentResourceDayOff == null)
            {
                return NotFound();
            }

            db.Delete(appointmentResourceDayOff);
            db.Save();

            return Ok(appointmentResourceDayOff);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool AppointmentResourceDayOffExists(long id)
        {
            return true;//db.AppointmentResourceDayOffs.Count(e => e.AppointmentResourceDayOffID == id) > 0;
        }
    }
}