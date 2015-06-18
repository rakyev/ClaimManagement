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
    public class CaseMVAsController : ApiController
    {
        private CaseMvaBO db = new CaseMvaBO();

        // GET: api/CaseMVAs
        public IQueryable<CaseMVA> Get()
        {
            return db.GetAll();
        }

        // GET: api/CaseMVAs/5
        [ResponseType(typeof(CaseMVA))]
        public IHttpActionResult Get(long id)
        {
            CaseMVA caseMVA = db.GetByKey(id);
            if (caseMVA == null)
            {
                return NotFound();
            }

            return Ok(caseMVA);
        }

        // PUT: api/CaseMVAs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, CaseMVA caseMVA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caseMVA.CaseMVAID)
            {
                return BadRequest();
            }
            try
            {
                db.Update(caseMVA);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseMVAExists(id))
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

        // POST: api/CaseMVAs
        [ResponseType(typeof(CaseMVA))]
        public IHttpActionResult Post(CaseMVA caseMVA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(caseMVA);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = caseMVA.CaseMVAID }, caseMVA);
        }

        // DELETE: api/CaseMVAs/5
        [ResponseType(typeof(CaseMVA))]
        public IHttpActionResult Delete(long id)
        {
            CaseMVA caseMVA = db.GetByKey(id);
            if (caseMVA == null)
            {
                return NotFound();
            }

            db.Delete(caseMVA);
            db.Save();

            return Ok(caseMVA);
        }

        protected override void Dispose(bool disposing)
        {
          /*  if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool CaseMVAExists(long id)
        {
           // return db.CaseMVAs.Count(e => e.CaseMVAID == id) > 0;
            return true;
        }
    }
}