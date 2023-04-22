using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Provedor
    {

        CD_Provedor pr = CD_Provedor.Instance;




        private static CN_Provedor instance = null;

        private CN_Provedor()
        {

            // Constructor privado para evitar la creación de objetos desde fuera de la clase
        }

        public static CN_Provedor Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new CN_Provedor();
                }
                return instance;


            }
        }


        public DataTable listado()
        {
            return pr.D_listado();
            // llenar la tabla de la agenda

        }
        public void InsertarProvedor(string documento, string NombreC, string razonS, string correo, string telefono, string Estado)
        {
            pr.InsertarProvedor(documento, NombreC, razonS, correo, telefono, Estado);
        }



        public void ModificarProvedor(int idProvedor, string documento, string NombreC, string razonS, string correo, string telefono, string Estado)
        {

          pr.modificarProvedor(idProvedor, documento, NombreC, razonS, correo, telefono, Estado);
        }



        public void EliminarProvedor(int idProvedor)
        {

            pr.eliminarProvedor(idProvedor);

        }

    }
}
