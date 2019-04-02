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
    public class TipoCobroDAO
    {

        public static List<TipoCobro> Listar()
        {
            List<TipoCobro> lis = new List<TipoCobro>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<TipoCobro>("itData.SP_S_TipoCobro", dypa, commandType: CommandType.StoredProcedure).ToList();
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


        public static string Ingresar(TipoCobro value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@NomTipoCobro", value.NomTipoCobro);
                dp1.Add("@Descripcion", value.Descripcion);


                cn.Execute("itData.SP_I_TipoCobro", dp1, commandType: CommandType.StoredProcedure);
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
        public static string Actualizar(TipoCobro value)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@IdTipoCobro", value.IdTipoCobro);
                dp1.Add("@NomTipoCobro", value.NomTipoCobro);
                dp1.Add("@Descripcion", value.Descripcion);


                cn.Execute("itData.SP_U_TipoCobro", dp1, commandType: CommandType.StoredProcedure);
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


        public static TipoCobro BuscarTipoCobro(int id)
        {
            TipoCobro lis = new TipoCobro();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@idtipoCobro", id);
                lis = cn.Query<TipoCobro>("itData.SP_S_ID_TipoCobro", dypa, commandType: CommandType.StoredProcedure).First();
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


        public static string Eliminar(int id)
        {
            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dp1 = new DynamicParameters();
                dp1.Add("@idtipocobro", id);


                cn.Execute("itData.SP_D_TipoCobro", dp1, commandType: CommandType.StoredProcedure);
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
