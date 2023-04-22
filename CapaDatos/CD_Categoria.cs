using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Categoria : CD_Conexion
    {



        private static CD_Categoria instance = null;

        private CD_Categoria()
        {

            // Constructor privado para evitar la creación de objetos desde fuera de la clase
        }

        public static CD_Categoria Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new CD_Categoria ();
                }
                return instance;


            }
        }


        public List<Categoria> Listar()
        {




            List<Categoria> lista = new List<Categoria>();


            using (SqlConnection D_conexion = new SqlConnection(CD_Conexion.conn))
            {

                try
                {



                    StringBuilder qry = new StringBuilder();

                    qry.AppendLine("Select Idcategoria, Descripcion, Estado from Categoria");





                    SqlCommand cmd = new SqlCommand(qry.ToString(), D_conexion);
                    cmd.CommandType = CommandType.Text;

                    D_conexion.Open();



                    // para mostrar todo los registro y lo almacene en mi lista
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {

                            lista.Add(new Categoria()
                            {
                                IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                               
                                Descripcion = dr["Descripcion"].ToString(),

                                Estado = dr["Estado"].ToString(),
                             
                              

                            }); ;
                        }
                    }


                    D_conexion.Close();

                }
                catch (Exception ex)
                {

                    // si hay error ,e trae una lista vacia
                    lista = new List<Categoria>();

                }

                return lista;
            }

        }

        SqlCommand cmm = new SqlCommand();
        CD_Conexion DatosEmp = new CD_Conexion();
        public void InsertarCategoria (string Descripcion, string Estado)
        {
            {

               


                    cmm.Connection = DatosEmp.AbrirConexion();

                    cmm.CommandText = "sp_RegistrarCategoria";
                    cmm.CommandType = CommandType.StoredProcedure;

                    cmm.Parameters.AddWithValue("@Descripcion", Descripcion);
                     cmm.Parameters.AddWithValue("@Estado", Estado);


                cmm.ExecuteNonQuery();

                    cmm.Parameters.Clear();

               
            }

        }

        public void modificarCategoria(int IdCategoria, string Descripcion, string Estado)
        {


            cmm.Connection = DatosEmp.AbrirConexion();

            cmm.CommandText = "sp_EditarCategoria";
            cmm.CommandType = CommandType.StoredProcedure;

            cmm.Parameters.AddWithValue("@IdCategoria", IdCategoria);
            cmm.Parameters.AddWithValue("@Estado", Estado);
            cmm.Parameters.AddWithValue("@Descripcion", Descripcion);



            cmm.ExecuteNonQuery();

            cmm.Parameters.Clear();



        }

       


        public void eliminarCategoria(int idCategoria)
        {

            cmm.Connection = DatosEmp.AbrirConexion();
            cmm.CommandText = "sp_EliminarCategoria";
            cmm.CommandType = CommandType.StoredProcedure;


            cmm.Parameters.AddWithValue("@IdCategoria", idCategoria);

            cmm.ExecuteNonQuery();

            cmm.Parameters.Clear();
        }


        public DataTable D_listado()
        {
            using (SqlConnection connection = AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_listarCategoria", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


    }
}
