using BE;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ClienteEmpresaModelDAO
    {
        public static List<ClienteEmpresaModel> Listar()
        {
            List<ClienteEmpresaModel> lis = new List<ClienteEmpresaModel>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<ClienteEmpresaModel>("itData.SP_SM_CLIENTEEMPRESA", dypa, commandType: CommandType.StoredProcedure).ToList();
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
