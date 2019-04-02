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
    public static class EventoDAO
    {
        public static List<CabEvento> Listar()
        {
            List<CabEvento> lis = new List<CabEvento>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<CabEvento>("itData.SP_S_EVENTO", dypa, commandType: CommandType.StoredProcedure).ToList();
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
        public static CabEvento Listar(int IdEvento)
        {
            CabEvento lis = new CabEvento();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdEvento", IdEvento);
                lis = cn.Query<CabEvento>("itData.SP_S_ID_EVENTO", dypa, commandType: CommandType.StoredProcedure).First();
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
        public static CabEvento Listar(string Nombre)
        {
            CabEvento lis = new CabEvento();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@Nombre", Nombre);
                lis = cn.Query<CabEvento>("itData.SP_S_NOM_EVENTO", dypa, commandType: CommandType.StoredProcedure).First();
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
        public static string Eliminar(int Id)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdEvento", Id);
                cn.Execute("itData.SP_D_EVENTO", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Actualizar(Eventos value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            SqlTransaction tran = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdEvento", value.IdEvento);
                dp1.Add("@IdTipoEvento", value.IdTipoEvento);
                dp1.Add("@NombreEvento", value.Nombre);
                dp1.Add("@Descripcion", value.Descripcion);
                cn.Execute("itData.SP_U_Eventos", dp1, tran, commandType: CommandType.StoredProcedure);

                foreach (var item in value.DetalleEvento)
                {
                    if (item.IdEvento == 0) { 
                    DynamicParameters dypa4 = new DynamicParameters();
                    dypa4.Add("@IdEvento", value.IdEvento);
                    dypa4.Add("@Fecha", item.Fecha);
                    dypa4.Add("@HoraEvento", item.HoraEvento);
                    dypa4.Add("@Comentario", item.Comentario);


                    cn.Execute("itData.SP_I_DetEventosFechas", dypa4, tran, commandType: CommandType.StoredProcedure);
                    }
                }
                tran.Commit();
            }
            catch (Exception e)
            {
                rpt = "Excepción ocurrida: " + e.Message;
                tran.Rollback();
            }
            finally
            {
                tran.Dispose();
                cn.Close();
                cn.Dispose();
            }
            return rpt;
        }
        public static string Ingresar(Eventos value)
        {
            string rpt = "ok";
   
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            SqlTransaction tran = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdTipoEvento", value.IdTipoEvento);
                dp1.Add("@NombreEvento", value.Nombre);
                dp1.Add("@Descripcion", value.Descripcion);
                string idevento =cn.ExecuteScalar("itData.SP_I_Eventos", dp1, tran, commandType: CommandType.StoredProcedure).ToString();

                foreach (var item in value.DetalleEvento)
                {
                    DynamicParameters dypa4 = new DynamicParameters();
                    dypa4.Add("@IdEvento", int.Parse(idevento));
                    dypa4.Add("@Fecha", item.Fecha);
                    dypa4.Add("@HoraEvento", item.HoraEvento);
                    dypa4.Add("@Comentario", item.Comentario);

                    cn.Execute("itData.SP_I_DetEventosFechas", dypa4, tran, commandType: CommandType.StoredProcedure);
                }
                tran.Commit();

            }
            catch (Exception e)
            {
                rpt = "Excepción ocurrida: " + e.Message;
                tran.Rollback();
            }
            finally
            {
                tran.Dispose();
                cn.Close();
                cn.Dispose();
            }
            return rpt;
        }
    }
}
