namespace Sistema
{
    partial class frmReporteProveedores
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteProveedores));
            this.DataTable4BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Qkarne = new Sistema.Qkarne();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable4BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Qkarne)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable4BindingSource
            // 
            this.DataTable4BindingSource.DataMember = "DataTable4";
            this.DataTable4BindingSource.DataSource = this.Qkarne;
            // 
            // Qkarne
            // 
            this.Qkarne.DataSetName = "Qkarne";
            this.Qkarne.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DataTable4BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sistema.Report4.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(706, 513);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmReporteProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 513);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReporteProveedores";
            this.Text = "Reporte Proveedores";
            this.Load += new System.EventHandler(this.frmReporteProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable4BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Qkarne)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DataTable4BindingSource;
        private Qkarne Qkarne;
    }
}