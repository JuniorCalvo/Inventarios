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
   public class CD_Rol
   {


        private static CD_Rol instance = null;

        private CD_Rol()
        {

            // Constructor privado para evitar la creación de objetos desde fuera de la clase
        }

        public static CD_Rol Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new CD_Rol();
                }
                return instance;


            }
        }

       
        public List<Rol> ListarRol()
        {




            List<Rol> lista = new List<Rol>();


            using (SqlConnection D_conexion = new SqlConnection(CD_Conexion.conn))
            {

                try
                {


                    // salto de linea
                    StringBuilder qry = new StringBuilder();
                    qry.AppendLine("select idRol, Descripcion from Rol");
                                     

                    SqlCommand cmd = new SqlCommand(qry.ToString(), D_conexion);
                    

                    cmd.CommandType = CommandType.Text;

                    D_conexion.Open();



                    // para mostrar todo los registro y lo almacene en mi lista
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {

                            lista.Add(new Rol()
                            {


                                 IdRol = Convert.ToInt32(dr["IdRol"]),                            
                                 Descripcion = dr["Descripcion"].ToString(),



                            }); ;
                        }
                    }


                    D_conexion.Close();

                }
                catch (Exception ex)
                {

                    // si hay error ,e trae una lista vacia
                    lista = new List<Rol>();

                }

                return lista;
            }

        }

    }
}
