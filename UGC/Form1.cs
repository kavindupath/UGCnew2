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
using System.Threading;
using System.Security.Cryptography;

namespace UGC
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            Thread t = new Thread(new ThreadStart(startform));
            t.Start();
            Thread.Sleep(5000);

            t.Abort();
            InitializeComponent();

             txtpass.PasswordChar = '*';

        }

        public void startform()
        {
            Application.Run(new frmsplashscreen());
        }

    
        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string x=Encrypt(txtpass.Text);
                //MessageBox.Show(x);
                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
                MySqlConnection ugccon = new MySqlConnection(connectionString);
                string query1 = "select * from investment_table where EmployeeID='" + txtid.Text.Trim() + "' and Password='"+ x + "'";
                MySqlDataAdapter sda1 = new MySqlDataAdapter(query1, ugccon);

                DataTable dtb1 = new DataTable();
                sda1.Fill(dtb1);

                if (dtb1.Rows.Count == 1)
                {
                    
                    this.timer1.Start();
                    MessageBox.Show("Welcome !. Press OK to continue");
                    this.Hide();
                    investment1 i1 = new investment1();
                    
                    i1.Show();
                    
                    //MessageBox.Show(Encrypt(txtpass.Text));
                   

                }

                else
                {
                    this.timer1.Start();
                    MessageBox.Show(" Please Check your Employee Id and password");
                    clear();
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        static string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider mds = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = mds.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        void clear()
        {
            txtid.Text = txtpass.Text = "";
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(100);
           
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             
        }
    }
}
