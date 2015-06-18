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
    public class SFSProjectsController : ApiController
    {
        private readonly SFSProjectBO _db = new SFSProjectBO();
        //private ICMDBContext db = new ICMDBContext();

        // GET: api/SFSProjects
        public IQueryable<SFSProject> Get()
        {
            return _db.GetAll();
        }

        // GET: api/SFSProjects/5
        [ResponseType(typeof(SFSProject))]
        public IHttpActionResult Get(int id)
        {
            SFSProject sFSProject = _db.GetByKey(id);
            if (sFSProject == null)
            {
                return NotFound();
            }

            return Ok(sFSProject);
        }

        // PUT: api/SFSProjects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, SFSProject sFSProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sFSProject.sproj_pk)
            {
                return BadRequest();
            }

            try
            {
                _db.Update(sFSProject);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SFSProjectExists(id))
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

        // POST: api/SFSProjects
        [ResponseType(typeof(SFSProject))]
        public IHttpActionResult Post(SFSProject sFSProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(sFSProject);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = sFSProject.sproj_pk }, sFSProject);
        }

        // DELETE: api/SFSProjects/5
        [ResponseType(typeof(SFSProject))]
        public IHttpActionResult Delete(int id)
        {
            SFSProject sFSProject = _db.GetByKey(id);
            if (sFSProject == null)
            {
                return NotFound();
            }

            _db.Delete(sFSProject);
            _db.Save();

            return Ok(sFSProject);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool SFSProjectExists(int id)
        {
            //return db.SFSProjects.Count(e => e.sproj_pk == id) > 0;
            return true;
        }
    }
}