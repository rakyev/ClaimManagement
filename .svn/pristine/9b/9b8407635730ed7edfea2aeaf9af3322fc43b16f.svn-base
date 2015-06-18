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
    public class AppointmentResourceBookingTypesController : ApiController
    {
        private AppointmentResourceBookingTypeBO db = new AppointmentResourceBookingTypeBO();

        // GET: api/AppointmentResourceBookingTypes
        public IQueryable<AppointmentResourceBookingType> Get()
        {
            return db.GetAll();
        }

        // GET: api/AppointmentResourceBookingTypes/5
        [ResponseType(typeof(AppointmentResourceBookingType))]
        public IHttpActionResult Get(long id)
        {
            AppointmentResourceBookingType appointmentResourceBookingType = db.GetByKey(id);
            if (appointmentResourceBookingType == null)
            {
                return NotFound();
            }

            return Ok(appointmentResourceBookingType);
        }

        // PUT: api/AppointmentResourceBookingTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, AppointmentResourceBookingType appointmentResourceBookingType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointmentResourceBookingType.AppointmentResourceBookingTypeID)
            {
                return BadRequest();
            }
            try
            {
                db.Update(appointmentResourceBookingType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentResourceBookingTypeExists(id))
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

        // POST: api/AppointmentResourceBookingTypes
        [ResponseType(typeof(AppointmentResourceBookingType))]
        public IHttpActionResult Post(AppointmentResourceBookingType appointmentResourceBookingType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(appointmentResourceBookingType);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = appointmentResourceBookingType.AppointmentResourceBookingTypeID }, appointmentResourceBookingType);
        }

        // DELETE: api/AppointmentResourceBookingTypes/5
        [ResponseType(typeof(AppointmentResourceBookingType))]
        public IHttpActionResult Delete(long id)
        {
            AppointmentResourceBookingType appointmentResourceBookingType = db.GetByKey(id);
            if (appointmentResourceBookingType == null)
            {
                return NotFound();
            }

            db.Delete(appointmentResourceBookingType);
            db.Save();

            return Ok(appointmentResourceBookingType);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool AppointmentResourceBookingTypeExists(long id)
        {
            return true;//db.AppointmentResourceBookingTypes.Count(e => e.AppointmentResourceBookingTypeID == id) > 0;
        }
    }
}