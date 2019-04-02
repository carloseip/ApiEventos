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
    public class CarteraCobroDAO
    {
        public static List<CarteraCobro> Listar()
        {
            List<CarteraCobro> lis = new List<CarteraCobro>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<CarteraCobro>("itData.SP_S_CARTERACOBRO", dypa, commandType: CommandType.StoredProcedure).ToList();
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
        public static CarteraCobro ListarPorIdCartera(int IdCarteraCobro)
        {
            CarteraCobro lis = new CarteraCobro();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdCarteraCobro", IdCarteraCobro);
                lis = cn.Query<CarteraCobro>("itData.SP_S_ID_CARTERACOBRO", dypa, commandType: CommandType.StoredProcedure).First();
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
        public static CarteraCobro ListarPorIdCab(int IdCabVenta)
        {
            CarteraCobro lis = new CarteraCobro();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdCabVenta", @IdCabVenta);
                lis = cn.Query<CarteraCobro>("itData.SP_S_IDCab_CARTERACOBRO", dypa, commandType: CommandType.StoredProcedure).First();
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
        public static CarteraCobro Listar(int IdCabVenta, int IdEvento)
        {
            CarteraCobro lis = new CarteraCobro();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdCabVenta", IdCabVenta);
                dypa.Add("@IdEvento", IdEvento);

                lis = cn.Query<CarteraCobro>("itData.SP_S_IDS_CARTERACOBRO", dypa, commandType: CommandType.StoredProcedure).First();
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

        public static string Ingresar(CarteraCobro value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdCarteraCobro", value.IdCarteraCobro);
                dp1.Add("@TipoDoc", value.TipoDoc);
                dp1.Add("@SerieDoc", value.SerieDoc);
                dp1.Add("@NumeroDoc", value.NumeroDoc);
                dp1.Add("@Moneda", value.Moneda);
                dp1.Add("@MontoOriginal", value.MontoOriginal);
                dp1.Add("@MontoPagado", value.MontoPagado);
                dp1.Add("@TipoCartera", value.TipoCartera);
                dp1.Add("@IdCabVenta", value.IdCabVenta);
                dp1.Add("@IdEvento", value.IdEvento);

                cn.Execute("itData.SP_I_CARTERACOBRO", dp1, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                rpt = "Excepción ocurrida: "+ e.Message;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return rpt;
        }
        public static string Actualizar(CarteraCobro value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdCarteraCobro", value.IdCarteraCobro);
                dp1.Add("@TipoDoc", value.TipoDoc);
                dp1.Add("@SerieDoc", value.SerieDoc);
                dp1.Add("@NumeroDoc", value.NumeroDoc);
                dp1.Add("@Moneda", value.Moneda);
                dp1.Add("@MontoOriginal", value.MontoOriginal);
                dp1.Add("@MontoPagado", value.MontoPagado);
                dp1.Add("@TipoCartera", value.TipoCartera);
                dp1.Add("@IdCabVenta", value.IdCabVenta);
                dp1.Add("@IdEvento", value.IdEvento);

                cn.Execute("itData.SP_U_CARTERACOBRO", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Eliminar(int IdCarteraCobro)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdCarteraCobro", IdCarteraCobro);
                cn.Execute("itData.SP_D_CARTERACOBRO", dp1, commandType: CommandType.StoredProcedure);
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
