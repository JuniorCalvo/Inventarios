using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CapaDatos
{
    // aqui estaran los metodos de conexion a mi base de datos
    public class CD_Conexion
    {
        public static String conn =  ConfigurationManager.ConnectionStrings["sqlconex"].ToString();

      
        public SqlConnection AbrirConexion()
        {
            var connn = new SqlConnection(conn);
            if (connn.State == ConnectionState.Closed)
                connn.Open();
            return connn;
        }

        public SqlConnection CerrarConexion()
        {
            var connn = new SqlConnection(conn);
            if (connn.State == ConnectionState.Open)
                connn.Close();
            return connn;
        }



    }
}
