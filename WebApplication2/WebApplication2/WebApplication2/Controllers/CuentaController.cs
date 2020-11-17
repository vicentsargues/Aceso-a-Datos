using Placemybet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Placemybet.Controllers
{
    public class CuentaController : ApiController
    {
        // GET: api/Cuenta


        [Authorize]
        public IEnumerable<Cuenta> Get()
        {
            return new CuentaRepository().Retrive();

        }

        // GET: api/Cuenta/5
        public Cuenta Get(int id)
        {
            var usu = new Cuenta(1,1,"1","1");

            Console.WriteLine(usu);
            return usu;
        }

        // POST: api/Cuenta
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cuenta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cuenta/5
        public void Delete(int id)
        {
        }
    }
}
