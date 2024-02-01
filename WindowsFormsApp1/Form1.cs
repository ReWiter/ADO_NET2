using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        string connString = "Host=localhost;Username=postgres;Password=aA1aA1aA1;Database=postgres";
        public void cler()
        {
            name.Clear();
            price.Clear();
            count.Clear();
            type.Clear();
            phone.Clear();
        }
        public void opin()
        {
            price.ReadOnly = false;
            count.ReadOnly = false;
            type.ReadOnly = false;
            phone.ReadOnly = false;
            name.ReadOnly = false;
        }
        public void rem()
        {
            int rowsCount = dataGridView1.Rows.Count;
            for (int i = 0; i < rowsCount - 1; i++)
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[0]);
            }
        }
        private void Table_load(string a)
        {
            string comandString = "select * from storage." + a;
            using (DbDataAdapter dbDataAdapter = new NpgsqlDataAdapter(comandString, connString))
            {
                    try
                    {
                        dbDataAdapter.Fill(dataSet1);
                        dataGridView1.DataSource = dataSet1.Tables[0];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR");
                    }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                opin();
                rem();
                string a = "provider";
                Table_load(a);
                price.ReadOnly= true;
                count.ReadOnly= true;
                type.ReadOnly= true;
            }
            
            if (checkBox2.Checked)
            {
                opin();
                rem();
                string a = "product";
                Table_load(a);
                type.ReadOnly = true;
                phone.ReadOnly= true;
            }
            if (checkBox3.Checked)
            {
                opin();
                rem();
                string a = "type";
                Table_load(a);
                price.ReadOnly = true;
                count.ReadOnly = true;
                phone.ReadOnly = true;
                name.ReadOnly = true;
            }
            if (checkBox1.Checked && checkBox2.Checked) {
                opin();
                rem();
                string a = "provider";
                string b = "product";
                Table_load(a);
                Table_load(b);
                name.ReadOnly = true;
                price.ReadOnly = true;
                count.ReadOnly = true;
                phone.ReadOnly = true;
                type.ReadOnly = true;
            }
            if (checkBox2.Checked && checkBox3.Checked) {
                opin();
                rem();
                string a = "product";
                string b = "type";
                Table_load(a);
                Table_load(b);
                name.ReadOnly = true;
                price.ReadOnly = true;
                count.ReadOnly = true;
                phone.ReadOnly = true;
                type.ReadOnly = true;
            }
            if (checkBox1.Checked && checkBox3.Checked) {
                opin();
                rem();
                string a = "provider";
                string b = "type";
                Table_load(a);
                Table_load(b);
                name.ReadOnly = true;
                price.ReadOnly = true;
                count.ReadOnly = true;
                phone.ReadOnly = true;
                type.ReadOnly = true;
            }
            if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked) {
                opin();
                rem();
                string a = "provider";
                string b = "product";
                string c= "type";
                Table_load(a);
                Table_load(b);
                Table_load(c);
                name.ReadOnly = true;
                price.ReadOnly = true;
                count.ReadOnly = true;
                phone.ReadOnly = true;
                type.ReadOnly= true;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        { 
        }
        private void name_TextChanged(object sender, EventArgs e)
        {

        }
        private void count_TextChanged(object sender, EventArgs e)
        {

        }
        private void price_TextChanged(object sender, EventArgs e)
        {

        }
        private void pr_id_TextChanged(object sender, EventArgs e)
        {

        }
        private void typ_id_TextChanged(object sender, EventArgs e)
        {

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }
        private void type_TextChanged(object sender, EventArgs e)
        {

        }
        private void ID_TextChanged(object sender, EventArgs e)
        {

        }
        private void phone_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string error;
                int isert=CURD.InsertUser(name.Text,phone.Text,out error);
                if (isert == 1)
                {
                    MessageBox.Show("Succes");
                    cler();
                }
                else
                {
                    MessageBox.Show(error);
                }
            }
            if(checkBox2.Checked)
            {
                string error;
                int isert = CURD2.InsertUser(name.Text, count.Text,price.Text,dateTimePicker1.Value,Convert.ToInt32(pr_id.Text),Convert.ToInt32(typ_id.Text),out error);
                if (isert == 1)
                {
                    MessageBox.Show("Succes");
                    cler();
                }
                else
                {
                    MessageBox.Show(error);
                }
            }
            if (checkBox3.Checked)
            {
                string error;
                int isert = CURD3.InsertUser(type.Text, out error);
                if (isert == 1)
                {
                    MessageBox.Show("Succes");
                    cler();
                }
                else
                {
                    MessageBox.Show(error);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string error;
                int isert = CURD.UpdateUser(name.Text, phone.Text, out error,Convert.ToInt32(ID.Text));
                if (isert == 1)
                {
                    MessageBox.Show("Succes");
                    cler();
                }
                else
                {
                    MessageBox.Show(error);
                }
            }
            if (checkBox2.Checked)
            {
                string error;
                int isert = CURD2.UpdateUser(name.Text, count.Text,price.Text,dateTimePicker1.Value,Convert.ToInt32(ID.Text), Convert.ToInt32(pr_id.Text), Convert.ToInt32(typ_id.Text), out error);
                if (isert == 1)
                {
                    MessageBox.Show("Succes");
                    cler();
                }
                else
                {
                    MessageBox.Show(error);
                }
            }
            if (checkBox3.Checked)
            {
                string error;
                int isert = CURD3.UpdateUser(type.Text,  Convert.ToInt32(ID.Text),out error);
                if (isert == 1)
                {
                    MessageBox.Show("Succes");
                    cler();
                }
                else
                {
                    MessageBox.Show(error);
                }
            }
        }
        private void delete_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string error;
                int isert = CURD.DeleteUser(Convert.ToInt32(ID.Text),out error);
                if (isert == 1)
                {
                    MessageBox.Show("Succes");
                    cler();
                }
                else
                {
                    MessageBox.Show(error);
                }
            }
            if (checkBox2.Checked)
            {
                string error;
                int isert = CURD2.DeleteUser(Convert.ToInt32(ID.Text), out error);
                if (isert == 1)
                {
                    MessageBox.Show("Succes");
                    cler();
                }
                else
                {
                    MessageBox.Show(error);
                }
            }
            if (checkBox3.Checked)
            {
                string error;
                int isert = CURD3.DeleteUser(Convert.ToInt32(ID.Text), out error);
                if (isert == 1)
                {
                    MessageBox.Show("Succes");
                    cler();
                }
                else
                {
                    MessageBox.Show(error);
                }
            }
        }
        private void max_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                rem();
                string comn = "select count(pro.typ_id),pr.name,pr.phone from storage.product pro, storage.provider pr where pro.pr_id = pr.id group by pr.name, pro.typ_id,pr.phone having count(pro.typ_id) > (select max(pro.typ_id))";
                using (DbDataAdapter dbDataAdapter = new NpgsqlDataAdapter(comn, connString))
                {
                    try
                    {
                        dbDataAdapter.Fill(dataSet1);
                        dataGridView1.DataSource = dataSet1.Tables[0];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR");
                    }
                }
            }
            if (checkBox3.Checked)
            {
                rem();
                string comn = "select max(p.count),t.type from \"storage\".product p ,\"storage\".\"type\" t \r\nwhere p.typ_id =t.id group by t.\"type\" ;";
                using (DbDataAdapter dbDataAdapter = new NpgsqlDataAdapter(comn, connString))
                {
                    try
                    {
                        dbDataAdapter.Fill(dataSet1);
                        dataGridView1.DataSource = dataSet1.Tables[0];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR");
                    }
                }
            }
        }
        private void min_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                rem();
                string comn = "select count(pro.typ_id),pr.name,pr.phone from storage.product pro, storage.provider pr where pro.pr_id = pr.id group by pr.name, pro.typ_id,pr.phone having count(pro.typ_id) <= (select min(pro.typ_id))";
                using (DbDataAdapter dbDataAdapter = new NpgsqlDataAdapter(comn, connString))
                {
                    try
                    {
                        dbDataAdapter.Fill(dataSet1);
                        dataGridView1.DataSource = dataSet1.Tables[0];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR");
                    }
                }
            }
            if (checkBox3.Checked)
            {
                rem();
                string comn = "select min(p.count),t.type from \"storage\".product p ,\"storage\".\"type\" t \r\nwhere p.typ_id =t.id group by t.\"type\" ;";
                using (DbDataAdapter dbDataAdapter = new NpgsqlDataAdapter(comn, connString))
                {
                    try
                    {
                        dbDataAdapter.Fill(dataSet1);
                        dataGridView1.DataSource = dataSet1.Tables[0];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR");
                    }
                }
            }
        }
        private void clear_Click(object sender, EventArgs e)
        {
            rem();
        }
        private void data_calc_Click(object sender, EventArgs e)
        {
            const string co = "\'";
            string connString = "Host=localhost;Username=postgres;Password=aA1aA1aA1;Database=postgres";
            DateTime pdata = dateTimePicker1.Value;
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string coma = "select date_part('day',"+co+pdata+co+"::date)-date_part('day',p.date) from storage.product p where id="+Convert.ToInt32(ID.Text)+"";
                using (NpgsqlCommand cmd = new NpgsqlCommand(coma, conn))
                {
                    using (DbDataAdapter dbDataAdapter = new NpgsqlDataAdapter(coma, connString))
                    {
                        try
                        {
                                DataTable dataTable = new DataTable();
                                dbDataAdapter.Fill(dataTable);
                                MessageBox.Show(dataTable.Rows[0][0].ToString()+" days","DIFF");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR");
                        }
                    }
                }
            }
        }
    }
}