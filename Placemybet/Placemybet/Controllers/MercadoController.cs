using Placemybet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Placemybet.Controllers
{
    public class MercadoController : ApiController
    {
        // GET: api/Mercado
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Mercado/5
        public Mercado Get(int id)
        {
            var usu = new MercadoRepository();
            Mercado usua = usu.Retrive();
            return usua;
        }

        // POST: api/Mercado
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercado/5
        public void Delete(int id)
        {
        }
    }
}
