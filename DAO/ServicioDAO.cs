using System;
using System.Collections.Generic;
using System.Text;
using BE;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAO
{
   public class ServicioDAO
    {

        public static List<Servicio> Listar()
        {

            List<Servicio> lis = new List<Servicio>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
               
                lis = cn.Query<Servicio>("itData.SP_S_Servicio", dypa, commandType: CommandType.StoredProcedure).ToList();
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


        public static Servicio BuscarServicio(int id)
        {

            Servicio lis = new Servicio();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdServicio", id);
                lis = cn.Query<Servicio>("itData.SP_S_ID_Servicio", dypa, commandType: CommandType.StoredProcedure).First();
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
        public static string Ingresar(Servicio value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@NomServicio", value.NomServicio);
                dp1.Add("@Descripcion", value.Descripcion);


                cn.Execute("itData.SP_I_Servicio", dp1, commandType: CommandType.StoredProcedure);
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

        public static string Actualizar(Servicio value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdServicio", value.IdServicio);
                dp1.Add("@NombreServicio", value.NomServicio);
                dp1.Add("@Descripcion", value.Descripcion);
              


                cn.Execute("itData.SP_U_Servicio", dp1, commandType: CommandType.StoredProcedure);
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

        public static string Eliminar(int id)
        {

            string rpt = "ok";

            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdServicio", id);
                 cn.Execute("itData.SP_D_Servicio", dypa, commandType: CommandType.StoredProcedure);
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
        public static List<Servicio> BuscarServicios(int id)
        {

            List<Servicio> lis = new List<Servicio>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdEvento", id);
                lis = cn.Query<Servicio>("itData.SP_S_ID_Servicios", dypa, commandType: CommandType.StoredProcedure).ToList();
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
