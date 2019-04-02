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
    public class LoginRequestDAO
    {
        public static LoginRequest Listar(string Usuario,string Password)
        {
            LoginRequest lis = new LoginRequest();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
            //    DynamicParameters dypa = new DynamicParameters();
            //    dypa.Add("@DocIdentidad", DocIdentidad);
            //    dypa.Add("@IdEvento", IdEvento);
            //    lis = cn.Query<DetEvento_Ponente>("itData.SP_S_ID_DetEventoPonente", dypa, commandType: CommandType.StoredProcedure).First();
            }
            catch (Exception)
            {
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
