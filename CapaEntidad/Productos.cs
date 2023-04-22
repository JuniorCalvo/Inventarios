using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    internal class Productos
    {
        private static Productos instance = null;

        private Productos()
        {

            // Constructor privado para evitar la creación de objetos desde fuera de la clase
        }

        public static Productos Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new Productos();
                }
                return instance;


            }
        }
        public int IdProductos { get; set; }
        public string codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Categoria IdCategoria { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool Estado { get; set; }
        public string FechaRegistro { get; set; }

    }
}
