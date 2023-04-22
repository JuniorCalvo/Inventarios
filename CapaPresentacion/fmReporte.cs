using CapaNegocio;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace CapaPresentacion
{
    public partial class fmReporte : Form
    {
        public fmReporte()
        {
            InitializeComponent();
        }

        CN_Usuarios Ng = CN_Usuarios.Instance;

        private void fmReporte_Load(object sender, EventArgs e)
        {

            DataTable dt = Ng.listado();




            Listado();
        }

        public void Listado()
        {

            CN_Usuarios objectoN = CN_Usuarios.Instance;
            DataTable dt = objectoN.listado();

            data1.DataSource = dt;


        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ExcelProducto();
        }


        public void ExcelProducto()
        {

            if (data1.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos por exportar");
            }
            else
            {
                DataTable dt = new DataTable();

                foreach (DataGridViewColumn column in data1.Columns)
                {
                    if (column.HeaderText != "" && column.Visible)
                    {
                        dt.Columns.Add(column.HeaderText, typeof(string));
                    }
                }

                foreach (DataGridViewRow row in data1.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        dt.Rows.Add(new object[] {
                             row.Cells[0].Value.ToString(),
                             row.Cells[1].Value.ToString(),
                             row.Cells[2].Value.ToString(),
                              row.Cells[3].Value.ToString(),
                              row.Cells[4].Value.ToString(),
                             row.Cells[5].Value.ToString(),
                              row.Cells[6].Value.ToString(),

                     });
                    }
                }

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteUsuarios_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files|*.xlsx";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe de Usuarios");

                        // Agregar encabezado o título
                        hoja.Row(1).InsertRowsAbove(1);
                        hoja.Cell("A1").Value = "Reporte de Usuarios";
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

    }
}
