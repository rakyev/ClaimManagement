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
    public class CaseContactTypesController : ApiController
    {
        private CaseContactTypeBO db = new CaseContactTypeBO();

        // GET: api/CaseContactTypes
        public IQueryable<CaseContactType> Get()
        {
            return db.GetAll();
        }

        // GET: api/CaseContactTypes/5
        [ResponseType(typeof(CaseContactType))]
        public IHttpActionResult Get(long id)
        {
            CaseContactType caseContactType = db.GetByKey(id);
            if (caseContactType == null)
            {
                return NotFound();
            }

            return Ok(caseContactType);
        }

        // PUT: api/CaseContactTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, CaseContactType caseContactType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caseContactType.CaseContactTypeID)
            {
                return BadRequest();
            }
            try
            {
                db.Update(caseContactType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseContactTypeExists(id))
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

        // POST: api/CaseContactTypes
        [ResponseType(typeof(CaseContactType))]
        public IHttpActionResult Post(CaseContactType caseContactType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(caseContactType);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = caseContactType.CaseContactTypeID }, caseContactType);
        }

        // DELETE: api/CaseContactTypes/5
        [ResponseType(typeof(CaseContactType))]
        public IHttpActionResult Delete(long id)
        {
            CaseContactType caseContactType = db.GetByKey(id);
            if (caseContactType == null)
            {
                return NotFound();
            }

            db.Delete(caseContactType);
            db.Save();

            return Ok(caseContactType);
        }

        protected override void Dispose(bool disposing)
        {
          /*  if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool CaseContactTypeExists(long id)
        {
            //return db.CaseContactTypes.Count(e => e.CaseContactTypeID == id) > 0;
            return true;
        }
    }
}