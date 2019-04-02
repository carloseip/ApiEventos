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
    public class ClienteEmpresaDAO
    {
        public static List<ClienteEmpresa> Listar()
        {
            List<ClienteEmpresa> lis = new List<ClienteEmpresa>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<ClienteEmpresa>("itData.SP_S_CLIENTEEMPRESA", dypa, commandType: CommandType.StoredProcedure).ToList();
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
        public static ClienteEmpresa Listar(string RUC)
        {
            ClienteEmpresa lis = new ClienteEmpresa();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@RUC", RUC);
                lis = cn.Query<ClienteEmpresa>("itData.SP_S_RUC_CLIENTEEMPRESA", dypa, commandType: CommandType.StoredProcedure).First();
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

        public static string Ingresar(ClienteEmpresa value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@RUC", value.RUC);
                dp1.Add("@RazonSocial", value.RazonSocial);
                dp1.Add("@Direccion", value.Direccion);
                dp1.Add("@Telefono", value.Telefono);
                dp1.Add("@Email", value.Email);
                dp1.Add("@Contacto", value.Contacto);
                dp1.Add("@IdDistrito", value.IdDistrito);
                cn.Execute("itData.SP_I_CLIENTEEMPRESA", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Actualizar(ClienteEmpresa value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@RUC", value.RUC);
                dp1.Add("@RazonSocial", value.RazonSocial);
                dp1.Add("@Direccion", value.Direccion);
                dp1.Add("@Telefono", value.Telefono);
                dp1.Add("@Email", value.Email);
                dp1.Add("@Contacto", value.Contacto);
                dp1.Add("@IdDistrito", value.IdDistrito);
                cn.Execute("itData.SP_U_CLIENTEEMPRESA", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Eliminar(string RUC)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@RUC", RUC);
                cn.Execute("itData.SP_D_CLIENTEEMPRESA", dp1, commandType: CommandType.StoredProcedure);
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
