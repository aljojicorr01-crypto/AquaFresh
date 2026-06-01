namespace SistemaAquaFresh_1._0._0.Formularios
{
    partial class frmReportes
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reporteDeVentasGeneralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDePagosPendientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasEnEfectivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasEnDepositoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarReporteVentaEnEfectivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarReporteVentaDepositosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasGeneralesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarReporteGeneralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarPagosPendientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarReportePagosPendientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEditEstadoVenta = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteDeVentasGeneralToolStripMenuItem,
            this.reporteDePagosPendientesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reporteDeVentasGeneralToolStripMenuItem
            // 
            this.reporteDeVentasGeneralToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasEnEfectivoToolStripMenuItem,
            this.ventasEnDepositoToolStripMenuItem,
            this.ventasGeneralesToolStripMenuItem});
            this.reporteDeVentasGeneralToolStripMenuItem.Name = "reporteDeVentasGeneralToolStripMenuItem";
            this.reporteDeVentasGeneralToolStripMenuItem.Size = new System.Drawing.Size(156, 20);
            this.reporteDeVentasGeneralToolStripMenuItem.Text = "Reporte de Ventas General";
            // 
            // reporteDePagosPendientesToolStripMenuItem
            // 
            this.reporteDePagosPendientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualizarPagosPendientesToolStripMenuItem});
            this.reporteDePagosPendientesToolStripMenuItem.Name = "reporteDePagosPendientesToolStripMenuItem";
            this.reporteDePagosPendientesToolStripMenuItem.Size = new System.Drawing.Size(172, 20);
            this.reporteDePagosPendientesToolStripMenuItem.Text = "Reporte de Pagos Pendientes";
            // 
            // ventasEnEfectivoToolStripMenuItem
            // 
            this.ventasEnEfectivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarReporteVentaEnEfectivoToolStripMenuItem});
            this.ventasEnEfectivoToolStripMenuItem.Name = "ventasEnEfectivoToolStripMenuItem";
            this.ventasEnEfectivoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ventasEnEfectivoToolStripMenuItem.Text = "Ventas en Efectivo";
            this.ventasEnEfectivoToolStripMenuItem.Click += new System.EventHandler(this.ventasEnEfectivoToolStripMenuItem_Click);
            // 
            // ventasEnDepositoToolStripMenuItem
            // 
            this.ventasEnDepositoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarReporteVentaDepositosToolStripMenuItem});
            this.ventasEnDepositoToolStripMenuItem.Name = "ventasEnDepositoToolStripMenuItem";
            this.ventasEnDepositoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ventasEnDepositoToolStripMenuItem.Text = "Ventas en Deposito";
            this.ventasEnDepositoToolStripMenuItem.Click += new System.EventHandler(this.ventasEnDepositoToolStripMenuItem_Click);
            // 
            // generarReporteVentaEnEfectivoToolStripMenuItem
            // 
            this.generarReporteVentaEnEfectivoToolStripMenuItem.Name = "generarReporteVentaEnEfectivoToolStripMenuItem";
            this.generarReporteVentaEnEfectivoToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.generarReporteVentaEnEfectivoToolStripMenuItem.Text = "Generar Reporte Venta En efectivo";
            this.generarReporteVentaEnEfectivoToolStripMenuItem.Click += new System.EventHandler(this.generarReporteVentaEnEfectivoToolStripMenuItem_Click);
            // 
            // generarReporteVentaDepositosToolStripMenuItem
            // 
            this.generarReporteVentaDepositosToolStripMenuItem.Name = "generarReporteVentaDepositosToolStripMenuItem";
            this.generarReporteVentaDepositosToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.generarReporteVentaDepositosToolStripMenuItem.Text = "Generar Reporte Venta Depositos";
            // 
            // ventasGeneralesToolStripMenuItem
            // 
            this.ventasGeneralesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarReporteGeneralToolStripMenuItem});
            this.ventasGeneralesToolStripMenuItem.Name = "ventasGeneralesToolStripMenuItem";
            this.ventasGeneralesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ventasGeneralesToolStripMenuItem.Text = "Ventas Generales";
            this.ventasGeneralesToolStripMenuItem.Click += new System.EventHandler(this.ventasGeneralesToolStripMenuItem_Click);
            // 
            // generarReporteGeneralToolStripMenuItem
            // 
            this.generarReporteGeneralToolStripMenuItem.Name = "generarReporteGeneralToolStripMenuItem";
            this.generarReporteGeneralToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.generarReporteGeneralToolStripMenuItem.Text = "Generar Reporte General";
            this.generarReporteGeneralToolStripMenuItem.Click += new System.EventHandler(this.generarReporteGeneralToolStripMenuItem_Click);
            // 
            // visualizarPagosPendientesToolStripMenuItem
            // 
            this.visualizarPagosPendientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarReportePagosPendientesToolStripMenuItem});
            this.visualizarPagosPendientesToolStripMenuItem.Name = "visualizarPagosPendientesToolStripMenuItem";
            this.visualizarPagosPendientesToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.visualizarPagosPendientesToolStripMenuItem.Text = "Visualizar Pagos Pendientes";
            this.visualizarPagosPendientesToolStripMenuItem.Click += new System.EventHandler(this.visualizarPagosPendientesToolStripMenuItem_Click);
            // 
            // generarReportePagosPendientesToolStripMenuItem
            // 
            this.generarReportePagosPendientesToolStripMenuItem.Name = "generarReportePagosPendientesToolStripMenuItem";
            this.generarReportePagosPendientesToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.generarReportePagosPendientesToolStripMenuItem.Text = "Generar Reporte Pagos Pendientes";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 270);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnEditEstadoVenta
            // 
            this.btnEditEstadoVenta.AutoSize = true;
            this.btnEditEstadoVenta.Location = new System.Drawing.Point(12, 353);
            this.btnEditEstadoVenta.Name = "btnEditEstadoVenta";
            this.btnEditEstadoVenta.Size = new System.Drawing.Size(99, 23);
            this.btnEditEstadoVenta.TabIndex = 2;
            this.btnEditEstadoVenta.Text = "Editar Estado";
            this.btnEditEstadoVenta.UseVisualStyleBackColor = true;
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEditEstadoVenta);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmReportes";
            this.Text = "Menú de Reportes";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reporteDeVentasGeneralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasEnEfectivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasEnDepositoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDePagosPendientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarReporteVentaEnEfectivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarReporteVentaDepositosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasGeneralesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarReporteGeneralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarPagosPendientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarReportePagosPendientesToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEditEstadoVenta;
    }
}