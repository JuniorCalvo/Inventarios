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
   public class CD_Negocio : CD_Conexion
    {


        public Negocio ObtenerDatos()
        {
            Negocio obj = new Negocio();
            try
            {
                using (SqlConnection D_conexion = new SqlConnection(CD_Conexion.conn))
                {
                    D_conexion.Open();
                    string qry = "SELECT IdNegocio, Nombre, RNC, Direccion from Negocio where idNegocio = 1";
                    SqlCommand cmd = new SqlCommand(qry, D_conexion);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Negocio()
                            {
                                IdNegocio = int.Parse(dr["IdNegocio"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                RNC = dr["Rnc"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                obj = new Negocio();
            }
            return obj;
        }

        public byte[] obtenerLogo(out bool obtenido)
        {
            obtenido = false;
            byte[] LogoByte = null;
            try
            {
                using (SqlConnection D_conexion = new SqlConnection(CD_Conexion.conn))
                {
                    D_conexion.Open();
                    string qry = "SELECT logo from Negocio where idNegocio = 1";
                    SqlCommand cmd = new SqlCommand(qry, D_conexion);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LogoByte = (byte[])dr["logo"];
                            obtenido = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                obtenido = false;
                LogoByte = null;
            }
            return LogoByte;
        }

        /*
        public Negocio ObtenerDatos () { 
        
            Negocio obj = new Negocio ();  
            


            try
            {



                using (SqlConnection D_conexion = new SqlConnection(CD_Conexion.conn))
                {

                    D_conexion.Open ();

                    string qry = "SELECT IdNegocio, Nombre, RNC, Direccion from Negocio where idNegocio = 1";
                    
                        SqlCommand cmd = new SqlCommand(qry, D_conexion);

                    cmd.CommandType = CommandType.Text;



                    using (SqlDataReader dr = cmd.ExecuteReader ())
                    {
                        while (dr.Read())
                        {
                            obj = new Negocio()
                            {

                                IdNegocio = int.Parse(dr["IdNegocio"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                RNC = dr["Rnc"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                            };


                        }

                    }

                }





                



            }catch (Exception ex)
            {

                obj = new Negocio();

            }


            return obj;
        
        }    


        */


        public bool GuardarDatos (Negocio objeto, out string mensaje)
        {

            mensaje = string.Empty;
            bool respuesta = true;


            try
            {



                using (SqlConnection D_conexion = new SqlConnection(CD_Conexion.conn))
                {
                    D_conexion.Open();

                    StringBuilder qry = new StringBuilder();
                    qry.AppendLine("IF NOT EXISTS (SELECT * FROM negocio WHERE idNegocio = 1)");
                    qry.AppendLine("BEGIN");
                    qry.AppendLine("INSERT INTO negocio (Nombre, RNC, Direccion) VALUES (@nombre, @rnc, @direccion)");
                    qry.AppendLine("END");
                    qry.AppendLine("ELSE");
                    qry.AppendLine("BEGIN");
                    qry.AppendLine("UPDATE negocio SET Nombre=@nombre, RNC=@rnc, Direccion=@direccion WHERE idNegocio = 1");
                    qry.AppendLine("END");

                    SqlCommand cmd = new SqlCommand(qry.ToString(), D_conexion);

                    cmd.Parameters.AddWithValue("@nombre", objeto.Nombre);
                    cmd.Parameters.AddWithValue("@rnc", objeto.RNC);
                    cmd.Parameters.AddWithValue("@direccion", objeto.Direccion);
                    cmd.CommandType = CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1 )
                    {
                        mensaje = "No se pudo Guardar los Datos";

                        respuesta = false;

                    }


                }









            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
              respuesta= false;

            }

            return respuesta;
            

        }

/*
        public byte[] obtenerLogo  (out bool obtenido)
        {
            obtenido= false;

            byte[] LogoByte = new byte[0];


            try
            {



                using (SqlConnection D_conexion = new SqlConnection(CD_Conexion.conn))
                {
                    D_conexion.Open();

                    string qry = "SELECT logo from Negocio where idNegocio = 1";

                    SqlCommand cmd = new SqlCommand(qry, D_conexion);

                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LogoByte = (byte[])dr["logo"];


                          

                        }

                    }


                }









            }
            catch (Exception ex)
            {
               obtenido = false;
               LogoByte = new byte [0];

            }

            return LogoByte;
        }



        */
        public bool ActualizarLogo (byte[] image, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;


            try
            {



                using (SqlConnection D_conexion = new SqlConnection(CD_Conexion.conn))
                {
                    D_conexion.Open();

                    StringBuilder qry = new StringBuilder();
                    qry.AppendLine("Update Negocio set Logo=@image");                   
                    qry.AppendLine("where idNegocio = 1;");

                    SqlCommand cmd = new SqlCommand(qry.ToString(), D_conexion);

                    cmd.Parameters.AddWithValue("@image",image);
                  
                    cmd.CommandType = CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo Actualizar el Logo";

                        respuesta = false;

                    }


                }









            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;

            }

            return respuesta;





        }


    }
}
