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
    public class DetEvento_EncargadoController : ApiController
    {
        private DetEvento_EncargadoBO gestorDetEvento_Encargado = new DetEvento_EncargadoBO();

        // GET: api/DetEvento_Encargado
        [Route("api/EncargadosAsistencia")]
        public IEnumerable<DetEvento_EncargadoModelView> Get()
        {
            return gestorDetEvento_Encargado.Listar();
        }

        // GET: api/DetEvento_Encargado/5
        [Route("api/ObtenerEncargado")]
        public EncargadoModelView Get(int id)
        {
            return gestorDetEvento_Encargado.Encargado(id);
        }


        // POST: api/DetEvento_Encargado
        [Route("api/AsignarEncargado")]
        public string Post([FromBody]DetEvento_Encargado value)
        {
            return gestorDetEvento_Encargado.Insertar(value);

        }

        // PUT: api/DetEvento_Encargado/5
        [Route("api/ActualizarAsistenciaEncargado")]
        public string Put([FromBody]DetEvento_Encargado value)
        {

            return gestorDetEvento_Encargado.Actualizar(value);
        }

        // DELETE: api/DetEvento_Encargado/5
        [HttpDelete]
        [Route("api/EliminarEncargado")]
        public string Delete(int IdEvento, string dni)
        {
            return gestorDetEvento_Encargado.EiminarDetEvento_Encargado(IdEvento, dni);
        }
    }
}
