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
    public class ClientContactSpecialitiesController : ApiController
    {
        private ClientContactSpecialityBO db = new ClientContactSpecialityBO();

        // GET: api/ClientContactSpecialities
        public IQueryable<ClientContactSpeciality> Get()
        {
            return db.GetAll();
        }

        // GET: api/ClientContactSpecialities/5
        [ResponseType(typeof(ClientContactSpeciality))]
        public IHttpActionResult Get(long id)
        {
            ClientContactSpeciality clientContactSpeciality = db.GetByKey(id);
            if (clientContactSpeciality == null)
            {
                return NotFound();
            }

            return Ok(clientContactSpeciality);
        }

        // PUT: api/ClientContactSpecialities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, ClientContactSpeciality clientContactSpeciality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientContactSpeciality.ClientContactSpecialityID)
            {
                return BadRequest();
            }
            try
            {
                db.Update(clientContactSpeciality);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientContactSpecialityExists(id))
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

        // POST: api/ClientContactSpecialities
        [ResponseType(typeof(ClientContactSpeciality))]
        public IHttpActionResult Post(ClientContactSpeciality clientContactSpeciality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(clientContactSpeciality);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = clientContactSpeciality.ClientContactSpecialityID }, clientContactSpeciality);
        }

        // DELETE: api/ClientContactSpecialities/5
        [ResponseType(typeof(ClientContactSpeciality))]
        public IHttpActionResult Delete(long id)
        {
            ClientContactSpeciality clientContactSpeciality = db.GetByKey(id);
            if (clientContactSpeciality == null)
            {
                return NotFound();
            }

            db.Delete(clientContactSpeciality);
            db.Save();

            return Ok(clientContactSpeciality);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool ClientContactSpecialityExists(long id)
        {
            return true;//db.ClientContactSpecialities.Count(e => e.ClientContactSpecialityID == id) > 0;
        }
    }
}