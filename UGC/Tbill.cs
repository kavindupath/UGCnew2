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
    public partial class Tbill : Form
    {
        public Tbill()
        {
            InitializeComponent();
            ColumnSelect();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                DateTime purchaseDate = dateTimePicker1.Value.Date;
                DateTime settlementDate = dateTimePicker2.Value.Date;

                TimeSpan ts = settlementDate - purchaseDate;
                textBox5.Text = ts.ToString();

                //String interestIncome = (Convert.ToDouble(textBox6.Text) - Convert.ToDouble(textBox4.Text)).ToString();


              


                if (textBox1.Text == "" || textBox2.Text == "" || dateTimePicker1.Text == "" || textBox4.Text == "" || textBox6.Text == "" || dateTimePicker2.Text == "" || textBox5.Text == "" || textBox8.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("please fill all the required fields");

                }
           // String interestIncome = (Convert.ToDouble(textBox6.Text) - Convert.ToDouble(textBox4.Text)).ToString();



            /*if (textBox8.Text != interestIncome.Trim())
            {
                MessageBox.Show("Check the values again");
                validateintersetincome();
                Validaterate();
                return;

            }*/

            else if (dateTimePicker2.Value < dateTimePicker1.Value)
                {
                    MessageBox.Show("Please check the Settlement date and Purchase date of  your investment");
                }

                else if (Convert.ToDouble(textBox6.Text) < Convert.ToDouble(textBox4.Text))
                {
                    label5.BackColor = Color.Red;
                }

           





            else
            {

                try
                {

                    string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
                    MySqlConnection ugccon = new MySqlConnection(connectionString);
                    validateintersetincome();
                    Validaterate();
                    string query2 = "insert into bills(InvestmentId,Description,PurchaseDate,PurchasePrice,FaceValue,SettlementDate,MaturityPeriod,InterestIncome,ReturnRate) values('" + textBox1.Text + "','" + textBox2.Text + "', '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '" + textBox4.Text + "', '" + textBox6.Text + "','" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "', '" + textBox5.Text + "', '" + textBox8.Text + "','" + textBox3.Text + "');";

                MySqlDataAdapter sda1 = new MySqlDataAdapter(query2, ugccon);
                    label5.BackColor = Color.Transparent;
                   // String interestIncome = (Convert.ToDouble(textBox6.Text) - Convert.ToDouble(textBox4.Text)).ToString();


                    ugccon.Open();
                    //int sumofbills;

                    DataTable tb = new DataTable();
                    sda1.Fill(tb);
                               
                    clear();
                    MessageBox.Show("Saved Successfully ");
                  

                }

                catch (Exception ex)
                {
                    // MessageBox.Show("Save completed");
                    MessageBox.Show(ex.Message);
                }
            }
        }
       

        void clear()
        {
            textBox1.Text = textBox2.Text  = textBox4.Text = textBox5.Text = textBox6.Text = textBox8.Text = textBox3.Text ="";

            
        }

           public void Validaterate()
        {

            double multiply = 100;
            String ReturnRate = (((Convert.ToDouble(textBox6.Text) - Convert.ToDouble(textBox4.Text)) / Convert.ToDouble(textBox4.Text)) * multiply).ToString();
            textBox3.Text = ReturnRate.Trim();
           

        }

        public void validateintersetincome()
        {
            String interestIncome = (Convert.ToDouble(textBox6.Text) - Convert.ToDouble(textBox4.Text)).ToString();
            textBox8.Text = interestIncome.Trim();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       /* private void Tbill_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to Close the Programme?", "Exit", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }

            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }

        }*/

        private void tabPage2_Click(object sender, EventArgs e)
        {
            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            string query3 = "select * from bills";
            MySqlDataAdapter sda2 = new MySqlDataAdapter(query3, ugccon);

            this.circularProgressBar1.Increment(100);
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
                MessageBox.Show(ex.Message);
            }


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            string querysum = "select SUM(InterestIncome) as sum from bills";
            MySqlDataAdapter sdas = new MySqlDataAdapter(querysum, ugccon);

           // DataTable tbs = new DataTable();
            //sdas.Fill(tbs);
            //object sums = tbs.Rows[0]["sum"];
            //int sum = Convert.ToInt32(sums);

            Open o2 = new Open();
            o2.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            o2.textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //o2.textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            o2.textBox4.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            o2.textBox5.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            o2.textBox6.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            o2.textBox8.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            o2.dateTimePicker1.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            o2.dateTimePicker2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            o2.textBox3.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();


            //int income = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[5].Value.ToString());




            o2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            string query3 = "select * from bills";
            MySqlDataAdapter sda2 = new MySqlDataAdapter(query3, ugccon);
            try
            {
                ugccon.Open();
               DataTable dbdataset2= new DataTable();
                sda2.Fill(dbdataset2);
               BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdataset2;
                dataGridView1.DataSource = bsource;
                sda2.Update(dbdataset2);



                DataSet ds = new DataSet("New_Dataset");//create a name and give a name to the dataset
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
                sda2.Fill(dbdataset2);
                ds.Tables.Add(dbdataset2);
                ExcelLibrary.DataSetHelper.CreateWorkbook("ugcreport3.xls", ds);

                MessageBox.Show("Your Excell file is created Succcessfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Document doc1 = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc1, new FileStream("Tbill report.pdf", FileMode.Create));
            doc1.Open();  //open document to write


            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance("UgcLogoL.jpg");
            
            
            doc1.Add(jpg);

            Paragraph para1 = new Paragraph("University Grantt Commission-Sri Lanka");
            doc1.Add(para1);
            // write some content
            // Paragraph para1 = new Paragraph("this is my first line");
            //now add the above created text using different class object to our pdf document

            Paragraph para2 = new Paragraph("The following report contains the details of all the Treasurey bill investments done by University Grantt commission");
            doc1.Add(para2);

            Paragraph para3 = new Paragraph("The following table shows  the comparisons between those treasurey bills");
            doc1.Add(para3);



            //create a table in the pdf

            /* PdfPTable table1 = new PdfPTable(3);  // 3 coloumns

             PdfPCell cell1 = new PdfPCell(new Phrase("header spanning 3 coloumns",new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL,8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLUE)));
             cell1.Colspan = 3;
             cell1.HorizontalAlignment = 1;
             table1.AddCell(cell1);

             table1.AddCell("col 1 row 1");
             table1.AddCell("col 2 row 1");
             table1.AddCell("col 3 row 1");


             table1.AddCell("col 1 row 2");
             table1.AddCell("col 2 row 2");
             table1.AddCell("col 3 row 2");

             doc1.Add(table1);*/

            PdfPTable table2 = new PdfPTable(dataGridView1.Columns.Count);

            //add header to the table
            for(int i=0;i<dataGridView1.Columns.Count;i++)
            {
                table2.AddCell(new Phrase(dataGridView1.Columns[i].HeaderText));
            }

            table2.HeaderRows = 1;

            // add actual rows to the table

            for(int j=0;j<dataGridView1.Rows.Count;j++)
            {
                for(int k=0;k<dataGridView1.Columns.Count;k++)
                {
                    /*if(dataGridView1[k,j]!=null)
                    {
                        table2.AddCell(new Phrase(dataGridView1[k,j].Value.ToString()));
                    }*/
                    table2.AddCell(new Phrase(dataGridView1[k, j].Value.ToString()));
                }
            }
            doc1.Add(table2);


            var chartimage = new MemoryStream();
            chart3.SaveImage(chartimage, ChartImageFormat.Jpeg);
            iTextSharp.text.Image chart_image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            doc1.Add(chart_image);



            doc1.Close();
            MessageBox.Show("A PDF file was created Successfully");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openf1 = new OpenFileDialog();

            if(openf1.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                axAcroPDF1.src = openf1.FileName;  //axAcroPDF1 name of the pdf

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            investment1 in1 = new investment1();
            
            in1.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Tbill_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ugcdatabaseDataSet22.Bills' table. You can move, or remove it, as needed.
            this.billsTableAdapter2.Fill(this.ugcdatabaseDataSet22.Bills);
            // TODO: This line of code loads data into the 'ugcdatabaseDataSet20.Bills' table. You can move, or remove it, as needed.
            //this.billsTableAdapter1.Fill(this.ugcdatabaseDataSet20.Bills);
            // TODO: This line of code loads data into the 'ugcdatabaseDataSet3.Bills' table. You can move, or remove it, as needed.
            // this.billsTableAdapter.Fill(this.ugcdatabaseDataSet3.Bills);
            LoadTable();
            InterestIncomeChart();
            ReturnRateChart();
            PurchasePriceBill();
            FaceValueBill();

        }

        public void LoadTable()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            string query3 = "select * from bills";
            MySqlDataAdapter sda2 = new MySqlDataAdapter(query3, ugccon);

            this.circularProgressBar1.Increment(100);
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
                MessageBox.Show(ex.Message);
            }
        }

        public void InterestIncomeChart()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            MySqlCommand cmddatabase = new MySqlCommand("select * from bills;", ugccon);
            MySqlDataReader myreader;

            try
            {
                ugccon.Open();
                myreader = cmddatabase.ExecuteReader();

                while (myreader.Read())
                {
                    this.chart1.Series["InterestIncome"].Points.AddXY(myreader.GetInt32("InvestmentId"), myreader.GetDouble("InterestIncome"));
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void ReturnRateChart()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            MySqlCommand cmddatabase = new MySqlCommand("select * from bills;", ugccon);
            MySqlDataReader myreader;

            try
            {
                ugccon.Open();
                myreader = cmddatabase.ExecuteReader();

                while (myreader.Read())
                {
                    this.chart2.Series["ReturnRate"].Points.AddXY(myreader.GetInt32("InvestmentId"), myreader.GetDouble("ReturnRate"));
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PurchasePriceBill()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            MySqlCommand cmddatabase = new MySqlCommand("select * from bills;", ugccon);
            MySqlDataReader myreader;

            try
            {
                ugccon.Open();
                myreader = cmddatabase.ExecuteReader();

                while (myreader.Read())
                {
                    this.chart3.Series["PurchasePrice"].Points.AddXY(myreader.GetString("Description"), myreader.GetDouble("PurchasePrice"));
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void FaceValueBill()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            MySqlCommand cmddatabase = new MySqlCommand("select * from bills;", ugccon);
            MySqlDataReader myreader;

            try
            {
                ugccon.Open();
                myreader = cmddatabase.ExecuteReader();

                while (myreader.Read())
                {
                    this.chart4.Series["FaceValue"].Points.AddXY(myreader.GetString("Description"), myreader.GetDouble("FaceValue"));
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
          TbillnewReport tbr = new TbillnewReport();
            tbr.Show();
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //textBox8.Text = (Convert.ToDouble(textBox6.Text) - Convert.ToDouble(textBox4.Text)).ToString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                MessageBox.Show("Please check the Settlement date and Purchase date of  your investment");
            

            }

            else {
                double multiply = 100;
                string interestIncome = (Convert.ToDouble(textBox6.Text) - Convert.ToDouble(textBox4.Text)).ToString();
                textBox8.Text = interestIncome.Trim();

                String ReturnRate = (((Convert.ToDouble(textBox6.Text) - Convert.ToDouble(textBox4.Text)) / Convert.ToDouble(textBox4.Text)) * multiply).ToString();
                textBox3.Text = ReturnRate.Trim();
            }

        }

        private void textBox8_Click(object sender, EventArgs e)
        {
            //textBox8.Text = (Convert.ToInt32(textBox6.Text) - Convert.ToInt32(textBox4.Text)).ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            MySqlCommand cmddatabase = new MySqlCommand("select * from bills;",ugccon);
            MySqlDataReader myreader;

            try
            {
                ugccon.Open();
                myreader = cmddatabase.ExecuteReader();

                while(myreader.Read())
                {
                    this.chart1.Series["InterestIncome"].Points.AddXY(myreader.GetInt32("InvestmentId"), myreader.GetDouble("InterestIncome"));
                }

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            


            



        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }



        void clearrate()
        {
            textBox3.Text = "";
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Can't insert the rate.");
            clearrate();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
                MySqlConnection ugccon = new MySqlConnection(connectionString);
            MySqlCommand cmddatabase = new MySqlCommand("select * from bills;", ugccon);
            MySqlDataReader myreader;

            try
            {
                ugccon.Open();
                myreader = cmddatabase.ExecuteReader();

                while (myreader.Read())
                {
                    this.chart2.Series["ReturnRate"].Points.AddXY(myreader.GetInt32("InvestmentId"), myreader.GetDouble("ReturnRate"));
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            MySqlCommand cmddatabase = new MySqlCommand("select * from bills;", ugccon);
            MySqlDataReader myreader;

            try
            {
                ugccon.Open();
                myreader = cmddatabase.ExecuteReader();

                while (myreader.Read())
                {
                    this.chart3.Series["PurchasePrice"].Points.AddXY(myreader.GetString("Description"), myreader.GetDouble("PurchasePrice"));
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            MySqlCommand cmddatabase = new MySqlCommand("select * from bills;", ugccon);
            MySqlDataReader myreader;

            try
            {
                ugccon.Open();
                myreader = cmddatabase.ExecuteReader();

                while (myreader.Read())
                {
                    this.chart4.Series["FaceValue"].Points.AddXY(myreader.GetString("Description"), myreader.GetDouble("FaceValue"));
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }


        public void searchdata(string valueTosearch)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);

            string query = "select * from bills where  CONCAT(`InvestmentId`, `Description`, `PurchaseDate`, `PurchasePrice`, `FaceValue`, `MaturityPeriod`, `SettlementDate`, `InterestIncome`, `ReturnRate`) like '%" +valueTosearch+ "%'";
            MySqlDataAdapter search = new MySqlDataAdapter(query, ugccon);

            try
            {
                ugccon.Open();
                DataTable searchtable = new DataTable();
                search.Fill(searchtable);
                BindingSource bs = new BindingSource();

                bs.DataSource = searchtable;
                dataGridView1.DataSource = bs;
                search.Update(searchtable);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string valueTosearch = textBox7.Text.ToString();
            searchdata(valueTosearch);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        public void FilterData()
        {
            try
            {
                string column = null;
                string filt = null;
                column = ColumnS.SelectedValue.ToString();
                filt = Filter.SelectedValue.ToString();
                MySqlConnection conn = new MySqlConnection("datasource = 127.0.0.1; port = 3306; username = root; password =; database = ugcnew");
                DataTable ds = new DataTable();
                MySqlDataAdapter sql;
                if (column == null || filt == null)
                {

                    sql = new MySqlDataAdapter("select * from bills ", conn);
                }


                else
                {
                    sql = new MySqlDataAdapter("select * from bills where " + column + "='" + filt + "'", conn);
                    //MessageBox.Show(Filter.SelectedValue.ToString());
                }

                sql.Fill(ds);
                dataGridView1.DataSource = ds;

            }
            catch (Exception ee)
            {
                //  MessageBox.Show(ee.ToString());
            }


        }
        public void Search()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("datasource = 127.0.0.1; port = 3306; username = root; password =; database = ugcnew");
                MySqlDataAdapter sql = new MySqlDataAdapter("select * from bills", conn);
                DataTable ds = new DataTable();
                sql.Fill(ds);

                Filter.DisplayMember = ColumnS.SelectedValue.ToString();
                Filter.ValueMember = ColumnS.SelectedValue.ToString();
                Filter.DataSource = ds;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
        public void ColumnSelect()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("datasource = 127.0.0.1; port = 3306; username = root; password =; database = ugcnew");
                MySqlDataAdapter sql = new MySqlDataAdapter("select column_name from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='bills' order by ORDINAL_POSITION", conn);
                DataTable ds = new DataTable();
                sql.Fill(ds);
                ColumnS.DataSource = ds;
                ColumnS.DisplayMember = "column_name";
                ColumnS.ValueMember = "column_name";


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());

            }

        }
        private void ColumnS_SelectedValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void Filter_SelectedValueChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            LoadTable();
        }

        // private void textBox2_TextChanged_click(object sender, EventArgs e)




        /* private void button4_Click_1(object sender, EventArgs e)
          {
              SqlConnection tbillchart = new SqlConnection(@"Data Source=KAVINDUPATH\SQLEXPRESS;Initial Catalog=ugcdatabase;Integrated Security=True");
              string query2 = "select from Bills";
              SqlCommand sda2 = new SqlCommand(query2, tbillchart);
              SqlDataReader read;

              try
              {
                  tbillchart.Open();
                  read = sda2.ExecuteReader();

                  while(read.Read())
                  {
                      this.chart1.Series["[Investment ID]"].Points.AddXY(read.GetValues("[Investment ID]"), read.GetSqlInt16("[Interest Income]"));
                  }
              }
              catch(Exception ex)
              {
                  MessageBox.Show(ex.Message);
              }
          }*/
    }
}
