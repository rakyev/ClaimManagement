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
    public class CompanyBranchesController : ApiController
    {
        private CompanyBranchBO db = new CompanyBranchBO();

        // GET: api/CompanyBranches
        public IQueryable<CompanyBranch> Get()
        {
            return db.GetAll();
        }

        // GET: api/CompanyBranches/5
        [ResponseType(typeof(CompanyBranch))]
        public IHttpActionResult Get(long id)
        {
            CompanyBranch companyBranch = db.GetByKey(id);
            if (companyBranch == null)
            {
                return NotFound();
            }

            return Ok(companyBranch);
        }

        // PUT: api/CompanyBranches/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, CompanyBranch companyBranch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyBranch.CompanyBranchID)
            {
                return BadRequest();
            }

            

            try
            {
                db.Update(companyBranch);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyBranchExists(id))
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

        // POST: api/CompanyBranches
        [ResponseType(typeof(CompanyBranch))]
        public IHttpActionResult Post(CompanyBranch companyBranch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(companyBranch);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = companyBranch.CompanyBranchID }, companyBranch);
        }

        // DELETE: api/CompanyBranches/5
        [ResponseType(typeof(CompanyBranch))]
        public IHttpActionResult Delete(long id)
        {
            CompanyBranch companyBranch = db.GetByKey(id);
            if (companyBranch == null)
            {
                return NotFound();
            }

            db.Delete(companyBranch);
            db.Save();

            return Ok(companyBranch);
        }

        protected override void Dispose(bool disposing)
        {
           /* if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool CompanyBranchExists(long id)
        {
            return true;//db.CompanyBranches.Count(e => e.CompanyBranchID == id) > 0;
        }
    }
}