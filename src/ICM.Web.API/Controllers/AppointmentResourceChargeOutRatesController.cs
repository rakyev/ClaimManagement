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
    public class AppointmentResourceChargeOutRatesController : ApiController
    {
        private AppointmentResourceChargeOutRateBO db = new AppointmentResourceChargeOutRateBO();

        // GET: api/AppointmentResourceChargeOutRates
        public IQueryable<AppointmentResourceChargeOutRate> Get()
        {
            return db.GetAll();
        }

        // GET: api/AppointmentResourceChargeOutRates/5
        [ResponseType(typeof(AppointmentResourceChargeOutRate))]
        public IHttpActionResult Get(long id)
        {
            AppointmentResourceChargeOutRate appointmentResourceChargeOutRate = db.GetByKey(id);
            if (appointmentResourceChargeOutRate == null)
            {
                return NotFound();
            }

            return Ok(appointmentResourceChargeOutRate);
        }

        // PUT: api/AppointmentResourceChargeOutRates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, AppointmentResourceChargeOutRate appointmentResourceChargeOutRate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointmentResourceChargeOutRate.AppointmentResourceChargeOutRateID)
            {
                return BadRequest();
            }

            
            try
            {
                db.Update(appointmentResourceChargeOutRate);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentResourceChargeOutRateExists(id))
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

        // POST: api/AppointmentResourceChargeOutRates
        [ResponseType(typeof(AppointmentResourceChargeOutRate))]
        public IHttpActionResult Post(AppointmentResourceChargeOutRate appointmentResourceChargeOutRate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(appointmentResourceChargeOutRate);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = appointmentResourceChargeOutRate.AppointmentResourceChargeOutRateID }, appointmentResourceChargeOutRate);
        }

        // DELETE: api/AppointmentResourceChargeOutRates/5
        [ResponseType(typeof(AppointmentResourceChargeOutRate))]
        public IHttpActionResult Delete(long id)
        {
            AppointmentResourceChargeOutRate appointmentResourceChargeOutRate = db.GetByKey(id);
            if (appointmentResourceChargeOutRate == null)
            {
                return NotFound();
            }

            db.Delete(appointmentResourceChargeOutRate);
            db.Save();

            return Ok(appointmentResourceChargeOutRate);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool AppointmentResourceChargeOutRateExists(long id)
        {
            return true;//db.AppointmentResourceChargeOutRates.Count(e => e.AppointmentResourceChargeOutRateID == id) > 0;
        }
    }
}