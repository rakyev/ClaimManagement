
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
    public class SFSUsersXRolesController : ApiController
    {
        private readonly SFSUsersXRolesBO _db = new SFSUsersXRolesBO();

        // GET: api/SFSUsersXRoles
        public IQueryable<SFSUsersXRole> Get()
        {
            return _db.GetAll();
        }

        // GET: api/SFSUsersXRoles/5
        [ResponseType(typeof(SFSUsersXRole))]
        public IHttpActionResult Get(int id)
        {
            SFSUsersXRole sfsUsersXRole = _db.GetByKey(id);
            if (sfsUsersXRole == null)
            {
                return NotFound();
            }

            return Ok(sfsUsersXRole);
        }

        // PUT: api/SFSUsersXRoles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, SFSUsersXRole sfsUsersXRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sfsUsersXRole.ur_pk)
            {
                return BadRequest();
            }

            try
            {
                _db.Update(sfsUsersXRole);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SFSUsersXRoleExists(id))
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

        // POST: api/SFSUsersXRoles
        [ResponseType(typeof(SFSUsersXRole))]
        public IHttpActionResult Post(SFSUsersXRole sfsUsersXRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(sfsUsersXRole);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = sfsUsersXRole.ur_pk }, sfsUsersXRole);
        }

        // DELETE: api/SFSUsersXRoles/5
        [ResponseType(typeof(SFSUsersXRole))]
        public IHttpActionResult Delete(int id)
        {
            SFSUsersXRole sfsUsersXRole = _db.GetByKey(id);
            if (sfsUsersXRole == null)
            {
                return NotFound();
            }

            _db.Delete(sfsUsersXRole);
            _db.Save();

            return Ok(sfsUsersXRole);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool SFSUsersXRoleExists(int id)
        {
            //return db.SFSUsersXRoles.Count(e => e.ur_pk == id) > 0;
            return true;
        }
    }
}