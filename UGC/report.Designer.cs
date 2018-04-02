namespace UGC
{
    partial class report
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
            this.ugcdatabaseDataSet14 = new UGC.ugcdatabaseDataSet14();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BillsTableAdapter = new UGC.ugcdatabaseDataSet14TableAdapters.BillsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.BillsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugcdatabaseDataSet14)).BeginInit();
            this.SuspendLayout();
            // 
            // BillsBindingSource
            // 
            this.BillsBindingSource.DataMember = "Bills";
            this.BillsBindingSource.DataSource = this.ugcdatabaseDataSet14;
            // 
            // ugcdatabaseDataSet14
            // 
            this.ugcdatabaseDataSet14.DataSetName = "ugcdatabaseDataSet14";
            this.ugcdatabaseDataSet14.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(200, 148);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.BillsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UGC.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(532, 410);
            this.reportViewer1.TabIndex = 1;
            // 
            // BillsTableAdapter
            // 
            this.BillsTableAdapter.ClearBeforeFill = true;
            // 
            // report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 448);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.radioButton1);
            this.Name = "report";
            this.Text = "report";
            this.Load += new System.EventHandler(this.report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BillsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugcdatabaseDataSet14)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BillsBindingSource;
        private ugcdatabaseDataSet14 ugcdatabaseDataSet14;
        private ugcdatabaseDataSet14TableAdapters.BillsTableAdapter BillsTableAdapter;
    }
}