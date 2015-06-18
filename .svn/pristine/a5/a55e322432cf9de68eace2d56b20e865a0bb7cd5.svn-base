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
    public class AdjustersController : ApiController
    {
        private AdjusterBO db = new AdjusterBO();

        // GET: api/Adjusters
        public IQueryable<Adjuster> Get()
        {
            return db.GetAll();
        }

        // GET: api/Adjusters/5
        [ResponseType(typeof(Adjuster))]
        public IHttpActionResult Get(long id)
        {
            Adjuster adjuster = db.GetByKey(id);
            if (adjuster == null)
            {
                return NotFound();
            }

            return Ok(adjuster);
        }

        // PUT: api/Adjusters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, Adjuster adjuster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adjuster.AdjusterID)
            {
                return BadRequest();
            }

            db.Update(adjuster);

            try
            {
                db.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdjusterExists(id))
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

        // POST: api/Adjusters
        [ResponseType(typeof(Adjuster))]
        public IHttpActionResult Post(Adjuster adjuster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(adjuster);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = adjuster.AdjusterID }, adjuster);
        }

        // DELETE: api/Adjusters/5
        [ResponseType(typeof(Adjuster))]
        public IHttpActionResult Delete(long id)
        {
            Adjuster adjuster = db.GetByKey(id);
            if (adjuster == null)
            {
                return NotFound();
            }

            db.Delete(adjuster);
            db.Save();

            return Ok(adjuster);
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

        private bool AdjusterExists(long id)
        {
            return true;//db.Adjusters.Count(e => e.AdjusterID == id) > 0;
        }
    }
}