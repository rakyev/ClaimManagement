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
    public class ActivitySubTypesController : ApiController
    {
        private ActivitySubTypeBO db = new ActivitySubTypeBO();

        // GET: api/ActivitySubTypes
        public IQueryable<ActivitySubType> Get()
        {
            return db.GetAll();
        }

        // GET: api/ActivitySubTypes/5
        [ResponseType(typeof(ActivitySubType))]
        public IHttpActionResult Get(long id)
        {
            ActivitySubType activitySubType = db.GetByKey(id);
            if (activitySubType == null)
            {
                return NotFound();
            }

            return Ok(activitySubType);
        }

        // PUT: api/ActivitySubTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, ActivitySubType activitySubType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activitySubType.ActivitySubTypeID)
            {
                return BadRequest();
            }

            db.Update(activitySubType);

            try
            {
                db.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivitySubTypeExists(id))
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

        // POST: api/ActivitySubTypes
        [ResponseType(typeof(ActivitySubType))]
        public IHttpActionResult Post(ActivitySubType activitySubType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(activitySubType);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = activitySubType.ActivitySubTypeID }, activitySubType);
        }

        // DELETE: api/ActivitySubTypes/5
        [ResponseType(typeof(ActivitySubType))]
        public IHttpActionResult Delete(long id)
        {
            ActivitySubType activitySubType = db.GetByKey(id);
            if (activitySubType == null)
            {
                return NotFound();
            }

            db.Delete(activitySubType);
            db.Save();

            return Ok(activitySubType);
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

        private bool ActivitySubTypeExists(long id)
        {
            return true;//db.ActivitySubTypes.Count(e => e.ActivitySubTypeID == id) > 0;
        }
    }
}