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
    public class SFSRolesXPermissionsController : ApiController
    {
        private SFSRolesXPermissionsBO _db = new SFSRolesXPermissionsBO();

        // GET: api/SFSRolesXPermissions
        public IQueryable<SFSRolesXPermission> Get()
        {
            return _db.GetAll();
        }

        // GET: api/SFSRolesXPermissions/5
        [ResponseType(typeof(SFSRolesXPermission))]
        public IHttpActionResult Get(int id)
        {
            SFSRolesXPermission sfsRolesXPermission = _db.GetByKey(id);
            if (sfsRolesXPermission == null)
            {
                return NotFound();
            }

            return Ok(sfsRolesXPermission);
        }

        // PUT: api/SFSRolesXPermissions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, SFSRolesXPermission sfsRolesXPermission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sfsRolesXPermission.rp_pk)
            {
                return BadRequest();
            }

   

            try
            {
                _db.Update(sfsRolesXPermission);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SFSRolesXPermissionExists(id))
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

        // POST: api/SFSRolesXPermissions
        [ResponseType(typeof(SFSRolesXPermission))]
        public IHttpActionResult Post(SFSRolesXPermission sfsRolesXPermission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(sfsRolesXPermission);
            _db.Save();
            return CreatedAtRoute("DefaultApi", new { id = sfsRolesXPermission.rp_pk }, sfsRolesXPermission);
        }

        // DELETE: api/SFSRolesXPermissions/5
        [ResponseType(typeof(SFSRolesXPermission))]
        public IHttpActionResult Delete(int id)
        {
            SFSRolesXPermission sfsRolesXPermission = _db.GetByKey(id);
            if (sfsRolesXPermission == null)
            {
                return NotFound();
            }

            _db.Delete(sfsRolesXPermission);
            _db.Save();
            return Ok(sfsRolesXPermission);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool SFSRolesXPermissionExists(int id)
        {
           // return db.SFSRolesXPermissions.Count(e => e.rp_pk == id) > 0;
            return true;
        }
    }
}