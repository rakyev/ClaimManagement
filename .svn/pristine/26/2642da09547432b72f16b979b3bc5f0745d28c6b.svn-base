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
    public class SFSPermissionsController : ApiController
    {
        private readonly SFSPermissionBO _db = new SFSPermissionBO();
        //private ICMDBContext db = new ICMDBContext();

        // GET: api/SFSPermissions
        public IQueryable<SFSPermission> Get()
        {
            return _db.GetAll();
        }

        // GET: api/SFSPermissions/5
        [ResponseType(typeof(SFSPermission))]
        public IHttpActionResult Get(int id)
        {
            SFSPermission sFSPermission = _db.GetByKey(id);
            if (sFSPermission == null)
            {
                return NotFound();
            }

            return Ok(sFSPermission);
        }

        // GET: api/SFSPermissions/name
        public IHttpActionResult Get(string category)
        {
            IList<SFSPermission> sFSPermission = _db.GetByCategory(category);
            if (sFSPermission == null)
            {
                return NotFound();
            }

            return Ok(sFSPermission);
        }

        // PUT: api/SFSPermissions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, SFSPermission sFSPermission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sFSPermission.pm_pk)
            {
                return BadRequest();
            }

            try
            {
                _db.Update(sFSPermission);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SFSPermissionExists(id))
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

        // POST: api/SFSPermissions
        [ResponseType(typeof(SFSPermission))]
        public IHttpActionResult Post(SFSPermission sFSPermission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(sFSPermission);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = sFSPermission.pm_pk }, sFSPermission);
        }

        // DELETE: api/SFSPermissions/5
        [ResponseType(typeof(SFSPermission))]
        public IHttpActionResult Delete(int id)
        {
            SFSPermission sFSPermission = _db.GetByKey(id);
            if (sFSPermission == null)
            {
                return NotFound();
            }

            _db.Delete(sFSPermission);
            _db.Save();

            return Ok(sFSPermission);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool SFSPermissionExists(int id)
        {
            //return db.SFSPermissions.Count(e => e.pm_pk == id) > 0;
            return true;
        }
    }
}