using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public  class CN_Categoria
    {
        CD_Categoria Ct = CD_Categoria.Instance;




        private static CN_Categoria instance = null;

        private CN_Categoria()
        {

            // Constructor privado para evitar la creación de objetos desde fuera de la clase
        }

        public static CN_Categoria  Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new CN_Categoria();
                }
                return instance;


            }
        }
        public List<Categoria> Listar()
        {
            return Ct.Listar();

        }

        public DataTable listado()
        {
            return Ct.D_listado();
            // llenar la tabla de la agenda

        }
        public void InsertarCategoria(string Descripcion, string Estado)
        {
            Ct.InsertarCategoria(Descripcion, Estado);
        }


        
        public void ModificarCategoria(int IdCategoria, string Descripcion, string Estado)
        {

            Ct.modificarCategoria(IdCategoria, Descripcion,Estado);
        }



        public void EliminarCategoria (int idCategoria)
        {

          Ct.eliminarCategoria(idCategoria);

        }

    }
}
