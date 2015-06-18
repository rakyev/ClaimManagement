using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ICM.Data;
using ICM.Data.Business.BusinessObject;

namespace ICM.Web.API.Controllers
{
    public class InjuryCodesController : ApiController
    {
        private readonly InjuryCodeBO _db = new InjuryCodeBO();

        // GET: api/InjuryCodes
        public IQueryable<InjuryCode> Get()
        {
            return _db.GetAll();
        }

        // GET: api/InjuryCodes/5
        [ResponseType(typeof(InjuryCode))]
        public IHttpActionResult Get(long id)
        {
            InjuryCode injuryCode = _db.GetByKey(id);
            if (injuryCode == null)
            {
                return NotFound();
            }

            return Ok(injuryCode);
        }

        // PUT: api/InjuryCodes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, InjuryCode injuryCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != injuryCode.InjuryCodeID)
            {
                return BadRequest();
            }

            try
            {
                _db.Update(injuryCode);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InjuryCodeExists(id))
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

        // POST: api/InjuryCodes
        [ResponseType(typeof(InjuryCode))]
        public IHttpActionResult Post(InjuryCode injuryCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(injuryCode);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = injuryCode.InjuryCodeID }, injuryCode);
        }

        // DELETE: api/InjuryCodes/5
        [ResponseType(typeof(InjuryCode))]
        public IHttpActionResult Delete(long id)
        {
            InjuryCode injuryCode = _db.GetByKey(id);
            if (injuryCode == null)
            {
                return NotFound();
            }

            _db.Delete(injuryCode);
            _db.Save();

            return Ok(injuryCode);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool InjuryCodeExists(long id)
        {
           // return db.InjuryCodes.Count(e => e.InjuryCodeID == id) > 0;
            return true;
        }
    }
}