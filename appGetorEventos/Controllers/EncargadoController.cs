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
    public class EncargadoController : ApiController
    {
        EncargadoBO gestorEncargado = new EncargadoBO();

        // GET: api/Encargado
        [HttpGet]
        public IEnumerable<Encargado> Get()
        {
            return gestorEncargado.ListarEncargados();
        }
        // GET: api/Encargado/5
        [HttpGet]
        public Encargado Get(string DNI)
        {
            return gestorEncargado.ListarEncargadosDNI(DNI);
        }
        // POST: api/Encargado
        [HttpPost]
        public string Post([FromBody]Encargado value, string nombre)
        {
            return gestorEncargado.IngresarEncargado(value, nombre);
        }
        // PUT: api/Encargado/5
        [HttpPut]
        public string Put([FromBody]Encargado value,string nombre)
        {
            return gestorEncargado.ActualizarEncargado(value, nombre);
        }
        // DELETE: api/Encargado/5
        [HttpDelete]
        public string Delete(string DNI)
        {
            return gestorEncargado.EiminarEncargado(DNI);
        }
    }
}
