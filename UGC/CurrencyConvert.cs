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
    public partial class CurrencyConvert : Form
    {
        public CurrencyConvert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.cbsl.gov.lk/htm/english/_cei/er/e_1.asp");
        }
    }
}
