
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Data;
using System.Data.SqlClient;


using CapaNegocio;
using ClosedXML.Excel;
using System;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.IO;
using DocumentFormat.OpenXml.Bibliography;
using iTextSharp.tool.xml;
using ClosedXML.Excel;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;
using CapaEntidad;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    public partial class fmProductos : Form
    {
        private Usuarios usuarioActual;

     
        public fmProductos(Usuarios objusuarios)
        {
            InitializeComponent();

            usuarioActual = objusuarios;

           


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






        private void fmProductos_Load(object sender, EventArgs e)
        {
            Listado();

            if (usuarioActual != null && usuarioActual.IdRol != 1)
            {
                OcultarBotones();
            }

           
        }
        CN_Productos pr = CN_Productos.Instance;
        public void Listado()
        {

            
            DataTable dt = pr.listado();

            data.DataSource = dt;


        }




        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // guardar

           // int idC = int.Parse(txtIdCategoria.Text = data.CurrentRow.Cells[8].Value.ToString());

            int idCant = int.Parse(txtCantidad.Text);

            if (txtCantidad.Text == ""|| txtNombre.Text == ""||   cbxEstado.Text == "" || txtId.Text == "" || cbxDescripcion.Text == "")
            {

                MessageBox.Show("Por favor complete los datos", "Faltan Campos por llenar", MessageBoxButtons.OK, MessageBoxIcon.Information);

             




            }
            else
            {

                int idC=0;

                if (cbxDescripcion.SelectedItem.ToString() == "Lacteos")
                {
                    idC = 1;
                }
                else if (cbxDescripcion.SelectedItem.ToString() == "Embutido")
                {
                    idC = 3;
                }
                else if (cbxDescripcion.SelectedItem.ToString() == "Enlatados")
                {
                    idC = 4;
                }
                else if (cbxDescripcion.SelectedItem.ToString() == "Comida")
                {
                    idC = 5;
                }
                else if (cbxDescripcion.SelectedItem.ToString() == "Bebida")
                {
                    idC = 6;
                }





                pr.InsertarProductos(txtCodigo.Text, txtNombre.Text, cbxDescripcion.SelectedItem.ToString(), idC, idCant, txtPrecioC.Text, txtPrecioV.Text, cbxEstado.SelectedItem.ToString());

                Listado();

            }



            limpiar();
        }




        private void limpiar()
        {
            txtIdCategoria.Text = "";
            txtId.Text = "";
            cbxDescripcion.Text = "";
            cbxEstado.Text = "";
            txtCantidad.Text = "";
            txtCodigo.Text = "";        
            txtNombre.Text = "";   
            txtPrecioC.Text = "";
            txtPrecioV.Text = "";
            txtBuscar.Text = "";
            cbxBuscar.SelectedItem = "";

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // editar 

            if (txtCantidad.Text == "" || txtNombre.Text == "" || cbxEstado.Text == "" || txtId.Text == "" || cbxDescripcion.Text == "")
            {

                MessageBox.Show("Selecione los Campos", "Vuelve  a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                int idC = int.Parse(txtIdCategoria.Text = data.CurrentRow.Cells[8].Value.ToString());

                int id = int.Parse(txtId.Text = data.CurrentRow.Cells[0].Value.ToString());

                int idCant = int.Parse(txtCantidad.Text = data.CurrentRow.Cells[4].Value.ToString());


                pr.ModificarProductos (id,txtNombre.Text, txtNombre.Text, cbxDescripcion.SelectedItem.ToString(), idC, idCant, txtPrecioC.Text, txtPrecioV.Text, cbxEstado.SelectedItem.ToString());


                Listado();

            }
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text = data.CurrentRow.Cells[0].Value.ToString());


            if (txtCantidad.Text == "" || txtNombre.Text == "" || txtId.Text == ""|| cbxEstado.Text == "")
            {

                MessageBox.Show("Selecione los Campos", "Vuelve  a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                pr.EliminarProductos(id);

                Listado();

            }

            limpiar();
        }

        private void data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = data.CurrentRow.Cells[0].Value.ToString();
            txtCodigo.Text = data.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = data.CurrentRow.Cells[2].Value.ToString();
            cbxDescripcion.Text = data.CurrentRow.Cells[3].Value.ToString();
           txtCantidad.Text = data.CurrentRow.Cells[4].Value.ToString();

            txtPrecioC.Text = data.CurrentRow.Cells[5].Value.ToString();

          
            
            
            txtPrecioV.Text = data.CurrentRow.Cells[6].Value.ToString();
            cbxEstado.Text = data.CurrentRow.Cells[7].Value.ToString();
            txtIdCategoria.Text = data.CurrentRow.Cells[8].Value.ToString();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //ndaklncdsknvlksv

            //////////////dddddddddddd njbdk   jnkbk   kjbkbk   knkj
            ///


            if (data.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos por exportar");
            }
            else
            {
                DataTable dt = new DataTable();

                foreach (DataGridViewColumn column in data.Columns)
                {
                    if (column.HeaderText != "" && column.Visible)
                    {
                        dt.Columns.Add(column.HeaderText, typeof(string));
                    }
                }

                foreach (DataGridViewRow row in data.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[] {
                row.Cells[0].Value.ToString(),
                row.Cells[1].Value.ToString(),
                row.Cells[2].Value.ToString(),
                row.Cells[3].Value.ToString(),
                row.Cells[4].Value.ToString(),
                row.Cells[5].Value.ToString(),
                row.Cells[6].Value.ToString(),
                row.Cells[7].Value.ToString(),
                row.Cells[8].Value.ToString()
            });
                    }
                }

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteProductos_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files|*.xlsx";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe de Productos");

                        // Agregar encabezado o título
                        hoja.Row(1).InsertRowsAbove(1);
                        hoja.Cell("A1").Value = "Reporte de Productos";
                        hoja.Range("A1:I1").Merge();
                        hoja.Cell("A1").Style.Font.Bold = true;
                        hoja.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte generado");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al generar reporte: " + ex.Message);
                    }
                }
            }






        }

        private void button1_Click(object sender, EventArgs e)
        {




            SaveFileDialog save = new SaveFileDialog(); 
            save.FileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + "*.pdf";
           

            string paginahtml = "<table bo><tr><td>HOLA MUNDO</td></tr></table>";

            if (save.ShowDialog() == DialogResult.OK)
            {
                using (FileStream strean = new FileStream(save.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, strean);

                    pdfDoc.Open();

                    pdfDoc.Add(new Phrase(""));

                    using (StreamReader sr  = new StreamReader(paginahtml)) {

                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);


                    }

                    pdfDoc.Close();

                    strean.Close();

                }

            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblUsu_Click(object sender, EventArgs e)
        {

        }

       

        private void lblc_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblcl_Click(object sender, EventArgs e)
        {

        }

        private void txtPrecioC_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtPrecioV_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cbxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

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

            if (filtro.Equals("Nombre"))
            {
                qry = "SELECT * FROM productos WHERE nombre LIKE '" + valor + "%'";
            }
            else if (filtro.Equals("Descripcion"))
            {
                qry = "SELECT * FROM productos WHERE Descripcion LIKE '" + valor + "%'";
            }
            else if (filtro.Equals("Precio Compra"))
            {
                qry = "SELECT * FROM productos WHERE PrecioCompra LIKE '" + valor + "%'";
            }
            else if (filtro.Equals("Precio Venta"))
            {
                qry = "SELECT * FROM productos WHERE PrecioVenta LIKE '" + valor + "%'";
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


       
    }
}
