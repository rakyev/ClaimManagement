using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ICM.Data;
using ICM.Data.Business.BusinessObject;

namespace ICM.Web.API.Controllers
{
    public class InjuryCodeCategoryTypesController : ApiController
    {
        private readonly InjuryCodeCategoryTypeBO _db = new InjuryCodeCategoryTypeBO();

        // GET: api/InjuryCodeCategoryTypes
        public IQueryable<InjuryCodeCategoryType> Get()
        {
            return _db.GetAll();
        }

        // GET: api/InjuryCodeCategoryTypes/5
        [ResponseType(typeof(InjuryCodeCategoryType))]
        public IHttpActionResult Get(long id)
        {
            InjuryCodeCategoryType injuryCodeCategoryType = _db.GetByKey(id);
            if (injuryCodeCategoryType == null)
            {
                return NotFound();
            }

            return Ok(injuryCodeCategoryType);
        }

        // PUT: api/InjuryCodeCategoryTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, InjuryCodeCategoryType injuryCodeCategoryType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != injuryCodeCategoryType.InjuryCodeCategoryTypeID)
            {
                return BadRequest();
            }

            try
            {
                _db.Update(injuryCodeCategoryType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InjuryCodeCategoryTypeExists(id))
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

        // POST: api/InjuryCodeCategoryTypes
        [ResponseType(typeof(InjuryCodeCategoryType))]
        public IHttpActionResult Post(InjuryCodeCategoryType injuryCodeCategoryType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(injuryCodeCategoryType);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = injuryCodeCategoryType.InjuryCodeCategoryTypeID }, injuryCodeCategoryType);
        }

        // DELETE: api/InjuryCodeCategoryTypes/5
        [ResponseType(typeof(InjuryCodeCategoryType))]
        public IHttpActionResult Delete(long id)
        {
            InjuryCodeCategoryType injuryCodeCategoryType = _db.GetByKey(id);
            if (injuryCodeCategoryType == null)
            {
                return NotFound();
            }

            _db.Delete(injuryCodeCategoryType);
            _db.Save();

            return Ok(injuryCodeCategoryType);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool InjuryCodeCategoryTypeExists(long id)
        {
           // return db.InjuryCodeCategoryTypes.Count(e => e.InjuryCodeCategoryTypeID == id) > 0;
            return true;
        }
    }
}