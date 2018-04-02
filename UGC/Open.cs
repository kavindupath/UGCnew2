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
    public partial class Open : Form
    {
        public Open()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime purchaseDate = dateTimePicker2.Value.Date;
            DateTime settlementDate = dateTimePicker1 .Value.Date;

            TimeSpan ts = settlementDate - purchaseDate;
            textBox6.Text = ts.ToString();

           /* String interestIncome = (Convert.ToDouble(textBox5.Text) - Convert.ToDouble(textBox4.Text)).ToString();


            if (textBox8.Text != interestIncome.Trim())
            {
                MessageBox.Show("Check the values again");
                validateintersetincome();
                Validaterate();
                return;

            }*/

            if (textBox1.Text == " " || textBox2.Text == " " || dateTimePicker1.Text == " " || textBox4.Text == " " || textBox6.Text == " "  || textBox5.Text == " " || textBox8.Text == " "|| dateTimePicker2.Text == " " || textBox3.Text == " ")
            {
                MessageBox.Show("please fill all the required fields");
            }

            else if (dateTimePicker2.Value > dateTimePicker1.Value)
            {
                MessageBox.Show("Please check the Settlement date anad Purchase date of  your investment");
            }

            else if (Convert.ToDouble(textBox5.Text) < Convert.ToDouble(textBox4.Text))
            {
                label4.BackColor = Color.Red;
            }


            else
            {


                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
                MySqlConnection ugccon = new MySqlConnection(connectionString);
                validateintersetincome();
                Validaterate();
                label4.BackColor = Color.Transparent;

                string query4 = "Update Bills set SettlementDate='" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "',Description='" + textBox2.Text + "', PurchaseDate='" +dateTimePicker2.Value.ToString("yyyy-MM-dd") + "', PurchasePrice='" + textBox4.Text + "', FaceValue='" + textBox5.Text + "',MaturityPeriod='" + textBox6.Text + "', InterestIncome='" + textBox8.Text + "', ReturnRate='" + textBox3.Text + "' where InvestmentId='" + textBox1.Text + "';";
                MySqlDataAdapter sda2 = new MySqlDataAdapter(query4, ugccon);

                // string query5 = "update Bills set [Interest Income]='" +textBox8.Text + "'  where [Investment ID]='" + textBox1.Text + "';";
                //SqlDataAdapter sda3 = new SqlDataAdapter(query5, ugccon);
                

                try
                {
                    ugccon.Open();
                    DataTable tb = new DataTable();
                    sda2.Fill(tb);
                    // sda3.Fill(tb);
                    clear();
                    MessageBox.Show("Updated Successfully");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void clear()
        {
            textBox1.Text = textBox2.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox8.Text = textBox3.Text = "";


        }

        public void Validaterate()
        {

            double multiply = 100;
            String ReturnRate = (((Convert.ToDouble(textBox5.Text) - Convert.ToDouble(textBox4.Text)) / Convert.ToDouble(textBox4.Text)) * multiply).ToString();
            textBox3.Text = ReturnRate.Trim();


        }

        public void validateintersetincome()
        {
            String interestIncome = (Convert.ToDouble(textBox5.Text) - Convert.ToDouble(textBox4.Text)).ToString();
            textBox8.Text = interestIncome.Trim();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Open_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ugcdatabaseDataSet13.Bills' table. You can move, or remove it, as needed.
            //this.billsTableAdapter1.Fill(this.ugcdatabaseDataSet13.Bills);
            // TODO: This line of code loads data into the 'ugcdatabaseDataSet5.Bills' table. You can move, or remove it, as needed.
            //this.billsTableAdapter.Fill(this.ugcdatabaseDataSet5.Bills);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}
