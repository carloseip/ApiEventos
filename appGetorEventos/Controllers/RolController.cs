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
    public class RolController : ApiController
    {
        RolBO gestorRol = new RolBO();

        // GET: api/Rol
        [HttpGet]
        public List<Rol> Get()
        {
            var list = gestorRol.ListarRol();
            return list;
        }
    }
}
