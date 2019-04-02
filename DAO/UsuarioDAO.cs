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
    public class UsuarioDAO
    {
        public static string Ingresar(Usuario usuario)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@Nombres", usuario.Nombres);
                dp1.Add("@ApellidoP", usuario.ApellidoP);
                dp1.Add("@ApellidoM", usuario.ApellidoM);
                dp1.Add("@DNI", usuario.DNI);
                dp1.Add("@Telefono", usuario.Telefono);
                dp1.Add("@UsuarioN", usuario.UsuarioN);
                dp1.Add("@Password", usuario.Password);
                dp1.Add ("@IdRol", usuario.IdRol);

                cn.Execute("itLogin.SP_I_USUARIO", dp1, commandType: CommandType.StoredProcedure);
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

        public static List<UsuarioModel> Listar()
        {

            List<UsuarioModel> lis = new List<UsuarioModel>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();

                lis = cn.Query<UsuarioModel>("itLogin.SP_S_USUARIO", dypa, commandType: CommandType.StoredProcedure).ToList();
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

        public static string Eliminar(int IdUsuario)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdUsuario", IdUsuario);
                cn.Execute("itLogin.SP_D_USUARIO", dp1, commandType: CommandType.StoredProcedure);
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
        public static UsuarioModelActualizar Listar(int IdUsuario)
        {
            UsuarioModelActualizar lis = new UsuarioModelActualizar();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdUsuario", IdUsuario);
                lis = cn.Query<UsuarioModelActualizar>("itLogin.SP_S_ID_USUARIO", dypa, commandType: CommandType.StoredProcedure).First();
            }
            catch (Exception e)
            {
                var rpt = "Excepción ocurrida: " + e.Message;
                lis = null;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return lis;
        }
        public static string Actualizar(UsuarioModelActualizar value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdUsuario",value.IdUsuario);
                dp1.Add("@Nombre", value.Nombre);
                dp1.Add("@ApellidoP", value.ApellidoP);
                dp1.Add("@ApellidoM", value.ApellidoM);
                dp1.Add("@DNI", value.DNI);
                dp1.Add("@Telefono", value.Telefono);
                dp1.Add("@Usuario", value.Usuario);
                dp1.Add("@Pass", value.Pass);
                dp1.Add("@Rol", value.Rol);

                cn.Execute("itLogin.SP_U_USUARIO", dp1, commandType: CommandType.StoredProcedure);
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
