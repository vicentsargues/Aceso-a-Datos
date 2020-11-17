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

        public IEnumerable<Evento> Get()
        {
            return new EventoRepository().Retrive();
        }

        // GET: api/Evento/5

        public IEnumerable<EventoDTO> GetDTO()
        {
            return new EventoRepository().GetEventosDTO();
        }
        public string Get(int id)
        {
  
            return "usu";
        }
        /***  EJERCICIO PARA EXAMEN (EJERCIOCIO 2) ***/
        // POST: api/Evento

        public void Post([FromBody]EventoExamen value)
        {
            var repo2 = new MercadoRepository();
            repo2.AutoInsert(value.Mercado,value.TipoMercado);
            var repo = new EventoRepository();
            repo.Save(value);
        }
        /***  EJERCICIO PARA EXAMEN (EJERCIOCIO 2) ***/
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
