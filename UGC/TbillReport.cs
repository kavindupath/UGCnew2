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
    public partial class TbillReport : Form
    {
        public TbillReport()
        {
            InitializeComponent();
        }

        private void TbillReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ugcdatabaseDataSet24.Bills' table. You can move, or remove it, as needed.
            this.BillsTableAdapter.Fill(this.ugcdatabaseDataSet24.Bills);

            this.reportViewer1.RefreshReport();
        }
    }
}
