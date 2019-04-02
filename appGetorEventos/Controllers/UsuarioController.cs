using System;
using System.Collections.Generic;
using System.Web.Http;
using BO;
using BE;
using System.Web.Http.Cors;

namespace appGetorEventos.Controllers
{
    [EnableCors("*", "*", "*")]
    public class UsuarioController : ApiController
    {
        RolAccionCasoBO gestorRolAccionCaso = new RolAccionCasoBO();
        UsuarioBO gestorUsuario = new UsuarioBO();
        // POST: api/Usuario
        [HttpPost]
        public string Post([FromBody]RolAccionCaso value)
        {
            return gestorRolAccionCaso.IngresarRolAccionCaso(value);
        }
        [Route("api/ingresarUser")]
        [HttpPost]
        public string Post([FromBody]Usuario usuario)
        {
            return gestorUsuario.IngresarUsuario(usuario);
        }
        // GET: api/Usuario
        [HttpGet]
        public IEnumerable<UsuarioModel> Get()
        {
            return gestorUsuario.Listar();
        }
        // DELETE: api/Usuario/5
        [HttpDelete]
        public string Delete(int IdUsuario)
        {
            return gestorUsuario.EliminarUsuario(IdUsuario);
        }
        // GET: api/buscarUsuario/4
        [HttpGet]
        public UsuarioModelActualizar Get(int IdUsuario)
        {
            return gestorUsuario.ListarUsuario(IdUsuario);
        }
        // PUT: api/Usuario
        [HttpPut]
        public string Put([FromBody]UsuarioModelActualizar value)
        {
            var rpt = gestorUsuario.ActualizarUsuario(value);
            return rpt;
        }

    }
}
