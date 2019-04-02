using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BO
{
    public class DetVentaBO
    {
        public List<DetVenta> ListarDetVenta()
        {
            return DetVentaDAO.Listar();
        }
        public DetVenta ListarDetVenta(int IdCabVenta, int IdEvento)
        {
            return DetVentaDAO.Listar(IdCabVenta, IdEvento);
        }
        public string IngresarDetVenta(DetVenta value)
        {
            return DetVentaDAO.Ingresar(value);
        }
        public string ActualizarDetVenta(DetVenta value)
        {
            return DetVentaDAO.Actualizar(value);
        }
        public string EliminarDetVenta(int IdCabVenta, int IdEvento)
        {
            return DetVentaDAO.Eliminar(IdCabVenta,IdEvento);
        }
    }
}
