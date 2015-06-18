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
    public class CaseManagementsController : ApiController
    {
        private CaseManagementBO db = new CaseManagementBO();

        // GET: api/CaseManagements
        public IQueryable<CaseManagement> Get()
        {
            return db.GetAll();
        }

        // GET: api/CaseManagements/5
        [ResponseType(typeof(CaseManagement))]
        public IHttpActionResult Get(long id)
        {
            CaseManagement caseManagement = db.GetByKey(id);
            if (caseManagement == null)
            {
                return NotFound();
            }

            return Ok(caseManagement);
        }

        // PUT: api/CaseManagements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, CaseManagement caseManagement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caseManagement.CaseManagementID)
            {
                return BadRequest();
            }
            try
            {
                db.Update(caseManagement);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseManagementExists(id))
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

        // POST: api/CaseManagements
        [ResponseType(typeof(CaseManagement))]
        public IHttpActionResult Post(CaseManagement caseManagement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(caseManagement);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = caseManagement.CaseManagementID }, caseManagement);
        }

        // DELETE: api/CaseManagements/5
        [ResponseType(typeof(CaseManagement))]
        public IHttpActionResult Delete(long id)
        {
            CaseManagement caseManagement = db.GetByKey(id);
            if (caseManagement == null)
            {
                return NotFound();
            }

            db.Delete(caseManagement);
            db.Save();

            return Ok(caseManagement);
        }

        protected override void Dispose(bool disposing)
        {
          /*  if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool CaseManagementExists(long id)
        {
           // return db.CaseManagements.Count(e => e.CaseManagementID == id) > 0;
            return true;
        }
    }
}