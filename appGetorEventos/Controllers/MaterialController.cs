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
    public class MaterialController : ApiController
    {
        MaterialBO gestorMaterial = new MaterialBO();

        // GET: api/Material
        [HttpGet]
        public List<Material> Get()
        {
            var rpt= gestorMaterial.ListarMaterial();
            return rpt;
        }
        // GET: api/Material/5
        [HttpGet]
        public Material Get(int id)
        {
            return gestorMaterial.ListarMaterial(id);
        }
        // POST: api/Material
        [HttpPost]
        public string Post([FromBody]Material material)
        {
            var resp= gestorMaterial.IngresarMaterial(material);
            return resp;
        }
        // PUT: api/Material/5
        [HttpPut]
        public string Put([FromBody]Material value)
        {
            var rpt = gestorMaterial.ActualizarMaterial(value);
            return rpt;
        }
        // DELETE: api/Material/5
        [HttpDelete]
        public string Delete(int id)
        {
            var rpt=gestorMaterial.EliminarMaterial(id);
            return rpt;
        }
    }
}
