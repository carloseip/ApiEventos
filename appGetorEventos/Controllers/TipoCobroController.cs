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
    public class TipoCobroController : ApiController
    {
        private TipoCobroBO gestorTipoCobro = new TipoCobroBO();

        // GET: api/TipoCobro
        [HttpGet]
        public IEnumerable<TipoCobro> Get()
        {
            return gestorTipoCobro.Listar();
        }
        // GET: api/TipoCobro/5
        [HttpGet]
        public TipoCobro Get(int id)
        {
            return gestorTipoCobro.BuscarTipoCobro(id);
        }
        // POST: api/TipoCobro
        [HttpPost]
        public string Post([FromBody]TipoCobro value)
        {
            return gestorTipoCobro.Insertar(value);
        }
        // PUT: api/TipoCobro/5
        [HttpPut]
        public string Put([FromBody]TipoCobro value)
        {
            return gestorTipoCobro.Actualizar(value);
        }
        // DELETE: api/TipoCobro/5
        [HttpDelete]
        public string Delete(int id)
        {
            return gestorTipoCobro.Eliminar(id);
        }
    }
}
