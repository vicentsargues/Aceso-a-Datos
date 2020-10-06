using Placemybet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Placemybet.Controllers
{
    public class EventoController : ApiController
    {
        // GET: api/Evento
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Evento/5
        public Evento Get(int id)
        {
            var usu = new EventoRepository();
            Evento usua = usu.Retrive();
            return usua;
        }

        // POST: api/Evento
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Evento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Evento/5
        public void Delete(int id)
        {
        }
    }
}
