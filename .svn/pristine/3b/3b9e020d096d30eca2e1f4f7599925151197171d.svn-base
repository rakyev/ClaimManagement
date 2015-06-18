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
    public class ActivityTypesController : ApiController
    {
        private ActivityTypeBO db = new ActivityTypeBO();

        // GET: api/ActivityTypes
        public IQueryable<ActivityType> Get()
        {
            return db.GetAll();
        }

        // GET: api/ActivityTypes/5
        [ResponseType(typeof(ActivityType))]
        public IHttpActionResult Get(long id)
        {
            ActivityType activityType = db.GetByKey(id);
            if (activityType == null)
            {
                return NotFound();
            }

            return Ok(activityType);
        }

        // PUT: api/ActivityTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, ActivityType activityType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activityType.ActivityTypeID)
            {
                return BadRequest();
            }

            db.Update(activityType);

            try
            {
                db.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityTypeExists(id))
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

        // POST: api/ActivityTypes
        [ResponseType(typeof(ActivityType))]
        public IHttpActionResult Post(ActivityType activityType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(activityType);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = activityType.ActivityTypeID }, activityType);
        }

        // DELETE: api/ActivityTypes/5
        [ResponseType(typeof(ActivityType))]
        public IHttpActionResult Delete(long id)
        {
            ActivityType activityType = db.GetByKey(id);
            if (activityType == null)
            {
                return NotFound();
            }

            db.Delete(activityType);
            db.Save();

            return Ok(activityType);
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

        private bool ActivityTypeExists(long id)
        {
            return true;//db.ActivityTypes.Count(e => e.ActivityTypeID == id) > 0;
        }
    }
}