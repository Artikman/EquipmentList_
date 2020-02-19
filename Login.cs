using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CourseWork
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            this.textBox2.AutoSize = false;
            this.textBox2.Size = new Size(this.textBox2.Size.Width, 50);
        }

        // label close MOUSE ENTER
        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        // label close MOUSE LEAVE
        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
        }

        // button login
        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            String username = textBox1.Text;
            String password = textBox2.Text;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE username = @usn and password = @pass", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            // check if the user exists or not
            /*if (table.Rows.Count > 0)
            {
                this.Hide();
                MainForm mainform = new MainForm();
                mainform.Show();
            }
            else
            {
                // check if the username field is empty
                if (username.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Username To Login", "Empty Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // check if the password field is empty
                else if (password.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Password To Login", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // check if the username or the password don't exist
                else
                {
                    MessageBox.Show("Wrong Username Or Password", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }*/

            if (textBox1.Text == "artem10" && textBox2.Text == "12345")
            {
                this.Hide();
                ThirdForm thirdForm = new ThirdForm();
                thirdForm.Show();
                MessageBox.Show("Вы вошли как администратор!");
            }
            else
            {
                // check if the username field is empty
                if (username.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Username To Login", "Empty Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // check if the password field is empty
                else if (password.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Password To Login", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // check if the username or the password don't exist
                else if((textBox1.Text != "artem10" && textBox2.Text != "12345") && (textBox1.Text != "konstantin10" && textBox2.Text != "1234"))
                {
                    this.Hide();
                    SecondForm secondForm = new SecondForm();
                    secondForm.Show();
                    MessageBox.Show("Вы вошли как пользователь!");
                }
                else if(textBox1.Text == "konstantin10" && textBox2.Text == "1234")
                {
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    MessageBox.Show("Вы вошли как специалист!");
                }
                else
                {
                    MessageBox.Show("Wrong login or password!", "Repeat please!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.Show();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Yellow;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}