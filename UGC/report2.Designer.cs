namespace UGC
{
    partial class report2
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
            this.ugcdatabaseDataSet15 = new UGC.ugcdatabaseDataSet15();
            this.sumtableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sumtableTableAdapter = new UGC.ugcdatabaseDataSet15TableAdapters.sumtableTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ugcdatabaseDataSet15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sumtableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet3";
            reportDataSource1.Value = this.sumtableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UGC.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(85, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(618, 341);
            this.reportViewer1.TabIndex = 0;
            // 
            // ugcdatabaseDataSet15
            // 
            this.ugcdatabaseDataSet15.DataSetName = "ugcdatabaseDataSet15";
            this.ugcdatabaseDataSet15.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sumtableBindingSource
            // 
            this.sumtableBindingSource.DataMember = "sumtable";
            this.sumtableBindingSource.DataSource = this.ugcdatabaseDataSet15;
            // 
            // sumtableTableAdapter
            // 
            this.sumtableTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(136, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "load data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // report2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 399);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "report2";
            this.Text = "report2";
            this.Load += new System.EventHandler(this.report2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ugcdatabaseDataSet15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sumtableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sumtableBindingSource;
        private ugcdatabaseDataSet15 ugcdatabaseDataSet15;
        private ugcdatabaseDataSet15TableAdapters.sumtableTableAdapter sumtableTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}