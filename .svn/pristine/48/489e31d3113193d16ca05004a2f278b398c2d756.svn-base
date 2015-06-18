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
    public class AppointmentResourceNationalHolidaysController : ApiController
    {
        private AppointmentResourceNationalHolidayBO db = new AppointmentResourceNationalHolidayBO();

        // GET: api/AppointmentResourceNationalHolidays
        public IQueryable<AppointmentResourceNationalHoliday> Get()
        {
            return db.GetAll();
        }

        // GET: api/AppointmentResourceNationalHolidays/5
        [ResponseType(typeof(AppointmentResourceNationalHoliday))]
        public IHttpActionResult Get(long id)
        {
            AppointmentResourceNationalHoliday appointmentResourceNationalHoliday = db.GetByKey(id);
            if (appointmentResourceNationalHoliday == null)
            {
                return NotFound();
            }

            return Ok(appointmentResourceNationalHoliday);
        }

        // PUT: api/AppointmentResourceNationalHolidays/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, AppointmentResourceNationalHoliday appointmentResourceNationalHoliday)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointmentResourceNationalHoliday.AppointmentResourceNationalHolidayID)
            {
                return BadRequest();
            }

            

            try
            {
                db.Update(appointmentResourceNationalHoliday);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentResourceNationalHolidayExists(id))
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

        // POST: api/AppointmentResourceNationalHolidays
        [ResponseType(typeof(AppointmentResourceNationalHoliday))]
        public IHttpActionResult Post(AppointmentResourceNationalHoliday appointmentResourceNationalHoliday)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(appointmentResourceNationalHoliday);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = appointmentResourceNationalHoliday.AppointmentResourceNationalHolidayID }, appointmentResourceNationalHoliday);
        }

        // DELETE: api/AppointmentResourceNationalHolidays/5
        [ResponseType(typeof(AppointmentResourceNationalHoliday))]
        public IHttpActionResult Delete(long id)
        {
            AppointmentResourceNationalHoliday appointmentResourceNationalHoliday = db.GetByKey(id);
            if (appointmentResourceNationalHoliday == null)
            {
                return NotFound();
            }

            db.Delete(appointmentResourceNationalHoliday);
            db.Save();

            return Ok(appointmentResourceNationalHoliday);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool AppointmentResourceNationalHolidayExists(long id)
        {
            return true;//db.AppointmentResourceNationalHolidays.Count(e => e.AppointmentResourceNationalHolidayID == id) > 0;
        }
    }
}