using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public  class ReporteProductos
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string cantidad { get; set; }
        public string precioCompra { get; set; }

        public string fechaRegistro { get; set; }
        public string precioVenta { get; set; }
        public string estado { get; set; }

    }
}
