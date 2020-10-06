using Placemybet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Placemybet.Controllers
{
    public class ApuestaController : ApiController
    {
        // GET: api/Apuesta
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Apuesta/5
        public Apuesta Get(int id)
        {
            var usu = new ApuestaRepositorio();
            Apuesta usua = usu.Retrive();
            return usua;
        }

        // POST: api/Apuesta
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Apuesta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuesta/5
        public void Delete(int id)
        {
        }
    }
}
