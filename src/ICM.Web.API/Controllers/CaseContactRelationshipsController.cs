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
    public class CaseContactRelationshipsController : ApiController
    {
        private CaseContactRelationshipBO db = new CaseContactRelationshipBO();

        // GET: api/CaseContactRelationships
        public IQueryable<CaseContactRelationship> Get()
        {
            return db.GetAll();
        }

        // GET: api/CaseContactRelationships/5
        [ResponseType(typeof(CaseContactRelationship))]
        public IHttpActionResult Get(long id)
        {
            CaseContactRelationship caseContactRelationship = db.GetByKey(id);
            if (caseContactRelationship == null)
            {
                return NotFound();
            }

            return Ok(caseContactRelationship);
        }

        // PUT: api/CaseContactRelationships/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, CaseContactRelationship caseContactRelationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caseContactRelationship.CaseContactRelationshipID)
            {
                return BadRequest();
            }
            try
            {
                db.Update(caseContactRelationship);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseContactRelationshipExists(id))
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

        // POST: api/CaseContactRelationships
        [ResponseType(typeof(CaseContactRelationship))]
        public IHttpActionResult Post(CaseContactRelationship caseContactRelationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(caseContactRelationship);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = caseContactRelationship.CaseContactRelationshipID }, caseContactRelationship);
        }

        // DELETE: api/CaseContactRelationships/5
        [ResponseType(typeof(CaseContactRelationship))]
        public IHttpActionResult Delete(long id)
        {
            CaseContactRelationship caseContactRelationship = db.GetByKey(id);
            if (caseContactRelationship == null)
            {
                return NotFound();
            }

            db.Delete(caseContactRelationship);
            db.Save();

            return Ok(caseContactRelationship);
        }

        protected override void Dispose(bool disposing)
        {
          /*  if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool CaseContactRelationshipExists(long id)
        {
           // return db.CaseContactRelationships.Count(e => e.CaseContactRelationshipID == id) > 0;
            return true;
        }
    }
}