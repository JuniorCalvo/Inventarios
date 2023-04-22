using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                txtContraseña.UseSystemPasswordChar = false;
            }
            else
            {
                 txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            //isertando el registro si los campos no estan vacios si los datos son
            // incorrectos que me tirre un error


            CN_Usuarios usuarios = CN_Usuarios.Instance;

            //List<Usuarios> TEST = CN_Usuarios.Instance.Listar();


           Usuarios validarLogin = usuarios.loginUsuario(txtUsuario.Text, txtContraseña.Text);


            



            if (txtUsuario.Text == "" || txtContraseña.Text == "")
            {

                MessageBox.Show("Complete Los Campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (validarLogin != null)
            {
                Inicio inicio = new Inicio(usuarios.loginUsuario(txtUsuario.Text, txtContraseña.Text)) ;

                inicio.Show(); // mostras
                this.Hide(); // ocultar

                inicio.FormClosed += formCerrar;

            }
            else
            {

                MessageBox.Show("NO SE ENCONTRO EL USUARIO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            





            /*
            
            
            List <Usuarios> TEST = CN_Usuarios.Instance.Listar();


            // Siempre y cuando el usuario este ingresando los datos nombre u contraseña del usuario 
            //podra ingresar de lo contrario esto sera null
            Usuarios usuarios = CN_Usuarios.Instance.Listar().Where
            ( u=> u.Nombre == txtUsuario.Text && u.Clave == txtContraseña.Text).FirstOrDefault();

            if (usuarios != null)
            {
                Inicio inicio = new Inicio();

                inicio.Show(); // mostras
                this.Hide(); // ocultar

                inicio.FormClosed += formCerrar;

            }else
            {


                MessageBox.Show("NO SE ENCONTRO EL USUARIO","MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



            */


        }

        private void formCerrar (object sender, FormClosedEventArgs e)
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            
            this.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
