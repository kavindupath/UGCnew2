namespace UGC
{
    partial class TbillReport
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
            this.BillsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ugcdatabaseDataSet24 = new UGC.ugcdatabaseDataSet24();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BillsTableAdapter = new UGC.ugcdatabaseDataSet24TableAdapters.BillsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.BillsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugcdatabaseDataSet24)).BeginInit();
            this.SuspendLayout();
            // 
            // BillsBindingSource
            // 
            this.BillsBindingSource.DataMember = "Bills";
            this.BillsBindingSource.DataSource = this.ugcdatabaseDataSet24;
            // 
            // ugcdatabaseDataSet24
            // 
            this.ugcdatabaseDataSet24.DataSetName = "ugcdatabaseDataSet24";
            this.ugcdatabaseDataSet24.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.BillsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UGC.TbillReportRDLC.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 32);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(840, 434);
            this.reportViewer1.TabIndex = 0;
            // 
            // BillsTableAdapter
            // 
            this.BillsTableAdapter.ClearBeforeFill = true;
            // 
            // TbillReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 494);
            this.Controls.Add(this.reportViewer1);
            this.Name = "TbillReport";
            this.Text = "TbillReport";
            this.Load += new System.EventHandler(this.TbillReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BillsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugcdatabaseDataSet24)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BillsBindingSource;
        private ugcdatabaseDataSet24 ugcdatabaseDataSet24;
        private ugcdatabaseDataSet24TableAdapters.BillsTableAdapter BillsTableAdapter;
    }
}