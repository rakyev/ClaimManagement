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
    public class AppointmentResourceChargeOutTypesController : ApiController
    {
        private AppointmentResourceChargeOutTypeBO db = new AppointmentResourceChargeOutTypeBO();

        // GET: api/AppointmentResourceChargeOutTypes
        public IQueryable<AppointmentResourceChargeOutType> Get()
        {
            return db.GetAll();
        }

        // GET: api/AppointmentResourceChargeOutTypes/5
        [ResponseType(typeof(AppointmentResourceChargeOutType))]
        public IHttpActionResult Get(long id)
        {
            AppointmentResourceChargeOutType appointmentResourceChargeOutType = db.GetByKey(id);
            if (appointmentResourceChargeOutType == null)
            {
                return NotFound();
            }

            return Ok(appointmentResourceChargeOutType);
        }

        // PUT: api/AppointmentResourceChargeOutTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, AppointmentResourceChargeOutType appointmentResourceChargeOutType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointmentResourceChargeOutType.AppointmentResourceChargeOutTypeID)
            {
                return BadRequest();
            }

            try
            {
                db.Update(appointmentResourceChargeOutType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentResourceChargeOutTypeExists(id))
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

        // POST: api/AppointmentResourceChargeOutTypes
        [ResponseType(typeof(AppointmentResourceChargeOutType))]
        public IHttpActionResult Post(AppointmentResourceChargeOutType appointmentResourceChargeOutType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(appointmentResourceChargeOutType);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = appointmentResourceChargeOutType.AppointmentResourceChargeOutTypeID }, appointmentResourceChargeOutType);
        }

        // DELETE: api/AppointmentResourceChargeOutTypes/5
        [ResponseType(typeof(AppointmentResourceChargeOutType))]
        public IHttpActionResult Delete(long id)
        {
            AppointmentResourceChargeOutType appointmentResourceChargeOutType = db.GetByKey(id);
            if (appointmentResourceChargeOutType == null)
            {
                return NotFound();
            }

            db.Delete(appointmentResourceChargeOutType);
            db.Save();

            return Ok(appointmentResourceChargeOutType);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool AppointmentResourceChargeOutTypeExists(long id)
        {
            return true;
                //db.AppointmentResourceChargeOutTypes.Count(e => e.AppointmentResourceChargeOutTypeID == id) > 0;
        }
    }
}