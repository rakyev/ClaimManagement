using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ICM.Data;
using ICM.Data.Business.BusinessObject;

namespace ICM.Web.API.Controllers
{
    public class CaseProvidersController : ApiController
    {
        private CaseProviderBO db = new CaseProviderBO();

        // GET: api/CaseProviders
        public IQueryable<CaseProvider> Get()
        {
            return db.GetAll();
        }

        // GET: api/CaseProviders/5
        [ResponseType(typeof(CaseProvider))]
        public IHttpActionResult Get(long id)
        {
            CaseProvider caseProvider = db.GetByKey(id);
            if (caseProvider == null)
            {
                return NotFound();
            }

            return Ok(caseProvider);
        }

        // PUT: api/CaseProviders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, CaseProvider caseProvider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caseProvider.CaseProviderID)
            {
                return BadRequest();
            }
            try
            {
                db.Update(caseProvider);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseProviderExists(id))
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

        // POST: api/CaseProviders
        [ResponseType(typeof(CaseProvider))]
        public IHttpActionResult Post(CaseProvider caseProvider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(caseProvider);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = caseProvider.CaseProviderID }, caseProvider);
        }

        // DELETE: api/CaseProviders/5
        [ResponseType(typeof(CaseProvider))]
        public IHttpActionResult Delete(long id)
        {
            CaseProvider caseProvider = db.GetByKey(id);
            if (caseProvider == null)
            {
                return NotFound();
            }

            db.Delete(caseProvider);
            db.Save();

            return Ok(caseProvider);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool CaseProviderExists(long id)
        {
            return true; // db.CaseProviders.Count(e => e.CaseProviderID == id) > 0;
        }
    }
}