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
    public class DistritoDAO
    {
        public static List<Distrito> Listar()
        {
            List<Distrito> lis = new List<Distrito>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<Distrito>("itData.SP_S_DISTRITOS", dypa, commandType: CommandType.StoredProcedure).ToList();
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
        public static List<Distrito> Listar(string NombreDistrito)
        {
            List<Distrito> lis = new List<Distrito>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@Nombre", NombreDistrito);
                lis = cn.Query<Distrito>("itData.SP_S_NOM_DISTRITOS", dypa, commandType: CommandType.StoredProcedure).ToList();
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
