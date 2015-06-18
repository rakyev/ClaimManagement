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
    public class AppointmentResourceResourceTypesController : ApiController
    {
        private AppointmentResourceResourceTypeBO db = new AppointmentResourceResourceTypeBO();

        // GET: api/AppointmentResourceResourceTypes
        public IQueryable<AppointmentResourceResourceType> Get()
        {
            return db.GetAll();
        }

        // GET: api/AppointmentResourceResourceTypes/5
        [ResponseType(typeof(AppointmentResourceResourceType))]
        public IHttpActionResult Get(long id)
        {
            AppointmentResourceResourceType appointmentResourceResourceType = db.GetByKey(id);
            if (appointmentResourceResourceType == null)
            {
                return NotFound();
            }

            return Ok(appointmentResourceResourceType);
        }

        // PUT: api/AppointmentResourceResourceTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, AppointmentResourceResourceType appointmentResourceResourceType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointmentResourceResourceType.AppointmentResourceResourceTypeID)
            {
                return BadRequest();
            }

            

            try
            {
                db.Update(appointmentResourceResourceType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentResourceResourceTypeExists(id))
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

        // POST: api/AppointmentResourceResourceTypes
        [ResponseType(typeof(AppointmentResourceResourceType))]
        public IHttpActionResult Post(AppointmentResourceResourceType appointmentResourceResourceType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(appointmentResourceResourceType);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = appointmentResourceResourceType.AppointmentResourceResourceTypeID }, appointmentResourceResourceType);
        }

        // DELETE: api/AppointmentResourceResourceTypes/5
        [ResponseType(typeof(AppointmentResourceResourceType))]
        public IHttpActionResult Delete(long id)
        {
            AppointmentResourceResourceType appointmentResourceResourceType = db.GetByKey(id);
            if (appointmentResourceResourceType == null)
            {
                return NotFound();
            }

            db.Delete(appointmentResourceResourceType);
            db.Save();

            return Ok(appointmentResourceResourceType);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool AppointmentResourceResourceTypeExists(long id)
        {
            return true;//db.AppointmentResourceResourceTypes.Count(e => e.AppointmentResourceResourceTypeID == id) > 0;
        }
    }
}