using BE;
using DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class MaterialBO
    {
        public List<Material> ListarMaterial()
        {
            return MaterialDAO.Listar();
        }
        public Material ListarMaterial(int IdMaterial)
        {
            return MaterialDAO.Listar(IdMaterial);
        }
        public string IngresarMaterial(Material mat)
        {
            return MaterialDAO.Ingresar(mat);
        }
        public string EliminarMaterial(int Id)
        {
            return MaterialDAO.Eliminar(Id);
        }
        public string ActualizarMaterial(Material mat)
        {
            return MaterialDAO.Actualizar(mat);
        }
    }
}
