using System;
using System.Collections.Generic;
using System.Text;
using BE;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace DAO
{
    public class CobroDAO
    {

        public static List<CobroModelView> Listar()
        {

            List<CobroModelView> lis = new List<CobroModelView>();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                lis = cn.Query<CobroModelView>("itData.SP_S_Cobro", dypa, commandType: CommandType.StoredProcedure).ToList();
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

        public static CobroModelView BuscarCobro(int id)
        {

            CobroModelView lis = new CobroModelView();
            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdCobro", id);
                lis = cn.Query<CobroModelView>("itData.SP_S_ID_Cobro", dypa, commandType: CommandType.StoredProcedure).First();
            }
            catch (Exception e)
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



        public static string IngresarCobro(CobroModelView cobro)
        {

            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            SqlTransaction tran = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@Fecha", cobro.Fecha);
                dypa.Add("@MontoML", cobro.MontoML);
                dypa.Add("@MontoME", cobro.MontoME);
                dypa.Add("@Dni", cobro.DNI);
                dypa.Add("@IdTipoCobro", cobro.IdTipoCobro);
                dypa.Add("@TipoDoc", cobro.TipoDoc);
                dypa.Add("@SerieDoc", cobro.SerieDoc);
                dypa.Add("@NumeroDoc", cobro.NumeroDoc);
                dypa.Add("@Moneda", cobro.Moneda);
                dypa.Add("@MontoCobrado", cobro.MontoCobrado);
                dypa.Add("@TipoDocCobro", cobro.TipoDocCobro);
                dypa.Add("@NumOperacion", cobro.NumOperacion);
                dypa.Add("@Observacion", cobro.Observacion);
                cn.Execute("itData.SP_I_CABCOBRO_DETCOBRO", dypa, tran, commandType: CommandType.StoredProcedure);
                rpt = "ok";
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                rpt = "no";
            }
            finally
            {
                tran.Dispose();
                cn.Close();
                cn.Dispose();
            }
            return rpt;

        }

        public static string ActualizarCobro(CobroModelView cobro)
        {

            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            SqlTransaction tran = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdCobro", cobro.IdCobro);
                dypa.Add("@MontoML", cobro.MontoML);
                dypa.Add("@MontoME", cobro.MontoME);
                dypa.Add("@Dni", cobro.DNI);
                dypa.Add("@IdTipoCobro", cobro.IdTipoCobro);
                dypa.Add("@TipoDoc", cobro.TipoDoc);
                dypa.Add("@SerieDoc", cobro.SerieDoc);
                dypa.Add("@NumeroDoc", cobro.NumeroDoc);
                dypa.Add("@Moneda", cobro.Moneda);
                dypa.Add("@MontoCobrado", cobro.MontoCobrado);
                dypa.Add("@TipoDocCobro", cobro.TipoDocCobro);
                dypa.Add("@NumOperacion", cobro.NumOperacion);
                dypa.Add("@Observacion", cobro.Observacion);
                cn.Execute("itData.SP_U_CABCOBRO_DETCOBRO", dypa, tran, commandType: CommandType.StoredProcedure);
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                rpt = "no";
            }
            finally
            {
                tran.Dispose();
                cn.Close();
                cn.Dispose();
            }
            return rpt;

        }

        public static string DeleteCobro(int idcobro)
        {

            string rpt = "ok";
            SqlConnection cn = new SqlConnection(Conexion.cn);
            cn.Open();
            SqlTransaction tran = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                DynamicParameters dypa = new DynamicParameters();
                dypa.Add("@IdCobro", idcobro);
                cn.Execute("itData.SP_D_CABCOBRO_DETCOBRO", dypa, tran, commandType: CommandType.StoredProcedure);
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                rpt = "no";
            }
            finally
            {
                tran.Dispose();
                cn.Close();
                cn.Dispose();
            }
            return rpt;

        }


    }
}

