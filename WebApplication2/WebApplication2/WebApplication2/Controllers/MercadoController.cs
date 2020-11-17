using Placemybet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Placemybet.Controllers
{
    [Route("api/Mercados/{action}")]
    public class MercadoController : ApiController
    {
        // GET: api/Mercado
        [HttpGet]
        [ActionName("Get")]
        public IEnumerable<Mercado> Get()
        {
            return new MercadoRepository().Retrive();
        }

        [HttpGet]
        [ActionName("GetDTO")]
        public IEnumerable<MercadoDTO> GetDTO()
        {
            return new MercadoRepository().GetMercadosDTO();
        }

        [HttpGet]
        [Route("api/Mercados/over={over}")]


        public IEnumerable<Mercado> Getover(int over)
        {
            return new MercadoRepository().RetriveOver(over);
        }

        [HttpGet]
        [Route("api/Mercados/under={under}")]

        public IEnumerable<Mercado> Getunder(int under)
        {
            return new MercadoRepository().RetriveUnder(under);
        }

        // GET: api/Mercado/5
        public Mercado Get(int id)
        {
            var usu = new Mercado(1,"1",1,1,1,1);

            return usu;
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
