using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DAO
{
    public class Det_Evento_ServicioDAO
    {
        public static List<Servicio> BuscarDetEvento_Servicio(int idevento)
        {

            List<Servicio> lis = new List<Servicio>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdEvento", idevento);
                lis = cn.Query<Servicio>("itData.SP_S_ID_Servicios", dypa, commandType: CommandType.StoredProcedure).ToList();
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
        public static string Ingresar(Det_Evento_Servicio value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdEvento", value.IdEvento);
                dp1.Add("@IdServicio", value.IdServicio);
                dp1.Add("@Descripcion", value.Descripcion);

                cn.Execute("itData.SP_I_DETEVENTO_SERVICIOS", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Eliminar(int IdEvento, int idservicio)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdEvento", IdEvento);
                dp1.Add("@IdServicio", idservicio);
                cn.Execute("itData.SP_D_DetEvento_Servicio", dp1, commandType: CommandType.StoredProcedure);
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
