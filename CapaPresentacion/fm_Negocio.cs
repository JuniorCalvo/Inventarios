using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class fm_Negocio : Form
    {
        public fm_Negocio()
        {
            InitializeComponent();
        }


        public Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);
            return image;



            /*
            MemoryStream ms = new MemoryStream();

            ms.Write(imageBytes,0,imageBytes.Length);

            Image image = new Bitmap(ms);

            return image;*/

        }
        private void fm_Negocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] byteImagen = new CN_Negocio().obtenerLogo(out obtenido);
            if (obtenido && byteImagen != null && byteImagen.Length > 0)
            {
                picLogo.Image = ByteToImage(byteImagen);
            }
            Negocio datos = new CN_Negocio().obtenerDatos();
            txtNombre.Text = datos.Nombre;
            txtRNC.Text = datos.RNC;
            txtDireccion.Text = datos.Direccion;











            /*
            bool obtenido = true;

            byte[] byteImagen = new CN_Negocio().obtenerLogo(out obtenido);

            if (obtenido)
            {
              

                picLogo.Image = ByteToImage(byteImagen);
            }

            Negocio datos = new CN_Negocio().obtenerDatos();

            txtNombre.Text = datos.Nombre;
            txtRNC.Text = datos.RNC;
            txtDireccion.Text = datos.Direccion;
           */
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

           



                          string mensaje = string.Empty;
                        OpenFileDialog ope = new OpenFileDialog();

                        ope.FileName = "Files|*.jpg;*.jpeg;*.png";


                        if (ope.ShowDialog() == DialogResult.OK)
                        {
                            byte[] byteimage = File.ReadAllBytes(ope.FileName);
                            bool respuesta = new CN_Negocio().actualizarLogo(byteimage, out mensaje);


                            if (respuesta) { 

                                picLogo.Image = ByteToImage(byteimage);

                            }
                            else
                            {
                                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            }
                        }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;


            Negocio obj = new Negocio() { 
            
                Nombre= txtNombre.Text,
                RNC= txtRNC.Text,
                Direccion = txtDireccion.Text,  
            
            
            };


            bool respuesta = new CN_Negocio().GuardarDatos(obj, out mensaje);    
                
                if (respuesta) {

                    MessageBox.Show("Los Cambios Fueron Guardados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }else
                {


                     MessageBox.Show( "No  Fueron Guardados los Dtaos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    
                 }
        }
    }
}
