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
    public class VentaDAO
    {
        public static List<CabVenta> Listar()
        {
            List<CabVenta> lis = new List<CabVenta>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<CabVenta>("itData.SP_S_VENTA", dypa, commandType: CommandType.StoredProcedure).ToList();
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

        public static List<Ventas> ListarVentas()
        {
            List<Ventas> lis = new List<Ventas>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<Ventas>("itdata.SP_S_VENTAS", dypa, commandType: CommandType.StoredProcedure).ToList();
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
        public static CabVenta Listar(int IdCabVenta)
        {
            CabVenta lis = new CabVenta();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdCabVenta", IdCabVenta);
                lis = cn.Query<CabVenta>("itData.SP_S_ID_VENTA", dypa, commandType: CommandType.StoredProcedure).First();
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

        public static string Ingresar(CabVenta value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            SqlTransaction trans = cn.BeginTransaction(IsolationLevel.Serializable);

            string num = Numero.getNumero("itdata.SP_S_VENTA");
            string fecha = DateTime.Now.ToString("dd/MM/yyyy");
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@TipoDoc", value.TipoDoc);
                dp1.Add("@SerieDoc", value.SerieDoc);
                dp1.Add("@NumeroDoc", num);
                dp1.Add("@Moneda", value.Moneda);
                dp1.Add("@PrecioTotal", value.PrecioTotal);
                dp1.Add("@Descuento", value.Descuento);
                dp1.Add("@ValVenta", value.ValVenta);
                dp1.Add("@IVA", value.IVA);
                dp1.Add("@Total", value.Total);
                dp1.Add("@Fecha", fecha);
                dp1.Add("@DNI", value.DNI);
                dp1.Add("@RUC", value.RUC);

                string IdVenta = cn.ExecuteScalar("itData.SP_I_VENTA", dp1, trans, commandType: CommandType.StoredProcedure).ToString();

                foreach (var item in value.DetVenta)
                {
                    DynamicParameters dp2 = new DynamicParameters();
                    dp2.Add("@IdCabVenta", int.Parse(IdVenta));
                    dp2.Add("@IdEvento", item.IdEvento);
                    dp2.Add("@Servicio", item.Servicio);
                    dp2.Add("@Cantidad", item.Cantidad);
                    dp2.Add("@Precio", item.Precio);
                    dp2.Add("@Descuento", item.Descuento);
                    dp2.Add("@ValTotal", item.ValTotal);
                    dp2.Add("@IVA", item.IVA);
                    dp2.Add("@Total", item.Total);

                    cn.Execute("itData.SP_I_DetVenta", dp2, trans, commandType: CommandType.StoredProcedure);
                }

                trans.Commit();
            }
            catch (Exception e)
            {
                rpt = "Excepción ocurrida: " + e.Message;
                trans.Rollback();
            }
            finally
            {
                trans.Dispose();
                cn.Close();
                cn.Dispose();
            }
            return rpt;
        }

        public static string Actualizar(CabVenta value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdCabVenta", value.IdCabVenta);
                dp1.Add("@TipoDoc", value.TipoDoc);
                dp1.Add("@SerieDoc", value.SerieDoc);
                dp1.Add("@NumeroDoc", value.NumeroDoc);
                dp1.Add("@Moneda", value.Moneda);
                dp1.Add("@PrecioTotal", value.PrecioTotal);
                dp1.Add("@Descuento", value.Descuento);
                dp1.Add("@ValVenta", value.ValVenta);
                dp1.Add("@IVA", value.IVA);
                dp1.Add("@Total", value.Total);
                dp1.Add("@DNI", value.DNI);
                dp1.Add("@RUC", value.RUC);

                cn.Execute("itData.SP_U_VENTA", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Eliminar(int IdCabVenta)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdCabVenta", IdCabVenta);
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
