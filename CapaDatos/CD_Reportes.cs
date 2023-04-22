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
    public class CD_Reportes
    {



        public List <ReporteProductos> productos (string fechaInicio, string fechaFin, int idProducto)
        {
           List<ReporteProductos> lista = new List<ReporteProductos>();


            try
            {
                using (SqlConnection D_conexion = new SqlConnection(CD_Conexion.conn))
                {
                    

                    StringBuilder qry = new StringBuilder();

                    SqlCommand cmd = new SqlCommand("sp_ReporteProductos", D_conexion);

                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.CommandType = CommandType.StoredProcedure;

                    D_conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteProductos()
                            {
                                
                                nombre = dr["Nombre"].ToString(),

                                 descripcion = dr["Descripcion"].ToString(),

                                cantidad = dr["Cantidad"].ToString(),
                                fechaRegistro =  dr["FechaRegistro"].ToString(),
                                precioCompra = dr["PrecioCompra"].ToString(),
                                precioVenta = dr["PrecioVenta"].ToString(),
                                estado = dr["Estado"].ToString(),
                                codigo = dr["Codigo"].ToString(),
                               
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lista = new List<ReporteProductos>();
            }


            return lista;
        }



        public List<ReporteUsuarios> usuarios (string fechaInicio, string fechaFin, int idProducto)
        {
            List<ReporteUsuarios> lista = new List<ReporteUsuarios>();


            try
            {
                using (SqlConnection D_conexion = new SqlConnection(CD_Conexion.conn))
                {


                    StringBuilder qry = new StringBuilder();

                    SqlCommand cmd = new SqlCommand("sp_ReporteProductos", D_conexion);

                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                    cmd.Parameters.AddWithValue("@idUsuario", idProducto);
                    cmd.CommandType = CommandType.StoredProcedure;

                    D_conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteUsuarios()
                            {

                               nombreCompleto = dr["NombreCompleto"].ToString(),

                                nombreUsuario = dr["nombreUsuario"].ToString(),

                                documento = dr["documento"].ToString(),
                                fechaRegistro = dr["fechaRegistro"].ToString(),
                                descripcionRol = dr["descripcionRol"].ToString(),
                         
                                estado = dr["Estado"].ToString(),
                               

                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lista = new List<ReporteUsuarios>();
            }


            return lista;
        }


    }
}
