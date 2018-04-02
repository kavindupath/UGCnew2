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
    public partial class TbondReport : Form
    {
        public TbondReport()
        {
            InitializeComponent();
        }

        private void TbondReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ugcdatabaseDataSet17.TreasureyBonds' table. You can move, or remove it, as needed.
            this.TreasureyBondsTableAdapter.Fill(this.ugcdatabaseDataSet17.TreasureyBonds);

            this.reportViewer1.RefreshReport();
            
        }
    }
}
