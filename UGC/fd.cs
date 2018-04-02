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


using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;
using ExcelLibrary.BinaryDrawingFormat;
using ExcelLibrary.BinaryFileFormat;


using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

using System.Windows.Forms.DataVisualization.Charting;



namespace UGC
{
    public partial class fd : Form
    {
        public fd()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {


            if (textBox1.Text == "" || textBox2.Text == "" || dateTimePicker1.Text == "" || textBox4.Text == "" || textBox6.Text == "" || dateTimePicker2.Text == "" || textBox5.Text == "" || textBox3.Text == ""||textBox7.Text=="" || textBox8.Text == "")
            {
                MessageBox.Show("please fill all the required fields");
                
            }

            else if (dateTimePicker2.Value< dateTimePicker1.Value) 
            {
                MessageBox.Show("Please check the date of fixed deposit and the  Maturity date of your investment");
            }

            else if((dateTimePicker2.Value.Year-dateTimePicker1.Value.Year).ToString()!=textBox7.Text.ToString())
            {
                MessageBox.Show("Please check the no of years to mature");
            }
            else
            {
                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
                MySqlConnection ugccon = new MySqlConnection(connectionString);
                string query1 = "insert into FD(NameOfTheInstitute,BranchCode,NoOfYears,DateOfFd,Amount,Rate,MaturityDate,MaturityValue,TotalInterest) values('" + textBox6.Text + "','" + textBox1.Text + "','" + textBox7.Text + "', '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '" + textBox2.Text + "', '" + textBox3.Text + "','" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "', '" + textBox4.Text + "', '" + textBox5.Text + "');";
                MySqlDataAdapter sda1 = new MySqlDataAdapter(query1, ugccon);

                try
                {
                    ugccon.Open();
                    DataTable tb = new DataTable();
                    sda1.Fill(tb);
                    clearfd();
                    MessageBox.Show("Saved Successfully");
                    
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    //MessageBox.Show("Saving Completed");
                }
            }
        }

        public void  validateNoOfyears()
        {
            textBox7.Text=(dateTimePicker2.Value.Year - dateTimePicker1.Value.Year).ToString();
        }


        void clearfd()
        {
            textBox1.Text = textBox2.Text  = textBox4.Text = textBox5.Text = textBox6.Text = textBox3.Text =textBox7.Text= "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            string query2 = "select * from FD";
            MySqlDataAdapter sda2 = new MySqlDataAdapter(query2, ugccon);
            try
            {
                ugccon.Open();
                DataTable dbdataset = new DataTable();
                sda2.Fill(dbdataset);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdataset;
                dataGridView2.DataSource = bsource;
                sda2.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Open2 o2 = new Open2();
            o2.textBox6.Text = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
            o2.textBox1.Text = this.dataGridView2.CurrentRow.Cells[1].Value.ToString();
            o2.textBox7.Text = this.dataGridView2.CurrentRow.Cells[2].Value.ToString();
            o2.dateTimePicker1.Text = this.dataGridView2.CurrentRow.Cells[3].Value.ToString();
            o2.textBox2.Text = this.dataGridView2.CurrentRow.Cells[4].Value.ToString();


            o2.textBox3.Text = this.dataGridView2.CurrentRow.Cells[5].Value.ToString();
            o2.dateTimePicker2.Text = this.dataGridView2.CurrentRow.Cells[6].Value.ToString();
            o2.textBox4.Text = this.dataGridView2.CurrentRow.Cells[7].Value.ToString();
            o2.textBox5.Text = this.dataGridView2.CurrentRow.Cells[8].Value.ToString();
            o2.textBox8.Text = this.dataGridView2.CurrentRow.Cells[9].Value.ToString();

            o2.ShowDialog();
        }

        private void fd_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ugcdatabaseDataSet18.FD' table. You can move, or remove it, as needed.
            this.fDTableAdapter1.Fill(this.ugcdatabaseDataSet18.FD);
            // TODO: This line of code loads data into the 'ugcdatabaseDataSet4.FD' table. You can move, or remove it, as needed.
            //this.fDTableAdapter.Fill(this.ugcdatabaseDataSet4.FD);
            Loadtable();
            Amount();
            TotalInterest();

          
        }

        public void Amount()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            MySqlCommand cmddatabase = new MySqlCommand("select * from fd;", ugccon);
            MySqlDataReader myreader;

