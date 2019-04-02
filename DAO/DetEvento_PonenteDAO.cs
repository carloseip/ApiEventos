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
    public class DetEvento_PonenteDAO
    {
        public static List<DetEvento_Ponente> Listar()
        {
            List<DetEvento_Ponente> lis = new List<DetEvento_Ponente>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<DetEvento_Ponente>("itData.SP_S_DetEventoPonente", dypa, commandType: CommandType.StoredProcedure).ToList();
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
        public static DetEvento_Ponente Listar(string DocIdentidad, int IdEvento)
        {
            DetEvento_Ponente lis = new DetEvento_Ponente();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@DocIdentidad", DocIdentidad);
                dypa.Add("@IdEvento", IdEvento);
                lis = cn.Query<DetEvento_Ponente>("itData.SP_S_ID_DetEventoPonente", dypa, commandType: CommandType.StoredProcedure).First();
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
        public static string Ingresar(DetEvento_Ponente value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@DocIdentidad", value.DocIdentidad);
                dp1.Add("@IdEvento", value.IdEvento);
                dp1.Add("@Costo", value.Costo);
                dp1.Add("@Comentario", value.Comentario);

                cn.Execute("itData.SP_I_DetEventoPonente", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Eliminar(string DocIdentidad, int IdEvento)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@DocIdentidad", DocIdentidad);
                dp1.Add("@IdEvento", IdEvento);
                cn.Execute("itData.SP_D_DetEventoPonente", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Actualizar(DetEvento_Ponente value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@DocIdentidad", value.DocIdentidad);
                dp1.Add("@IdEvento", value.IdEvento);
                dp1.Add("@Costo", value.Costo);
                dp1.Add("@Comentario", value.Comentario);

                cn.Execute("itData.SP_U_DetEventoPonente", dp1, commandType: CommandType.StoredProcedure);
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
        public static List<PonenteModelView> BuscarPonentes(int IdEvento)
        {
            string rpt = "ok";
            List<PonenteModelView> lis = new List<PonenteModelView>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdEvento", IdEvento);
                lis = cn.Query<PonenteModelView>("itData.SP_S_ID_Ponente", dp1, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e)
            {
                rpt = "Excepción ocurrida: " + e.Message;
                lis = null;
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
