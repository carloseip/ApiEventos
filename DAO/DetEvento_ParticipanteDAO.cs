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
    public class DetEvento_ParticipanteDAO
    {

        public static List<DetEvento_ParticipanteModelView> Listar()
        {
            List<DetEvento_ParticipanteModelView> lis = new List<DetEvento_ParticipanteModelView>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<DetEvento_ParticipanteModelView>("itData.SP_S_DetEvento_Participante", dypa, commandType: CommandType.StoredProcedure).ToList();
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
        public static List<DetEvento_ParticipanteModelView> BuscarParticipantes(int IdLocal)
        {

            List<DetEvento_ParticipanteModelView> lis = new List<DetEvento_ParticipanteModelView>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdEvento", IdLocal);
                lis = cn.Query<DetEvento_ParticipanteModelView>("itData.SP_S_ID_DetEvento_Participante", dypa, commandType: CommandType.StoredProcedure).ToList();
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

        public static string Ingresar(DetEvento_Participante value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdEvento", value.IdEvento);
                dp1.Add("@DNI", value.DNI);
                dp1.Add("@Confirmacion", value.Confirmacion);

                cn.Execute("itData.SP_I_DetEvento_Participante", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Actualizar(DetEvento_Participante value)
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
                cn.Execute("itData.SP_U_DetEvento_Participante", dp1, commandType: CommandType.StoredProcedure);
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
