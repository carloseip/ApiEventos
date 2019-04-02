using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DAO
{
    public static class Conexion
    {
        public static string cn
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["cn"].ToString();
            }
        }
    }
}
