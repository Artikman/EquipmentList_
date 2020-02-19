using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class ThirdForm : Form
    {

        string connectionString = @"Server=localhost;Database=quipmentlist;Uid=root;Pwd=root;";
        int UsersID;

        public ThirdForm()
        {
            InitializeComponent();
        }

        void GridFill()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                mySqlConnection.Open();
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter("UsersViewAll", mySqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[0].Visible = false;
            }
        }

        private void ThirdForm_Load(object sender, EventArgs e)
        {
            GridFill();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                mySqlConnection.Open();
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter("UsersSearchByValue", mySqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("_SearchValue", textBox6.Text);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[0].Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("EquipmentDeleteByID", mySqlConnection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.Parameters.AddWithValue("_ID", UsersID);
                mySqlCommand.ExecuteNonQuery();
                MessageBox.Show("Deleted Successful");
                GridFill();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}