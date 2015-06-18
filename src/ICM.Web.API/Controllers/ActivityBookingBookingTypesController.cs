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
    public class ActivityBookingBookingTypesController : ApiController
    {
        private ActivityBookingBookingTypeBO db = new ActivityBookingBookingTypeBO();

        // GET: api/ActivityBookingBookingTypes
        public IQueryable<ActivityBookingBookingType> Get()
        {
            return db.GetAll();
        }

        // GET: api/ActivityBookingBookingTypes/5
        [ResponseType(typeof(ActivityBookingBookingType))]
        public IHttpActionResult Get(long id)
        {
            ActivityBookingBookingType activityBookingBookingType = db.GetByKey(id);
            if (activityBookingBookingType == null)
            {
                return NotFound();
            }

            return Ok(activityBookingBookingType);
        }

        // PUT: api/ActivityBookingBookingTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, ActivityBookingBookingType activityBookingBookingType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activityBookingBookingType.ActivityBookingBookingTypeID)
            {
                return BadRequest();
            }

            db.Update(activityBookingBookingType);

            try
            {
                db.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityBookingBookingTypeExists(id))
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

        // POST: api/ActivityBookingBookingTypes
        [ResponseType(typeof(ActivityBookingBookingType))]
        public IHttpActionResult Post(ActivityBookingBookingType activityBookingBookingType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(activityBookingBookingType);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = activityBookingBookingType.ActivityBookingBookingTypeID }, activityBookingBookingType);
        }

        // DELETE: api/ActivityBookingBookingTypes/5
        [ResponseType(typeof(ActivityBookingBookingType))]
        public IHttpActionResult Delete(long id)
        {
            ActivityBookingBookingType activityBookingBookingType = db.GetByKey(id);
            if (activityBookingBookingType == null)
            {
                return NotFound();
            }

            db.Delete(activityBookingBookingType);
            db.Save();

            return Ok(activityBookingBookingType);
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

        private bool ActivityBookingBookingTypeExists(long id)
        {
            return true;//db.ActivityBookingBookingTypes.Count(e => e.ActivityBookingBookingTypeID == id) > 0;
        }
    }
}