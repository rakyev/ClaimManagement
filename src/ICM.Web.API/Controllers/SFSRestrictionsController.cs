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
    public class SFSRestrictionsController : ApiController
    {
        private readonly SFSRestrictionBO _db = new SFSRestrictionBO();
        //private ICMDBContext db = new ICMDBContext();

        // GET: api/SFSRestrictions
        public IQueryable<SFSRestriction> Get()
        {
            return _db.GetAll();
        }

        // GET: api/SFSRestrictions/5
        [ResponseType(typeof(SFSRestriction))]
        public IHttpActionResult Get(int id)
        {
            SFSRestriction sFSRestriction = _db.GetByKey(id);
            if (sFSRestriction == null)
            {
                return NotFound();
            }

            return Ok(sFSRestriction);
        }

        // PUT: api/SFSRestrictions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, SFSRestriction sFSRestriction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sFSRestriction.rs_pk)
            {
                return BadRequest();
            }

            try
            {
                _db.Update(sFSRestriction);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SFSRestrictionExists(id))
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

        // POST: api/SFSRestrictions
        [ResponseType(typeof(SFSRestriction))]
        public IHttpActionResult Post(SFSRestriction sFSRestriction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(sFSRestriction);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = sFSRestriction.rs_pk }, sFSRestriction);
        }

        // DELETE: api/SFSRestrictions/5
        [ResponseType(typeof(SFSRestriction))]
        public IHttpActionResult Delete(int id)
        {
            SFSRestriction sFSRestriction = _db.GetByKey(id);
            if (sFSRestriction == null)
            {
                return NotFound();
            }

            _db.Delete(sFSRestriction);
            _db.Save();

            return Ok(sFSRestriction);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool SFSRestrictionExists(int id)
        {
            //return db.SFSRestrictions.Count(e => e.rs_pk == id) > 0;
            return true;
        }
    }
}