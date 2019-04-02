using BE;
using DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class VentaBO
    {
        public List<CabVenta> ListarVentas()
        {
            return VentaDAO.Listar();
        }
        public List<Ventas> ListarVentasModel()
        {
            return VentaDAO.ListarVentas();
        }
        public CabVenta ListarVentas(int IdCabVenta)
        {
            return VentaDAO.Listar(IdCabVenta);
        }
        public string IngresarVenta(CabVenta value)
        {
            return VentaDAO.Ingresar(value);
        }
        public string EliminarVenta(int IdCabVenta)
        {
            return VentaDAO.Eliminar(IdCabVenta);
        }
        public string ActualizarVenta(CabVenta value)
        {
            return VentaDAO.Actualizar(value);
        }
    }
}
