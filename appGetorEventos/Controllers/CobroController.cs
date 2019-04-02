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
    public class CobroController : ApiController
    {

        private CobroBO gestorCobro = new CobroBO();

        // GET: api/Cobro
        [HttpGet]
        public IEnumerable<CobroModelView> Get()
        {
            return gestorCobro.Listar();
        }

        // GET: api/Cobro/5
        [HttpGet]
        public CobroModelView Get(int id)
        {
            return gestorCobro.BuscarCobro(id);
        }

        // POST: api/Cobro
        [HttpPost]
        public string Post([FromBody]CobroModelView value)
        {
            DateTime Hoy = DateTime.Today;
            string fecha_actual = Hoy.ToString("dd/MM/yyyy");
            value.Fecha = fecha_actual;
            return gestorCobro.IngresarCobro(value);
        }

        // PUT: api/Cobro/5
        [HttpPut]
        public string Put([FromBody]CobroModelView value)
        {

            return gestorCobro.ActualizarCobro(value);
        }

        // DELETE: api/Cobro/5
        [HttpDelete]
        public string Delete(int id)
        {
            return gestorCobro.DeleteCobro(id);
        }
    }
}
