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
    public class VentaController : ApiController
    {
        VentaBO gestorVenta = new VentaBO();

        // GET: api/Venta
        [HttpGet]
        public List<CabVenta> Get()
        {
            var rpt = gestorVenta.ListarVentas();
            return rpt;
        }
        // GET: api/Ventas
        [HttpGet]
        [Route("api/ventas")]
        public List<Ventas> GetModel()
        {
            var rpt = gestorVenta.ListarVentasModel();
            return rpt;
        }
        // GET: api/Venta/5
        [HttpGet]
        public CabVenta Get(int IdCabVenta)
        {
            return gestorVenta.ListarVentas(IdCabVenta);
        }
        // POST: api/Venta
        [HttpPost]
        public string Post([FromBody]CabVenta value)
        {
            var resp = gestorVenta.IngresarVenta(value);
            return resp;
        }
        // PUT: api/Venta
        [HttpPut]
        public string Put([FromBody]CabVenta value)
        {
            var rpt = gestorVenta.ActualizarVenta(value);
            return rpt;
        }
        // DELETE: api/Venta/5
        [HttpDelete]
        public string Delete(int IdCabVenta)
        {
            var rpt = gestorVenta.EliminarVenta(IdCabVenta);
            return rpt;
        }
    }
}
