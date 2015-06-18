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
    public class ActivityBookingsController : ApiController
    {
        private ActivityBookingBO db = new ActivityBookingBO();

        // GET: api/ActivityBookings
        public IQueryable<ActivityBooking> Get()
        {
            return db.GetAll();
        }

        // GET: api/ActivityBookings/5
        [ResponseType(typeof(ActivityBooking))]
        public IHttpActionResult Get(long id)
        {
            ActivityBooking activityBooking = db.GetByKey(id);
            if (activityBooking == null)
            {
                return NotFound();
            }

            return Ok(activityBooking);
        }

        // PUT: api/ActivityBookings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, ActivityBooking activityBooking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activityBooking.ActivityBookingID)
            {
                return BadRequest();
            }

            db.Update(activityBooking);

            try
            {
                db.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityBookingExists(id))
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

        // POST: api/ActivityBookings
        [ResponseType(typeof(ActivityBooking))]
        public IHttpActionResult Post(ActivityBooking activityBooking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(activityBooking);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = activityBooking.ActivityBookingID }, activityBooking);
        }

        // DELETE: api/ActivityBookings/5
        [ResponseType(typeof(ActivityBooking))]
        public IHttpActionResult Delete(long id)
        {
            ActivityBooking activityBooking = db.GetByKey(id);
            if (activityBooking == null)
            {
                return NotFound();
            }

            db.Delete(activityBooking);
            db.Save();

            return Ok(activityBooking);
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

        private bool ActivityBookingExists(long id)
        {
            return true;//db.ActivityBookings.Count(e => e.ActivityBookingID == id) > 0;
        }
    }
}