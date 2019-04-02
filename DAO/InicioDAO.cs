using System;
using System.Collections.Generic;
using System.Text;
using BE;
using System.Data;
using System.Data.SqlClient;
using Dapper;


namespace DAO
{
    public class InicioDAO
    {
        public static IEnumerable<Inicio> Listar()
        {
            IEnumerable<Inicio> lis = new List<Inicio>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<Inicio>("itData.SP_S_INICIO", dypa, commandType: CommandType.StoredProcedure);
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
