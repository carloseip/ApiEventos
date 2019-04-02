using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BO;
using BE;
using System.Web.Http.Cors;

namespace ApiSeguraEventos.Controllers
{
    [EnableCors("*", "*", "*")]
    public class DetVentaController : ApiController
    {
        DetVentaBO gestorDetVenta = new DetVentaBO();

        // GET: api/DetVenta
        [HttpGet]
        public IEnumerable<DetVenta> Get()
        {
            return gestorDetVenta.ListarDetVenta();
        }

        // GET: api/DetVenta/5/6
        [HttpGet]
        public DetVenta Get(int IdCabVenta, int IdEvento)
        {
            return gestorDetVenta.ListarDetVenta(IdCabVenta, IdEvento);
        }
        // POST: api/DetVenta
        [HttpGet]
        public string Post([FromBody]DetVenta value)
        {
            return gestorDetVenta.IngresarDetVenta(value);
        }
        // PUT: api/DetVenta
        [HttpPut]
        public string Put([FromBody]DetVenta value)
        {
            return gestorDetVenta.ActualizarDetVenta(value);
        }
        // DELETE: api/DetVenta/5/5
        [HttpDelete]
        public string Delete(int IdCabVenta, int IdEvento)
        {
            return gestorDetVenta.EliminarDetVenta(IdCabVenta, IdEvento);
        }
    }
}
