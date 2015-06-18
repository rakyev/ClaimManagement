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
    public class ProvincesOrStatesController : ApiController
    {
         private readonly ProvinceOrStateBO _db = new ProvinceOrStateBO();

        // GET: api/ProvincesOrStates
        public IQueryable<ProvinceOrState> GetProvincesOrStates()
        {
            return _db.GetAll();
        }

        // GET: api/ProvincesOrStates/5
        [ResponseType(typeof(ProvinceOrState))]
        public IHttpActionResult Get(long id)
        {
            ProvinceOrState provinceOrState = _db.GetByKey(id);
            if (provinceOrState == null)
            {
                return NotFound();
            }

            return Ok(provinceOrState);
        }

        // PUT: api/ProvincesOrState/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, ProvinceOrState provinceOrState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != provinceOrState.ProvinceOrStateID)
            {
                return BadRequest();
            }
            try
            {
                _db.Update(provinceOrState);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinceOrStateExists(id))
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

        // POST: api/ProvincesOrStates
        [ResponseType(typeof(ProvinceOrState))]
        public IHttpActionResult Post(ProvinceOrState provinceOrState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(provinceOrState);
            _db.Save();
            return CreatedAtRoute("DefaultApi", new { id = provinceOrState.ProvinceOrStateID }, provinceOrState);
        }

        // DELETE: api/ProvincesOrStates/5
        [ResponseType(typeof(ProvinceOrState))]
        public IHttpActionResult Delete(long id)
        {
            ProvinceOrState provinceOrState = _db.GetByKey(id);
            if (provinceOrState == null)
            {
                return NotFound();
            }

            _db.Delete(provinceOrState);
            _db.Save();
            return Ok(provinceOrState);
        }
        
        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
              {
                db.Dispose();
              }
            base.Dispose(disposing);*/
        }
   
        private bool ProvinceOrStateExists(long id)
        {
            //return db.ProvincesOrStates.Count(e => e.ProvinceOrStateID == id) > 0;
            return true;
        }
    }  
}