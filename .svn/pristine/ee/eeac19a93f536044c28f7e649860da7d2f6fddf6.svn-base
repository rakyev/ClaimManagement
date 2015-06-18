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
    public class PrefixesController : ApiController
    {
         private readonly PrefixBO _db = new PrefixBO();

        // GET: api/Prefixes
        public IQueryable<Prefix> Get()
        {
            return _db.GetAll();
        }

        // GET: api/Prefixes/5
        [ResponseType(typeof(Prefix))]
        public IHttpActionResult Get(long id)
        {
            Prefix prefix = _db.GetByKey(id);
            if (prefix == null)
            {
                return NotFound();
            }

            return Ok(prefix);
        }

        // PUT: api/Prefixes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, Prefix prefix)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prefix.PrefixID)
            {
                return BadRequest();
            }
            try
            {
                _db.Update(prefix);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrefixExists(id))
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

        // POST: api/Prefixes
        [ResponseType(typeof(Prefix))]
        public IHttpActionResult Post(Prefix prefix)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(prefix);
            _db.Save();
            return CreatedAtRoute("DefaultApi", new { id = prefix.PrefixID }, prefix);
        }

        // DELETE: api/Prefixes/5
        [ResponseType(typeof(Prefix))]
        public IHttpActionResult Delete(long id)
        {
            Prefix prefix = _db.GetByKey(id);
            if (prefix == null)
            {
                return NotFound();
            }

            _db.Delete(prefix);
            _db.Save();
            return Ok(prefix);
        }
        
        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            //{
            //    db.Dispose();
            //}
            base.Dispose(disposing);*/
        }

        private bool PrefixExists(long id)
        {
            //return db.Prefix.Count(e => e.PrefixID == id) > 0;
            return true;
        }
    } 
}