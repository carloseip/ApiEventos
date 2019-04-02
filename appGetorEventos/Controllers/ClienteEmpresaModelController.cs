using BE;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace appGetorEventos.Controllers
{

    [EnableCors("*", "*", "*")]
    public class ClienteEmpresaModelController : ApiController
    {
        ClienteEmpresaModelBO negocioEmpresaModel = new ClienteEmpresaModelBO();
        // GET: api/ClienteEmpresaModel
        public IEnumerable<ClienteEmpresaModel> Get()
        {
            return negocioEmpresaModel.ListarClienteEmpresa();
        }

        // GET: api/ClienteEmpresaModel/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ClienteEmpresaModel
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ClienteEmpresaModel/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ClienteEmpresaModel/5
        public void Delete(int id)
        {
        }
    }
}
