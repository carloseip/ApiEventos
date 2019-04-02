using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BO;
using BE;

namespace ApiSeguraEventos.Controllers
{
    [EnableCors("*", "*", "*")]
    [Authorize]
    public class CarteraCobroController : ApiController
    {
        CarteraCobroBO gestorCarteraCobro = new CarteraCobroBO();
        // GET: api/CarteraCobro
        [HttpGet]
        public IEnumerable<CarteraCobro> Get()
        {
            return gestorCarteraCobro.ListarCarteraCobro();
        }
        // GET: api/CarteraCobro/5
        [HttpGet]
        public CarteraCobro Get(int IdCarteraCobro)
        {
            return gestorCarteraCobro.ListarCarteraCobro(IdCarteraCobro);
        }
        [Route("api/GetIdCabVenta")]
        public CarteraCobro Get2(int IdCabVenta)
        {
            return gestorCarteraCobro.ListarCarteraCobroVenta(IdCabVenta);
        }
        [Route("api/GetIds")]
        public CarteraCobro Get3(int IdCabVenta,int IdEvento)
        {
            return gestorCarteraCobro.ListarCarteraCobro(IdCabVenta, IdEvento);
        }
        // POST: api/CarteraCobro
        [HttpPost]
        public string Post([FromBody]CarteraCobro value)
        {
            return gestorCarteraCobro.IngresarCarteraCobro(value);
        }
        // PUT: api/CarteraCobro
        [HttpPut]
        public string Put([FromBody]CarteraCobro value)
        {
            return gestorCarteraCobro.ActualizarCarteraCobro(value);
        }
        // DELETE: api/CarteraCobro/id
        [HttpDelete]
        public string Delete(int IdCarteraCobro)
        {
            return gestorCarteraCobro.EiminarCarteraCobro(IdCarteraCobro);
        }
    }
}
