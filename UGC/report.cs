using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UGC
{
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
        }

        private void report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ugcdatabaseDataSet14.Bills' table. You can move, or remove it, as needed.
            this.BillsTableAdapter.Fill(this.ugcdatabaseDataSet14.Bills);

            this.reportViewer1.RefreshReport();
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            try
            {

                using (ugcdatabaseDataSet14 ugcreport = new ugcdatabaseDataSet14())
                {
                    BillsBindingSource.DataSource = ugcreport.DataSetName.ToList();
                    reportViewer1.RefreshReport();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
