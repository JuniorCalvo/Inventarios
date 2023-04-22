using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
   public  class CN_Rol
   {


        private static CN_Rol instance = null;

        private CN_Rol()
        {

            // Constructor privado para evitar la creación de objetos desde fuera de la clase
        }

        public static CN_Rol Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new CN_Rol();
                }
                return instance;


            }
        }


        CD_Rol obj_Rol = CD_Rol.Instance;
        public List<Rol> ListarRol()
        {
            return obj_Rol.ListarRol();

        }
    }
}
