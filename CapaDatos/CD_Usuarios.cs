using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaEntidad;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Management.Instrumentation;
using System.Security.Claims;
using System.Xml.Linq;

namespace CapaDatos
{
    // uso patron de diseño singleton
   public class CD_Usuarios : CD_Conexion
    {

        private static CD_Usuarios instance = null;

        

        private CD_Usuarios()
        {

            // Constructor privado para evitar la creación de objetos desde fuera de la clase
        }

        public static CD_Usuarios Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new CD_Usuarios();
                }
                return instance;


            }
        }

       

        public Usuarios login(string nombreUsuario, string clave)
        {
            using (var connection = AbrirConexion())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM usuarios WHERE nombreUsuario = @nombreUsuario AND clave = @clave";
                    command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                    command.Parameters.AddWithValue("@clave", clave);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        Usuarios usuario = new Usuarios();
                        while (reader.Read())
                        {
                            usuario.IdUsuarios = Convert.ToInt32(reader["Idusuarios"]);
                            usuario.NombreCompleto = reader["nombreCompleto"].ToString();
                            usuario.NombreUsuario = reader["nombreUsuario"].ToString();
                            usuario.IdRol = Convert.ToInt32(reader["IdRol"]);
                            usuario.Clave = reader["clave"].ToString();
                        }

                        return usuario;
                    }
                    else
                    {
                        return null; // no se encontró ningún usuario con las credenciales proporcionadas
                    }
                }
            }
        }



        public DataTable D_listado()
        {
            using (SqlConnection connection = AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_listarUsuarios", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        SqlCommand cmm = new SqlCommand();
         CD_Conexion DatosEmp = new CD_Conexion();  

        public void Insertar(string Documentos, string NombreUsuario, string NombreCompleto, string Clave, string descripcionRol, string Estado, int IdRol)
        {
            {
                


                cmm.Connection = DatosEmp.AbrirConexion();

                cmm.CommandText = "sp_insertar";
                cmm.CommandType = CommandType.StoredProcedure;

                cmm.Parameters.AddWithValue("@documento", Documentos);
                cmm.Parameters.AddWithValue("@nombreUsuario", NombreUsuario);
                cmm.Parameters.AddWithValue("@NombreCompleto", NombreCompleto);
                cmm.Parameters.AddWithValue("@clave", Clave);
                cmm.Parameters.AddWithValue("@IdRol", IdRol);
                cmm.Parameters.AddWithValue("@descripcionRol", descripcionRol);
                cmm.Parameters.AddWithValue("@estado", Estado);
              

                cmm.ExecuteNonQuery();

                cmm.Parameters.Clear();

            }

        }







        public void modificar(int IdUsuario, string Documento, string NombreUsuario, string NombreCompleto, string Clave, string DescripcionRol, string Estado, int IdRol)
        {


            cmm.Connection = DatosEmp.AbrirConexion();

            cmm.CommandText = "sp_modificar";
            cmm.CommandType = CommandType.StoredProcedure;

                    cmm.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    cmm.Parameters.AddWithValue("@Documento", Documento);
                    cmm.Parameters.AddWithValue("@NombreUsuario", NombreUsuario);
                    cmm.Parameters.AddWithValue("@NombreCompleto", NombreCompleto);
                    cmm.Parameters.AddWithValue("@Clave", Clave);
                    cmm.Parameters.AddWithValue("@DescripcionRol", DescripcionRol);
                    cmm.Parameters.AddWithValue("@Estado", Estado);
                    cmm.Parameters.AddWithValue("IdRol", IdRol);


            cmm.ExecuteNonQuery();

            cmm.Parameters.Clear();



        }


        public void eliminar(int idUsuarios)
        {

            cmm.Connection = DatosEmp.AbrirConexion();
            cmm.CommandText = "sp_eliminar";
            cmm.CommandType = CommandType.StoredProcedure;


            cmm.Parameters.AddWithValue("@IdUsuario", idUsuarios);

            cmm.ExecuteNonQuery();

            cmm.Parameters.Clear();
        }



    }
}














