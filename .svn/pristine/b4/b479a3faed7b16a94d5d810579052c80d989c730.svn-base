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
    public class CaseNotesController : ApiController
    {
        private CaseNoteBO db = new CaseNoteBO();

        // GET: api/CaseNotes
        public IQueryable<CaseNote> Get()
        {
            return db.GetAll();
        }

        // GET: api/CaseNotes/5
        [ResponseType(typeof(CaseNote))]
        public IHttpActionResult Get(long id)
        {
            CaseNote caseNote = db.GetByKey(id);
            if (caseNote == null)
            {
                return NotFound();
            }

            return Ok(caseNote);
        }

        // PUT: api/CaseNotes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, CaseNote caseNote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caseNote.CaseNoteID)
            {
                return BadRequest();
            }
            try
            {
                db.Update(caseNote);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseNoteExists(id))
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

        // POST: api/CaseNotes
        [ResponseType(typeof(CaseNote))]
        public IHttpActionResult Post(CaseNote caseNote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(caseNote);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = caseNote.CaseNoteID }, caseNote);
        }

        // DELETE: api/CaseNotes/5
        [ResponseType(typeof(CaseNote))]
        public IHttpActionResult Delete(long id)
        {
            CaseNote caseNote = db.GetByKey(id);
            if (caseNote == null)
            {
                return NotFound();
            }

            db.Delete(caseNote);
            db.Save();

            return Ok(caseNote);
        }

        protected override void Dispose(bool disposing)
        {
          /*  if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool CaseNoteExists(long id)
        {
            //return db.CaseNotes.Count(e => e.CaseNoteID == id) > 0;
            return true;
        }
    }
}