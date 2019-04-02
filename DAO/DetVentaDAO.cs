using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using BE;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DetVentaDAO
    {
        public static List<DetVenta> Listar()
        {
            List<DetVenta> lis = new List<DetVenta>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<DetVenta>("itData.SP_S_DetVenta", dypa, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e)
            {
                lis = null;
                var rpt = "Excepción ocurrida: " + e.Message;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return lis;
        }
        public static DetVenta Listar(int IdCabVenta, int IdEvento)
        {
            DetVenta lis = new DetVenta();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdCabVenta", IdCabVenta);
                dypa.Add("@IdEvento", IdEvento);
                lis = cn.Query<DetVenta>("itData.SP_S_ID_DetVenta", dypa, commandType: CommandType.StoredProcedure).First();
            }
            catch (Exception e)
            {
                lis = null;
                var rpt = "Excepción ocurrida: " + e.Message;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return lis;
        }

        public static string Ingresar(DetVenta value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdCabVenta", value.IdCabVenta);
                dp1.Add("@IdEvento", value.IdEvento);
                dp1.Add("@Servicio", value.Servicio);
                dp1.Add("@Cantidad", value.Cantidad);
                dp1.Add("@Precio", value.Precio);
                dp1.Add("@Descuento", value.Descuento);
                dp1.Add("@ValTotal", value.ValTotal);
                dp1.Add("@IVA", value.IVA);
                dp1.Add("@Total", value.Total);

                cn.Execute("itData.SP_I_DetVenta", dp1, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                rpt = "Excepción ocurrida: " + e.Message;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return rpt;
        }
        public static string Actualizar(DetVenta value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdCabVenta", value.IdCabVenta);
                dp1.Add("@IdEvento", value.IdEvento);
                dp1.Add("@Servicio", value.Servicio);
                dp1.Add("@Cantidad", value.Cantidad);
                dp1.Add("@Precio", value.Precio);
                dp1.Add("@Descuento", value.Descuento);
                dp1.Add("@ValTotal", value.ValTotal);
                dp1.Add("@IVA", value.IVA);
                dp1.Add("@Total", value.Total);

                cn.Execute("itData.SP_U_DetVenta", dp1, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                rpt = "Excepción ocurrida: " + e.Message;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return rpt;
        }
        public static string Eliminar(int IdCabVenta,int IdEvento)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdCabVenta", IdCabVenta);
                dp1.Add("@IdEvento", IdEvento);

                cn.Execute("itData.SP_D_VENTA", dp1, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                rpt = "Excepción ocurrida: " + e.Message;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return rpt;
        }
    }
}
