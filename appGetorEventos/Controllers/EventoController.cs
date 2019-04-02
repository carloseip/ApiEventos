using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BE;
using BO;

namespace ApiSeguraEventos.Controllers
{
    [EnableCors("*", "*", "*")]
    public class EventoController : ApiController
    {
        EventoBO gestorEvento = new EventoBO();

        // GET: api/Evento
        [HttpGet]
        public List<CabEvento> Get()
        {
            var list=gestorEvento.ListarEvento();
            return list;
        }

        // GET: api/Evento/5
        [HttpGet]
        public CabEvento Get(int id)
        {
            var evento = gestorEvento.ListarEvento(id);
            return evento;
        }
        //GET: api/Evento/nombre
        [HttpGet]
        public CabEvento Get(string nombre)
        {
            var evento = gestorEvento.ListarEvento(nombre);
            return evento;
        }

        // POST: api/Evento
        [HttpPost]
        public string Post([FromBody]Eventos value)
        {
            return gestorEvento.IngresarEvento(value);
        }

        // DELETE: api/Evento/5
        [HttpPut]
        [Route("api/EliminarEvento")]
        public string Put(int id)
        {
            return gestorEvento.EliminarEvento(id);
        }

        // PUT: api/Evento
        [HttpPut]
        [Route("api/ActualizarEvento")]
        public string Put([FromBody]Eventos value)
        {
            return gestorEvento.ActualizarEvento(value);
        }        
    }
}
