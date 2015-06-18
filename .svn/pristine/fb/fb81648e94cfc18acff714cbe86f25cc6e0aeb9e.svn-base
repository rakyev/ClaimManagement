using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ICM.Data;
using ICM.Data.Business.BusinessObject;

namespace ICM.Web.API.Controllers
{
    public class LanguagesController : ApiController
    {
        private readonly LanguageBO _db = new LanguageBO();

        // GET: api/Languages
        public IQueryable<Language> Get()
        {
            return _db.GetAll();
        }

        // GET: api/Languages/5
        [ResponseType(typeof(Language))]
        public IHttpActionResult Get(long id)
        {
            Language language = _db.GetByKey(id);
            if (language == null)
            {
                return NotFound();
            }

            return Ok(language);
        }

        // PUT: api/Languages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, Language language)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != language.LanguageID)
            {
                return BadRequest();
            }

            try
            {
                _db.Update(language);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageExists(id))
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

        // POST: api/Languages
        [ResponseType(typeof(Language))]
        public IHttpActionResult Post(Language language)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(language);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = language.LanguageID }, language);
        }

        // DELETE: api/Languages/5
        [ResponseType(typeof(Language))]
        public IHttpActionResult Delete(long id)
        {
            Language language = _db.GetByKey(id);
            if (language == null)
            {
                return NotFound();
            }

            _db.Delete(language);
            _db.Save();

            return Ok(language);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool LanguageExists(long id)
        {
            //return db.Languages.Count(e => e.LanguageID == id) > 0;
            return true;
        }
    }
}