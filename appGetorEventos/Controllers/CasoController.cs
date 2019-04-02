using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BE;
using BO;

namespace appGetorEventos.Controllers
{
    [EnableCors("*", "*", "*")]
    //  [Authorize]
    public class CasoController : ApiController
    {
        CasoBO gestorCaso = new CasoBO();

        // GET: api/Caso
        [HttpGet]
        public List<Caso> Get()
        {
            var list = gestorCaso.ListarCasosDeUso();
            return list;
        }
    }
}
