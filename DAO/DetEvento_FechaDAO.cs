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
    public class DetEvento_FechaDAO
    {
        public static List<DetEvento_Fecha> Listar()
        {
            List<DetEvento_Fecha> lis = new List<DetEvento_Fecha>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<DetEvento_Fecha>("itData.SP_S_DetEvento_Fecha", dypa, commandType: CommandType.StoredProcedure).ToList();
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
        public static List<DetEvento_Fecha> Listar(int IdEvento)
        {
            List<DetEvento_Fecha> lis = new List<DetEvento_Fecha>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdEvento", IdEvento);
                lis = cn.Query<DetEvento_Fecha>("itData.SP_S_ID_DetEvento_Fecha", dypa, commandType: CommandType.StoredProcedure).ToList();
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
        public static string Ingresar(DetEvento_Fecha value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdEvento", value.IdEvento);
                dp1.Add("@Fecha", value.Fecha);
                dp1.Add("@HoraEvento", value.HoraEvento);
                dp1.Add("@Comentario", value.Comentario);

                cn.Execute("itData.SP_I_DetEvento_Fecha", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Eliminar(int IdEvento, DateTime Fecha)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdEvento", IdEvento);
                dp1.Add("@Fecha", Fecha);
            
                cn.Execute("itData.SP_D_DetEvento_Fecha", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Actualizar(DetEvento_Fecha value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdEvento", value.IdEvento);
                dp1.Add("@Fecha", value.Fecha);
                dp1.Add("@HoraEvento", value.HoraEvento);
                dp1.Add("@Comentario", value.Comentario);

                cn.Execute("itData.SP_U_DetEvento_Fecha", dp1, commandType: CommandType.StoredProcedure);
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
