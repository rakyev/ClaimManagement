using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ICM.Data;
using ICM.Data.Business.BusinessObject;

namespace ICM.Web.API.Controllers
{
    public class DocumentTypesController : ApiController
    {
        private readonly DocumentTypeBO _db = new DocumentTypeBO();

        // GET: api/DocumentTypes
        public IQueryable<DocumentType> Get()
        {
            return _db.GetAll();
        }

        // GET: api/DocumentTypes/5
        [ResponseType(typeof(DocumentType))]
        public IHttpActionResult Get(long id)
        {
            DocumentType documentType = _db.GetByKey(id);
            if (documentType == null)
            {
                return NotFound();
            }

            return Ok(documentType);
        }

        // PUT: api/DocumentTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, DocumentType documentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documentType.DocumentTypeID)
            {
                return BadRequest();
            }
            try
            {
                _db.Update(documentType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentTypeExists(id))
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

        // POST: api/DocumentTypes
        [ResponseType(typeof(DocumentType))]
        public IHttpActionResult Post(DocumentType documentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Add(documentType);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = documentType.DocumentTypeID }, documentType);
        }

        // DELETE: api/DocumentTypes/5
        [ResponseType(typeof(DocumentType))]
        public IHttpActionResult Delete(long id)
        {
            DocumentType documentType = _db.GetByKey(id);
            if (documentType == null)
            {
                return NotFound();
            }

            _db.Delete(documentType);
            _db.Save();

            return Ok(documentType);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }

        private bool DocumentTypeExists(long id)
        {
          //  return db.DocumentTypes.Count(e => e.DocumentTypeID == id) > 0;
            return true;
        }
    }
}