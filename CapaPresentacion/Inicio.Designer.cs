namespace CapaPresentacion
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuTitulo = new System.Windows.Forms.MenuStrip();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuUsuarios = new FontAwesome.Sharp.IconMenuItem();
            this.menuMantenedor = new FontAwesome.Sharp.IconMenuItem();
            this.subCategoria = new FontAwesome.Sharp.IconMenuItem();
            this.subProductos = new FontAwesome.Sharp.IconMenuItem();
            this.menuProvedor = new FontAwesome.Sharp.IconMenuItem();
            this.menuReporte = new FontAwesome.Sharp.IconMenuItem();
            this.submenuReporteProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuReporteUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNegocio = new FontAwesome.Sharp.IconMenuItem();
            this.manuAcerca = new FontAwesome.Sharp.IconMenuItem();
            this.contenedor = new System.Windows.Forms.Panel();
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuTitulo
            // 
            this.menuTitulo.AutoSize = false;
            this.menuTitulo.BackColor = System.Drawing.Color.SteelBlue;
            this.menuTitulo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTitulo.Location = new System.Drawing.Point(0, 0);
            this.menuTitulo.Name = "menuTitulo";
            this.menuTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuTitulo.Size = new System.Drawing.Size(1301, 66);
            this.menuTitulo.TabIndex = 1;
            this.menuTitulo.Text = "menuStrip2";
            this.menuTitulo.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuTitulo_ItemClicked);
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuarios,
            this.menuMantenedor,
            this.menuProvedor,
            this.menuReporte,
            this.menuNegocio,
            this.manuAcerca});
            this.menu.Location = new System.Drawing.Point(0, 66);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1301, 73);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.AutoSize = false;
            this.menuUsuarios.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            this.menuUsuarios.IconColor = System.Drawing.Color.Black;
            this.menuUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuUsuarios.IconSize = 50;
            this.menuUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Size = new System.Drawing.Size(80, 69);
            this.menuUsuarios.Text = "Usuarios";
            this.menuUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuUsuarios.Click += new System.EventHandler(this.menuUsuarios_Click_1);
            // 
            // menuMantenedor
            // 
            this.menuMantenedor.AutoSize = false;
            this.menuMantenedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subCategoria,
            this.subProductos});
            this.menuMantenedor.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.menuMantenedor.IconColor = System.Drawing.Color.Black;
            this.menuMantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuMantenedor.IconSize = 50;
            this.menuMantenedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuMantenedor.Name = "menuMantenedor";
            this.menuMantenedor.Size = new System.Drawing.Size(152, 69);
            this.menuMantenedor.Text = "Mantenedor";
            this.menuMantenedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // subCategoria
            // 
            this.subCategoria.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subCategoria.IconColor = System.Drawing.Color.Black;
            this.subCategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subCategoria.Name = "subCategoria";
            this.subCategoria.Size = new System.Drawing.Size(224, 26);
            this.subCategoria.Text = "Categorias";
            this.subCategoria.Click += new System.EventHandler(this.subCategoria_Click);
            // 
            // subProductos
            // 
            this.subProductos.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subProductos.IconColor = System.Drawing.Color.Black;
            this.subProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subProductos.Name = "subProductos";
            this.subProductos.Size = new System.Drawing.Size(224, 26);
            this.subProductos.Text = "Productos";
            this.subProductos.Click += new System.EventHandler(this.subProductos_Click);
            // 
            // menuProvedor
            // 
            this.menuProvedor.AutoSize = false;
            this.menuProvedor.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.menuProvedor.IconColor = System.Drawing.Color.Black;
            this.menuProvedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuProvedor.IconSize = 50;
            this.menuProvedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuProvedor.Name = "menuProvedor";
            this.menuProvedor.Size = new System.Drawing.Size(152, 69);
            this.menuProvedor.Text = "Provedor";
            this.menuProvedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuProvedor.Click += new System.EventHandler(this.iconMenuItem1_Click);
            // 
            // menuReporte
            // 
            this.menuReporte.AutoSize = false;
            this.menuReporte.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuReporteProductos,
            this.submenuReporteUsuarios});
            this.menuReporte.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            this.menuReporte.IconColor = System.Drawing.Color.Black;
            this.menuReporte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuReporte.IconSize = 50;
            this.menuReporte.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuReporte.Name = "menuReporte";
            this.menuReporte.Size = new System.Drawing.Size(152, 69);
            this.menuReporte.Text = "Reportes";
            this.menuReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuReporte.Click += new System.EventHandler(this.menuReporte_Click);
            // 
            // submenuReporteProductos
            // 
            this.submenuReporteProductos.Name = "submenuReporteProductos";
            this.submenuReporteProductos.Size = new System.Drawing.Size(215, 26);
            this.submenuReporteProductos.Text = "Reporte Productos";
            this.submenuReporteProductos.Click += new System.EventHandler(this.submenuReporteProductos_Click);
            // 
            // submenuReporteUsuarios
            // 
            this.submenuReporteUsuarios.Name = "submenuReporteUsuarios";
            this.submenuReporteUsuarios.Size = new System.Drawing.Size(215, 26);
            this.submenuReporteUsuarios.Text = "Reporte Usuarios";
            this.submenuReporteUsuarios.Click += new System.EventHandler(this.submenuReporteUsuarios_Click);
            // 
            // menuNegocio
            // 
            this.menuNegocio.AutoSize = false;
            this.menuNegocio.IconChar = FontAwesome.Sharp.IconChar.Building;
            this.menuNegocio.IconColor = System.Drawing.Color.Black;
            this.menuNegocio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuNegocio.IconSize = 50;
            this.menuNegocio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuNegocio.Name = "menuNegocio";
            this.menuNegocio.Size = new System.Drawing.Size(152, 69);
            this.menuNegocio.Text = "Negocio";
            this.menuNegocio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuNegocio.Click += new System.EventHandler(this.menuNegocio_Click);
            // 
            // manuAcerca
            // 
            this.manuAcerca.AutoSize = false;
            this.manuAcerca.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.manuAcerca.IconColor = System.Drawing.Color.Black;
            this.manuAcerca.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.manuAcerca.IconSize = 50;
            this.manuAcerca.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manuAcerca.Name = "manuAcerca";
            this.manuAcerca.Size = new System.Drawing.Size(152, 69);
            this.manuAcerca.Text = "Acerca de";
            this.manuAcerca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.manuAcerca.Click += new System.EventHandler(this.manuAcerca_Click);
            // 
            // contenedor
            // 
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 139);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1301, 888);
            this.contenedor.TabIndex = 3;
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.BackColor = System.Drawing.Color.SteelBlue;
            this.lblUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarios.ForeColor = System.Drawing.Color.White;
            this.lblUsuarios.Location = new System.Drawing.Point(662, 20);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Size = new System.Drawing.Size(441, 40);
            this.lblUsuarios.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(529, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Usuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "SISTEMA DE INVENTARIO";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 1027);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblUsuarios);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menuTitulo);
            this.MainMenuStrip = this.menu;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuTitulo;
        private System.Windows.Forms.MenuStrip menu;
        private FontAwesome.Sharp.IconMenuItem menuUsuarios;
        private FontAwesome.Sharp.IconMenuItem manuAcerca;
        private FontAwesome.Sharp.IconMenuItem menuProvedor;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.Label lblUsuarios;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconMenuItem menuMantenedor;
        private FontAwesome.Sharp.IconMenuItem subCategoria;
        private FontAwesome.Sharp.IconMenuItem subProductos;
        private FontAwesome.Sharp.IconMenuItem menuReporte;
        private System.Windows.Forms.ToolStripMenuItem submenuReporteProductos;
        private System.Windows.Forms.ToolStripMenuItem submenuReporteUsuarios;
        private FontAwesome.Sharp.IconMenuItem menuNegocio;
        private System.Windows.Forms.Label label1;
    }
}

