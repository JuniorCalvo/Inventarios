using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Compra : CD_Conexion
    {
        // aqui estamos ****************************+



        private static CD_Compra instance = null;

        private CD_Compra()
        {

            // Constructor privado para evitar la creación de objetos desde fuera de la clase
        }

        public static CD_Compra Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new CD_Compra ();
                }
                return instance;


            }
        }



        SqlCommand cmm = new SqlCommand();
        CD_Conexion DatosEmp = new CD_Conexion();
        public void InsertarCompra(int idUsuario, int idProvedor, int idProduct, string tipoDocumento, string numeroDocumento, string montoTotal, string precioC, string precioV)
        {
            {




                cmm.Connection = DatosEmp.AbrirConexion();

                cmm.CommandText = "sp_registrarCompra";
                cmm.CommandType = CommandType.StoredProcedure;

                cmm.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmm.Parameters.AddWithValue("@idProvedor", idProvedor);
                cmm.Parameters.AddWithValue("@idProducto", idProduct);
                cmm.Parameters.AddWithValue("@tipoDocumento", tipoDocumento);
                cmm.Parameters.AddWithValue("@numeroDocumento", numeroDocumento);
                cmm.Parameters.AddWithValue("@montoTotal", montoTotal);
                cmm.Parameters.AddWithValue("@precioCompra", precioC);
                cmm.Parameters.AddWithValue("@precioVenta", precioV);



                cmm.ExecuteNonQuery();

                cmm.Parameters.Clear();


            }

        }

          
   


        public DataTable D_listado()
        {
            using (SqlConnection connection = AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_listarCompra", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }



    }
}
