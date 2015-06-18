using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ICM.Data;
using ICM.Data.Business.BusinessObject;

namespace ICM.Web.API.Controllers
{
    public class GoodAndServiceTypesController : ApiController
    {
        private readonly GoodAndServiceTypeBO _db = new GoodAndServiceTypeBO();

        // GET: api/GoodAndServiceTypes
        public IQueryable<GoodAndServiceType> Get()
        {
            return _db.GetAll();
        }

        // GET: api/GoodAndServiceTypes/5
        [ResponseType(typeof(GoodAndServiceType))]
        public IHttpActionResult Get(long id)
        {
            GoodAndServiceType goodAndServiceType = _db.GetByKey(id);
            if (goodAndServiceType == null)
            {
                return NotFound();
            }

            return Ok(goodAndServiceType);
        }

        // PUT: api/GoodAndServiceTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, GoodAndServiceType goodAndServiceType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != goodAndServiceType.GoodAndServiceTypeID)
            {
                return BadRequest();
            }

            try
            {
                _db.Update(goodAndServiceType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoodAndServiceTypeExists(id))
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

        // POST: api/GoodAndServiceTypes
        [ResponseType(typeof(GoodAndServiceType))]
        public IHttpActionResult Post(GoodAndServiceType goodAndServiceType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(goodAndServiceType);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = goodAndServiceType.GoodAndServiceTypeID }, goodAndServiceType);
        }

        // DELETE: api/GoodAndServiceTypes/5
        [ResponseType(typeof(GoodAndServiceType))]
        public IHttpActionResult Delete(long id)
        {
            GoodAndServiceType goodAndServiceType = _db.GetByKey(id);
            if (goodAndServiceType == null)
            {
                return NotFound();
            }

            _db.Delete(goodAndServiceType);
            _db.Save();

            return Ok(goodAndServiceType);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool GoodAndServiceTypeExists(long id)
        {
           // return db.GoodAndServiceTypes.Count(e => e.GoodAndServiceTypeID == id) > 0;
            return true;
        }
    }
}