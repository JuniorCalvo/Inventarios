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


using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{
    public partial class fmUsuarios : Form
    {
        CN_Usuarios Ng = CN_Usuarios.Instance;
        public fmUsuarios()
        {
            InitializeComponent();

           // Login lc = new Login();
           
        }

       
        private void fmUsuarios_Load(object sender, EventArgs e)
        {
            

            DataTable dt = Ng.listado();



            Listado();
        }






        public void Listado()
        {

            CN_Usuarios objectoN = CN_Usuarios.Instance;
            DataTable dt = objectoN.listado();

            data.DataSource = dt;


        }
   
        private void btnGuardar_Click(object sender, EventArgs e)
        {
             



         

           

            if (txtDocumento.Text == "" || txtNombreC.Text  == "" || cbxRol.Text ==  "" || txtUsuario.Text == "" )
            {

                MessageBox.Show("Por favor complete los datos", "Faltan Campos por llenar", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }else if (txtPass.Text != txtPass2.Text)
            {

                MessageBox.Show("La contraseña no son iguales", "Vuelve  a Ingresar la contraseña  ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtPass.Text = "";
                txtPass2.Text = "";
            }
            else {

                string rol = "";

                if (cbxRol.SelectedItem.ToString() == "ADMINISTRADOR")
                {
                    rol = "1";
                }
                else if (cbxRol.SelectedItem.ToString() == "USUARIO GENERAL")
                {
                    rol = "2";
                }

                int idRol = int.Parse(rol);

                Ng.Insertar(txtDocumento.Text, txtUsuario.Text, txtNombreC.Text, txtPass.Text, cbxRol.SelectedItem.ToString(), cbxEstado.SelectedItem.ToString(), idRol);

                Listado();

            }

           


            limpiar();
        }


        private void limpiar()
        {

            txtId.Text = "0";
            txtDocumento.Text = "";
            txtNombreC.Text = "";
            txtUsuario.Text = "";
            txtPass.Text = "";
            txtPass2.Text = "";
            cbxRol.Text = "";
            cbxEstado.Text  = "";
           // cbxBuscar.Text = "";
            txtBuscar.Text = "";

           cbxBuscar.SelectedItem= "";

        }

        

        private void data_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = data.CurrentRow.Cells[0].Value.ToString();
            txtDocumento.Text = data.CurrentRow.Cells[1].Value.ToString();
            txtNombreC.Text = data.CurrentRow.Cells[2].Value.ToString();
            txtUsuario.Text = data.CurrentRow.Cells[3].Value.ToString();
            cbxEstado.Text = data.CurrentRow.Cells[4].Value.ToString();
            cbxRol.Text = data.CurrentRow.Cells[5].Value.ToString();

            txtIdRol.Text = data.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {


            if (txtDocumento.Text == "" || txtNombreC.Text == "" || cbxRol.Text == "" || txtUsuario.Text == "" )
            {

                MessageBox.Show("Selecione el Usuario", "Vuelve  a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else {



                string rol = "";

                if (cbxRol.SelectedItem != null)
                {
                    if (cbxRol.SelectedItem.ToString() == "ADMINISTRADOR")
                    {
                        rol = "1";
                    }
                    else if (cbxRol.SelectedItem.ToString() == "USUARIO GENERAL")
                    {
                        rol = "2";
                    }
                }

                int idRol = int.Parse(rol);

                int id = int.Parse(txtId.Text = data.CurrentRow.Cells[0].Value.ToString());

                Ng.modificar(id, txtDocumento.Text, txtUsuario.Text, txtNombreC.Text, txtPass.Text, rol, cbxEstado.SelectedItem.ToString(), idRol);

                Listado();

            }

            limpiar();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            int id = int.Parse(txtId.Text = data.CurrentRow.Cells[0].Value.ToString());


            if (txtDocumento.Text == "" || txtNombreC.Text == "" || cbxRol.Text == "" || txtUsuario.Text == "" )
            {

                MessageBox.Show("Selecione el Usuario", "Vuelve  a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                Ng.eliminar(id);

                Listado();

            }

            limpiar();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            // BUSCAR

            // boton buscar
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
                qry = "SELECT * FROM usuarios WHERE documento LIKE '" + valor + "%'";
            }
            else if (filtro.Equals("Nombre de Usuario"))
            {
                qry = "SELECT * FROM usuarios WHERE nombreUsuario LIKE '" + valor + "%'";
            }
            else if (filtro.Equals("Nombre Completo"))
            {
                qry = "SELECT * FROM usuarios WHERE NombreCompleto LIKE '" + valor + "%'";
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
            limpiar();
            Listado();
        }


        public void habilitarBoton()
        {
            SqlConnection cn = new SqlConnection("Data Source=JUNIOR; Initial Catalog=SistemaInventario; integrated security=true");
            cn.Open();

            String qry = "";

             qry = "SELECT * FROM usuarios WHERE DescripcionRol LIKE 'ADMINISTRADOR'";

            btnEliminar.Visible = false;
            btnEditar.Visible = false;



            SqlDataAdapter adap = new SqlDataAdapter(qry, cn);

            DataTable dt = new DataTable();

            adap.Fill(dt);

            data.DataSource = dt;

            SqlCommand cm = new SqlCommand(qry, cn);

            SqlDataReader lc = cm.ExecuteReader();

            cn.Close();

        }
    }
}
