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
    public class ClientCasesController : ApiController
    {
        private ClientCaseBO db = new ClientCaseBO();

        // GET: api/ClientCases
        public IQueryable<ClientCase> Get()
        {
            return db.GetAll();
        }

        // GET: api/ClientCases/5
        [ResponseType(typeof(ClientCase))]
        public IHttpActionResult Get(long id)
        {
            ClientCase clientCase = db.GetByKey(id);
            if (clientCase == null)
            {
                return NotFound();
            }

            return Ok(clientCase);
        }

        // PUT: api/ClientCases/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, ClientCase clientCase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientCase.CaseID)
            {
                return BadRequest();
            }

           try
            {
                db.Update(clientCase);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientCaseExists(id))
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

        // POST: api/ClientCases
        [ResponseType(typeof(ClientCase))]
        public IHttpActionResult Post(ClientCase clientCase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(clientCase);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = clientCase.CaseID }, clientCase);
        }

        // DELETE: api/ClientCases/5
        [ResponseType(typeof(ClientCase))]
        public IHttpActionResult Delete(long id)
        {
            ClientCase clientCase = db.GetByKey(id);
            if (clientCase == null)
            {
                return NotFound();
            }

            db.Delete(clientCase);
            db.Save();

            return Ok(clientCase);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool ClientCaseExists(long id)
        {
            return true; //db.ClientCases.Count(e => e.CaseID == id) > 0;
        }
    }
}