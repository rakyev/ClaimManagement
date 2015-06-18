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
    public class CaseContactSpecialitiesController : ApiController
    {
        private CaseContactSpecialityBO db = new CaseContactSpecialityBO();

        // GET: api/CaseContactSpecialities
        public IQueryable<CaseContactSpeciality> Get()
        {
            return db.GetAll();
        }

        // GET: api/CaseContactSpecialities/5
        [ResponseType(typeof(CaseContactSpeciality))]
        public IHttpActionResult Get(long id)
        {
            CaseContactSpeciality caseContactSpeciality = db.GetByKey(id);
            if (caseContactSpeciality == null)
            {
                return NotFound();
            }

            return Ok(caseContactSpeciality);
        }

        // PUT: api/CaseContactSpecialities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, CaseContactSpeciality caseContactSpeciality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caseContactSpeciality.CaseContactSpecialityID)
            {
                return BadRequest();
            }
            try
            {
                db.Update(caseContactSpeciality);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseContactSpecialityExists(id))
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

        // POST: api/CaseContactSpecialities
        [ResponseType(typeof(CaseContactSpeciality))]
        public IHttpActionResult Post(CaseContactSpeciality caseContactSpeciality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(caseContactSpeciality);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = caseContactSpeciality.CaseContactSpecialityID }, caseContactSpeciality);
        }

        // DELETE: api/CaseContactSpecialities/5
        [ResponseType(typeof(CaseContactSpeciality))]
        public IHttpActionResult Delete(long id)
        {
            CaseContactSpeciality caseContactSpeciality = db.GetByKey(id);
            if (caseContactSpeciality == null)
            {
                return NotFound();
            }

            db.Delete(caseContactSpeciality);
            db.Save();

            return Ok(caseContactSpeciality);
        }

        protected override void Dispose(bool disposing)
        {
          /*  if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool CaseContactSpecialityExists(long id)
        {
           // return db.CaseContactSpecialities.Count(e => e.CaseContactSpecialityID == id) > 0;
            return true;
        }
    }
}