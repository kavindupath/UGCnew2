﻿using System;
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
    public partial class Toexpired : Form
    {
        public Toexpired()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Toexpired_Load(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ugcnew";
            MySqlConnection ugccon = new MySqlConnection(connectionString);
            string query6 = "select * from bills where (SettlementDate-(select CURDATE())<10)"; ;
            MySqlDataAdapter sda2 = new MySqlDataAdapter(query6, ugccon);
            try
            {
                ugccon.Open();
                DataTable dbdataset1 = new DataTable();
                sda2.Fill(dbdataset1);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdataset1;
                dataGridView2.DataSource = bsource;
                sda2.Update(dbdataset1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
