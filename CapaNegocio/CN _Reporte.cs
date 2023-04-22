using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public  class CN__Reporte
    {

        CD_Reportes obj = new CD_Reportes();



        public List<ReporteProductos> productos(string fechaInicio, string fechaFin, int idProducto)
        {
           return obj.productos(fechaInicio, fechaFin, idProducto);

        }

        public List<ReporteUsuarios> Usuarios (string fechaInicio, string fechaFin, int idUsuario)
        {
            return obj.usuarios(fechaInicio, fechaFin, idUsuario);

        }







    }
}
