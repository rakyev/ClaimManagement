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
    public class SFSPreferencesController : ApiController
    {
        private readonly SFSPreferenceBO _db = new SFSPreferenceBO();
        //private ICMDBContext db = new ICMDBContext();

        // GET: api/SFSPreferences
        public IQueryable<SFSPreference> Get()
        {
            return _db.GetAll();
        }

        // GET: api/SFSPreferences/5
        [ResponseType(typeof(SFSPreference))]
        public IHttpActionResult Get(int id)
        {
            SFSPreference sFSPreference = _db.GetByKey(id);
            if (sFSPreference == null)
            {
                return NotFound();
            }

            return Ok(sFSPreference);
        }

        // PUT: api/SFSPreferences/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, SFSPreference sFSPreference)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sFSPreference.sp_pk)
            {
                return BadRequest();
            }

            try
            {
                _db.Update(sFSPreference);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SFSPreferenceExists(id))
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

        // POST: api/SFSPreferences
        [ResponseType(typeof(SFSPreference))]
        public IHttpActionResult Post(SFSPreference sFSPreference)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(sFSPreference);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = sFSPreference.sp_pk }, sFSPreference);
        }

        // DELETE: api/SFSPreferences/5
        [ResponseType(typeof(SFSPreference))]
        public IHttpActionResult Delete(int id)
        {
            SFSPreference sFSPreference = _db.GetByKey(id);
            if (sFSPreference == null)
            {
                return NotFound();
            }

            _db.Delete(sFSPreference);
            _db.Save();

            return Ok(sFSPreference);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool SFSPreferenceExists(int id)
        {
            //return db.SFSPreferences.Count(e => e.sp_pk == id) > 0;
            return true;
        }
    }
}