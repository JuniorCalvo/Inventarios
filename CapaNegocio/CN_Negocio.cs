using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Negocio
    {
        private CD_Negocio cn = new CD_Negocio();

        public Negocio obtenerDatos()
        {

            return cn.ObtenerDatos();

        }




        public bool GuardarDatos(Negocio obj, out string mensaje)
        {

            mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                mensaje += "Es Necesario el Nombre";


            }

            if (obj.RNC == "")
            {
                mensaje += "Es Necesario el RNC";


            }


            if (obj.Direccion == "")
            {
                mensaje += "Es Necesaria la Direccion";


            }


            if (mensaje != string.Empty)
            {
                return false;


            }
            else
            {
                return cn.GuardarDatos(obj, out mensaje);

            }




        }



        public byte[] obtenerLogo(out bool obtenido)
        {

            return cn.obtenerLogo(out obtenido);

        }


        public bool actualizarLogo(byte[] imagen, out string mensaje)
        {

            return cn.ActualizarLogo(imagen,out mensaje);

        }

    }

}


