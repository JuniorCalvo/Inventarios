using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;


namespace CapaNegocio
{
    public  class CN_Permisos
    {
        // capadatos
        CD_Permisos objcd_permisos = CD_Permisos.Instance;


        private static CN_Permisos instance = null;

        private CN_Permisos()
        {

            // Constructor privado para evitar la creación de objetos desde fuera de la clase
        }

        public static CN_Permisos Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new CN_Permisos();
                }
                return instance;


            }
        }

        public List<Permisos> Listar(int idUsuarios)
        {
            return objcd_permisos.Listar(idUsuarios);

        }
    }
}
