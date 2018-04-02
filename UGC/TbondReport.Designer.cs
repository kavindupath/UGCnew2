namespace UGC
{
    partial class TbondReport
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
            this.ugcdatabaseDataSet17 = new UGC.ugcdatabaseDataSet17();
            this.TreasureyBondsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TreasureyBondsTableAdapter = new UGC.ugcdatabaseDataSet17TableAdapters.TreasureyBondsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ugcdatabaseDataSet17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TreasureyBondsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.TreasureyBondsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UGC.TbondReportrdlc.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(416, 312);
            this.reportViewer1.TabIndex = 0;
            // 
            // ugcdatabaseDataSet17
            // 
            this.ugcdatabaseDataSet17.DataSetName = "ugcdatabaseDataSet17";
            this.ugcdatabaseDataSet17.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TreasureyBondsBindingSource
            // 
            this.TreasureyBondsBindingSource.DataMember = "TreasureyBonds";
            this.TreasureyBondsBindingSource.DataSource = this.ugcdatabaseDataSet17;
            // 
            // TreasureyBondsTableAdapter
            // 
            this.TreasureyBondsTableAdapter.ClearBeforeFill = true;
            // 
            // TbondReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 336);
            this.Controls.Add(this.reportViewer1);
            this.Name = "TbondReport";
            this.Text = "TbondReport";
            this.Load += new System.EventHandler(this.TbondReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ugcdatabaseDataSet17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TreasureyBondsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource TreasureyBondsBindingSource;
        private ugcdatabaseDataSet17 ugcdatabaseDataSet17;
        private ugcdatabaseDataSet17TableAdapters.TreasureyBondsTableAdapter TreasureyBondsTableAdapter;
    }
}