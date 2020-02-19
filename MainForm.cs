using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CourseWork
{
    public partial class MainForm : Form
    {
        string connectionString = @"Server=localhost;Database=quipmentlist;Uid=root;Pwd=root;";
        int equipmentID;

        public MainForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("EquipmentAddOrEdit", mySqlConnection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.Parameters.AddWithValue("_EquipmentID", equipmentID);
                mySqlCommand.Parameters.AddWithValue("_Cathedra", textBox1.Text.Trim());
                mySqlCommand.Parameters.AddWithValue("_EquipmentName", textBox2.Text.Trim());
                mySqlCommand.Parameters.AddWithValue("_Quantity", textBox3.Text.Trim());
                mySqlCommand.Parameters.AddWithValue("_Cost", textBox4.Text.Trim());
                mySqlCommand.Parameters.AddWithValue("_TotalCost", textBox5.Text.Trim());
                mySqlCommand.ExecuteNonQuery();
                MessageBox.Show("Submitted Successfully!");
                Clear();
                GridFill();
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            Clear();
            GridFill();
        }

        void Clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
            equipmentID = 0;
            button1.Text = "Save";
            button2.Enabled = false;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                equipmentID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                button1.Text = "Update";
                button2.Enabled = Enabled;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                mySqlConnection.Open();
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter("EquipmentSearchByValue", mySqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("_SearchValue", textBox6.Text);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[0].Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("EquipmentDeleteByID", mySqlConnection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.Parameters.AddWithValue("_EquipmentID", equipmentID);
                mySqlCommand.ExecuteNonQuery();
                MessageBox.Show("Deleted Successful");
                Clear();
                GridFill();
            }
        }

        private void label10_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login register = new Login();
            register.Show();
        }

        private void label10_Enter(object sender, EventArgs e)
        {
            label10.ForeColor = Color.White;
        }

        private void label10_Leave(object sender, EventArgs e)
        {
            label10.ForeColor = Color.Yellow;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar <= 48 || e.KeyChar >= 59) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 59) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 59) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}