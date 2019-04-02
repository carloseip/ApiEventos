using BE;
using DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class DetEvento_MaterialBO
    {
        public List<DetEvento_Material> ListarDetEvento_Material()
        {
            return DetEvento_MaterialDAO.Listar();
        }
        public DetEvento_Material ListarDetEvento_Material(int IdEvento, int IdMaterial)
        {
            return DetEvento_MaterialDAO.Listar(IdEvento, IdMaterial);
        }
        public string IngresarDetEvento_Material(DetEvento_Material mat)
        {
            return DetEvento_MaterialDAO.Ingresar(mat);
        }
        public string EliminarDetEvento_Material(int IdEvento, int IdMaterial)
        {
            return DetEvento_MaterialDAO.Eliminar(IdEvento, IdMaterial);
        }
        public string ActualizarDetEvento_Material(DetEvento_Material mat)
        {
            return DetEvento_MaterialDAO.Actualizar(mat);
        }
        public List<MaterialModelView> BuscarMateriales(int IdEvento)
        {
            return DetEvento_MaterialDAO.BuscarMateriales(IdEvento);
        }
    }
}
