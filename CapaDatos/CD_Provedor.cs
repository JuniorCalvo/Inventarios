using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public  class CD_Provedor : CD_Conexion
    { // aqui estamos ****************************+



        private static CD_Provedor instance = null;

        private CD_Provedor()
        {

            // Constructor privado para evitar la creación de objetos desde fuera de la clase
        }

        public static CD_Provedor Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new CD_Provedor();
                }
                return instance;


            }
        }



        SqlCommand cmm = new SqlCommand();

        CD_Conexion DatosEmp = new CD_Conexion();
        public void InsertarProvedor(string documento, string NombreC, string razonS,  string correo, string telefono, string Estado)
        {
            {




                cmm.Connection = DatosEmp.AbrirConexion();

                cmm.CommandText = "sp_registrarProvedor ";
                cmm.CommandType = CommandType.StoredProcedure;

                cmm.Parameters.AddWithValue("@Documento", documento);
                cmm.Parameters.AddWithValue("@NombreCompleto", NombreC);
                cmm.Parameters.AddWithValue("@RazonSocial", razonS);
                cmm.Parameters.AddWithValue("@Correo", correo);
                cmm.Parameters.AddWithValue("@Telefono", telefono);
           
                cmm.Parameters.AddWithValue("@estado", Estado);



                cmm.ExecuteNonQuery();

                cmm.Parameters.Clear();


            }

        }

        public void modificarProvedor(int idProvedor, string documento, string NombreC, string razonS, string correo, string telefono, string Estado)
        {


            cmm.Connection = DatosEmp.AbrirConexion();

            cmm.CommandText = "sp_modificarProvedor";
            cmm.CommandType = CommandType.StoredProcedure;

            cmm.Parameters.AddWithValue("@idProvedor", idProvedor);
            cmm.Parameters.AddWithValue("@Documento", documento);
            cmm.Parameters.AddWithValue("@NombreCompleto", NombreC);
            cmm.Parameters.AddWithValue("@RazonSocial", razonS);
            cmm.Parameters.AddWithValue("@Correo", correo);
            cmm.Parameters.AddWithValue("@Telefono", telefono);

            cmm.Parameters.AddWithValue("@estado", Estado);



            cmm.ExecuteNonQuery();

            cmm.Parameters.Clear();



        }




        public void eliminarProvedor(int idProvedor)
        {

            cmm.Connection = DatosEmp.AbrirConexion();
            cmm.CommandText = "sp_eliminarProvedor";
            cmm.CommandType = CommandType.StoredProcedure;


            cmm.Parameters.AddWithValue("@idProvedro", idProvedor);

            cmm.ExecuteNonQuery();

            cmm.Parameters.Clear();
        }


        public DataTable D_listado()
        {
            using (SqlConnection connection = AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_listarProvedor", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }



    }
}
