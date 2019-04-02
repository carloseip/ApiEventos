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
    public class LocalDAO
    {
        public static List<Local>Listar()
        {
            List<Local> lis = new List<Local>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<Local>("itData.SP_S_LOCAL", dypa, commandType: CommandType.StoredProcedure).ToList();
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
        public static Local Listar(int IdLocal)
        {
            Local lis = new Local();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdLocal", IdLocal);
                lis = cn.Query<Local>("itData.SP_S_ID_LOCAL", dypa, commandType: CommandType.StoredProcedure).First();
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
        public static Local Listar(string Nombre)
        {
            Local lis = new Local();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@NombreLocal", Nombre);
                lis = cn.Query<Local>("itData.SP_S_NOM_LOCAL", dypa, commandType: CommandType.StoredProcedure).First();
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
        public static string Ingresar(Local value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@NomDistrito", value.NomDistrito);
                dp1.Add("@NombreLocal", value.NombreLocal);
                dp1.Add("@Direccion", value.Direccion);
                dp1.Add("@Capacidad", value.Capacidad);
                dp1.Add("@Referencia", value.Referencia);
                dp1.Add("@Contacto", value.Contacto);
                dp1.Add("@Telefono", value.Telefono);
                cn.Execute("itData.SP_I_LOCAL", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Actualizar(Local value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdLocal", value.IdLocal);
                dp1.Add("@NomDistrito", value.NomDistrito);
                dp1.Add("@NombreLocal", value.NombreLocal);
                dp1.Add("@Direccion", value.Direccion);
                dp1.Add("@Capacidad", value.Capacidad);
                dp1.Add("@Referencia", value.Referencia);
                dp1.Add("@Contacto", value.Contacto);
                dp1.Add("@Telefono", value.Telefono);
                cn.Execute("itData.SP_U_LOCAL", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Eliminar(int Id)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdLocal", Id);
                cn.Execute("itData.SP_D_LOCAL", dp1, commandType: CommandType.StoredProcedure);
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
