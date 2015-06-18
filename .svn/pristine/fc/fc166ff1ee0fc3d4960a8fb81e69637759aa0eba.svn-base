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
    public class CountriesController : ApiController
    {
        private CountryBO db = new CountryBO();

        // GET: api/Countries
        public IQueryable<Country> Get()
        {
            return db.GetAll();
        }

        // GET: api/Countries/5
        [ResponseType(typeof(Country))]
        public IHttpActionResult Get(long id)
        {
            Country country = db.GetByKey(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        // PUT: api/Countries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != country.CountryID)
            {
                return BadRequest();
            }

            

            try
            {
                db.Update(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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

        // POST: api/Countries
        [ResponseType(typeof(Country))]
        public IHttpActionResult Post(Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(country);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = country.CountryID }, country);
        }

        // DELETE: api/Countries/5
        [ResponseType(typeof(Country))]
        public IHttpActionResult Delete(long id)
        {
            Country country = db.GetByKey(id);
            if (country == null)
            {
                return NotFound();
            }

            db.Delete(country);
            db.Save();

            return Ok(country);
        }

        protected override void Dispose(bool disposing)
        {
           /* if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool CountryExists(long id)
        {
            return true;//db.Countries.Count(e => e.CountryID == id) > 0;
        }
    }
}