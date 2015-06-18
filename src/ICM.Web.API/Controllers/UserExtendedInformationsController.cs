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
    public class UserExtendedInformationsController : ApiController
    {
         private readonly UserExtendedInformationBO _db = new UserExtendedInformationBO();

        // GET: api/UserExtendedInformations
        public IQueryable<UserExtendedInformation> Get()
        {
            return _db.GetAll();
        }

        // GET: api/UserExtendedInformations/5
        [ResponseType(typeof(UserExtendedInformation))]
        public IHttpActionResult Get(long id)
        {
            UserExtendedInformation userExtendedInformation = _db.GetByKey(id);
            if (userExtendedInformation == null)
            {
                return NotFound();
            }

            return Ok(userExtendedInformation);
        }

        // PUT: api/UserExtendedInformations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, UserExtendedInformation userExtendedInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userExtendedInformation.UserID)
            {
                return BadRequest();
            }
            try
            {
                _db.Update(userExtendedInformation);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExtendedInformationExists(id))
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

        // POST: api/UserExtendedInformations
        [ResponseType(typeof(UserExtendedInformation))]
        public IHttpActionResult Post(UserExtendedInformation userExtendedInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(userExtendedInformation);
            _db.Save();
            return CreatedAtRoute("DefaultApi", new { id = userExtendedInformation.UserID }, userExtendedInformation);
        }

        // DELETE: api/UserExtendedInformations/5
        [ResponseType(typeof(UserExtendedInformation))]
        public IHttpActionResult Delete(long id)
        {
            UserExtendedInformation userExtendedInformation = _db.GetByKey(id);
            if (userExtendedInformation == null)
            {
                return NotFound();
            }

            _db.Delete(userExtendedInformation);
            _db.Save();
            return Ok(userExtendedInformation);
        }
       
        protected override void Dispose(bool disposing)
        {
            /* if (disposing)
              {
                   _db.Dispose();
              }
              base.Dispose(disposing);*/     
        }

        private bool UserExtendedInformationExists(long id)
        {
           // return _db.UserExtendedInformation.Count(e => e.UserID == id) > 0;
            return true;
        }
    }
}