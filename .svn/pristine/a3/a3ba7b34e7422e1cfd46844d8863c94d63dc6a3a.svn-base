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
    public class AppointmentResourceTypesController : ApiController
    {
        private AppointmentResourceTypeBO db = new AppointmentResourceTypeBO();

        // GET: api/AppointmentResourceTypes
        public IQueryable<AppointmentResourceType> Get()
        {
            return db.GetAll();
        }

        // GET: api/AppointmentResourceTypes/5
        [ResponseType(typeof(AppointmentResourceType))]
        public IHttpActionResult Get(long id)
        {
            AppointmentResourceType appointmentResourceType = db.GetByKey(id);
            if (appointmentResourceType == null)
            {
                return NotFound();
            }

            return Ok(appointmentResourceType);
        }

        // PUT: api/AppointmentResourceTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, AppointmentResourceType appointmentResourceType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointmentResourceType.AppointmentResourceTypeID)
            {
                return BadRequest();
            }

            

            try
            {
                db.Update(appointmentResourceType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentResourceTypeExists(id))
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

        // POST: api/AppointmentResourceTypes
        [ResponseType(typeof(AppointmentResourceType))]
        public IHttpActionResult Post(AppointmentResourceType appointmentResourceType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(appointmentResourceType);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = appointmentResourceType.AppointmentResourceTypeID }, appointmentResourceType);
        }

        // DELETE: api/AppointmentResourceTypes/5
        [ResponseType(typeof(AppointmentResourceType))]
        public IHttpActionResult Delete(long id)
        {
            AppointmentResourceType appointmentResourceType = db.GetByKey(id);
            if (appointmentResourceType == null)
            {
                return NotFound();
            }

            db.Delete(appointmentResourceType);
            db.Save();

            return Ok(appointmentResourceType);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool AppointmentResourceTypeExists(long id)
        {
            return true;//db.AppointmentResourceTypes.Count(e => e.AppointmentResourceTypeID == id) > 0;
        }
    }
}