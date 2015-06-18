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
    public class SkedulexMessagesController : ApiController
    {
        private readonly SkedulexMessageBO _db = new SkedulexMessageBO();

        // GET: api/SkedulexMessages
        public IQueryable<SkedulexMessage> Get()
        {
            return _db.GetAll();
        }

        // GET: api/SkedulexMessages/5
        [ResponseType(typeof(SkedulexMessage))]
        public IHttpActionResult Get(long id)
        {
            SkedulexMessage skedulexMessage = _db.GetByKey(id);
            if (skedulexMessage == null)
            {
                return NotFound();
            }

            return Ok(skedulexMessage);
        }

        // PUT: api/SkedulexMessages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, SkedulexMessage skedulexMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skedulexMessage.sm_pk)
            {
                return BadRequest();
            }

           

            try
            {
                _db.Update(skedulexMessage);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkedulexMessageExists(id))
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

        // POST: api/SkedulexMessages
        [ResponseType(typeof(SkedulexMessage))]
        public IHttpActionResult Post(SkedulexMessage skedulexMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(skedulexMessage);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = skedulexMessage.sm_pk }, skedulexMessage);
        }

        // DELETE: api/SkedulexMessages/5
        [ResponseType(typeof(SkedulexMessage))]
        public IHttpActionResult Delete(long id)
        {
            SkedulexMessage skedulexMessage = _db.GetByKey(id);
            if (skedulexMessage == null)
            {
                return NotFound();
            }

            _db.Delete(skedulexMessage);
            _db.Save();

            return Ok(skedulexMessage);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool SkedulexMessageExists(long id)
        {
           // return db.SkedulexMessages.Count(e => e.sm_pk == id) > 0;
            return true;
        }
    }
}