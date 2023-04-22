using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuarios
    {
      
        public int IdUsuarios { get; set; }
        public string Documentos { get; set; }

        public string NombreCompleto { get; set; }

        public string descripcionRol { get; set; }

        public string NombreUsuario { get; set; }

        public string Clave { get; set; }


        public int IdRol { get; set; }

        public string Estado { get; set; }

        public string FechaRegistro { get; set; }
    }
}
