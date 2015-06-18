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
    public class ActivityBookingTypesController : ApiController
    {
        private ActivityBookingTypeBO db = new ActivityBookingTypeBO();

        // GET: api/ActivityBookingTypes
        public IQueryable<ActivityBookingType> Get()
        {
            return db.GetAll();
        }

        // GET: api/ActivityBookingTypes/5
        [ResponseType(typeof(ActivityBookingType))]
        public IHttpActionResult Get(long id)
        {
            ActivityBookingType activityBookingType = db.GetByKey(id);
            if (activityBookingType == null)
            {
                return NotFound();
            }

            return Ok(activityBookingType);
        }

        // PUT: api/ActivityBookingTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, ActivityBookingType activityBookingType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activityBookingType.ActivityBookingTypeID)
            {
                return BadRequest();
            }

            db.Update(activityBookingType);

            try
            {
                db.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityBookingTypeExists(id))
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

        // POST: api/ActivityBookingTypes
        [ResponseType(typeof(ActivityBookingType))]
        public IHttpActionResult Post(ActivityBookingType activityBookingType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(activityBookingType);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = activityBookingType.ActivityBookingTypeID }, activityBookingType);
        }

        // DELETE: api/ActivityBookingTypes/5
        [ResponseType(typeof(ActivityBookingType))]
        public IHttpActionResult Delete(long id)
        {
            ActivityBookingType activityBookingType = db.GetByKey(id);
            if (activityBookingType == null)
            {
                return NotFound();
            }

            db.Delete(activityBookingType);
            db.Save();

            return Ok(activityBookingType);
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

        private bool ActivityBookingTypeExists(long id)
        {
            return true;//db.ActivityBookingTypes.Count(e => e.ActivityBookingTypeID == id) > 0;
        }
    }
}