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
    public class ClientsController : ApiController
    {
        private ClientBO db = new ClientBO();

        // GET: api/Clients
        [ResponseType(typeof(IQueryable<Client>))]
        public IQueryable<Client> Get()
        {
            return db.GetAll();
        }

        // GET: api/Clients/5
       [ResponseType(typeof(Client))]
        public IHttpActionResult Get(long? id)
        {
            var client = db.GetByKey(id);
            if (client == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            //return Ok(client);
           return Ok(client);
        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //JToken token = JObject.Parse(client.ToString());
            //dynamic clientObject = JsonConvert.DeserializeObject(token.ToString(), typeof(Client));
            //int page = (int)token.SelectToken("page");
            //int totalPages = (int)token.SelectToken("total_pages");

            //JValue v1 = new JValue(client);
            //Client b = (Client)v1.ToObject(typeof(Client));

            if (id != client.ClientID)
            {
                return BadRequest();
            }

            try
            {
                db.Update(client);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public IHttpActionResult Post(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(client);
            db.Save();

            //TODO--- This might throw an exception...I will review (Femi)
            return CreatedAtRoute("DefaultApi", new { id = client.ClientID }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult Delete(long id)
        {
            var client = db.GetByKey(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Delete(client);
            db.Save();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool ClientExists(long id)
        {
            return true; //db.Clients.Count(e => e.ClientID == id) > 0;
        }
    }
}