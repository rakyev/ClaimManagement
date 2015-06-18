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
    public class StandardInvoiceLineItemsController : ApiController
    {
        private readonly StandardInvoiceLineItemBO _db = new StandardInvoiceLineItemBO();

        // GET: api/StandardInvoiceLineItems
        public IQueryable<StandardInvoiceLineItem> Get()
        {
            return _db.GetAll();
        }

        // GET: api/StandardInvoiceLineItems/5
        [ResponseType(typeof(StandardInvoiceLineItem))]
        public IHttpActionResult Get(long id)
        {
            StandardInvoiceLineItem standardInvoiceLineItem = _db.GetByKey(id);
            if (standardInvoiceLineItem == null)
            {
                return NotFound();
            }

            return Ok(standardInvoiceLineItem);
        }

        // PUT: api/StandardInvoiceLineItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, StandardInvoiceLineItem standardInvoiceLineItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != standardInvoiceLineItem.StandardInvoiceLineItemID)
            {
                return BadRequest();
            }


            try
            {
                _db.Update(standardInvoiceLineItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StandardInvoiceLineItemExists(id))
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

        // POST: api/StandardInvoiceLineItems
        [ResponseType(typeof(StandardInvoiceLineItem))]
        public IHttpActionResult Post(StandardInvoiceLineItem standardInvoiceLineItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(standardInvoiceLineItem);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = standardInvoiceLineItem.StandardInvoiceLineItemID }, standardInvoiceLineItem);
        }

        // DELETE: api/StandardInvoiceLineItems/5
        [ResponseType(typeof(StandardInvoiceLineItem))]
        public IHttpActionResult Delete(long id)
        {
            StandardInvoiceLineItem standardInvoiceLineItem = _db.GetByKey(id);
            if (standardInvoiceLineItem == null)
            {
                return NotFound();
            }

            _db.Delete(standardInvoiceLineItem);
            _db.Save();

            return Ok(standardInvoiceLineItem);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool StandardInvoiceLineItemExists(long id)
        {
            //return db.StandardInvoiceLineItems.Count(e => e.StandardInvoiceLineItemID == id) > 0;
            return true;
        }
    }
}