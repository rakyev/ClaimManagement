using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ICM.Data;
using ICM.Data.Business.BusinessObject;

namespace ICM.Web.API.Controllers
{
    public class InsuranceCompaniesController : ApiController
    {
        private readonly InsuranceCompanyBO _db = new InsuranceCompanyBO();

        // GET: api/InsuranceCompanies
        public IQueryable<InsuranceCompany> Get()
        {
            return _db.GetAll();
        }

        // GET: api/InsuranceCompanies/5
        [ResponseType(typeof(InsuranceCompany))]
        public IHttpActionResult Get(long id)
        {
            InsuranceCompany insuranceCompany = _db.GetByKey(id);
            if (insuranceCompany == null)
            {
                return NotFound();
            }

            return Ok(insuranceCompany);
        }

        // PUT: api/InsuranceCompanies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, InsuranceCompany insuranceCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != insuranceCompany.InsuranceCompanyID)
            {
                return BadRequest();
            }

            try
            {
                _db.Update(insuranceCompany);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceCompanyExists(id))
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

        // POST: api/InsuranceCompanies
        [ResponseType(typeof(InsuranceCompany))]
        public IHttpActionResult Post(InsuranceCompany insuranceCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(insuranceCompany);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = insuranceCompany.InsuranceCompanyID }, insuranceCompany);
        }

        // DELETE: api/InsuranceCompanies/5
        [ResponseType(typeof(InsuranceCompany))]
        public IHttpActionResult Delete(long id)
        {
            InsuranceCompany insuranceCompany = _db.GetByKey(id);
            if (insuranceCompany == null)
            {
                return NotFound();
            }

            _db.Delete(insuranceCompany);
            _db.Save();

            return Ok(insuranceCompany);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool InsuranceCompanyExists(long id)
        {
           // return db.InsuranceCompanies.Count(e => e.InsuranceCompanyID == id) > 0;
            return true;
        }
    }
}