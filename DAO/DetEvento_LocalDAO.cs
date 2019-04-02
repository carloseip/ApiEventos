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
    public class DetEvento_LocalDAO
    {
        public static List<DetEvento_Local> Listar()
        {
            List<DetEvento_Local> lis = new List<DetEvento_Local>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<DetEvento_Local>("itData.SP_S_DetEVENTO_LOCAL", dypa, commandType: CommandType.StoredProcedure).ToList();
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
        public static DetEvento_Local Listar(int IdEvento, int IdLocal)
        {
            DetEvento_Local lis = new DetEvento_Local();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdLocal", IdLocal);
                dypa.Add("@IdEvento", IdEvento);
                lis = cn.Query<DetEvento_Local>("itData.SP_S_ID_DetEVENTO_LOCAL", dypa, commandType: CommandType.StoredProcedure).First();
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
        public static string Ingresar(DetEvento_Local value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdLocal", value.IdLocal);
                dp1.Add("@IdEvento", value.IdEvento);
                dp1.Add("@FechaIni", value.FechaIni);
                dp1.Add("@FechaFin", value.FechaFin);
                dp1.Add("@Costo", value.Costo );
                dp1.Add("@Comentario", value.Comentario);

                cn.Execute("itData.SP_I_DetEVENTO_LOCAL", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Eliminar(int IdEvento, int IdLocal)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdLocal", IdLocal);
                dp1.Add("@IdEvento", IdEvento);
                cn.Execute("itData.SP_D_DetEVENTO_LOCAL", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Actualizar(DetEvento_Local value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdLocal", value.IdLocal );
                dp1.Add("@IdEvento",value.IdEvento );
                dp1.Add("@FechaIni", value.FechaIni);
                dp1.Add("@FechaFin", value.FechaFin);
                dp1.Add("@Costo", value.Costo );
                dp1.Add("@Comentario", value.Comentario);

                cn.Execute("itData.SP_U_DetEVENTO_LOCAL", dp1, commandType: CommandType.StoredProcedure);
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
        public static LocalModelView GetLocal(int IdEvento)
        {
            LocalModelView lis = new LocalModelView();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdEvento", IdEvento);
                lis = cn.Query<LocalModelView>("itData.SP_S_IDEvento_Local", dypa, commandType: CommandType.StoredProcedure).First();
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
    }
}

