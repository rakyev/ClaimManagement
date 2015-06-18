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
    public class SFSRestrictionItemsController : ApiController
    {
        private readonly SFSRestrictionItemBO _db = new SFSRestrictionItemBO();
        //private ICMDBContext db = new ICMDBContext();

        // GET: api/SFSRestrictionItems
        public IQueryable<SFSRestrictionItem> Get()
        {
            return _db.GetAll();
        }

        // GET: api/SFSRestrictionItems/5
        [ResponseType(typeof(SFSRestrictionItem))]
        public IHttpActionResult Get(int id)
        {
            SFSRestrictionItem sFSRestrictionItem = _db.GetByKey(id);
            if (sFSRestrictionItem == null)
            {
                return NotFound();
            }

            return Ok(sFSRestrictionItem);
        }

        // PUT: api/SFSRestrictionItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, SFSRestrictionItem sFSRestrictionItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sFSRestrictionItem.ri_pk)
            {
                return BadRequest();
            }

            try
            {
                _db.Update(sFSRestrictionItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SFSRestrictionItemExists(id))
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

        // POST: api/SFSRestrictionItems
        [ResponseType(typeof(SFSRestrictionItem))]
        public IHttpActionResult Post(SFSRestrictionItem sFSRestrictionItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(sFSRestrictionItem);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = sFSRestrictionItem.ri_pk }, sFSRestrictionItem);
        }

        // DELETE: api/SFSRestrictionItems/5
        [ResponseType(typeof(SFSRestrictionItem))]
        public IHttpActionResult Delete(int id)
        {
            SFSRestrictionItem sFSRestrictionItem = _db.GetByKey(id);
            if (sFSRestrictionItem == null)
            {
                return NotFound();
            }

            _db.Delete(sFSRestrictionItem);
            _db.Save();

            return Ok(sFSRestrictionItem);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool SFSRestrictionItemExists(int id)
        {
            //return db.SFSRestrictionItems.Count(e => e.ri_pk == id) > 0;
            return true;
        }
    }
}