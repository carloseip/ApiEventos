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
    public class TipoEventoController : ApiController
    {
        private BO.TipoEventoBO gestorTipoEvento = new BO.TipoEventoBO();

        // GET: api/TipoEvento
        [HttpGet]
        public IEnumerable<TipoEvento> Get()
        {
            var lista = gestorTipoEvento.Listar();
            return lista;
        }
        // GET: api/TipoEvento/5
        [HttpGet]
        public TipoEvento Get(int id)
        {
            var lista = gestorTipoEvento.BuscarEvento(id);
            return lista;
        }
        // POST: api/TipoEvento
        [HttpPost]
        public string Post([FromBody]TipoEvento value)
        {
            return gestorTipoEvento.Ingresar(value);
        }
        // PUT: api/TipoEvento/5
        [HttpPut]
        public string Put([FromBody]TipoEvento value)
        {
            return gestorTipoEvento.Actualizar(value);
        }
        // DELETE: api/TipoEvento/5
        [HttpDelete]
        public string Delete(int id)
        {
            return gestorTipoEvento.Eliminar(id);
        }
    }
}
