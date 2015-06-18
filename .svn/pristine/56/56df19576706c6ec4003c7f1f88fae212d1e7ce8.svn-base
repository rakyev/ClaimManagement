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
    public class SFSAuditEventsController : ApiController
    {
        private readonly SFSAuditEventBO _db = new SFSAuditEventBO();
        //private ICMDBContext db = new ICMDBContext();

        // GET: api/SFSAuditEvents
        public IQueryable<SFSAuditEvent> Get()
        {
            return _db.GetAll();
        }

        // GET: api/SFSAuditEvents/5
        [ResponseType(typeof(SFSAuditEvent))]
        public IHttpActionResult Get(long id)
        {
            SFSAuditEvent sFSAuditEvent = _db.GetByKey(id);
            if (sFSAuditEvent == null)
            {
                return NotFound();
            }

            return Ok(sFSAuditEvent);
        }

        // PUT: api/SFSAuditEvents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, SFSAuditEvent sFSAuditEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sFSAuditEvent.ae_pk)
            {
                return BadRequest();
            }

            try
            {
                _db.Update(sFSAuditEvent);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SFSAuditEventExists(id))
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

        // POST: api/SFSAuditEvents
        [ResponseType(typeof(SFSAuditEvent))]
        public IHttpActionResult Post(SFSAuditEvent sFSAuditEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(sFSAuditEvent);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = sFSAuditEvent.ae_pk }, sFSAuditEvent);
        }

        // DELETE: api/SFSAuditEvents/5
        [ResponseType(typeof(SFSAuditEvent))]
        public IHttpActionResult Delete(long id)
        {
            SFSAuditEvent sFSAuditEvent = _db.GetByKey(id);
            if (sFSAuditEvent == null)
            {
                return NotFound();
            }

            _db.Delete(sFSAuditEvent);
            _db.Save();

            return Ok(sFSAuditEvent);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool SFSAuditEventExists(long id)
        {
            //return db.SFSAuditEvents.Count(e => e.ae_pk == id) > 0;
            return true;
        }
    }
}