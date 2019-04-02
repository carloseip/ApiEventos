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
    public class AccionDAO
    {
        public static List<Accion> Listar()
        {
            List<Accion> lis = new List<Accion>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<Accion>("itLogin.SP_S_ACCION", dypa, commandType: CommandType.StoredProcedure).ToList();
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
