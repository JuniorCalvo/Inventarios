using CapaNegocio;
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
using System.Data.SqlClient;
using FontAwesome.Sharp;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class fmCategoria : Form
    {
        private Usuarios usuarioActual;
        public fmCategoria(Usuarios objusuarios)
        {
            InitializeComponent();

            usuarioActual = objusuarios;
        }

        private void fmCategoria_Load(object sender, EventArgs e)
        {
            Listado();

            if (usuarioActual != null && usuarioActual.IdRol != 1)
            {
                OcultarBotones();
            }
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

        CN_Categoria Ct = CN_Categoria.Instance;

        public void Listado()
        {
                       

            DataTable dt = Ct.listado();

            data.DataSource = dt;


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Guardar




            if (txtDescripcion.Text == ""  || cbxEstado.Text == "")
            {

                MessageBox.Show("Por favor complete los datos", "Faltan Campos por llenar", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }            
            else
            {

                
                Ct.InsertarCategoria( txtDescripcion.Text , cbxEstado.SelectedItem.ToString());

                Listado();

            }
            limpiar();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "" || cbxEstado.Text == "" || txtId.Text == "")
            {

                MessageBox.Show("Selecione los Campos", "Vuelve  a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                                

                int id = int.Parse(txtId.Text = data.CurrentRow.Cells[0].Value.ToString());

                Ct.ModificarCategoria(id,txtDescripcion.Text ,cbxEstado.SelectedItem.ToString());

                Listado();

            }
            limpiar();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text = data.CurrentRow.Cells[0].Value.ToString());


            if (txtDescripcion.Text == "" || cbxEstado.Text == "" || txtId.Text == "")
            {

                MessageBox.Show("Selecione los Campos", "Vuelve  a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                Ct.EliminarCategoria(id);

                Listado();

            }

            limpiar();
        }


        private void limpiar()
        {

            txtId.Text = "0";
            txtDescripcion.Text = "";   
            cbxEstado.Text = "";
            txtBuscar.Text = "";
               cbxBuscar.SelectedItem = "";
        }

        private void data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = data.CurrentRow.Cells[0].Value.ToString();
            txtDescripcion.Text = data.CurrentRow.Cells[1].Value.ToString();
       
            cbxEstado.Text = data.CurrentRow.Cells[2].Value.ToString();
            
        }

        private void data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cbxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {



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

            if (filtro.Equals("Descripcion"))
            {
                qry = "SELECT * FROM Categoria WHERE Descripcion LIKE '" + valor + "%'";
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
