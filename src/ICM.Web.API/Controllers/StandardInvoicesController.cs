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
    public class StandardInvoicesController : ApiController
    {
        private  readonly StandardInvoiceBO _db = new StandardInvoiceBO();

        // GET: api/StandardInvoices
        public IQueryable<StandardInvoice> Get()
        {
            return _db.GetAll();
        }

        // GET: api/StandardInvoices/5
        [ResponseType(typeof(StandardInvoice))]
        public IHttpActionResult Get(long id)
        {
            StandardInvoice standardInvoice = _db.GetByKey(id);
            if (standardInvoice == null)
            {
                return NotFound();
            }

            return Ok(standardInvoice);
        }

        // PUT: api/StandardInvoices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, StandardInvoice standardInvoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != standardInvoice.StandardInvoiceID)
            {
                return BadRequest();
            }

          

            try
            {
                _db.Update(standardInvoice);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StandardInvoiceExists(id))
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

        // POST: api/StandardInvoices
        [ResponseType(typeof(StandardInvoice))]
        public IHttpActionResult Post(StandardInvoice standardInvoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(standardInvoice);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = standardInvoice.StandardInvoiceID }, standardInvoice);
        }

        // DELETE: api/StandardInvoices/5
        [ResponseType(typeof(StandardInvoice))]
        public IHttpActionResult Delete(long id)
        {
            StandardInvoice standardInvoice = _db.GetByKey(id);
            if (standardInvoice == null)
            {
                return NotFound();
            }

            _db.Delete(standardInvoice);
            _db.Save();

            return Ok(standardInvoice);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool StandardInvoiceExists(long id)
        {
           // return db.StandardInvoices.Count(e => e.StandardInvoiceID == id) > 0;
            return true;
        }
    }
}