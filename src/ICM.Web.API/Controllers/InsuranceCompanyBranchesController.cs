using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ICM.Data;
using ICM.Data.Business.BusinessObject;

namespace ICM.Web.API.Controllers
{
    public class InsuranceCompanyBranchesController : ApiController
    {
        private readonly InsuranceCompanyBranchBO _db = new InsuranceCompanyBranchBO();

        // GET: api/InsuranceCompanyBranches
        public IQueryable<InsuranceCompanyBranch> Get()
        {
            return _db.GetAll();
        }

        // GET: api/InsuranceCompanyBranches/5
        [ResponseType(typeof(InsuranceCompanyBranch))]
        public IHttpActionResult Get(long id)
        {
            InsuranceCompanyBranch insuranceCompanyBranch = _db.GetByKey(id);
            if (insuranceCompanyBranch == null)
            {
                return NotFound();
            }

            return Ok(insuranceCompanyBranch);
        }

        // PUT: api/InsuranceCompanyBranches/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, InsuranceCompanyBranch insuranceCompanyBranch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != insuranceCompanyBranch.InsuranceCompanyBranchID)
            {
                return BadRequest();
            }

            try
            {
                _db.Update(insuranceCompanyBranch);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceCompanyBranchExists(id))
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

        // POST: api/InsuranceCompanyBranches
        [ResponseType(typeof(InsuranceCompanyBranch))]
        public IHttpActionResult Post(InsuranceCompanyBranch insuranceCompanyBranch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(insuranceCompanyBranch);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = insuranceCompanyBranch.InsuranceCompanyBranchID }, insuranceCompanyBranch);
        }

        // DELETE: api/InsuranceCompanyBranches/5
        [ResponseType(typeof(InsuranceCompanyBranch))]
        public IHttpActionResult Delete(long id)
        {
            InsuranceCompanyBranch insuranceCompanyBranch = _db.GetByKey(id);
            if (insuranceCompanyBranch == null)
            {
                return NotFound();
            }

            _db.Delete(insuranceCompanyBranch);
            _db.Save();

            return Ok(insuranceCompanyBranch);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool InsuranceCompanyBranchExists(long id)
        {
           // return db.InsuranceCompanyBranches.Count(e => e.InsuranceCompanyBranchID == id) > 0;
            return true;
        }
    }
}