using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ICM.Data;
using ICM.Data.Business.BusinessObject;

namespace ICM.Web.API.Controllers
{
    public class GendersController : ApiController
    {
        private readonly GenderBO _db = new GenderBO();

        // GET: api/Genders
        public IQueryable<Gender> Get()
        {
            return _db.GetAll();
        }

        // GET: api/Genders/5
        [ResponseType(typeof(Gender))]
        public IHttpActionResult Get(long id)
        {
            Gender gender = _db.GetByKey(id);
            if (gender == null)
            {
                return NotFound();
            }

            return Ok(gender);
        }

        // PUT: api/Genders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, Gender gender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gender.GenderID)
            {
                return BadRequest();
            }
            try
            {
                _db.Update(gender);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenderExists(id))
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

        // POST: api/Genders
        [ResponseType(typeof(Gender))]
        public IHttpActionResult Post(Gender gender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(gender);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = gender.GenderID }, gender);
        }

        // DELETE: api/Genders/5
        [ResponseType(typeof(Gender))]
        public IHttpActionResult Delete(long id)
        {
            Gender gender = _db.GetByKey(id);
            if (gender == null)
            {
                return NotFound();
            }

            _db.Delete(gender);
            _db.Save();

            return Ok(gender);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool GenderExists(long id)
        {
           // return db.Genders.Count(e => e.GenderID == id) > 0;
            return true;
        }
    }
}