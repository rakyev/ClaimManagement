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
    public class CaseTypesController : ApiController
    {
        private CaseTypeBO db = new CaseTypeBO();

        // GET: api/CaseTypes
        public IQueryable<CaseType> Get()
        {
            return db.GetAll();
        }

        // GET: api/CaseTypes/5
        [ResponseType(typeof(CaseType))]
        public IHttpActionResult Get(long id)
        {
            CaseType caseType = db.GetByKey(id);
            if (caseType == null)
            {
                return NotFound();
            }

            return Ok(caseType);
        }

        // PUT: api/CaseTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, CaseType caseType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caseType.CaseTypeID)
            {
                return BadRequest();
            }
            try
            {
                db.Update(caseType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseTypeExists(id))
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

        // POST: api/CaseTypes
        [ResponseType(typeof(CaseType))]
        public IHttpActionResult Post(CaseType caseType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(caseType);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = caseType.CaseTypeID }, caseType);
        }

        // DELETE: api/CaseTypes/5
        [ResponseType(typeof(CaseType))]
        public IHttpActionResult Delete(long id)
        {
            CaseType caseType = db.GetByKey(id);
            if (caseType == null)
            {
                return NotFound();
            }

            db.Delete(caseType);
            db.Save();

            return Ok(caseType);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool CaseTypeExists(long id)
        {
            return true; // db.CaseTypes.Count(e => e.CaseTypeID == id) > 0;
        }
    }
}