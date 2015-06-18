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
    public class SFSAuditActivitiesController : ApiController
    {
        private readonly SFSAuditActivityBO _db = new SFSAuditActivityBO();
        //private ICMDBContext db = new ICMDBContext();
        // GET: api/SFSAuditActivities
        public IQueryable<SFSAuditActivity> Get()
        {
            return _db.GetAll();
        }

        // GET: api/SFSAuditActivities/5
        [ResponseType(typeof(SFSAuditActivity))]
        public IHttpActionResult Get(long id)
        {
            SFSAuditActivity sfsAuditActivity = _db.GetByKey(id);
            if (sfsAuditActivity == null)
            {
                return NotFound();
            }

            return Ok(sfsAuditActivity);
        }

        // PUT: api/SFSAuditActivities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, SFSAuditActivity sfsAuditActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sfsAuditActivity.sa_pk)
            {
                return BadRequest();
            }
            try
            {
                _db.Update(sfsAuditActivity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SFSAuditActivityExists(id))
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

        // POST: api/SFSAuditActivities
        [ResponseType(typeof(SFSAuditActivity))]
        public IHttpActionResult Post(SFSAuditActivity sfsAuditActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(sfsAuditActivity);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = sfsAuditActivity.sa_pk }, sfsAuditActivity);
        }

        // DELETE: api/SFSAuditActivities/5
        [ResponseType(typeof(SFSAuditActivity))]
        public IHttpActionResult Delete(long id)
        {
            SFSAuditActivity sfsAuditActivity = _db.GetByKey(id);
            if (sfsAuditActivity == null)
            {
                return NotFound();
            }

            _db.Delete(sfsAuditActivity);
            _db.Save();

            return Ok(sfsAuditActivity);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool SFSAuditActivityExists(long id)
        {
            //return db.SFSAuditActivities.Count(e => e.sa_pk == id) > 0;
            return true;
        }
    }
}