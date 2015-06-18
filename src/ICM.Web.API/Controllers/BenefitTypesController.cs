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
    public class BenefitTypesController : ApiController
    {
        private readonly BenefitTypeBO _db = new BenefitTypeBO();

        // GET: api/BenefitTypes
        public IQueryable<BenefitType> Get()
        {
            return _db.GetAll();
        }

        // GET: api/BenefitTypes/5
        [ResponseType(typeof(BenefitType))]
        public IHttpActionResult Get(long id)
        {
            BenefitType benefitType = _db.GetByKey(id);
            if (benefitType == null)
            {
                return NotFound();
            }

            return Ok(benefitType);
        }

        // PUT: api/BenefitTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, BenefitType benefitType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != benefitType.BenefitTypeID)
            {
                return BadRequest();
            }
            try
            {
                _db.Update(benefitType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BenefitTypeExists(id))
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

        // POST: api/BenefitTypes
        [ResponseType(typeof(BenefitType))]
        public IHttpActionResult Post(BenefitType benefitType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(benefitType);
            _db.Save();
            return CreatedAtRoute("DefaultApi", new { id = benefitType.BenefitTypeID }, benefitType);
        }

        // DELETE: api/BenefitTypes/5
        [ResponseType(typeof(BenefitType))]
        public IHttpActionResult Delete(long id)
        {
            BenefitType benefitType = _db.GetByKey(id);
            if (benefitType == null)
            {
                return NotFound();
            }

            _db.Delete(benefitType);
            _db.Save();

            return Ok(benefitType);
        }
        //We need to find about about this method
        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }


        //this too should be found out about
        private bool BenefitTypeExists(long id)
        {
            //return db.BenefitTypes.Count(e => e.BenefitTypeID == id) > 0;
            return true;
        }
    }
}