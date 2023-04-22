namespace CapaPresentacion
{
    partial class fmReportesProductos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.data2 = new System.Windows.Forms.DataGridView();
            this.cbxBuscar = new System.Windows.Forms.ComboBox();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.data1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.data2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(33, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(452, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reporte sobre Nuestro Inventarios ";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1237, 605);
            this.label2.TabIndex = 5;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // data2
            // 
            this.data2.BackgroundColor = System.Drawing.Color.White;
            this.data2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data2.Location = new System.Drawing.Point(30, 163);
            this.data2.Name = "data2";
            this.data2.RowHeadersWidth = 51;
            this.data2.RowTemplate.Height = 24;
            this.data2.Size = new System.Drawing.Size(484, 179);
            this.data2.TabIndex = 6;
            // 
            // cbxBuscar
            // 
            this.cbxBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbxBuscar.FormattingEnabled = true;
            this.cbxBuscar.Items.AddRange(new object[] {
            "Reporte en Excel Productos",
            "Reporte en Excel Categorias"});
            this.cbxBuscar.Location = new System.Drawing.Point(591, 181);
            this.cbxBuscar.Name = "cbxBuscar";
            this.cbxBuscar.Size = new System.Drawing.Size(379, 24);
            this.cbxBuscar.TabIndex = 7;
            // 
            // iconButton3
            // 
            this.iconButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            this.iconButton3.IconColor = System.Drawing.Color.Lime;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.Location = new System.Drawing.Point(579, 233);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(169, 88);
            this.iconButton3.TabIndex = 8;
            this.iconButton3.Text = "Exportar a Excel";
            this.iconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton3.UseVisualStyleBackColor = false;
            this.iconButton3.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // iconButton4
            // 
            this.iconButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            this.iconButton4.IconColor = System.Drawing.Color.DeepSkyBlue;
            this.iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton4.IconSize = 50;
            this.iconButton4.Location = new System.Drawing.Point(801, 233);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Size = new System.Drawing.Size(169, 88);
            this.iconButton4.TabIndex = 9;
            this.iconButton4.Text = "Obtener Grafico";
            this.iconButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton4.UseVisualStyleBackColor = false;
            this.iconButton4.Click += new System.EventHandler(this.iconButton4_Click);
            // 
            // data1
            // 
            this.data1.BackgroundColor = System.Drawing.Color.White;
            this.data1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data1.Location = new System.Drawing.Point(30, 348);
            this.data1.Name = "data1";
            this.data1.RowHeadersWidth = 51;
            this.data1.RowTemplate.Height = 24;
            this.data1.Size = new System.Drawing.Size(1183, 291);
            this.data1.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(454, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "REPORTE DE PRODUCTOS Y SUS DIFERENTES CATEGORIAS";
            // 
            // fmReportesProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1282, 791);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.data1);
            this.Controls.Add(this.iconButton4);
            this.Controls.Add(this.iconButton3);
            this.Controls.Add(this.cbxBuscar);
            this.Controls.Add(this.data2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "fmReportesProductos";
            this.Text = "fmReportes";
            this.Load += new System.EventHandler(this.fmReportesProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView data2;
        private System.Windows.Forms.ComboBox cbxBuscar;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton4;
        private System.Windows.Forms.DataGridView data1;
        private System.Windows.Forms.Label label3;
    }
}