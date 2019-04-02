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
    public class DetAsistenciaDAO
    {
        public static List<DetAsistencia> Listar()
        {
            List<DetAsistencia> lis = new List<DetAsistencia>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<DetAsistencia>("itData.SP_S_DetAsistencia", dypa, commandType: CommandType.StoredProcedure).ToList();
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
        public static DetAsistencia Listar(string DNI, int IdEvento)
        {
            DetAsistencia lis = new DetAsistencia();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@DNI", DNI);
                dypa.Add("@IdEvento", IdEvento);
                lis = cn.Query<DetAsistencia>("itData.SP_S_ID_DetAsistencia", dypa, commandType: CommandType.StoredProcedure).First();
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
        public static string Ingresar(DetAsistencia value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@DNI", value.DNI);
                dp1.Add("@IdEvento", value.IdEvento);
                dp1.Add("@Fecha", value.Fecha);
                dp1.Add("@HoraLlegada", value.HoraLlegada);

                cn.Execute("itData.SP_I_DetAsistencia", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Eliminar(string DNI, int IdEvento)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@DNI", DNI);
                dp1.Add("@IdEvento", IdEvento);
                cn.Execute("itData.SP_D_DetAsistencia", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Actualizar(DetAsistencia value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@DNI", value.DNI);
                dp1.Add("@IdEvento", value.IdEvento);
                dp1.Add("@Fecha", value.Fecha);
                dp1.Add("@HoraLlegada", value.HoraLlegada);

                cn.Execute("itData.SP_U_DetAsistencia", dp1, commandType: CommandType.StoredProcedure);
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
