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


using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;



namespace UGC
{
    public partial class TreasureyBond : Form
    {
        public TreasureyBond()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           if (textBox1.Text == "" || textBox2.Text == "" ||dateTimePicker1.Text=="" || textBox4.Text == "" || textBox3.Text == ""|| dateTimePicker2.Text == "" || textBox5.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("please fill all the required fields");
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
                string querytb1 = "insert into TreasureyBonds (NameOfTheInstitute,BranchCode,IssuedDateOfTb,Price,FaceValue,CouponRate,CouponValue,Period,Yield,DateOfMature,BondId) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox9.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "','" + textBox8.Text + "');";
                MySqlDataAdapter sda1 = new MySqlDataAdapter(querytb1, ugccon);
               

                try
                {
                    ugccon.Open();
                    DataTable tb = new DataTable();
                    sda1.Fill(tb);
                    
                    MessageBox.Show("Saved Successfully");
                    cleartbond();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        public void calculatecoupon()
        {
            int div = 100;
            String coupon = ((Convert.ToDouble(textBox4.Text) * Convert.ToDouble(textBox5.Text)) / div).ToString();
            textBox9.Text = coupon.Trim();
        }

        void cleartbond()
            {
                textBox1.Text = textBox2.Text = dateTimePicker1.Text = textBox4.Text = textBox9.Text = textBox5.Text = textBox6.Text = textBox3.Text = textBox7.Text = dateTimePicker2.Text=textBox8.Text= "";
            }



        public void calculatePeriod()
        {
            
           
                textBox6.Text = (dateTimePicker2.Value.Year - dateTimePicker1.Value.Year).ToString();
            
        }

        public void calculateYield()
        {
            double i = 1.00;
            double yi= Convert.ToDouble(textBox4.Text)/ Convert.ToDouble(textBox3.Text);
            int power= Convert.ToInt32(textBox6.Text);
            double yi2 = Math.Pow(yi, (1 / power));
            string finalyield = (yi2-i).ToString();
            textBox7.Text = finalyield.Trim();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            string query3 = "select * from TreasureyBonds";
            MySqlDataAdapter sda2 = new MySqlDataAdapter(query3, ugccon);
            try
            {
                ugccon.Open();
                DataTable dbdataset = new DataTable();
                sda2.Fill(dbdataset);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdataset;
                dataGridView1.DataSource = bsource;
                sda2.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            opentb opt = new opentb();
            opt.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            opt.textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            opt.dateTimePicker1.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            opt.dateTimePicker2.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
            opt.textBox4.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            opt.textBox5.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            opt.textBox6.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            opt.textBox3.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            opt.textBox7.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            opt.textBox8.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            opt.textBox9.Text = this.dataGridView1.CurrentRow.Cells[10].Value.ToString();

            opt.ShowDialog();
        }

        private void TreasureyBond_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ugcdatabaseDataSet16.TreasureyBonds' table. You can move, or remove it, as needed.
            this.treasureyBondsTableAdapter.Fill(this.ugcdatabaseDataSet16.TreasureyBonds);
            // TODO: This line of code loads data into the 'ugcdatabaseDataSet2.Treasurey_bonds' table. You can move, or remove it, as needed.
            //this.treasurey_bondsTableAdapter.Fill(this.ugcdatabaseDataSet2.Treasurey_bonds);
            LoadTable();
            FaceValueChart();
            CouponValueChart();

        }

        public void LoadTable()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            string query3 = "select * from TreasureyBonds";
            MySqlDataAdapter sda2 = new MySqlDataAdapter(query3, ugccon);
            try
            {
                ugccon.Open();
                DataTable dbdataset = new DataTable();
                sda2.Fill(dbdataset);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdataset;
                dataGridView1.DataSource = bsource;
                sda2.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        public void FaceValueChart()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            MySqlCommand cmddatabase = new MySqlCommand("select * from treasureybonds;", ugccon);
            MySqlDataReader myreader;

            try
            {
                ugccon.Open();
                myreader = cmddatabase.ExecuteReader();

                while (myreader.Read())
                {
                    this.chart1.Series["FaceValue"].Points.AddXY(myreader.GetString("NameOfTheInstitute"), myreader.GetDouble("FaceValue"));
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CouponValueChart()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            MySqlCommand cmddatabase = new MySqlCommand("select * from treasureybonds;", ugccon);
            MySqlDataReader myreader;

            try
            {
                ugccon.Open();
                myreader = cmddatabase.ExecuteReader();

                while (myreader.Read())
                {
                    this.chart2.Series["CouponValue"].Points.AddXY(myreader.GetString("NameOfTheInstitute"), myreader.GetDouble("CouponValue"));
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Document doc3 = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc3, new FileStream("Tbonds report.pdf", FileMode.Create));
            doc3.Open();  //open document to write

           


          
            PdfPTable table3 = new PdfPTable(dataGridView1.Columns.Count);

            //add header to the table
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                table3.AddCell(new Phrase(dataGridView1.Columns[i].HeaderText));
            }

            table3.HeaderRows = 1;

            // add actual rows to the table

            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                for (int k = 0; k < dataGridView1.Columns.Count; k++)
                {
                    /*if(dataGridView1[k,j]!=null)
                    {
                        table2.AddCell(new Phrase(dataGridView1[k,j].Value.ToString()));
                    }*/
                    table3.AddCell(new Phrase(dataGridView1[k, j].Value.ToString()));
                }
            }
            doc3.Add(table3);


            doc3.Close();
            MessageBox.Show("A PDF file was created successfully");

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            TbondReport tbr = new TbondReport();
            tbr.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_Click(object sender, EventArgs e)
        {

           
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            //double a = Convert.ToDouble(textBox4.Text) / Convert.ToDouble(textBox3.Text);
           // double b = 1 / Convert.ToDouble(textBox6.Text);

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            MySqlCommand cmddatabase = new MySqlCommand("select * from treasureybonds;", ugccon);
            MySqlDataReader myreader;

            try
            {
                ugccon.Open();
                myreader = cmddatabase.ExecuteReader();

                while (myreader.Read())
                {
                    this.chart1.Series["FaceValue"].Points.AddXY(myreader.GetString("NameOfTheInstitute"), myreader.GetDouble("FaceValue"));
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            MySqlCommand cmddatabase = new MySqlCommand("select * from treasureybonds;", ugccon);
            MySqlDataReader myreader;

            try
            {
                ugccon.Open();
                myreader = cmddatabase.ExecuteReader();

                while (myreader.Read())
                {
                    this.chart2.Series["CouponValue"].Points.AddXY(myreader.GetString("NameOfTheInstitute"), myreader.GetDouble("CouponValue"));
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog openf1 = new OpenFileDialog();

            if (openf1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                axAcroPDF3.src = openf1.FileName;  //axAcroPDF3 name of the pdf

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if(textBox1.Text==null)
            {
                errorProvider1.SetError(textBox1, "please fill the text field");
            }
        }

        

        private void button3_Click_1(object sender, EventArgs e)
        {
            LoadTable();
        }
    }
}
