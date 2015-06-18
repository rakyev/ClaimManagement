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
    public class CompaniesController : ApiController
    {
        private CompanyBO db = new CompanyBO();

        // GET: api/Companies
        public IQueryable<Company> Get()
        {
            return db.GetAll();
        }

        // GET: api/Companies/5
        [ResponseType(typeof(Company))]
        public IHttpActionResult Get(long id)
        {
            Company company = db.GetByKey(id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // PUT: api/Companies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != company.CompanyID)
            {
                return BadRequest();
            }

            

            try
            {
                db.Update(company);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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

        // POST: api/Companies
        [ResponseType(typeof(Company))]
        public IHttpActionResult Post(Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(company);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = company.CompanyID }, company);
        }

        // DELETE: api/Companies/5
        [ResponseType(typeof(Company))]
        public IHttpActionResult Delete(long id)
        {
            Company company = db.GetByKey(id);
            if (company == null)
            {
                return NotFound();
            }

            db.Delete(company);
            db.Save();

            return Ok(company);
        }

        protected override void Dispose(bool disposing)
        {
           /* if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool CompanyExists(long id)
        {
            return true;// db.Companies.Count(e => e.CompanyID == id) > 0;
        }
    }
}