using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ICM.Data;
using ICM.Data.Business.BusinessObject;

namespace ICM.Web.API.Controllers
{
    public class GoodAndServicesController : ApiController
    {
        private readonly GoodAndServiceBO _db = new GoodAndServiceBO();

        // GET: api/GoodAndServices
        public IQueryable<GoodAndService> Get()
        {
            return _db.GetAll();
        }

        // GET: api/GoodAndServices/5
        [ResponseType(typeof(GoodAndService))]
        public IHttpActionResult Get(long id)
        {
            GoodAndService goodAndService = _db.GetByKey(id);
            if (goodAndService == null)
            {
                return NotFound();
            }

            return Ok(goodAndService);
        }

        // PUT: api/GoodAndServices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, GoodAndService goodAndService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != goodAndService.GoodAndServiceID)
            {
                return BadRequest();
            }

            try
            {
                _db.Update(goodAndService);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoodAndServiceExists(id))
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

        // POST: api/GoodAndServices
        [ResponseType(typeof(GoodAndService))]
        public IHttpActionResult Post(GoodAndService goodAndService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(goodAndService);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = goodAndService.GoodAndServiceID }, goodAndService);
        }

        // DELETE: api/GoodAndServices/5
        [ResponseType(typeof(GoodAndService))]
        public IHttpActionResult Delete(long id)
        {
            GoodAndService goodAndService = _db.GetByKey(id);
            if (goodAndService == null)
            {
                return NotFound();
            }

            _db.Delete(goodAndService);
            _db.Save();

            return Ok(goodAndService);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool GoodAndServiceExists(long id)
        {
           // return db.GoodAndServices.Count(e => e.GoodAndServiceID == id) > 0;
            return true;
        }
    }
}