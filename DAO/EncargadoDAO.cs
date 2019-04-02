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
    public class EncargadoDAO
    {
        public static List<Encargado> Listar()
        {
            List<Encargado> lis = new List<Encargado>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<Encargado>("itData.SP_S_ENCARGADO", dypa, commandType: CommandType.StoredProcedure).ToList();
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
        public static Encargado Listar(string DNI)
        {
            Encargado lis = new Encargado();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@DNI", DNI);
                lis = cn.Query<Encargado>("itData.SP_S_DNI_ENCARGADO", dypa, commandType: CommandType.StoredProcedure).First();
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
      
        public static string Ingresar(Encargado value, string nombreDistrito)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@DNI", value.DNI);
                dp1.Add("@Nombre", value.Nombre);
                dp1.Add("@ApellidoP", value.ApellidoP);
                dp1.Add("@ApellidoM", value.ApellidoM);
                dp1.Add("@Direccion", value.Direccion);
                dp1.Add("@Email", value.Email);
                dp1.Add("@FechaNac", value.FechaNac);
                dp1.Add("@Sexo", value.Sexo);
                dp1.Add("@Telefono", value.Telefono);
                dp1.Add("@NomDistrito",nombreDistrito);
                cn.Execute("itData.SP_I_ENCARGADO", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Actualizar(Encargado value,string nombreDistrito)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@DNI", value.DNI);
                dp1.Add("@Nombre", value.Nombre);
                dp1.Add("@ApellidoP", value.ApellidoP);
                dp1.Add("@ApellidoM", value.ApellidoM);
                dp1.Add("@Direccion", value.Direccion);
                dp1.Add("@Email", value.Email);
                dp1.Add("@FechaNac", value.FechaNac);
                dp1.Add("@Sexo", value.Sexo);
                dp1.Add("@Telefono", value.Telefono);
                dp1.Add("@NomDistrito", nombreDistrito);
                cn.Execute("itData.SP_U_ENCARGADO", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Eliminar(string DNI)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@DNI", DNI);
                cn.Execute("itData.SP_D_ENCARGADO", dp1, commandType: CommandType.StoredProcedure);
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
