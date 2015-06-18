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
    public class SFSAuditDataFieldsController : ApiController
    {
        private readonly SFSAuditDataFieldBO _db = new SFSAuditDataFieldBO();
        //private ICMDBContext db = new ICMDBContext();

        // GET: api/SFSAuditDataFields
        public IQueryable<SFSAuditDataField> Get()
        {
            return _db.GetAll();
        }

        // GET: api/SFSAuditDataFields/5
        [ResponseType(typeof(SFSAuditDataField))]
        public IHttpActionResult Get(long id)
        {
            SFSAuditDataField sFSAuditDataField = _db.GetByKey(id);
            if (sFSAuditDataField == null)
            {
                return NotFound();
            }

            return Ok(sFSAuditDataField);
        }

        // PUT: api/SFSAuditDataFields/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, SFSAuditDataField sFSAuditDataField)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sFSAuditDataField.adf_pk)
            {
                return BadRequest();
            }

            try
            {
                _db.Update(sFSAuditDataField);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SFSAuditDataFieldExists(id))
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

        // POST: api/SFSAuditDataFields
        [ResponseType(typeof(SFSAuditDataField))]
        public IHttpActionResult Post(SFSAuditDataField sFSAuditDataField)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(sFSAuditDataField);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = sFSAuditDataField.adf_pk }, sFSAuditDataField);
        }

        // DELETE: api/SFSAuditDataFields/5
        [ResponseType(typeof(SFSAuditDataField))]
        public IHttpActionResult Delete(long id)
        {
            SFSAuditDataField sFSAuditDataField = _db.GetByKey(id);
            if (sFSAuditDataField == null)
            {
                return NotFound();
            }

            _db.Delete(sFSAuditDataField);
            _db.Save();

            return Ok(sFSAuditDataField);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool SFSAuditDataFieldExists(long id)
        {
            //return db.SFSAuditDataFields.Count(e => e.adf_pk == id) > 0;
            return true;
        }
    }
}