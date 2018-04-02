using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace UGC
{
    public partial class TbillnewReport : Form
    {
        public TbillnewReport()
        {
            InitializeComponent();
        }

        private void TbillnewReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ugcdatabaseDataSet25.Bills' table. You can move, or remove it, as needed.
            this.BillsTableAdapter.Fill(this.ugcdatabaseDataSet25.Bills);

            this.reportViewer1.RefreshReport();
        }
    }
}