            try
            {
                ugccon.Open();
                myreader = cmddatabase.ExecuteReader();

                while (myreader.Read())
                {
                    this.chart2.Series["Amount"].Points.AddXY(myreader.GetString("NameOfTheInstitute"), myreader.GetDouble("Amount"));
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void TotalInterest()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            MySqlCommand cmddatabase = new MySqlCommand("select * from fd;", ugccon);
            MySqlDataReader myreader;

            try
            {
                ugccon.Open();
                myreader = cmddatabase.ExecuteReader();

                while (myreader.Read())
                {
                    this.chart3.Series["TotalInterest"].Points.AddXY(myreader.GetString("NameOfTheInstitute"), myreader.GetDouble("TotalInterest"));
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            investment1 in1 = new investment1();

            in1.Show();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            string query3 = "select * from FD";
            MySqlDataAdapter sda2 = new MySqlDataAdapter(query3, ugccon);
            try
            {
                ugccon.Open();
                DataTable dbdataset2 = new DataTable();
                sda2.Fill(dbdataset2);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdataset2;
                


                DataSet ds = new DataSet("New_Dataset");//create a name and give a name to the dataset
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
                //sda2.Fill(dbdataset2);
                ds.Tables.Add(dbdataset2);
                ExcelLibrary.DataSetHelper.CreateWorkbook("ugcreport4.xls", ds);
                MessageBox.Show("Your Excell file is created successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            Document doc1 = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc1, new FileStream("fd report.pdf", FileMode.Create));
            doc1.Open();
            PdfPTable table3= new PdfPTable(dataGridView2.Columns.Count);

            //add header to the table
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                table3.AddCell(new Phrase(dataGridView2.Columns[i].HeaderText));
            }

            table3.HeaderRows = 1;

            // add actual rows to the table

            for (int j = 0; j < dataGridView2.Rows.Count; j++)
            {
                for (int k = 0; k < dataGridView2.Columns.Count; k++)
                {
                    /*if(dataGridView1[k,j]!=null)
                    {
                        table2.AddCell(new Phrase(dataGridView1[k,j].Value.ToString()));
                    }*/
                    table3.AddCell(new Phrase(dataGridView2[k,j].Value.ToString()));
                }
            }
            doc1.Add(table3);

            var chartimage = new MemoryStream();
            chart2.SaveImage(chartimage, ChartImageFormat.Jpeg);
            iTextSharp.text.Image chart_image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            doc1.Add(chart_image);

            doc1.Close();
            MessageBox.Show("A PDF file was created Successfully");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)

        {

            validateNoOfyears();
            double div = 100;
            double k= 1;
            double t = (1 + Convert.ToDouble(textBox3.Text)/div);
                int r=Convert.ToInt32(textBox7.Text);

            
              double d=  Math.Pow(t, r);
                
            
            double f = d * Convert.ToDouble(textBox2.Text);
            string str = f.ToString(); 
            

            textBox4.Text = str.Trim();
           // String maturityvalue = (Convert.ToDouble(textBox2.Text) * (((1 + Convert.ToDouble(textBox3.Text))) ^ (Convert.ToInt32(textBox7.Text)))).ToString();
           

            String Aggreateamount = (Convert.ToDouble(textBox4.Text) - Convert.ToDouble(textBox2.Text)).ToString();
            textBox5.Text = Aggreateamount.Trim();

        }

        private void button8_Click(object sender, EventArgs e)
        {

          
        }

        private void button9_Click(object sender, EventArgs e)
        {

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            MySqlCommand cmddatabase = new MySqlCommand("select * from fd;", ugccon);
            MySqlDataReader myreader;

            try
            {
                ugccon.Open();
                myreader = cmddatabase.ExecuteReader();

                while (myreader.Read())
                {
                    this.chart2.Series["Amount"].Points.AddXY(myreader.GetString("NameOfTheInstitute"), myreader.GetDouble("Amount"));
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            MySqlCommand cmddatabase = new MySqlCommand("select * from fd;", ugccon);
            MySqlDataReader myreader;

            try
            {
                ugccon.Open();
                myreader = cmddatabase.ExecuteReader();

                while (myreader.Read())
                {
                    this.chart3.Series["TotalInterest"].Points.AddXY(myreader.GetString("NameOfTheInstitute"), myreader.GetDouble("TotalInterest"));
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openf1 = new OpenFileDialog();

            if (openf1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                axAcroPDF2.src = openf1.FileName;  //axAcroPDF1 name of the pdf

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        public void Loadtable()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            string query2 = "select * from FD";
            MySqlDataAdapter sda2 = new MySqlDataAdapter(query2, ugccon);
            try
            {
                ugccon.Open();
                DataTable dbdataset = new DataTable();
                sda2.Fill(dbdataset);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdataset;
                dataGridView2.DataSource = bsource;
                sda2.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Loadtable();
        }
    }
    }

