using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using BE;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAO
{
    public class DetEvento_EncargadoDAO
    {
        public static List<DetEvento_EncargadoModelView> Listar()
        {
            List<DetEvento_EncargadoModelView> lis = new List<DetEvento_EncargadoModelView>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<DetEvento_EncargadoModelView>("itData.SP_S_DetEvento_Encargado", dypa, commandType: CommandType.StoredProcedure).ToList();
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
        public static DetEvento_EncargadoModelView BuscarEncargado(int IdLocal)
        {
            DetEvento_EncargadoModelView lis = new DetEvento_EncargadoModelView();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdEvento", IdLocal);
                lis = cn.Query<DetEvento_EncargadoModelView>("itData.SP_S_ID_DetEvento_Encargado", dypa, commandType: CommandType.StoredProcedure).First();
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
     
        public static string Ingresar(DetEvento_Encargado value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdEvento", value.IdEvento);
                dp1.Add("@DNI", value.DNI);
                dp1.Add("@Confirmacion", value.Confirmacion);
               
                cn.Execute("itData.SP_I_DetEvento_Encargado", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Actualizar(DetEvento_Encargado value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdEvento", value.IdEvento);
                dp1.Add("@DNI", value.DNI);
                dp1.Add("@Confirmacion", value.Confirmacion);
                cn.Execute("itData.SP_U_DetEvento_Encargado", dp1, commandType: CommandType.StoredProcedure);
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
        public static EncargadoModelView Encargado(int idevento)
        {
            EncargadoModelView lis = new EncargadoModelView();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdEvento", idevento);
                lis = cn.Query<EncargadoModelView>("itData.SP_S_ID_Encargado", dypa, commandType: CommandType.StoredProcedure).First();
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
        public static string Eliminar(int IdEvento, string dni)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdEvento", IdEvento);
                dp1.Add("@DNI", dni);
                cn.Execute("itData.SP_D_DetEvento_Encargado", dp1, commandType: CommandType.StoredProcedure);
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
