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
    public partial class report2 : Form
    {
        public report2()
        {
            InitializeComponent();
        }

        private void report2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ugcdatabaseDataSet15.sumtable' table. You can move, or remove it, as needed.
            this.sumtableTableAdapter.Fill(this.ugcdatabaseDataSet15.sumtable);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                using (ugcdatabaseDataSet15 ugcreport = new ugcdatabaseDataSet15())
                {
                    sumtableBindingSource.DataSource = ugcreport.DataSetName.ToList();
                    reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
