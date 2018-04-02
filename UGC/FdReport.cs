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
    public partial class FdReport : Form
    {
        public FdReport()
        {
            InitializeComponent();
        }

        private void FdReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ugcdatabaseDataSet19.FD' table. You can move, or remove it, as needed.
            this.FDTableAdapter.Fill(this.ugcdatabaseDataSet19.FD);

            this.reportViewer1.RefreshReport();
        }
    }
}
