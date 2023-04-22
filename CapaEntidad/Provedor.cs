using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class Provedor
    {
        private static Provedor instance = null;

        private Provedor()
        {
            // Constructor privado para evitar la creación de objetos desde fuera de la clase
        }

        public static Provedor Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new Provedor();
                }
                return instance;


            }
        }

      
        public int IdProvedor{ get; set; }
        public string NombreCompleto { get; set; }
        public string RazonSocial { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public string FechaRegistro { get; set; }
    }
}
