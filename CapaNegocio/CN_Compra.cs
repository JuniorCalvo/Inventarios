using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Compra
    {

        CD_Compra cp = CD_Compra.Instance;




        private static CN_Compra instance = null;

        private CN_Compra()
        {

            // Constructor privado para evitar la creación de objetos desde fuera de la clase
        }

        public static CN_Compra Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new CN_Compra();
                }
                return instance;


            }
        }


        public DataTable listado()
        {
            return cp.D_listado();
            // llenar la tabla de la agenda

        }
        public void InsertarCompra(int idUsuario, int idProvedor, int idProduct, string tipoDocumento, string numeroDocumento, string montoTotal, string precioC, string precioV)
        {

            cp.InsertarCompra(idUsuario, idProvedor, idProduct, tipoDocumento, numeroDocumento, montoTotal, precioC, precioV);
        
                    
        }



     


        

    }
}
