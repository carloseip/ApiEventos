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
    public class ClienteEmpresaController : ApiController
    {
        ClienteEmpresaBO gestorClienteEmpresa = new ClienteEmpresaBO();
        // GET: api/ClienteEmpresa
        [HttpGet]
        public IEnumerable<ClienteEmpresa> Get()
        {
            return gestorClienteEmpresa.ListarClienteEmpresa();
        }

        // GET: api/ClienteEmpresa/5
        [HttpGet]
        public ClienteEmpresa Get(string RUC)
        {
            return gestorClienteEmpresa.ListarClienteEmpresaRUC(RUC);
        }
        // POST: api/ClienteEmpresa
        [HttpPost]
        public string Post([FromBody]ClienteEmpresa value)
        {
            return gestorClienteEmpresa.IngresarClienteEmpresa(value);
        }
        // PUT: api/ClienteEmpresa
        [HttpPut]
        public string Put([FromBody]ClienteEmpresa value)
        {
            return gestorClienteEmpresa.ActualizarClienteEmpresa(value);
        }
        // DELETE: api/EliminarEmpresa/5
        [HttpPut]
        [Route("api/EliminarEmpresa")]
        public string Put(string RUC)
        {
            return gestorClienteEmpresa.EiminarClienteEmpresa(RUC);
        }
    }
}
