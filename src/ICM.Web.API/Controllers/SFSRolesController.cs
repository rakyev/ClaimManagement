using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ICM.Data;
using ICM.Data.Business.BusinessObject;

namespace ICM.Web.API.Controllers
{
    public class SFSRolesController : ApiController
    {
        private readonly SFSRolesBO _db = new SFSRolesBO();

        // GET: api/SFSRoles
        public IQueryable<SFSRole> Get()
        {
            return _db.GetAll();
        }

        // GET: api/SFSRoles/5
        [ResponseType(typeof(SFSRole))]
        public IHttpActionResult Get(int id)
        {
            SFSRole sfsRole = _db.GetByKey(id);
            if (sfsRole == null)
            {
                return NotFound();
            }

            return Ok(sfsRole);
        }

        // PUT: api/SFSRoles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, SFSRole sfsRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != sfsRole.rl_pk)
            {
                return BadRequest();
            }

           
            try
            {
                _db.Update(sfsRole);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SFSRoleExists(id))
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

        // POST: api/SFSRoles
        [ResponseType(typeof(SFSRole))]
        public  IHttpActionResult Post(SFSRole sfsRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(sfsRole);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = sfsRole.rl_pk }, sfsRole);
        }

        // DELETE: api/SFSRoles/5
        [ResponseType(typeof(SFSRole))]
        public IHttpActionResult Delete(int id)
        {
            SFSRole sfsRole = _db.GetByKey(id);
            if (sfsRole == null)
            {
                return NotFound();
            }

            _db.Delete(sfsRole);
            _db.Save();

            return Ok(sfsRole);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool SFSRoleExists(int id)
        {
           // return db.SFSRoles.Count(e => e.rl_pk == id) > 0;
            return true;
        }
    }
}