using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BO;
using BE;
using System.Web.Http.Cors;

namespace appGetorEventos.Controllers
{
    [EnableCors("*", "*", "*")]
 //   [Authorize]
    public class InicioController : ApiController
    {
        InicioBO gestorInicio = new InicioBO();

        // GET: api/Inicio
        [HttpGet]
        public IEnumerable<Inicio> Get()
        {
            return gestorInicio.Listar();
        }
    }
}
