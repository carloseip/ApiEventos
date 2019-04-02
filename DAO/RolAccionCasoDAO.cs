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
    public class RolAccionCasoDAO
    {
        public static string Ingresar(RolAccionCaso value)
        {
            string rpt = "ok";
            int IdRol;
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            SqlTransaction tran = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@Nombre", value.Nombre);
                dp1.Add("@Siglas", value.Siglas);
                IdRol = int.Parse(cn.ExecuteScalar("itLogin.SP_I_ROL", dp1, tran, commandType: CommandType.StoredProcedure).ToString());

                foreach (var item in value.listaCasoAccion)
                {
                    DynamicParameters dypa4 = new DynamicParameters();
                    dypa4.Add("@IdRol", IdRol);
                    dypa4.Add("@NomCaso", item.Mantenimiento);
                    dypa4.Add("@NomAccion", item.Accion);
            
                    cn.Execute("itLogin.SP_I_AccionCasoRol", dypa4, tran, commandType: CommandType.StoredProcedure);

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
