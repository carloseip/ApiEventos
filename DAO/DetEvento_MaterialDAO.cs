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
    public class DetEvento_MaterialDAO
    {
        public static List<DetEvento_Material> Listar()
        {
            List<DetEvento_Material> lis = new List<DetEvento_Material>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<DetEvento_Material>("itData.SP_S_DetEvento_Material", dypa, commandType: CommandType.StoredProcedure).ToList();
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
        public static DetEvento_Material Listar(int IdEvento, int IdMaterial)
        {
            DetEvento_Material lis = new DetEvento_Material();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdEvento", IdEvento);
                dypa.Add("@IdMaterial", IdMaterial);

                lis = cn.Query<DetEvento_Material>("itData.SP_S_ID_DetEvento_Material", dypa, commandType: CommandType.StoredProcedure).First();
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
        public static string Ingresar(DetEvento_Material mat)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdEvento", mat.IdEvento);
                dp1.Add("@IdMaterial", mat.IdMaterial);
                dp1.Add("@CostoUnitario", mat.CostoUnitario);
                dp1.Add("@Cantidad", mat.Cantidad);

                cn.Execute("itData.SP_I_DetEvento_Material", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Eliminar(int IdEvento, int IdMaterial)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdEvento", IdEvento);
                dp1.Add("@IdMaterial", IdMaterial);

                cn.Execute("itData.SP_D_DetEvento_Material", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Actualizar(DetEvento_Material mat)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdEvento", mat.IdEvento);
                dp1.Add("@IdMaterial", mat.IdMaterial);
                dp1.Add("@CostoUnitario", mat.CostoUnitario);
                dp1.Add("@Cantidad", mat.Cantidad);

                cn.Execute("itData.SP_U_DetEvento_Material", dp1, commandType: CommandType.StoredProcedure);
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
        public static List<MaterialModelView> BuscarMateriales(int IdEvento)
        {
            List<MaterialModelView> lis = new List<MaterialModelView>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdEvento", IdEvento);
                lis = cn.Query<MaterialModelView>("itData.SP_S_ID_Materiales", dypa, commandType: CommandType.StoredProcedure).ToList();
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
    }
}
