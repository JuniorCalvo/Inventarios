using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class fmProvedores : Form
    {
        private Usuarios usuarioActual;
        public fmProvedores(Usuarios objusuarios)
        {
            InitializeComponent();

            usuarioActual = objusuarios;
        }

        private void fmProvedores_Load(object sender, EventArgs e)
        {
            if (usuarioActual != null && usuarioActual.IdRol != 1)
            {
                OcultarBotones();
            }
            Listado();
        }

        CN_Provedor prv = CN_Provedor.Instance;
        public void Listado()
        {


            DataTable dt = prv.listado();

            data.DataSource = dt;

        }
        public void OcultarBotones()
        {
            if (usuarioActual.IdRol != 1) // Si el usuario no es administrador
            {
                // Buscar todos los botones "btnModificar" y "btnEliminar" en los controles del formulario
                foreach (IconButton btnModificar in this.Controls.Find("btnEditar", true))
                {
                    btnModificar.Visible = false; // Ocultar el botón "modificar"
                }

                foreach (IconButton btnEliminar in this.Controls.Find("btnEliminar", true))
                {
                    btnEliminar.Visible = false; // Ocultar el botón "eliminar"
                }
            }
        }

        private void limpiar()
        {
         
            txtId.Text = "";       
            cbxEstado.Text = "";
            txtCorreo.Text = "";
            txtDocumento.Text = "";
            txtNombre.Text = "";
            txtTel.Text = "";
            txtRazon.Text = "";
            txtBuscar.Text = "";
            cbxBuscar.SelectedItem = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // guardar
           

            if (txtDocumento.Text == "" || txtNombre.Text == "" || cbxEstado.Text == "" || txtCorreo.Text == "" || txtTel.Text == ""|| cbxEstado.Text == "")
            {

                MessageBox.Show("Por favor complete los datos", "Faltan Campos por llenar", MessageBoxButtons.OK, MessageBoxIcon.Information);






            }
            else
            {
                /*
                string cat = "";

                if (cbxDescripcion.SelectedItem.ToString() == "Lacteos")
                {
                    cat = "1";
                }
                else if (cbxDescripcion.SelectedItem.ToString() == "Embutido")
                {
                    cat = "2";
                }
                else if (cbxDescripcion.SelectedItem.ToString() == "Enlatados")
                {
                    cat = "4";
                }
                else if (cbxDescripcion.SelectedItem.ToString() == "Comida")
                {
                    cat = "5";
                }
                else if (cbxDescripcion.SelectedItem.ToString() == "Bebida")
                {
                    cat = "6";
                }

                */
               

                prv.InsertarProvedor(txtDocumento.Text, txtNombre.Text, txtRazon.Text, txtCorreo.Text,txtTel.Text, cbxEstado.SelectedItem.ToString());

                Listado();

            }



            limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // editar

            if (txtDocumento.Text == "" || txtNombre.Text == "" || cbxEstado.Text == "" || txtCorreo.Text == "" || txtTel.Text == "" || cbxEstado.Text == "")
            {

                MessageBox.Show("Selecione los Campos", "Vuelve  a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
              

                int id = int.Parse(txtId.Text = data.CurrentRow.Cells[0].Value.ToString());

                


                prv.ModificarProvedor(id, txtDocumento.Text, txtNombre.Text, txtRazon.Text, txtCorreo.Text, txtTel.Text, cbxEstado.SelectedItem.ToString());

                Listado();

            }
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // eliminar 


            int id = int.Parse(txtId.Text = data.CurrentRow.Cells[0].Value.ToString());


            if (txtDocumento.Text == "" || txtNombre.Text == "" || cbxEstado.Text == "" ||txtCorreo.Text == "" || txtTel.Text == "" || cbxEstado.Text == "")
            {

                MessageBox.Show("Selecione los Campos", "Vuelve  a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                prv.EliminarProvedor(id);

                Listado();

            }

            limpiar();
        }

        private void data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // aqui

            txtId.Text = data.CurrentRow.Cells[0].Value.ToString();
            txtDocumento.Text = data.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = data.CurrentRow.Cells[2].Value.ToString();
            txtRazon.Text = data.CurrentRow.Cells[3].Value.ToString();
            txtCorreo.Text = data.CurrentRow.Cells[4].Value.ToString();
            txtTel.Text = data.CurrentRow.Cells[5].Value.ToString();
            cbxEstado.Text = data.CurrentRow.Cells[6].Value.ToString();
            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            //

            if (txtBuscar.Text == "")
            {   // errorProvider1.SetError(txtApellido, "Ingresar datos");


                errorProvider1.SetError(txtBuscar, "Ingresar datos");

                MessageBox.Show("Selecione lo que Quiere Buscar");

            }
            else if (cbxBuscar.Text == "")
            {


                errorProvider1.SetError(cbxBuscar, "Ingresar datos");

                MessageBox.Show("Selecione lo que Quiere Buscar");


            }
            else
            {
                errorProvider1.Clear();


                buscar(txtBuscar.Text, cbxBuscar.SelectedItem.ToString());



            }
        }


        public void buscar(String valor, String filtro)
        {
            SqlConnection cn = new SqlConnection("Data Source=JUNIOR; Initial Catalog=SistemaInventario; integrated security=true");
            cn.Open();

            String qry = "";

            if (filtro.Equals("Documento"))
            {
                qry = "SELECT * FROM provedor WHERE documento LIKE '" + valor + "%'";
            }
            else if (filtro.Equals("Razon Social"))
            {
                qry = "SELECT * FROM proverdor WHERE RazonSocial LIKE '" + valor + "%'";
            }
            else if (filtro.Equals("Nombre Completo"))
            {
                qry = "SELECT * FROM provedor WHERE NombreCompleto LIKE '" + valor + "%'";
            }
            else if (filtro.Equals("Correo"))
            {
                qry = "SELECT * FROM provedor WHERE correoLIKE '" + valor + "%'";
            }
            else if (filtro.Equals("Telefono"))
            {
                qry = "SELECT * FROM provedor WHERE telefono LIKE '" + valor + "%'";
            }

            SqlDataAdapter adap = new SqlDataAdapter(qry, cn);

            DataTable dt = new DataTable();

            adap.Fill(dt);

            data.DataSource = dt;

            SqlCommand cm = new SqlCommand(qry, cn);

            SqlDataReader lc = cm.ExecuteReader();

            cn.Close();

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Listado();

            limpiar();
        }
    }
}
