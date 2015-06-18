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
    public class CaseContactsController : ApiController
    {
        private CaseContactBO db = new CaseContactBO();

        // GET: api/CaseContacts
        public IQueryable<CaseContact> Get()
        {
            return db.GetAll();
        }

        // GET: api/CaseContacts/5
        [ResponseType(typeof(CaseContact))]
        public IHttpActionResult Get(long id)
        {
            CaseContact caseContact = db.GetByKey(id);
            if (caseContact == null)
            {
                return NotFound();
            }

            return Ok(caseContact);
        }

        // PUT: api/CaseContacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, CaseContact caseContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caseContact.CaseContactID)
            {
                return BadRequest();
            }
            try
            {
                db.Update(caseContact);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseContactExists(id))
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

        // POST: api/CaseContacts
        [ResponseType(typeof(CaseContact))]
        public IHttpActionResult Post(CaseContact caseContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(caseContact);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = caseContact.CaseContactID }, caseContact);
        }

        // DELETE: api/CaseContacts/5
        [ResponseType(typeof(CaseContact))]
        public IHttpActionResult Delete(long id)
        {
            CaseContact caseContact = db.GetByKey(id);
            if (caseContact == null)
            {
                return NotFound();
            }

            db.Delete(caseContact);
            db.Save();

            return Ok(caseContact);
        }

        protected override void Dispose(bool disposing)
        {
           /* if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool CaseContactExists(long id)
        {
            //return db.CaseContacts.Count(e => e.CaseContactID == id) > 0;
            return true;
        }
    }
}