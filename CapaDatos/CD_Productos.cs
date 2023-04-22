using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Productos : CD_Conexion
    {
        // aqui estamos ****************************+



        private static CD_Productos instance = null;

        private CD_Productos()
        {

            // Constructor privado para evitar la creación de objetos desde fuera de la clase
        }

        public static CD_Productos Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new CD_Productos();
                }
                return instance;


            }
        }


        
        SqlCommand cmm = new SqlCommand();
        CD_Conexion DatosEmp = new CD_Conexion();
        public void InsertarProductos(string Codigo, string  Nombre,  string Descripcion,int IdCategoria, int Cantidad, string PrecioCompra, string PrecioVenta, string Estado)
        {
            {




                cmm.Connection = DatosEmp.AbrirConexion();

                cmm.CommandText = "sp_insertarProductos";
                cmm.CommandType = CommandType.StoredProcedure;

                cmm.Parameters.AddWithValue("@codigo", Codigo);
                cmm.Parameters.AddWithValue("@nombre", Nombre);
                cmm.Parameters.AddWithValue("@descripcion", Descripcion);
                cmm.Parameters.AddWithValue("@idCategoria",IdCategoria);
                cmm.Parameters.AddWithValue("@cantidad", Cantidad);
                cmm.Parameters.AddWithValue("@precioCompra", PrecioCompra);
                cmm.Parameters.AddWithValue("@precioVenta", PrecioVenta);
                cmm.Parameters.AddWithValue("@estado", Estado);
           


                cmm.ExecuteNonQuery();

                cmm.Parameters.Clear();


            }

        }

        public void modificarProductos(int IdProducto, string Codigo, string Nombre, string Descripcion, int IdCategoria, int Cantidad, string PrecioCompra, string PrecioVenta, string Estado)
        {


            cmm.Connection = DatosEmp.AbrirConexion();

            cmm.CommandText = "sp_modificarProductos";
            cmm.CommandType = CommandType.StoredProcedure;

            cmm.Parameters.AddWithValue("@IdProducto", IdProducto);
            cmm.Parameters.AddWithValue("@codigo", Codigo);
            cmm.Parameters.AddWithValue("@nombre", Nombre);
            cmm.Parameters.AddWithValue("@descripcion", Descripcion);
            cmm.Parameters.AddWithValue("@idCategoria", IdCategoria);
            cmm.Parameters.AddWithValue("@cantidad", Cantidad);
            cmm.Parameters.AddWithValue("@precioCompra", PrecioCompra);
            cmm.Parameters.AddWithValue("@precioVenta", PrecioVenta);
            cmm.Parameters.AddWithValue("@estado", Estado);



            cmm.ExecuteNonQuery();

            cmm.Parameters.Clear();



        }




        public void eliminarProductos(int idProducto)
        {

            cmm.Connection = DatosEmp.AbrirConexion();
            cmm.CommandText = "sp_eliminarProductos";
            cmm.CommandType = CommandType.StoredProcedure;


            cmm.Parameters.AddWithValue("@IdProductos",idProducto);

            cmm.ExecuteNonQuery();

            cmm.Parameters.Clear();
        }


        public DataTable D_listado()
        {
            using (SqlConnection connection = AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_listarProductos", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

    }
}
