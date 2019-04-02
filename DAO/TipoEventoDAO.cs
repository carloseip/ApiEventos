using System;
using System.Collections.Generic;
using System.Text;
using BE;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace DAO
{
    public class TipoEventoDAO
    {
        public static List<TipoEvento> Listar()
        {
            List<TipoEvento> lis = new List<TipoEvento>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<TipoEvento>("itData.SP_S_TipoEvento", dypa, commandType: CommandType.StoredProcedure).ToList();
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


        public static string Ingresar(TipoEvento value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@NomtipoEvento", value.TipEvento);
                dp1.Add("@Descripcion", value.Descripcion);
               
                
               cn.Execute("itData.SP_I_TipoEvento", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Actualizar(TipoEvento value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdTipoEvento", value.IdTipoEvento);
                dp1.Add("@NomtipoEvento", value.TipEvento);
                dp1.Add("@Descripcion", value.Descripcion);


                 cn.Execute("itData.SP_U_TipoEvento", dp1, commandType: CommandType.StoredProcedure);
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


        public static TipoEvento BuscarEvento(int id)
        {
            TipoEvento lis = new TipoEvento();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdTipoEvento", id);
                lis = cn.Query<TipoEvento>("itData.SP_S_ID_TipoEvento", dypa, commandType: CommandType.StoredProcedure).First();
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


        public static string Eliminar(int id)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdTipoEvento", id);


               cn.Execute("itData.SP_D_TipoEvento", dp1, commandType: CommandType.StoredProcedure);
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
