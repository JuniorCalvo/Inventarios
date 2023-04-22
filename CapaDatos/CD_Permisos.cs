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
    public class CD_Permisos
    {

        private static CD_Permisos instance = null;

        private CD_Permisos()
        {

            // Constructor privado para evitar la creación de objetos desde fuera de la clase
        }

        public static CD_Permisos Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new CD_Permisos();
                }
                return instance;


            }
        }


        public List<Permisos> Listar(int idUsuarios)
        {




            List<Permisos> lista = new List<Permisos>();


            using (SqlConnection D_conexion = new SqlConnection(CD_Conexion.conn))
            {

                try
                {

                    
                    // salto de linea
                    StringBuilder qry =  new StringBuilder();
                    qry.AppendLine("select p.IdRol, p.NombreMenu from permisos p");
                    qry.AppendLine("inner join rol r on r.IdRol = p.IdRol");
                    qry.AppendLine("inner join Usuarios u on u.IdRol = r.IdRol");
                    qry.AppendLine("where u.IdUsuarios = @idUsuarios");
                    

                    /*

                    
                    string qry = "select p.IdRol, p.NombreMenu from Permisos p " +
                        "inner join rol r on r.IdRol = p.IdRol" +
                        "inner join Usuarios u on u.IdRol = r.IdRol" +
                        "where u.IdUsuarios =@idUsuarios";



                    */


                    SqlCommand cmd = new SqlCommand(qry.ToString(), D_conexion);
                    cmd.Parameters.AddWithValue("@IdUsuarios", idUsuarios);

                    cmd.CommandType = CommandType.Text;

                    D_conexion.Open();



                    // para mostrar todo los registro y lo almacene en mi lista
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {

                            lista.Add(new Permisos()
                            {
                                IdRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]) },
                                NombreMenu = dr["nombreMenu"].ToString(),
                               
                              

                            }); ;
                        }
                    }


                    D_conexion.Close();

                }
                catch (Exception ex)
                {
                    
                    // si hay error ,e trae una lista vacia
                    lista = new List<Permisos>();

                }

                return lista;
            }

        }

/*
        public List<Permisos> Listar(int idUsuario)
        {
            const string permisosTabla = "permisos";
            var lista = new List<Permisos>();

            using (SqlConnection conexion = new SqlConnection(CD_Conexion.conn))
            {
                try
                {
                    var consulta = $@"SELECT p.IdRol, p.NombreMenu FROM {permisosTabla} p
                              INNER JOIN rol r ON r.IdRol = p.IdRol
                              INNER JOIN Usuarios u ON u.IdRol = r.IdRol
                              WHERE u.IdUsuarios = @idUsuario";
                    SqlCommand comando = new SqlCommand(consulta, conexion);

                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Permisos
                            {
                                IdRol = new Rol { IdRol = Convert.ToInt32(reader["IdRol"]) },
                                NombreMenu = reader["NombreMenu"].ToString()
                            });
                        }
                    }
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    lista = new List<Permisos>();
                }
                return lista;
            }
        }

        */


    }
}
