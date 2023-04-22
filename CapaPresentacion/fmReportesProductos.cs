using CapaNegocio;
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
using System.Windows.Forms;
using CapaNegocio;
using System.Data.SqlClient;

using System.Windows.Markup;
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;
using System;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.IO;
using DocumentFormat.OpenXml.Bibliography;
using iTextSharp.tool.xml;
using DataTable = System.Data.DataTable;
using Chart = System.Windows.Forms.DataVisualization.Charting.Chart;
using Title = System.Windows.Forms.DataVisualization.Charting.Title;
using Font = System.Drawing.Font;

namespace CapaPresentacion
{
    public partial class fmReportesProductos : Form
    {
        public fmReportesProductos()
        {
            InitializeComponent();
        }

        private void fmReportesProductos_Load(object sender, EventArgs e)
        {
            ListadoC();
            ListadoP();
        }

        CN_Categoria Ct = CN_Categoria.Instance;

        CN_Productos pr = CN_Productos.Instance;
        public void ListadoP()
        {


            DataTable dt = pr.listado();

            data1.DataSource = dt;


        }
        public void ListadoC()
        {


            DataTable dt = Ct.listado();

            data2.DataSource = dt;


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



        public void ExcelCategoria()
        {




            if (data2.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos por exportar");
            }
            else
            {
                DataTable dt = new DataTable();

                foreach (DataGridViewColumn column in data2.Columns)
                {
                    if (column.HeaderText != "" && column.Visible)
                    {
                        dt.Columns.Add(column.HeaderText, typeof(string));
                    }
                }

                foreach (DataGridViewRow row in data2.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        dt.Rows.Add(new object[] {
                         row.Cells[0].Value.ToString(),
                         row.Cells[1].Value.ToString(),
                           row.Cells[2].Value.ToString(),

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
                        var hoja = wb.Worksheets.Add(dt, "Informe de Categoria");

                        // Agregar encabezado o título
                        hoja.Row(1).InsertRowsAbove(1);
                        hoja.Cell("A1").Value = "Reporte de Categorias";
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

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (cbxBuscar.Text == "Reporte en Excel Productos")
            {

                ExcelProducto();

            }
            else if (cbxBuscar.Text == "Reporte en Excel Categorias")
            {

                ExcelCategoria();

            }else
            {

                MessageBox.Show("Por favor Seleciones el Reporte que decee", "Completar el campo", MessageBoxButtons.OK, MessageBoxIcon.Information);




            }
        }


       



        public void GraficoProductos()
        {
           

              // Creamos un diccionario para almacenar la cantidad de productos por tipo
                Dictionary<string, int> cantidadPorTipo = new Dictionary<string, int>();

                // Recorremos las filas del DataGridView y vamos sumando las cantidades por tipo
                foreach (DataGridViewRow row in data1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                    {
                        string tipoProducto = row.Cells[1].Value.ToString();
                        int cantidad = 0;

                        if (row.Cells[4].Value != null)
                        {
                            int.TryParse(row.Cells[4].Value.ToString(), out cantidad);
                        }

                        if (cantidadPorTipo.ContainsKey(tipoProducto))
                        {
                            cantidadPorTipo[tipoProducto] += cantidad;
                        }
                        else
                        {
                            cantidadPorTipo.Add(tipoProducto, cantidad);
                        }
                    }
                }

                // Creamos el gráfico de barras
                var chart = new Chart();
                chart.Width = 800;
                chart.Height = 600;
                chart.Titles.Add(new Title("Cantidad de productos por tipo", Docking.Top, new Font("Arial", 14, FontStyle.Bold), Color.Black));

                var chartArea = new ChartArea();
                chartArea.AxisX.Interval = 1;
                chartArea.AxisX.Title = "Tipo de producto";
                chartArea.AxisY.Title = "Cantidad";
                chart.ChartAreas.Add(chartArea);

                var series = new Series();
                series.ChartType = SeriesChartType.Column;
                series.Color = Color.Blue;

                foreach (var item in cantidadPorTipo)
                {
                    series.Points.AddXY(item.Key, item.Value);
                }

                chart.Series.Add(series);

                // Mostramos el gráfico en un formulario
                var form = new Form();
                form.Width = 800;
                form.Height = 600;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Controls.Add(chart);
                form.ShowDialog();

                // Guardamos el gráfico como imagen
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("GraficoProductos_{0}.png", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "PNG Files|*.png";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        chart.SaveImage(savefile.FileName, ChartImageFormat.Png);
                        MessageBox.Show("Gráfico guardado como imagen");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar gráfico: " + ex.Message);
                    }
                }
            





        }

        private void iconButton4_Click(object sender, EventArgs e)
        {

           // GraficoCategoria();

            GraficoProductos();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
