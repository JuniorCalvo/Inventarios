using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuarios
    {
        CD_Usuarios objcd_usuarios = CD_Usuarios.Instance;

        private static CN_Usuarios instance = null;

        private CN_Usuarios()
        {

            // Constructor privado para evitar la creación de objetos desde fuera de la clase
        }

        public static CN_Usuarios Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new CN_Usuarios();
                }
                return instance;


            }
        }

/*
        public List<Usuarios> Listar()
        {
            return objcd_usuarios.Listar();

        }
        */




        CD_Usuarios usuariosD = CD_Usuarios.Instance;

        public Usuarios loginUsuario(string nombreRol, string contraseña)
        {
            // login del usuario
            return usuariosD.login(nombreRol, contraseña);
        }

        public DataTable listado()
        {
            return usuariosD.D_listado();
            // llenar la tabla de la agenda

        }

        /*
        public int Insertar(string Documentos, string NombreUsuario, string NombreCompleto, string Clave, string descripcionRol, string Estado, out string mensaje)
        {     // insertar agenda

            mensaje= string.Empty;

            if (Documentos== "")
            {


                mensaje += "es nesesario el documento del usuario";
            }

            if (NombreCompleto == "")
            {


                mensaje += "es nesesario el nombre del usuario";
            }

            if ( Clave == "")
            {

                mensaje += "es nesesario la clave  del usuario";
            }
            return usuariosD.Insertar(Documentos,  NombreUsuario, NombreCompleto, Clave, descripcionRol, Estado, out mensaje);
        }
        */

        public void Insertar(string Documentos, string NombreUsuario, string NombreCompleto, string Clave, string descripcionRol, string Estado, int IdRol)
        {
            usuariosD.Insertar(Documentos, NombreUsuario, NombreCompleto, Clave, descripcionRol, Estado, IdRol);
        }


        /*
                public bool modificar (int IdUsuario, string Documento, string NombreUsuario, string NombreCompleto, string Clave, string DescripcionRol, string Estado, out string mensaje)
                {

                    return usuariosD.modificar(IdUsuario, Documento, NombreUsuario, NombreCompleto, Clave, DescripcionRol, Estado, out mensaje);
                }
                */
        public void modificar(int IdUsuario, string Documento, string NombreUsuario, string NombreCompleto, string Clave, string DescripcionRol, string Estado,int IdRol)
        {

           usuariosD.modificar(IdUsuario, Documento, NombreUsuario, NombreCompleto, Clave, DescripcionRol, Estado,IdRol);
        }



        public void eliminar(int idUsuarios)
        {

            usuariosD.eliminar(idUsuarios);
        }

    


    }


}
