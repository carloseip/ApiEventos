using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BO
{
    public class CarteraCobroBO
    {
        public List<CarteraCobro> ListarCarteraCobro()
        {
            return CarteraCobroDAO.Listar();
        }
        public CarteraCobro ListarCarteraCobro(int IdCarteraCobro)
        {
            return CarteraCobroDAO.ListarPorIdCartera(IdCarteraCobro);
        }
        public CarteraCobro ListarCarteraCobroVenta(int IdCabVenta)
        {
            return CarteraCobroDAO.ListarPorIdCab(IdCabVenta);
        }
        public CarteraCobro ListarCarteraCobro(int IdCabVenta, int IdEvento)
        {
            return CarteraCobroDAO.Listar(IdCabVenta, IdEvento);
        }
        public string IngresarCarteraCobro(CarteraCobro value)
        {
            return CarteraCobroDAO.Ingresar(value);
        }
        public string EiminarCarteraCobro(int IdCarteraCobro)
        {
            return CarteraCobroDAO.Eliminar(IdCarteraCobro);
        }
        public string ActualizarCarteraCobro(CarteraCobro value)
        {
            return CarteraCobroDAO.Actualizar(value);
        }
    }
}
