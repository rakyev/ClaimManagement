using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ICM.Data;
using ICM.Data.Business.BusinessObject;

namespace ICM.Web.API.Controllers
{
    public class DayofWeeksController : ApiController
    {
        private readonly DayofWeekBO _db = new DayofWeekBO();

        // GET: api/DayofWeeks
        public IQueryable<DayofWeek> Get()
        {
            return _db.GetAll();
        }

        // GET: api/DayofWeeks/5
        [ResponseType(typeof(DayofWeek))]
        public IHttpActionResult Get(long id)
        {
            DayofWeek dayofWeek = _db.GetByKey(id);
            if (dayofWeek == null)
            {
                return NotFound();
            }

            return Ok(dayofWeek);
        }

        // PUT: api/DayofWeeks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, DayofWeek dayofWeek)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dayofWeek.DayofWeekID)
            {
                return BadRequest();
            }

            try
            {
                _db.Update(dayofWeek);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayofWeekExists(id))
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

        // POST: api/DayofWeeks
        [ResponseType(typeof(DayofWeek))]
        public IHttpActionResult Post(DayofWeek dayofWeek)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(dayofWeek);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = dayofWeek.DayofWeekID }, dayofWeek);
        }

        // DELETE: api/DayofWeeks/5
        [ResponseType(typeof(DayofWeek))]
        public IHttpActionResult Delete(long id)
        {
            DayofWeek dayofWeek = _db.GetByKey(id);
            if (dayofWeek == null)
            {
                return NotFound();
            }

            _db.Delete(dayofWeek);
            _db.Save();

            return Ok(dayofWeek);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    _db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool DayofWeekExists(long id)
        {
            //return db.DayofWeeks.Count(e => e.DayofWeekID == id) > 0;
            return true;
        }
    }
}