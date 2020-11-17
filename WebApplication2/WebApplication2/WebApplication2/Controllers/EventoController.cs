using Placemybet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Placemybet.Controllers
{
    [Route("api/Eventos/{action}")]
    public class EventoController : ApiController
    {
        // GET: api/Evento
        [HttpGet]
        [ActionName("Get")]
        public IEnumerable<Evento> Get()
        {
            return new EventoRepository().Retrive();
        }

        // GET: api/Evento/5
        [HttpGet]
        [ActionName("GetDTO")]
        public IEnumerable<EventoDTO> GetDTO()
        {
            return new EventoRepository().GetEventosDTO();
        }
        public string Get(int id)
        {
  
            return "usu";
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
