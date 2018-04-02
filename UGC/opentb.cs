using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace UGC
{
    public partial class opentb : Form
    {
        public opentb()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || dateTimePicker1.Text == "" || textBox4.Text == "" || textBox5.Text == "" || dateTimePicker2.Text == "" || textBox9.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("please fill all the required fields");
            }

            if (Convert.ToDouble(textBox4.Text) > Convert.ToDouble(textBox5.Text))

            {
                label4.BackColor = Color.Red;
            }

            else if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                MessageBox.Show("Please check the Settlement date and Purchase date of  your investment");
            }

            else
            {


                calculatecoupon();
                calculatePeriod();
                calculateYield();
                label4.BackColor = Color.Transparent;

                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
                MySqlConnection ugccon = new MySqlConnection(connectionString);
                string query2 = "Update TreasureyBonds set NameOfTheInstitute='" + textBox1.Text + "',IssuedDateOfTb='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "',DateOfMature='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "',Price='" + textBox4.Text + "',FaceValue='" + textBox5.Text + "',CouponRate='" + textBox6.Text + "',CouponValue='" + textBox3.Text + "',Period='" + textBox7.Text + "',Yield='" + textBox8.Text + "',BranchCode='" + textBox2.Text + "' where BondId='" + textBox9.Text + "';";
                MySqlDataAdapter sda1 = new MySqlDataAdapter(query2, ugccon);


                try
                {
                    ugccon.Open();
                    DataTable tb = new DataTable();
                    sda1.Fill(tb);
                    MessageBox.Show("Updated Successfully");
                    cleartbond();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public void calculatecoupon()
        {
            int div = 100;
            String coupon = ((Convert.ToDouble(textBox6.Text) * Convert.ToDouble(textBox5.Text)) / div).ToString();
            textBox3.Text = coupon.Trim();
        }

        void cleartbond()
        {
            textBox1.Text = textBox2.Text = dateTimePicker1.Text = textBox4.Text = textBox9.Text = textBox5.Text = textBox6.Text = textBox3.Text = textBox7.Text = dateTimePicker2.Text = textBox8.Text = "";
        }



        public void calculatePeriod()
        {


            textBox7.Text = (dateTimePicker2.Value.Year - dateTimePicker1.Value.Year).ToString();

        }

        public void calculateYield()
        {
            double i = 1.00;
            double yi = Convert.ToDouble(textBox5.Text) / Convert.ToDouble(textBox4.Text);
            int power = Convert.ToInt32(textBox7.Text);
            double yi2 = Math.Pow(yi, (1 / power));
            string finalyield = (yi2 - i).ToString();
            textBox8.Text = finalyield.Trim();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}
