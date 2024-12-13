using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Dashboard_STAFF
{
    public partial class LogInForm : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        int loginAttempts = 0;
        public LogInForm()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public static class CurrentUser
        {
            public static string Username { get; set; }
            public static string Role { get; set; }
            public static string FirstName { get; set; }
            public static string LastName { get; set; }
            public static string Email { get; set; }
            public static byte[] ProfilePicture { get; set; }
            public static int UserID { get; internal set; }
            public static string Address { get; internal set; }
            public static string PhoneNumber { get; internal set; }
            public static string FullName { get; internal set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || username == "Enter Username")
            {
                MessageBox.Show("Please enter a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(password) || password == "Enter Password")
            {
                MessageBox.Show("Please enter a password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    string query = "SELECT Username, AccountPassword, Role, FirstName, LastName, Email, ProfilePicture FROM users WHERE Username=@uname";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@uname", username);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            string storedPassword = reader["AccountPassword"].ToString();
                            string role = reader["Role"].ToString();
                            CurrentUser.FirstName = reader["FirstName"].ToString();
                            CurrentUser.LastName = reader["LastName"].ToString();

                            if (password == storedPassword)
                            {
                                // Set current user details
                                CurrentUser.Username = username;
                                CurrentUser.Role = role;
                                string FullName = CurrentUser.FirstName + " " + CurrentUser.LastName;
                                CurrentUser.Email = reader["Email"].ToString();
                                CurrentUser.ProfilePicture = reader["ProfilePicture"] as byte[];

                                LogAction(username, "Login");
                                MessageBox.Show($"Logged In Successfully as {role}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                loginAttempts = 0;

                                if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                                {
                                    Form1_ADMIN adminForm = new Form1_ADMIN();
                                    adminForm.Show();
                                    this.Hide();
                                }
                                else if (role.Equals("Staff", StringComparison.OrdinalIgnoreCase))
                                {
                                    Dashboard dashboard = new Dashboard();
                                    dashboard.Show();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                HandleFailedLogin();
                            }
                        }
                        else
                        {
                            HandleFailedLogin();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleFailedLogin()
        {
            loginAttempts++;
            if (loginAttempts >= 3)
            {
                MessageBox.Show("You have reached the maximum number of login attempts. Please try again later.", "Login Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Incorrect username or password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(99, 218, 255);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(0, 93, 217);
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "Enter Password" && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void LogAction(string username, string action)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    string query = "INSERT INTO user_audit_trail (username, action) VALUES (@uname, @action)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@uname", username);
                    cmd.Parameters.AddWithValue("@action", action);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to log action: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LogInForm_Load(object sender, EventArgs e)
        {

        }
    }
}
