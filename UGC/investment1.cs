using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Configuration;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

using iTextSharp.text.pdf.parser;

namespace UGC
{
    public partial class investment1 : Form
    {
        public investment1()
        {

            InitializeComponent();
            timer2.Start();

           
        }

       

       
        

        private void btntbill_Click(object sender, EventArgs e)
        {
            Tbill t1 = new Tbill();
            t1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void investment1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ugcdatabaseDataSet12.sumofinvestmnets4' table. You can move, or remove it, as needed.
            this.sumofinvestmnets4TableAdapter.Fill(this.ugcdatabaseDataSet12.sumofinvestmnets4);
            // TODO: This line of code loads data into the 'ugcdatabaseDataSet11.sumofinvestmnets3' table. You can move, or remove it, as needed.
            this.sumofinvestmnets3TableAdapter.Fill(this.ugcdatabaseDataSet11.sumofinvestmnets3);

            // TODO: This line of code loads data into the 'ugcdatabaseDataSet9.Bills' table. You can move, or remove it, as needed.
            // this.billsTableAdapter.Fill(this.ugcdatabaseDataSet9.Bills);
            comboBox1.Items.Clear();


            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            string query6 ="select InvestmentId,Description from bills where (SettlementDate-(select CURDATE())<10)";

            string query7 = "select BranchCode,NameOfTheInstitute from fd where (MaturityDate-CURRENT_DATE)<10 ";
            string query8 = "select * from TreasureyBonds where (DateOfMature-CURRENT_DATE)<10";
            //string query9 = "select [Investment ID],Description from Bills ";
            string query10 = "select SUM(PurchasePrice) from bills as sumofbills";
            string query11 = "select SUM(Amount) from FD as sumoffd ";
            string query12 = "select SUM(Price) from TreasureyBonds as sumoftbonds";

            MySqlDataAdapter sda1 = new MySqlDataAdapter(query6, ugccon);
            MySqlDataAdapter sda2 = new MySqlDataAdapter(query7, ugccon);
            MySqlDataAdapter sda3 = new MySqlDataAdapter(query8, ugccon);
            MySqlDataAdapter sda10 = new MySqlDataAdapter(query10, ugccon);
            MySqlDataAdapter sda11 = new MySqlDataAdapter(query11, ugccon);
            MySqlDataAdapter sda12 = new MySqlDataAdapter(query12, ugccon);

            //string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon2 = new MySqlConnection(connectionString);            //for the chart load
            MySqlCommand cmddatabase = new MySqlCommand("select * from sumofinvestmnets4;", ugccon2);
            MySqlDataReader myreader;



            DataTable d1 = new DataTable();
            sda1.Fill(d1);
            DataTable d2 = new DataTable();
            sda2.Fill(d2);
            DataTable d3 = new DataTable();
            sda3.Fill(d3);
            DataTable d10 = new DataTable();
            sda10.Fill(d10);
            DataTable d11 = new DataTable();
            sda11.Fill(d11);
            DataTable d12 = new DataTable();
            sda12.Fill(d12);

            
         


            if (d1 != null)
            {
                if (d1.Rows.Count >= 1)
                {
                    notifyIcon1.Icon = SystemIcons.Application;
                    notifyIcon1.BalloonTipText = "You have  Treasurey Bills that mature in a nearby date!";
                    notifyIcon1.ShowBalloonTip(100);

                    timer1.Start();
                    timer1.Enabled = true;
                  
                    //   label1.BackColor = Color.FromArgb(255, 0, 0);
                    // pictureBox1.BackColor = Color.FromArgb(255, 0, 0);
                    pictureBox1.Show();





                }
            }


            //DataTable d2 = new DataTable();
            //sda2.Fill(d2);
           
            if (d2 != null)
            {
                if (d2.Rows.Count >= 1)
                {
                    notifyIcon2.Icon = SystemIcons.Application;
                    notifyIcon2.BalloonTipText = "You have Fixed Deposits to be expired soon!";
                    notifyIcon2.ShowBalloonTip(100);
                    pictureBox3.Show();
                }
            }


            if (d3 != null)
            {
                if (d3.Rows.Count >= 1)
                {
                    notifyIcon3.Icon = SystemIcons.Application;
                    notifyIcon3.BalloonTipText = "You have Treasurey bonds to be expired soon!";
                    notifyIcon3.ShowBalloonTip(100);
                    pictureBox4.Show();
                }
            }


            try
            {
                MySqlDataAdapter sda4 = new MySqlDataAdapter(query6, ugccon);
                MySqlDataAdapter sda5 = new MySqlDataAdapter(query7, ugccon);
                MySqlDataAdapter sda6 = new MySqlDataAdapter(query8, ugccon);
                DataTable d4 = new DataTable();
                DataTable tbond = new DataTable();
                sda4.Fill(d4);
                sda5.Fill(d4);
                sda6.Fill(tbond);


                foreach (DataRow dr in d4.Rows)
                {
                    comboBox1.Items.Add(dr["InvestmentId"]);
                    comboBox1.Items.Add(dr["Description"]);
                    comboBox1.Items.Add("-------------------------------------------");

                    comboBox1.Items.Add(dr["BranchCode"]);
                    comboBox1.Items.Add(dr["NameOfTheInstitute"]);
                    comboBox1.Items.Add("-------------------------------------------");
                }
                foreach (DataRow dr2 in tbond.Rows)
                {
                    comboBox1.Items.Add("Treasurey bonds");
                    comboBox1.Items.Add(dr2["BranchCode"]);
                    comboBox1.Items.Add(dr2["NameOfTheInstitute"]);
                    comboBox1.Items.Add("-------------------------------------------");
                }

                

                ugccon2.Open();
                myreader = cmddatabase.ExecuteReader();

                while (myreader.Read())
                {
                    this.chart2.Series["summaziation"].Points.AddXY(myreader.GetString("NameOfTitle"), myreader.GetInt32("summaziation"));
                    this.chart3.Series["SumOfInterest"].Points.AddXY(myreader.GetString("NameOfTitle"), myreader.GetDouble("SumOfInterest"));
                }





            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string celld10 = d10.Rows[0][0].ToString();
            string celld11 = d11.Rows[0][0].ToString();
            string celld12 = d12.Rows[0][0].ToString();

                                 //DataTable portfolio = new DataTable();
            //portfolio.Rows[1][1] = celld10;
            //portfolio.Rows[1][2] = celld11;
            //portfolio.Rows[1][3] = celld12;

                                  //portfolio.Columns.Add(celld10);
                                  //portfolio.Columns.Add(celld11);
                                  //portfolio.Columns.Add(celld12);

            //chart1.DataSource = portfolio;
            //chart1.Series[Series1].XValueMember=
            //chart1.DataBindTable()





        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Toexpired ex1 = new Toexpired();
            ex1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fd fd1 = new fd();
            fd1.Show();
        }

        private void notifyIcon2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tobeexpired_fds ex2 = new tobeexpired_fds();
            ex2.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnbonds_Click(object sender, EventArgs e)
        {
            TreasureyBond Tb = new TreasureyBond();
            Tb.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //pictureBox1.BackColor = Color.FromArgb(255, 0, 0);

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Toexpired ex2 = new Toexpired();
            ex2.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnshare_Click(object sender, EventArgs e)
        {

        }

        private void investment1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to close the programme?", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }

            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //  SqlConnection ugccon = new SqlConnection(@"Data Source=KAVINDUPATH\SQLEXPRESS;Initial Catalog=ugcdatabase;Integrated Security=True");

            // string query9 = "select [Investment ID] from Bills ";


        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.label3.Text = datetime.ToString();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            CurrencyConvert c1 = new CurrencyConvert();
            c1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tobeexpired_fds ex2 = new tobeexpired_fds();
            ex2.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Tbondexpire ex3 = new Tbondexpire();
            ex3.Show();
        }

        private void notifyIcon3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Tbondexpire ex3 = new Tbondexpire();
            ex3.Show();
        }
    }
} 
