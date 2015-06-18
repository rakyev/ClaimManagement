using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ICM.Data;
using ICM.Data.Business.BusinessObject;

namespace ICM.Web.API.Controllers
{
    public class InjuryCodeSeriesTypesController : ApiController
    {
        private readonly InjuryCodeSeriesTypeBO _db = new InjuryCodeSeriesTypeBO();

        // GET: api/InjuryCodeSeriesTypes
        public IQueryable<InjuryCodeSeriesType> Get()
        {
            return _db.GetAll();
        }

        // GET: api/InjuryCodeSeriesTypes/5
        [ResponseType(typeof(InjuryCodeSeriesType))]
        public IHttpActionResult Get(long id)
        {
            InjuryCodeSeriesType injuryCodeSeriesType = _db.GetByKey(id);
            if (injuryCodeSeriesType == null)
            {
                return NotFound();
            }

            return Ok(injuryCodeSeriesType);
        }

        // PUT: api/InjuryCodeSeriesTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, InjuryCodeSeriesType injuryCodeSeriesType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != injuryCodeSeriesType.InjuryCodeSeriesTypeID)
            {
                return BadRequest();
            }

            try
            {
                _db.Update(injuryCodeSeriesType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InjuryCodeSeriesTypeExists(id))
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

        // POST: api/InjuryCodeSeriesTypes
        [ResponseType(typeof(InjuryCodeSeriesType))]
        public IHttpActionResult Post(InjuryCodeSeriesType injuryCodeSeriesType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(injuryCodeSeriesType);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = injuryCodeSeriesType.InjuryCodeSeriesTypeID }, injuryCodeSeriesType);
        }

        // DELETE: api/InjuryCodeSeriesTypes/5
        [ResponseType(typeof(InjuryCodeSeriesType))]
        public IHttpActionResult Delete(long id)
        {
            InjuryCodeSeriesType injuryCodeSeriesType = _db.GetByKey(id);
            if (injuryCodeSeriesType == null)
            {
                return NotFound();
            }

            _db.Delete(injuryCodeSeriesType);
            _db.Save();

            return Ok(injuryCodeSeriesType);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool InjuryCodeSeriesTypeExists(long id)
        {
            //return db.InjuryCodeSeriesTypes.Count(e => e.InjuryCodeSeriesTypeID == id) > 0;
            return true;
        }
    }
}