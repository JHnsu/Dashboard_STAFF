using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Dashboard_STAFF.LogInForm;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Dashboard_STAFF
{
    public partial class UserProfile : Form
    {

        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";

        private string fullName;
        private string email;

        public UserProfile(string fullName, string email)
        {
            InitializeComponent();

            label1.Text = CurrentUser.FirstName + " " + CurrentUser.LastName;  
            label3.Text = email;
            this.fullName = fullName;
            this.email = email;
            DisplayUserProfile();

            if (string.IsNullOrWhiteSpace(CurrentUser.Username))
            {
                MessageBox.Show("No user is logged in. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadUserData();
        }
        private void DisplayUserProfile()
        {
            label2.Text = fullName;
            label3.Text = email;
        }
        public void RefreshUserProfile(string updatedFullName, string updatedEmail)
        {
            // Update the details with the new data
            label2.Text = updatedFullName;
            label3.Text = updatedEmail;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            /*if (CurrentUser.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                Form1_ADMIN adminForm = new Form1_ADMIN();
                adminForm.Show();
                this.Hide();
            }
            else if (CurrentUser.Role.Equals("Staff", StringComparison.OrdinalIgnoreCase))
            {
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid role detected. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }*/
            LogInForm logInForm = new LogInForm();
            logInForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CurrentUser.Username))
            {
                MessageBox.Show("No user is logged in. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EditUserProfile editUserProfile = new EditUserProfile(CurrentUser.UserID, CurrentUser.Username, CurrentUser.Role,
                                                                   CurrentUser.FullName, CurrentUser.Email,
                                                                   CurrentUser.PhoneNumber, CurrentUser.Address, CurrentUser.ProfilePicture);

            editUserProfile.Show();

            this.Hide();
        }
        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(99, 218, 255);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(0, 93, 217);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            //Role
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //username
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //fullname
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //gmail
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //number
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //address
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //picture
        }
        private void LoadUserData()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CurrentUser.Username))
                {
                    MessageBox.Show("No user is logged in. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    string query = @"SELECT Username, CONCAT(FirstName, ' ', LastName) AS FullName, Email, Role, ProfilePicture, PhoneNumber, Address 
                             FROM users WHERE Username = @username";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", CurrentUser.Username);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            label6.Text = $"Role: {reader["Role"]}";
                            label1.Text = $"Username: {reader["Username"]}";
                            label2.Text = $"Full Name: {reader["FullName"]}";
                            label3.Text = $"Email: {reader["Email"]}";
                            label4.Text = $"Phone Number: {reader["PhoneNumber"]}";
                            label5.Text = $"Address: {reader["Address"]}";

                            if (reader["ProfilePicture"] != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])reader["ProfilePicture"];
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    pictureBox2.Image = Image.FromStream(ms);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("User data not found. Please ensure the user exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load user data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void UserProfile_Load(object sender, EventArgs e)
        {
            LoadUserData();

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
