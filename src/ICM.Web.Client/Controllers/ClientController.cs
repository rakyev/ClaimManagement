using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ICM.Data;
using ICM.Data.Business.BusinessObject;

namespace ICM.Web.Client.Controllers
{
    public class ClientController : ApiController
    {
        private ClientBO db = new ClientBO();
        // GET api/client
//        [ResponseType(typeof(IQueryable<ICM.Data.Client>))]
        public IQueryable<ICM.Data.Client> Get()
        {
            return db.GetAll();
        }

        // GET api/client/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/client
        public void Post([FromBody]string value)
        {
        }

        // PUT api/client/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/client/5
        public void Delete(int id)
        {
        }
    }
}
