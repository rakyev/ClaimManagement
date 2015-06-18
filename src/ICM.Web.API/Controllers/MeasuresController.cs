using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ICM.Data;
using ICM.Data.Business.BusinessObject;

namespace ICM.Web.API.Controllers
{
    public class MeasuresController : ApiController
    {
        private readonly MeasureBO _db = new MeasureBO();

        // GET: api/Measures
        public IQueryable<Measure> Get()
        {
            return _db.GetAll();
        }

        // GET: api/Measures/5
        [ResponseType(typeof(Measure))]
        public IHttpActionResult Get(long id)
        {
            Measure measure = _db.GetByKey(id);
            if (measure == null)
            {
                return NotFound();
            }

            return Ok(measure);
        }

        // PUT: api/Measures/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, Measure measure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != measure.MeasureID)
            {
                return BadRequest();
            }

            try
            {
                _db.Update(measure);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeasureExists(id))
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

        // POST: api/Measures
        [ResponseType(typeof(Measure))]
        public IHttpActionResult Post(Measure measure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(measure);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = measure.MeasureID }, measure);
        }

        // DELETE: api/Measures/5
        [ResponseType(typeof(Measure))]
        public IHttpActionResult Delete(long id)
        {
            Measure measure = _db.GetByKey(id);
            if (measure == null)
            {
                return NotFound();
            }

            _db.Delete(measure);
            _db.Save();

            return Ok(measure);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool MeasureExists(long id)
        {
           // return db.Measures.Count(e => e.MeasureID == id) > 0;
            return true;
        }
    }
}