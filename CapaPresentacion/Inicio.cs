using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using CapaNegocio;


using FontAwesome.Sharp;

namespace CapaPresentacion
{

    public partial class Inicio : Form
    {
        //Usuarios usuarioActual = new Usuarios();
        private static Usuarios usuarioActual;
        private static IconMenuItem menuActivo = null;
        private static Form formActivo = null;

        private static IconButton botonActivoc = null;
        public Inicio(Usuarios objusuarios = null)
        {


            usuarioActual = objusuarios;


            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
           


            // para cargar los permisos de los usuarios

            List<Permisos> listaPermisos = CN_Permisos.Instance.Listar(usuarioActual.IdUsuarios);

            IconButton bt = new IconButton();

            foreach (IconMenuItem iconMenu in menu.Items) {

                // todos los iconoes de menu los vas almacenar aqui

                bt.Visible = false;

                // determina si contiene elemento anny con la variable m voy hacer un recorido de los menus
                bool encontrado = listaPermisos.Any(m => m.NombreMenu == iconMenu.Name);

                if (encontrado == false)
                {
                    iconMenu.Visible = false;



                }

            }



            lblUsuarios.Text = usuarioActual.descripcionRol + ": " + usuarioActual.NombreCompleto;




        }

        


        private void abrirForm(IconMenuItem menu, Form form)
        {
            if (menuActivo != null) {


                menuActivo.BackColor = Color.White;
                        
            }

            menu.BackColor= Color.Silver;

            menuActivo= menu;

            if (formActivo != null)
            {

                formActivo.Close();
            }

            formActivo= form;
            form.TopLevel= false;// que no sea mayor a  mi formuladio actuar
            form.FormBorderStyle = FormBorderStyle.None; // que no tenga borde
            form.Dock = DockStyle.Fill;
            form.BackColor= Color.SteelBlue; // color de forms
            contenedor.Controls.Add(form); // que se me agregue en el panel 
            form.Show();  

        }

        private void subCategoria_Click(object sender, EventArgs e)
        {

            fmCategoria ct = new fmCategoria(usuarioActual);
           ct.OcultarBotones();
            abrirForm(menuMantenedor, new fmCategoria(usuarioActual));


        }

        private void subProductos_Click(object sender, EventArgs e)
        {
            fmProductos productosForm = new fmProductos(usuarioActual);
            productosForm.OcultarBotones();
            abrirForm(menuMantenedor, new fmProductos(usuarioActual));


        }

        private void iconMenuItem1_Click(object sender, EventArgs e)
        {
            fmProvedores productosForm = new fmProvedores(usuarioActual);
            productosForm.OcultarBotones();
            abrirForm((IconMenuItem)sender, new fmProvedores(usuarioActual));


           
          //  OcultarBotones();
        }

        private void menuReportes_Click(object sender, EventArgs e)
        {
            abrirForm((IconMenuItem)sender, new fmReportesProductos());
         
        }

        private void menuUsuarios_Click_1(object sender, EventArgs e)
        {
            abrirForm((IconMenuItem)sender, new fmUsuarios());
        }

        private void menuTitulo_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

       
      

      

        private void submenuReporteProductos_Click(object sender, EventArgs e)
        {
            abrirForm(menuReporte, new fmReportesProductos());
        }

        private void submenuReporteUsuarios_Click(object sender, EventArgs e)
        {
            abrirForm(menuReporte, new fmReporte());
        }

        private void menuNegocio_Click(object sender, EventArgs e)
        {
            abrirForm(menuNegocio, new fm_Negocio());
        }

        private void menuReporte_Click(object sender, EventArgs e)
        {

        }

        private void manuAcerca_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Por favor complete los datos en la aplicación de inventarios desarrollada por Mi Empresa.", "Faltan Campos por llenar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MostrarResumenApp();
        }



        private void MostrarResumenApp()
        {
            // Crear un formulario personalizado
            Form frm = new Form();
            frm.Size = new Size(800, 500);
            frm.Text = "Resumen de la aplicación de inventarios";
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;

            // Crear un label con el mensaje
            Label lblMensaje = new Label();
            lblMensaje.AutoSize = true;
            lblMensaje.Location = new Point(10, 10);
            lblMensaje.Text = "Bienvenido a la aplicación de inventarios.\n" +
                              "Esta herramienta fue creada para ayudar a las personas a llevar un registro\n" +
                              "eficiente de sus productos, simplificando así la tarea de hacer un inventario." +
                              "\n\nAlgunas de las características de nuestra app incluyen:" +
                              "\n\n- Interfaz fácil de usar e intuitiva\n- " +
                              "Registro de productos por categoría" +
                              "\n- Generación de reportes detallados" +
                              "\n\n\n" +
                              "Esperamos que disfrutes nuestra aplicación y que te sea de gran ayuda \n" +
                              "en la gestión de tu inventario!";
            frm.Controls.Add(lblMensaje);

            // Crear un picturebox con el icono de negocio y otro con el icono de Building
            PictureBox pbIcono1 = new PictureBox();
            pbIcono1.Image = Properties.Resources.business_icon;
            pbIcono1.SizeMode = PictureBoxSizeMode.AutoSize;
            pbIcono1.Location = new Point(10, frm.ClientSize.Height - pbIcono1.Height - 10);
            frm.Controls.Add(pbIcono1);

            PictureBox pbIcono2 = new PictureBox();
            pbIcono2.Image = Properties.Resources.building_icon;
            pbIcono2.SizeMode = PictureBoxSizeMode.AutoSize;
            pbIcono2.Location = new Point(pbIcono1.Width + 20, frm.ClientSize.Height - pbIcono2.Height - 10);
            frm.Controls.Add(pbIcono2);

            // Crear los botones
            Button btnAceptar = new Button();
            btnAceptar.Text = "Aceptar";
            btnAceptar.DialogResult = DialogResult.OK;
            btnAceptar.Location = new Point(frm.ClientSize.Width / 2 - btnAceptar.Width / 2, frm.ClientSize.Height - btnAceptar.Height - 20);
            btnAceptar.Anchor = AnchorStyles.Bottom;
            btnAceptar.BackColor = Color.LightBlue;
            frm.Controls.Add(btnAceptar);

            // Mostrar el formulario personalizado como cuadro de diálogo
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();

        }







    }
}
