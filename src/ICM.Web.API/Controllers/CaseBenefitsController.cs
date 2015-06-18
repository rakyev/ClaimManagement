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
    public class CaseBenefitsController : ApiController
    {
        private CaseBenefitBO db = new CaseBenefitBO();

        // GET: api/CaseBenefits
        public IQueryable<CaseBenefit> Get()
        {
            return db.GetAll();
        }

        // GET: api/CaseBenefits/5
        [ResponseType(typeof(CaseBenefit))]
        public IHttpActionResult Get(long id)
        {
            CaseBenefit caseBenefit = db.GetByKey(id);
            if (caseBenefit == null)
            {
                return NotFound();
            }

            return Ok(caseBenefit);
        }

        // PUT: api/CaseBenefits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, CaseBenefit caseBenefit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caseBenefit.CaseBenefitID)
            {
                return BadRequest();
            }
            try
            {
                db.Update(caseBenefit);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseBenefitExists(id))
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

        // POST: api/CaseBenefits
        [ResponseType(typeof(CaseBenefit))]
        public IHttpActionResult Post(CaseBenefit caseBenefit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(caseBenefit);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = caseBenefit.CaseBenefitID }, caseBenefit);
        }

        // DELETE: api/CaseBenefits/5
        [ResponseType(typeof(CaseBenefit))]
        public IHttpActionResult Delete(long id)
        {
            CaseBenefit caseBenefit = db.GetByKey(id);
            if (caseBenefit == null)
            {
                return NotFound();
            }

            db.Delete(caseBenefit);
            db.Save();

            return Ok(caseBenefit);
        }

        protected override void Dispose(bool disposing)
        {
           /* if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool CaseBenefitExists(long id)
        {
          // return db.CaseBenefits.Count(e => e.CaseBenefitID == id) > 0;
            return true;
        }
    }
}