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
    public class DetEvento_MaterialController : ApiController
    {
        DetEvento_MaterialBO gestorDetEvento_Material = new DetEvento_MaterialBO();

        // GET: api/DetEvento_Material
        [HttpGet]
        public List<DetEvento_Material> Get()
        {
            var rpt = gestorDetEvento_Material.ListarDetEvento_Material();
            return rpt;
        }
        [HttpGet]
        public List<MaterialModelView> BuscarMateriales(int IdEvento)
        {
            var rpt = gestorDetEvento_Material.BuscarMateriales(IdEvento);
            return rpt;
        }
        // GET: api/DetEvento_Material/5/4
        [HttpGet]
        public DetEvento_Material Get(int IdEvento, int IdMaterial)
        {
            return gestorDetEvento_Material.ListarDetEvento_Material(IdEvento, IdMaterial);
        }
        // POST: api/DetEvento_Material
        [HttpPost]
        public string Post([FromBody]DetEvento_Material material)
        {
            var resp = gestorDetEvento_Material.IngresarDetEvento_Material(material);
            return resp;
        }

        // PUT: api/DetEvento_Material
        [HttpPut]
        public string Put([FromBody]DetEvento_Material value)
        {
            var rpt = gestorDetEvento_Material.ActualizarDetEvento_Material(value);
            return rpt;
        }

        // DELETE: api/DetEvento_Material/5/4
        [HttpDelete]
        public string Delete(int IdEvento, int IdMaterial)
        {
            var rpt = gestorDetEvento_Material.EliminarDetEvento_Material(IdEvento, IdMaterial);
            return rpt;
        }
    }
}
