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
    public partial class registr : Form
    {
        public registr()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form registr = new Form1();
            registr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) MessageBox.Show("Заполните поле Логин");
            if (textBox2.Text.Length == 0) MessageBox.Show("Заполните поле Пароль");
            if (textBox3.Text.Length == 0) MessageBox.Show("Заполните поле Повторить пароль");
            if (textBox4.Text.Length == 0) MessageBox.Show("Заполните поле Имя");
            if (textBox5.Text.Length == 0) MessageBox.Show("Заполните поле Фамилия");
            String ConnectionString = @"Provider=Microsoft.JET.OLEDB.4.0; Data Source=|DataDirectory|\\Test.mdb";
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
            bool reg = false;
            for (int i = 0; i < Count; i++)
                if (textBox1.Text == dt.Rows[i][0].ToString())
                {
                    MessageBox.Show("Takoi login ezhe esst");
                    reg = true;
                }
            if (textBox2.Text.Length <= 6)
            {
                MessageBox.Show("Ne mennee 6");
                reg = true;
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("ne sovpadaet parol");
            }
            else

                conn.Close();



            string add = "INSERT INTO [User] (Login, [Password], Name, Surname) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "');";
            string connectionString1 = @"Provider=Microsoft.JET.OLEDB.4.0; Data Source=|DataDirectory|\\Test.mdb";
            OleDbCommand MyCommand1 = new OleDbCommand();
            OleDbConnection conn1 = new OleDbConnection(connectionString1);
            MyCommand1.Connection = conn1;
            MyCommand1.CommandText = add;
            conn1.Open();
            MyCommand1.ExecuteNonQuery();
            conn1.Close();

        }
    }
}
