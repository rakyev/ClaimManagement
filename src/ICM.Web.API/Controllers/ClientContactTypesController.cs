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
    public class ClientContactTypesController : ApiController
    {
        private ClientContactTypeBO db = new ClientContactTypeBO();

        // GET: api/ClientContactTypes
        public IQueryable<ClientContactType> Get()
        {
            return db.GetAll();
        }

        // GET: api/ClientContactTypes/5
        [ResponseType(typeof(ClientContactType))]
        public IHttpActionResult Get(long id)
        {
            ClientContactType clientContactType = db.GetByKey(id);
            if (clientContactType == null)
            {
                return NotFound();
            }

            return Ok(clientContactType);
        }

        // PUT: api/ClientContactTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, ClientContactType clientContactType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientContactType.ClientContactTypeID)
            {
                return BadRequest();
            }

            

            try
            {
                db.Update(clientContactType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientContactTypeExists(id))
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

        // POST: api/ClientContactTypes
        [ResponseType(typeof(ClientContactType))]
        public IHttpActionResult Post(ClientContactType clientContactType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(clientContactType);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = clientContactType.ClientContactTypeID }, clientContactType);
        }

        // DELETE: api/ClientContactTypes/5
        [ResponseType(typeof(ClientContactType))]
        public IHttpActionResult Delete(long id)
        {
            ClientContactType clientContactType = db.GetByKey(id);
            if (clientContactType == null)
            {
                return NotFound();
            }

            db.Delete(clientContactType);
            db.Save();

            return Ok(clientContactType);
        }

        protected override void Dispose(bool disposing)
        {
           /* if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool ClientContactTypeExists(long id)
        {
            return true;//db.ClientContactTypes.Count(e => e.ClientContactTypeID == id) > 0;
        }
    }
}