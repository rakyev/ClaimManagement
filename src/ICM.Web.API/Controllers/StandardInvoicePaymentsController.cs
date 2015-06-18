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
    public class StandardInvoicePaymentsController : ApiController
    {
        private readonly StandardInvoicePaymentBO _db = new StandardInvoicePaymentBO();

        // GET: api/StandardInvoicePayments
        public IQueryable<StandardInvoicePayment> Get()
        {
            return _db.GetAll();
        }

        // GET: api/StandardInvoicePayments/5
        [ResponseType(typeof(StandardInvoicePayment))]
        public IHttpActionResult Get(long id)
        {
            StandardInvoicePayment standardInvoicePayment = _db.GetByKey(id);
            if (standardInvoicePayment == null)
            {
                return NotFound();
            }

            return Ok(standardInvoicePayment);
        }

        // PUT: api/StandardInvoicePayments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, StandardInvoicePayment standardInvoicePayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != standardInvoicePayment.StandardInvoicePaymentID)
            {
                return BadRequest();
            }

           

            try
            {
                _db.Update(standardInvoicePayment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StandardInvoicePaymentExists(id))
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

        // POST: api/StandardInvoicePayments
        [ResponseType(typeof(StandardInvoicePayment))]
        public IHttpActionResult Post(StandardInvoicePayment standardInvoicePayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(standardInvoicePayment);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = standardInvoicePayment.StandardInvoicePaymentID }, standardInvoicePayment);
        }

        // DELETE: api/StandardInvoicePayments/5
        [ResponseType(typeof(StandardInvoicePayment))]
        public IHttpActionResult Delete(long id)
        {
            StandardInvoicePayment standardInvoicePayment = _db.GetByKey(id);
            if (standardInvoicePayment == null)
            {
                return NotFound();
            }

            _db.Delete(standardInvoicePayment);
            _db.Save();

            return Ok(standardInvoicePayment);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool StandardInvoicePaymentExists(long id)
        {
           // return db.StandardInvoicePayments.Count(e => e.StandardInvoicePaymentID == id) > 0;
            return true;
        }
    }
}