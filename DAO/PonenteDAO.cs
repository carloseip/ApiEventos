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
    public class PonenteDAO
    {
        public static List<Ponente> Listar()
        {
            List<Ponente> lis = new List<Ponente>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<Ponente>("itData.SP_S_PONENTE", dypa, commandType: CommandType.StoredProcedure).ToList();
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
        public static Ponente Listar(string DocIdentidad)
        {
            Ponente lis = new Ponente();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@DocIdentidad", DocIdentidad);
                lis = cn.Query<Ponente>("itData.SP_S_DOC_PONENTE", dypa, commandType: CommandType.StoredProcedure).First();
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

        public static string Ingresar(Ponente value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@DocIdentidad", value.DocIdentidad);
                dp1.Add("@Nombre", value.Nombre);
                dp1.Add("@ApellidoP", value.ApellidoP);
                dp1.Add("@ApellidoM", value.ApellidoM);
                dp1.Add("@Email", value.Email);
                dp1.Add("@FechaNac", value.FechaNac);
                dp1.Add("@Sexo", value.Sexo);
                dp1.Add("@Telefono", value.Telefono);
                dp1.Add("@Experiencia", value.Experiencia);
                dp1.Add("@Especialidad", value.Especialidad);
            
                cn.Execute("itData.SP_I_PONENTE", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Actualizar(Ponente value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@DocIdentidad", value.DocIdentidad);
                dp1.Add("@Nombre", value.Nombre);
                dp1.Add("@ApellidoP", value.ApellidoP);
                dp1.Add("@ApellidoM", value.ApellidoM);
                dp1.Add("@Email", value.Email);
                dp1.Add("@FechaNac", value.FechaNac);
                dp1.Add("@Sexo", value.Sexo);
                dp1.Add("@Telefono", value.Telefono);
                dp1.Add("@Experiencia", value.Experiencia);
                dp1.Add("@Especialidad", value.Especialidad);

                cn.Execute("itData.SP_U_PONENTE", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Eliminar(string DocIdentidad)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@DocIdentidad", DocIdentidad);
                cn.Execute("itData.SP_D_PONENTE", dp1, commandType: CommandType.StoredProcedure);
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
