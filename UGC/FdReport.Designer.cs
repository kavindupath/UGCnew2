namespace UGC
{
    partial class FdReport
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ugcdatabaseDataSet19 = new UGC.ugcdatabaseDataSet19();
            this.FDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FDTableAdapter = new UGC.ugcdatabaseDataSet19TableAdapters.FDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ugcdatabaseDataSet19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FDBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "datasetfd";
            reportDataSource1.Value = this.FDBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UGC.FdReportrdlc.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(702, 489);
            this.reportViewer1.TabIndex = 0;
            // 
            // ugcdatabaseDataSet19
            // 
            this.ugcdatabaseDataSet19.DataSetName = "ugcdatabaseDataSet19";
            this.ugcdatabaseDataSet19.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FDBindingSource
            // 
            this.FDBindingSource.DataMember = "FD";
            this.FDBindingSource.DataSource = this.ugcdatabaseDataSet19;
            // 
            // FDTableAdapter
            // 
            this.FDTableAdapter.ClearBeforeFill = true;
            // 
            // FdReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 513);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FdReport";
            this.Text = "FdReport";
            this.Load += new System.EventHandler(this.FdReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ugcdatabaseDataSet19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FDBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource FDBindingSource;
        private ugcdatabaseDataSet19 ugcdatabaseDataSet19;
        private ugcdatabaseDataSet19TableAdapters.FDTableAdapter FDTableAdapter;
    }
}