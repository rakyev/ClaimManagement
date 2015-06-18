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
    public class CaseInjuriesController : ApiController
    {
        private CaseInjuryBO db = new CaseInjuryBO();

        // GET: api/CaseInjuries
        public IQueryable<CaseInjury> Get()
        {
            return db.GetAll();
        }

        // GET: api/CaseInjuries/5
        [ResponseType(typeof(CaseInjury))]
        public IHttpActionResult Get(long id)
        {
            CaseInjury caseInjury = db.GetByKey(id);
            if (caseInjury == null)
            {
                return NotFound();
            }

            return Ok(caseInjury);
        }

        // PUT: api/CaseInjuries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, CaseInjury caseInjury)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caseInjury.CaseInjuryID)
            {
                return BadRequest();
            }
            try
            {
                db.Update(caseInjury);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseInjuryExists(id))
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

        // POST: api/CaseInjuries
        [ResponseType(typeof(CaseInjury))]
        public IHttpActionResult Post(CaseInjury caseInjury)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(caseInjury);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = caseInjury.CaseInjuryID }, caseInjury);
        }

        // DELETE: api/CaseInjuries/5
        [ResponseType(typeof(CaseInjury))]
        public IHttpActionResult Delete(long id)
        {
            CaseInjury caseInjury = db.GetByKey(id);
            if (caseInjury == null)
            {
                return NotFound();
            }

            db.Delete(caseInjury);
            db.Save();

            return Ok(caseInjury);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool CaseInjuryExists(long id)
        {
            //return db.CaseInjuries.Count(e => e.CaseInjuryID == id) > 0;
            return true;
        }
    }
}