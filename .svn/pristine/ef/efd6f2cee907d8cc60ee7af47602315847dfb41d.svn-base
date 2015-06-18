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
    public class PaymentTypesController : ApiController
    {
        private readonly PaymentTypeBO _db = new PaymentTypeBO();

        //GET: api/PaymentTypes
        public IQueryable<PaymentType> Get()
        {
            return _db.GetAll();
        }

        //GET: api/PaymentTypes/5
        [ResponseType(typeof(PaymentType))]
        public IHttpActionResult Get(long id)
        {
            PaymentType paymentType = _db.GetByKey(id);
            if (paymentType == null)
            {
                return NotFound();
            }

            return Ok(paymentType);
        }

        //PUT: api/PaymentTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, PaymentType paymentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentType.PaymentTypeID)
            {
                return BadRequest();
            }

            try
            {
                _db.Update(paymentType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTypeExists(id))
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

        //POST: api/PaymentTypes
        [ResponseType(typeof(PaymentType))]
        public IHttpActionResult Post(PaymentType paymentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(paymentType);
            _db.Save();
            return CreatedAtRoute("DefaultApi", new { id = paymentType.PaymentTypeID }, paymentType);           
        }

        //DELETE: api/PaymentTypes/5
        [ResponseType(typeof(PaymentType))]
        public IHttpActionResult Delete(long id)
        {
            PaymentType paymentType = _db.GetByKey(id);
            if (paymentType == null)
            {
                return NotFound();
            }

            _db.Delete(paymentType);
            _db.Save();
            return Ok(paymentType);
        }

        protected override void Dispose(bool disposing)
        { 
            /* if (disposing)
              {
                   _db.Dispose();
              }
              base.Dispose(disposing);*/           
        }

        private bool PaymentTypeExists(long id)
        {
            //return _db.PaymentTypes.Count(e => e.PaymentTypeID == id) > 0;
            return true;
        }
    }
}