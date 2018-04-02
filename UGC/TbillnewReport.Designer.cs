namespace UGC
{
    partial class TbillnewReport
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
            this.ugcdatabaseDataSet25 = new UGC.ugcdatabaseDataSet25();
            this.BillsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BillsTableAdapter = new UGC.ugcdatabaseDataSet25TableAdapters.BillsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ugcdatabaseDataSet25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.BillsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UGC.TbillnewrReportRDLC.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(830, 430);
            this.reportViewer1.TabIndex = 0;
            // 
            // ugcdatabaseDataSet25
            // 
            this.ugcdatabaseDataSet25.DataSetName = "ugcdatabaseDataSet25";
            this.ugcdatabaseDataSet25.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BillsBindingSource
            // 
            this.BillsBindingSource.DataMember = "Bills";
            this.BillsBindingSource.DataSource = this.ugcdatabaseDataSet25;
            // 
            // BillsTableAdapter
            // 
            this.BillsTableAdapter.ClearBeforeFill = true;
            // 
            // TbillnewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 476);
            this.Controls.Add(this.reportViewer1);
            this.Name = "TbillnewReport";
            this.Text = "TbillnewReport";
            this.Load += new System.EventHandler(this.TbillnewReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ugcdatabaseDataSet25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BillsBindingSource;
        private ugcdatabaseDataSet25 ugcdatabaseDataSet25;
        private ugcdatabaseDataSet25TableAdapters.BillsTableAdapter BillsTableAdapter;
    }
}