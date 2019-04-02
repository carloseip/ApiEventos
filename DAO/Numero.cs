using BE;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Numero
    {
        public static string getNumero(string query)
        {
            string numGen;
            string numObt = null;
            CabVenta cab = new CabVenta();

            SqlConnection cn = new SqlConnection(Conexion.cn);
            try
            {
                DynamicParameters dypa = new DynamicParameters();
                cab=cn.Query<CabVenta>(query, dypa, commandType: CommandType.StoredProcedure).Last();

                numObt = cab.NumeroDoc;

                string parInt = numObt.Substring(2);
                string parStr = numObt.Substring(0, 2);
                string nueParInt = (int.Parse(parInt) + 1).ToString();
                while (nueParInt.Length < 8)
                {
                    nueParInt = "0" + nueParInt;
                }
                numGen = parStr + nueParInt;
            }
            catch(Exception ex)
            {
                var res = ex.Message;
                numGen = null;
            }

            return numGen;
        }

    }
}
