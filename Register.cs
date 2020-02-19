using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CourseWork
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            // remove the focus from the textboxes by making a label the active control
            this.ActiveControl = label1;
        }

        // textbox first name ENTER
        private void textBoxFirstName_Enter(object sender, EventArgs e)
        {
            String fname = textBoxFirstName.Text;
            if (fname.ToLower().Trim().Equals("first name"))
            {
                textBoxFirstName.Text = "";
                textBoxFirstName.ForeColor = Color.Black;
            }
        }

        // textbox first name LEAVE
        private void textBoxFirstName_Leave(object sender, EventArgs e)
        {
            String fname = textBoxFirstName.Text;
            if (fname.ToLower().Trim().Equals("first name") || fname.Trim().Equals(""))
            {
                textBoxFirstName.Text = "first name";
                textBoxFirstName.ForeColor = Color.Gray;
            }
        }


        // textbox last name ENTER
        private void textBoxLastName_Enter(object sender, EventArgs e)
        {
            String lname = textBoxLastName.Text;
            if (lname.ToLower().Trim().Equals("last name"))
            {
                textBoxLastName.Text = "";
                textBoxLastName.ForeColor = Color.Black;
            }
        }


        // textbox last name LEAVE
        private void textBoxLastName_Leave(object sender, EventArgs e)
        {
            String lname = textBoxLastName.Text;
            if (lname.ToLower().Trim().Equals("last name") || lname.Trim().Equals(""))
            {
                textBoxLastName.Text = "last name";
                textBoxLastName.ForeColor = Color.Gray;
            }
        }

        // textbox email ENTER
        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            String email = textBoxEmail.Text;
            if (email.ToLower().Trim().Equals("email"))
            {
                textBoxEmail.Text = "";
                textBoxEmail.ForeColor = Color.Black;
            }
        }

        // textbox email LEAVE
        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            String email = textBoxEmail.Text;
            if (email.ToLower().Trim().Equals("email") || email.Trim().Equals(""))
            {
                textBoxEmail.Text = "email";
                textBoxEmail.ForeColor = Color.Gray;
            }
        }

        // textbox username ENTER
        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            String username = textBoxUsername.Text;
            if (username.ToLower().Trim().Equals("username"))
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = Color.Black;
            }
        }

        // textbox username LEAVE
        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            String username = textBoxUsername.Text;
            if (username.ToLower().Trim().Equals("username") || username.Trim().Equals(""))
            {
                textBoxUsername.Text = "username";
                textBoxUsername.ForeColor = Color.Gray;
            }
        }

        // textbox password ENTER
        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            String password = textBoxPassword.Text;
            if (password.ToLower().Trim().Equals("password"))
            {
                textBoxPassword.Text = "";
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxPassword.ForeColor = Color.Black;
            }
        }

        // textbox password LEAVE
        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            String password = textBoxPassword.Text;
            if (password.ToLower().Trim().Equals("password") || password.Trim().Equals(""))
            {
                textBoxPassword.Text = "password";
                textBoxPassword.UseSystemPasswordChar = false;
                textBoxPassword.ForeColor = Color.Gray;
            }
        }

        // textbox confirm password ENTER
        private void textBoxConfirmPassword_Enter(object sender, EventArgs e)
        {
            String cpassword = textBoxConfirmPassword.Text;
            if (cpassword.ToLower().Trim().Equals("confirm password"))
            {
                textBoxConfirmPassword.Text = "";
                textBoxConfirmPassword.UseSystemPasswordChar = true;
                textBoxConfirmPassword.ForeColor = Color.Black;
            }
        }

        // textbox confirm password LEAVE
        private void textBoxConfirmPassword_Leave(object sender, EventArgs e)
        {
            String cpassword = textBoxConfirmPassword.Text;
            if (cpassword.ToLower().Trim().Equals("confirm password") ||
                cpassword.ToLower().Trim().Equals("password") ||
                cpassword.Trim().Equals(""))
            {
                textBoxConfirmPassword.Text = "confirm password";
                textBoxConfirmPassword.UseSystemPasswordChar = false;
                textBoxConfirmPassword.ForeColor = Color.Gray;
            }
        }

        // label close CLICK
        private void label1_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        // label close MOUSE ENTER
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        // label close MOUSE LEAVE
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        // button signup
        private void button1_Click(object sender, EventArgs e)
        {
            // add a new user

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO users(firstname, lastname, emailaddress, username, password) VALUES (@fn, @ln, @email, @usn, @pass)", db.getConnection());

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = textBoxFirstName.Text;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = textBoxLastName.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBoxEmail.Text;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;

            // open the connection
            db.openConnection();

            // check if the textboxes contains the default values 
            if (!checkTextBoxesValues())
            {
                // check if the password equal the confirm password
                if (textBoxPassword.Text.Equals(textBoxConfirmPassword.Text))
                {
                    // check if this username already exists
                    if (checkUsername())
                    {
                        MessageBox.Show("This Username Already Exists, Select A Different One", "Duplicate Username", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // execute the query
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Your Account Has Been Created", "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("ERROR");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Confirmation Password", "Password Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Enter Your Informations First", "Empty Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }



            // close the connection
            db.closeConnection();

        }


        // check if the username already exists
        public Boolean checkUsername()
        {
            DB db = new DB();

            String username = textBoxUsername.Text;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE username = @usn", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            // check if this username already exists in the database
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // check if the textboxes contains the default values
        public Boolean checkTextBoxesValues()
        {
            String fname = textBoxFirstName.Text;
            String lname = textBoxLastName.Text;
            String email = textBoxEmail.Text;
            String uname = textBoxUsername.Text;
            String pass = textBoxPassword.Text;

            if (fname.Equals("first name") || lname.Equals("last name") ||
                email.Equals("email address") || uname.Equals("username")
                || pass.Equals("password"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Yellow;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
        }
    }
}