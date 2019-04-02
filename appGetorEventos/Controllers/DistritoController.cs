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
    public class DistritoController : ApiController
    {
        DistritoBO gestorDistrito = new DistritoBO();

        // GET: api/Distrito
        [HttpGet]
        public IEnumerable<Distrito> Get()
        {
            return gestorDistrito.ListarDistritos();
        }
        // GET: api/Distrito/nombre
        [HttpGet]
        public IEnumerable<Distrito> Get(string nombre)
        {
            return gestorDistrito.ListarDistritos(nombre);
        }
    }
}
