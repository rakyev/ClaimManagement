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
    public class SFSUsersController : ApiController
    {
        private SFSUsersBO _db = new SFSUsersBO();

        // GET: api/SFSUsers
        public IQueryable<SFSUser> Get()
        {
            return _db.GetAll();
        }

        // GET: api/SFSUsers/5
        [ResponseType(typeof(SFSUser))]
        public IHttpActionResult Get(int id)
        {
            SFSUser sfsUser = _db.GetByKey(id);
            if (sfsUser == null)
            {
                return NotFound();
            }

            return Ok(sfsUser);
        }

        // PUT: api/SFSUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, SFSUser sfsUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sfsUser.us_pk)
            {
                return BadRequest();
            }



            try
            {
                _db.Update(sfsUser);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SFSUserExists(id))
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

        // POST: api/SFSUsers
        [ResponseType(typeof(SFSUser))]
        public IHttpActionResult Post(SFSUser sfsUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(sfsUser);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = sfsUser.us_pk }, sfsUser);
        }

        // DELETE: api/SFSUsers/5
        [ResponseType(typeof(SFSUser))]
        public IHttpActionResult Delete(int id)
        {
            SFSUser sfsUser = _db.GetByKey(id);
            if (sfsUser == null)
            {
                return NotFound();
            }

            _db.Delete(sfsUser);
            _db.Save();

            return Ok(sfsUser);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool SFSUserExists(int id)
        {
           // return db.SFSUsers.Count(e => e.us_pk == id) > 0;
            return true;
        }
    }
}