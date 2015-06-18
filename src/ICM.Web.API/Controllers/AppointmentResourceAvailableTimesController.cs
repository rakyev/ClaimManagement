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
    public class AppointmentResourceAvailableTimesController : ApiController
    {
        private AppointmentResourceAvailableTimeBO db = new AppointmentResourceAvailableTimeBO();

        // GET: api/AppointmentResourceAvailableTimes
        public IQueryable<AppointmentResourceAvailableTime> Get()
        {
            return db.GetAll();
        }

        // GET: api/AppointmentResourceAvailableTimes/5
        [ResponseType(typeof(AppointmentResourceAvailableTime))]
        public IHttpActionResult Get(long id)
        {
            AppointmentResourceAvailableTime appointmentResourceAvailableTime = db.GetByKey(id);
            if (appointmentResourceAvailableTime == null)
            {
                return NotFound();
            }

            return Ok(appointmentResourceAvailableTime);
        }

        // PUT: api/AppointmentResourceAvailableTimes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, AppointmentResourceAvailableTime appointmentResourceAvailableTime)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointmentResourceAvailableTime.AppointmentResourceAvailableTimeID)
            {
                return BadRequest();
            }

            db.Update(appointmentResourceAvailableTime);

            try
            {
                db.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentResourceAvailableTimeExists(id))
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

        // POST: api/AppointmentResourceAvailableTimes
        [ResponseType(typeof(AppointmentResourceAvailableTime))]
        public IHttpActionResult Post(AppointmentResourceAvailableTime appointmentResourceAvailableTime)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(appointmentResourceAvailableTime);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = appointmentResourceAvailableTime.AppointmentResourceAvailableTimeID }, appointmentResourceAvailableTime);
        }

        // DELETE: api/AppointmentResourceAvailableTimes/5
        [ResponseType(typeof(AppointmentResourceAvailableTime))]
        public IHttpActionResult Delete(long id)
        {
            AppointmentResourceAvailableTime appointmentResourceAvailableTime = db.GetByKey(id);
            if (appointmentResourceAvailableTime == null)
            {
                return NotFound();
            }

            db.Delete(appointmentResourceAvailableTime);
            db.Save();

            return Ok(appointmentResourceAvailableTime);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
             */ 
        }

        private bool AppointmentResourceAvailableTimeExists(long id)
        {
            return true;//db.AppointmentResourceAvailableTimes.Count(e => e.AppointmentResourceAvailableTimeID == id) > 0;
        }
    }
}