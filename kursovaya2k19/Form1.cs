using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace kursovaya2k19
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            String ConnectionString = @"Provider=Microsoft.JET.OLEDB.4.0; Data Source=|DataDirectory|\\ClothShop.mdb";
            OleDbCommand Mycommand = new OleDbCommand();
            OleDbDataAdapter DataAdapter = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            OleDbConnection conn = new OleDbConnection(ConnectionString);
            String text = "SELECT User.Login, User.Password FROM [User]  ORDER BY Login";
            Mycommand.Connection = conn;
            Mycommand.CommandText = text;
            DataAdapter.SelectCommand = Mycommand;
            conn.Open();
            DataAdapter.TableMappings.Add("Table", "User");
            DataAdapter.Fill(ds);
            dt = ds.Tables[0];
            int Count = dt.Rows.Count;
            for (int i = 0; i < Count; i++) comboBox1.Items.Add(dt.Rows[i][0].ToString());
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String ConnectionString1 = @"Provider=Microsoft.JET.OLEDB.4.0; Data Source=|DataDirectory|\\ClothShop.mdb";
            OleDbCommand Mycommand1 = new OleDbCommand();
            OleDbDataAdapter DataAdapter1 = new OleDbDataAdapter();
            DataTable dt1 = new DataTable();
            DataSet ds1 = new DataSet();
            OleDbConnection conn1 = new OleDbConnection(ConnectionString1);
            String text1 = "SELECT User.Login, User.Password,User.Name,User.Surname FROM [User]  ORDER BY Login";
            Mycommand1.Connection = conn1;
            Mycommand1.CommandText = text1;
            DataAdapter1.SelectCommand = Mycommand1;
            conn1.Open();
            DataAdapter1.TableMappings.Add("Table", "User");
            DataAdapter1.Fill(ds1);
            dt1 = ds1.Tables[0];
            int count1 = dt1.Rows.Count;
            for (int i = 0; i < count1; i++)
                if (comboBox1.Text == dt1.Rows[i][0].ToString() && textBox1.Text == dt1.Rows[i][1].ToString())
                {
                    string name = dt1.Rows[i][2].ToString();
                    string surname = dt1.Rows[i][3].ToString();
                    Form Form1 = new prosmotr();
                    Form1.Show();
                    this.Hide();


                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form prosmotr = new prosmotr();
            prosmotr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form registr = new registr();
            registr.Show();
            this.Hide();
        }
    }
}
