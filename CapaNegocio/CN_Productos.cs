using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
   public  class CN_Productos
   {
        CD_Productos pr = CD_Productos.Instance;




        private static CN_Productos instance = null;

        private CN_Productos()
        {

            // Constructor privado para evitar la creación de objetos desde fuera de la clase
        }

        public static CN_Productos Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new CN_Productos();
                }
                return instance;


            }
        }
       

        public DataTable listado()
        {
            return pr.D_listado();
            // llenar la tabla de la agenda

        }
        public void InsertarProductos(string Codigo, string Nombre, string Descripcion, int IdCategoria, int Cantidad, string PrecioCompra, string PrecioVenta, string Estado)
        {
            pr.InsertarProductos(Codigo, Nombre, Descripcion, IdCategoria, Cantidad, PrecioCompra, PrecioVenta, Estado);
        }



        public void ModificarProductos(int IdProducto, string Codigo, string Nombre, string Descripcion, int IdCategoria, int Cantidad, string PrecioCompra, string PrecioVenta, string Estado)
        {

            pr.modificarProductos(IdProducto, Codigo, Nombre, Descripcion, IdCategoria, Cantidad, PrecioCompra, PrecioVenta, Estado);
        }



        public void EliminarProductos(int idProducto)
        {

            pr.eliminarProductos(idProducto);

        }

    }
}
