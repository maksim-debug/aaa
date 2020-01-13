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
    public partial class prosmotr : Form
    {
        public prosmotr()
        {

            InitializeComponent();
            String ConnectionString1 = @"Provider=Microsoft.JET.OLEDB.4.0; Data Source=|DataDirectory|\\ClothShop.mdb";
            OleDbCommand Mycommand1 = new OleDbCommand();
            OleDbDataAdapter DataAdapter1 = new OleDbDataAdapter();
            DataTable dt1 = new DataTable();
            DataSet ds1 = new DataSet();
            OleDbConnection conn1 = new OleDbConnection(ConnectionString1);


            String text1 = "SELECT  Test.ID_Test,Test.NameTest FROM [Test]  ORDER BY ID_Test";
            Mycommand1.Connection = conn1;
            Mycommand1.CommandText = text1;
            DataAdapter1.SelectCommand = Mycommand1;
            conn1.Open();
            DataAdapter1.TableMappings.Add("Table", "Test");
            DataAdapter1.Fill(ds1);
            dt1 = ds1.Tables[0];
            int count1 = dt1.Rows.Count;
            for (int i = 0; i < count1; i++)

            //    comboBox1.Items.Add(dt1.Rows[i][1].ToString());
            //conn1.Close();
            {

            }

            String ConnectionString = @"Provider=Microsoft.JET.OLEDB.4.0; Data Source=|DataDirectory|\\ClothShop.mdb";
            OleDbCommand Mycommand = new OleDbCommand();
            OleDbDataAdapter DataAdapter = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            OleDbConnection conn = new OleDbConnection(ConnectionString);
            String text = "SELECT Result.Marks, Result.TimeRez, Result.DateRez FROM [Result] WHERE (((Result.ID_User Like 3)))";
            Mycommand.Connection = conn;
            Mycommand.CommandText = text;
            DataAdapter.SelectCommand = Mycommand;
            conn.Open();
            DataAdapter.TableMappings.Add("Table", "Result");
            DataAdapter.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void prosmotr_Load(object sender, EventArgs e)
        {

        }
    }
}
