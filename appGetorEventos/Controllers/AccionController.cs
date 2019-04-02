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
    public class AccionController : ApiController
    {
        AccionBO gestorAccion = new AccionBO();

        // GET: api/Caso
        [HttpGet]
        public List<Accion> Get()
        {
            var list = gestorAccion.ListarAccion();
            return list;
        }
    }
}
