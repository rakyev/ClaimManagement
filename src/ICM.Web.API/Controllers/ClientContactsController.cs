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
    public class ClientContactsController : ApiController
    {
        private ClientContactBO db = new ClientContactBO();

        // GET: api/ClientContacts
        public IQueryable<ClientContact> Get()
        {
            return db.GetAll();
        }

        // GET: api/ClientContacts/5
        [ResponseType(typeof(ClientContact))]
        public IHttpActionResult Get(long id)
        {
            ClientContact clientContact = db.GetByKey(id);
            if (clientContact == null)
            {
                return NotFound();
            }

            return Ok(clientContact);
        }

        // PUT: api/ClientContacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, ClientContact clientContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientContact.ClientContactID)
            {
                return BadRequest();
            }
            try
            {
                db.Update(clientContact);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientContactExists(id))
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

        // POST: api/ClientContacts
        [ResponseType(typeof(ClientContact))]
        public IHttpActionResult Post(ClientContact clientContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(clientContact);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = clientContact.ClientContactID }, clientContact);
        }

        // DELETE: api/ClientContacts/5
        [ResponseType(typeof(ClientContact))]
        public IHttpActionResult Delete(long id)
        {
            ClientContact clientContact = db.GetByKey(id);
            if (clientContact == null)
            {
                return NotFound();
            }

            db.Delete(clientContact);
            db.Save();

            return Ok(clientContact);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool ClientContactExists(long id)
        {
            return true;//db.ClientContacts.Count(e => e.ClientContactID == id) > 0;
        }
    }
}