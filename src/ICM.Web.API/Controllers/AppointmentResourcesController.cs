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
    public class AppointmentResourcesController : ApiController
    {
        private AppointmentResourceBO db = new AppointmentResourceBO();

        // GET: api/AppointmentResources
        public IQueryable<AppointmentResource> Get()
        {
            return db.GetAll();
        }

        // GET: api/AppointmentResources/5
        [ResponseType(typeof(AppointmentResource))]
        public IHttpActionResult Get(long id)
        {
            AppointmentResource appointmentResource = db.GetByKey(id);
            if (appointmentResource == null)
            {
                return NotFound();
            }

            return Ok(appointmentResource);
        }

        // PUT: api/AppointmentResources/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, AppointmentResource appointmentResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointmentResource.AppointmentResourceID)
            {
                return BadRequest();
            }

            db.Update(appointmentResource);

            try
            {
                db.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentResourceExists(id))
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

        // POST: api/AppointmentResources
        [ResponseType(typeof(AppointmentResource))]
        public IHttpActionResult Post(AppointmentResource appointmentResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(appointmentResource);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = appointmentResource.AppointmentResourceID }, appointmentResource);
        }

        // DELETE: api/AppointmentResources/5
        [ResponseType(typeof(AppointmentResource))]
        public IHttpActionResult Delete(long id)
        {
            AppointmentResource appointmentResource = db.GetByKey(id);
            if (appointmentResource == null)
            {
                return NotFound();
            }

            db.Delete(appointmentResource);
            db.Save();

            return Ok(appointmentResource);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
             */ 
        }

        private bool AppointmentResourceExists(long id)
        {
            return true;//db.AppointmentResources.Count(e => e.AppointmentResourceID == id) > 0;
        }
    }
}