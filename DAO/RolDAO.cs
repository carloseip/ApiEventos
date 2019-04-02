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
    public class RolDAO
    {
        public static List<Rol> Listar()
        {
            List<Rol> lis = new List<Rol>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<Rol>("itLogin.SP_S_ROL", dypa, commandType: CommandType.StoredProcedure).ToList();
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
