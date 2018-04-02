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
    public partial class Open2 : Form
    {
        public Open2()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || dateTimePicker1.Text == "" || textBox4.Text == "" || textBox6.Text == "" || dateTimePicker2.Text == "" || textBox5.Text == "" || textBox3.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("please fill all the required fields");
            }

            else if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                MessageBox.Show("Please check the  date of fixed deposit and the  Maturity date of  your investment");
            }

            else if ((dateTimePicker2.Value.Year - dateTimePicker1.Value.Year).ToString() != textBox7.Text.ToString())
            {
                MessageBox.Show("Please check the no of years to mature");
            }

            else
            {
                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
                MySqlConnection ugccon = new MySqlConnection(connectionString);
                string query2 = "update FD set NoOfYears='" + textBox7.Text + "',DateOfFd='" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "',Amount= '" + textBox2.Text + "',Rate='" + textBox3.Text + "',MaturityDate='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "',MaturityValue='" + textBox4.Text + "',TotalInterest='" + textBox5.Text + "'  where BranchCode='" + textBox1.Text + "' AND NameOfTheInstitute='" + textBox6.Text + "' ;";
                MySqlDataAdapter sda2 = new MySqlDataAdapter(query2, ugccon);


                // string query5 = "update Bills set [Interest Income]='" +textBox8.Text + "'  where [Investment ID]='" + textBox1.Text + "';";
                //SqlDataAdapter sda3 = new SqlDataAdapter(query5, ugccon);

                try
                {
                    ugccon.Open();
                    DataTable tb = new DataTable();
                    sda2.Fill(tb);
                    // sda3.Fill(tb);
                    clearfd();
                    MessageBox.Show("Updated Successfully");
                }

                catch (Exception ex)
                {
                     MessageBox.Show(ex.Message);
                    //MessageBox.Show("Updation complete");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Open2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ugcdatabaseDataSet.FD' table. You can move, or remove it, as needed.
            //this.fDTableAdapter.Fill(this.ugcdatabaseDataSet.FD);

        }

        public void validateNoOfyears()
        {
            textBox7.Text = (dateTimePicker2.Value.Year - dateTimePicker1.Value.Year).ToString();
        }

        void clearfd()
        {
            textBox1.Text = textBox2.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox3.Text = textBox7.Text = "";
        }


        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            validateNoOfyears();
            double div = 100;
            double k = 1;
            double t = (1 + Convert.ToDouble(textBox3.Text) / div);
            int r = Convert.ToInt32(textBox7.Text);


            double d = Math.Pow(t, r);


            double f = d * Convert.ToDouble(textBox2.Text);
            string str = f.ToString();


            textBox4.Text = str.Trim();
            // String maturityvalue = (Convert.ToDouble(textBox2.Text) * (((1 + Convert.ToDouble(textBox3.Text))) ^ (Convert.ToInt32(textBox7.Text)))).ToString();


            String Aggreateamount = (Convert.ToDouble(textBox4.Text) - Convert.ToDouble(textBox2.Text)).ToString();
            textBox5.Text = Aggreateamount.Trim();
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
