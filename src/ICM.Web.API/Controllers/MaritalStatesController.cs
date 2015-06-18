using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ICM.Data;
using ICM.Data.Business.BusinessObject;

namespace ICM.Web.API.Controllers
{
    public class MaritalStatesController : ApiController
    {
        private readonly MaritalStateBO _db = new MaritalStateBO();

        // GET: api/MaritalStates
        public IQueryable<MaritalState> Get()
        {
            return _db.GetAll();
        }

        // GET: api/MaritalStates/5
        [ResponseType(typeof(MaritalState))]
        public IHttpActionResult Get(long id)
        {
            MaritalState maritalState = _db.GetByKey(id);
            if (maritalState == null)
            {
                return NotFound();
            }

            return Ok(maritalState);
        }

        // PUT: api/MaritalStates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, MaritalState maritalState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != maritalState.MaritalStatusID)
            {
                return BadRequest();
            }

            try
            {
                _db.Update(maritalState);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaritalStateExists(id))
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

        // POST: api/MaritalStates
        [ResponseType(typeof(MaritalState))]
        public IHttpActionResult Post(MaritalState maritalState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(maritalState);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = maritalState.MaritalStatusID }, maritalState);
        }

        // DELETE: api/MaritalStates/5
        [ResponseType(typeof(MaritalState))]
        public IHttpActionResult Delete(long id)
        {
            MaritalState maritalState = _db.GetByKey(id);
            if (maritalState == null)
            {
                return NotFound();
            }

            _db.Delete(maritalState);
            _db.Save();

            return Ok(maritalState);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool MaritalStateExists(long id)
        {
            //return db.MaritalStates.Count(e => e.MaritalStatusID == id) > 0;
            return true;
        }
    }
}