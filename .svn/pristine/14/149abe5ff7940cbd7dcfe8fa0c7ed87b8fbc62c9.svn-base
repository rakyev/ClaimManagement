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
    public class SFSUsersXPermissionsController : ApiController
    {
        private readonly SFSUsersXPermissionsBO _db = new SFSUsersXPermissionsBO();

        // GET: api/SFSUsersXPermissions
        public IQueryable<SFSUsersXPermission> Get()
        {
            return _db.GetAll();
        }

        // GET: api/SFSUsersXPermissions/5
        [ResponseType(typeof(SFSUsersXPermission))]
        public IHttpActionResult Get(int id)
        {
            SFSUsersXPermission sfsUsersXPermission = _db.GetByKey(id);
            if (sfsUsersXPermission == null)
            {
                return NotFound();
            }

            return Ok(sfsUsersXPermission);
        }

        // PUT: api/SFSUsersXPermissions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, SFSUsersXPermission sfsUsersXPermission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sfsUsersXPermission.up_pk)
            {
                return BadRequest();
            }

           

            try
            {
                _db.Update(sfsUsersXPermission);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SFSUsersXPermissionExists(id))
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

        // POST: api/SFSUsersXPermissions
        [ResponseType(typeof(SFSUsersXPermission))]
        public IHttpActionResult Post(SFSUsersXPermission sfsUsersXPermission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Add(sfsUsersXPermission);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = sfsUsersXPermission.up_pk }, sfsUsersXPermission);
        }

        // DELETE: api/SFSUsersXPermissions/5
        [ResponseType(typeof(SFSUsersXPermission))]
        public IHttpActionResult Delete(int id)
        {
            SFSUsersXPermission sfsUsersXPermission = _db.GetByKey(id);
            if (sfsUsersXPermission == null)
            {
                return NotFound();
            }

            _db.Delete(sfsUsersXPermission);
            _db.Save();

            return Ok(sfsUsersXPermission);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool SFSUsersXPermissionExists(int id)
        {
            //return db.SFSUsersXPermissions.Count(e => e.up_pk == id) > 0;
            return true;
        }
    }
}