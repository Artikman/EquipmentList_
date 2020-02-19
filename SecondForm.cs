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

namespace CourseWork
{
    public partial class SecondForm : Form
    {
        private string connectionString = @"Server=localhost;Database=quipmentlist;Uid=root;Pwd=root;";

        public SecondForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;port=3306;database=quipmentlist;Uid=root;Pwd=root;");
            MySqlCommand cmd = new MySqlCommand("select * from equipment", con);
            MySqlDataReader mySqlDataReader;
            try
            {
                con.Open();
                mySqlDataReader = cmd.ExecuteReader();
                while(mySqlDataReader.Read())
                {
                    this.chart1.Series["Cost"].Points.AddXY(mySqlDataReader.GetString("Cathedra"), mySqlDataReader.GetInt32("Cost"));
                    this.chart1.Series["TotalCost"].Points.AddXY(mySqlDataReader.GetString("Cathedra"), mySqlDataReader.GetInt32("TotalCost"));

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void GridFill()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                mySqlConnection.Open();
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter("EquipmentViewAll", mySqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[0].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GridFill();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login register = new Login();
            register.Show();
        }

        private void label3_Enter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
        }

        private void label3_Leave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Yellow;
        }
    }
}