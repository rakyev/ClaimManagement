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
    public class CaseActivitiesController : ApiController
    {
        private CaseActivityBO db = new CaseActivityBO();

        // GET: api/CaseActivities
        public IQueryable<CaseActivity> Get()
        {
            return db.GetAll();
        }

        // GET: api/CaseActivities/5
        [ResponseType(typeof(CaseActivity))]
        public IHttpActionResult Get(long id)
        {
            CaseActivity caseActivity = db.GetByKey(id);
            if (caseActivity == null)
            {
                return NotFound();
            }

            return Ok(caseActivity);
        }

        // PUT: api/CaseActivities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, CaseActivity caseActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caseActivity.CaseActivityID)
            {
                return BadRequest();
            }
            try
            {
                db.Update(caseActivity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseActivityExists(id))
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

        // POST: api/CaseActivities
        [ResponseType(typeof(CaseActivity))]
        public IHttpActionResult Post(CaseActivity caseActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(caseActivity);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = caseActivity.CaseActivityID }, caseActivity);
        }

        // DELETE: api/CaseActivities/5
        [ResponseType(typeof(CaseActivity))]
        public IHttpActionResult Delete(long id)
        {
            CaseActivity caseActivity = db.GetByKey(id);
            if (caseActivity == null)
            {
                return NotFound();
            }

            db.Delete(caseActivity);
            db.Save();

            return Ok(caseActivity);
        }

        
        protected override void Dispose(bool disposing)
        {
           /* if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool CaseActivityExists(long id)
        {
            //return db.CaseActivities.Count(e => e.CaseActivityID == id) > 0;
            return true;
        }
    }
}