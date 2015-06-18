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
    public class SFSAuditDataActionsController : ApiController
    {
        private readonly SFSAuditDataActionBO _db = new SFSAuditDataActionBO();
        //private ICMDBContext db = new ICMDBContext();

        // GET: api/SFSAuditDataActions
        public IQueryable<SFSAuditDataAction> Get()
        {
            return _db.GetAll();
        }

        // GET: api/SFSAuditDataActions/5
        [ResponseType(typeof(SFSAuditDataAction))]
        public IHttpActionResult Get(long id)
        {
            SFSAuditDataAction sfsAuditDataAction = _db.GetByKey(id);
            if (sfsAuditDataAction == null)
            {
                return NotFound();
            }

            return Ok(sfsAuditDataAction);
        }

        // PUT: api/SFSAuditDataActions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, SFSAuditDataAction sfsAuditDataAction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sfsAuditDataAction.ada_pk)
            {
                return BadRequest();
            }
            try
            {
                _db.Update(sfsAuditDataAction);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SFSAuditDataActionExists(id))
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

        // POST: api/SFSAuditDataActions
        [ResponseType(typeof(SFSAuditDataAction))]
        public IHttpActionResult Post(SFSAuditDataAction sfsAuditDataAction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(sfsAuditDataAction);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = sfsAuditDataAction.ada_pk }, sfsAuditDataAction);
        }

        // DELETE: api/SFSAuditDataActions/5
        [ResponseType(typeof(SFSAuditDataAction))]
        public IHttpActionResult Delete(long id)
        {
            SFSAuditDataAction sfsAuditDataAction = _db.GetByKey(id);
            if (sfsAuditDataAction == null)
            {
                return NotFound();
            }

            _db.Delete(sfsAuditDataAction);
            _db.Save();

            return Ok(sfsAuditDataAction);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool SFSAuditDataActionExists(long id)
        {
            //return db.SFSAuditDataActions.Count(e => e.ada_pk == id) > 0;
            return true;
        }
    }
}