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
    public class ClientContactRelationshipsController : ApiController
    {
        private ClientContactRelationshipBO db = new ClientContactRelationshipBO();

        // GET: api/ClientContactRelationships
        public IQueryable<ClientContactRelationship> Get()
        {
            return db.GetAll();
        }

        // GET: api/ClientContactRelationships/5
        [ResponseType(typeof(ClientContactRelationship))]
        public IHttpActionResult Get(long id)
        {
            ClientContactRelationship clientContactRelationship = db.GetByKey(id);
            if (clientContactRelationship == null)
            {
                return NotFound();
            }

            return Ok(clientContactRelationship);
        }

        // PUT: api/ClientContactRelationships/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, ClientContactRelationship clientContactRelationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientContactRelationship.ClientContactRelationshipID)
            {
                return BadRequest();
            }

           

            try
            {
                db.Update(clientContactRelationship);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientContactRelationshipExists(id))
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

        // POST: api/ClientContactRelationships
        [ResponseType(typeof(ClientContactRelationship))]
        public IHttpActionResult Post(ClientContactRelationship clientContactRelationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(clientContactRelationship);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = clientContactRelationship.ClientContactRelationshipID }, clientContactRelationship);
        }

        // DELETE: api/ClientContactRelationships/5
        [ResponseType(typeof(ClientContactRelationship))]
        public IHttpActionResult Delete(long id)
        {
            ClientContactRelationship clientContactRelationship = db.GetByKey(id);
            if (clientContactRelationship == null)
            {
                return NotFound();
            }

            db.Delete(clientContactRelationship);
            db.Save();

            return Ok(clientContactRelationship);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool ClientContactRelationshipExists(long id)
        {
            return true; //db.ClientContactRelationships.Count(e => e.ClientContactRelationshipID == id) > 0;
        }
    }
}