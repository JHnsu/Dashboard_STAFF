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

namespace Dashboard_STAFF
{
    public partial class UserProfile : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        public UserProfile()
        {
            InitializeComponent();
            string username = CurrentUser.Username;
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
            UserProfile userProfile = new UserProfile();
            userProfile.Show();
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
                // Ensure that the username is not empty or null
                if (string.IsNullOrWhiteSpace(CurrentUser.Username))
                {
                    MessageBox.Show("No user is logged in. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    // Query to select all user data based on the logged-in username
                    string query = "SELECT Username, CONCAT(FirstName, ' ', LastName) AS FullName, Email, Role, ProfilePicture, PhoneNumber, Address " +
                                   "FROM users WHERE Username = @username";

                    // Create command and add parameters to prevent SQL injection
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", CurrentUser.Username);

                    // Execute query and read data
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Check if the user exists in the database
                        if (reader.Read())
                        {
                            // Set the label texts to display the fetched data
                            label6.Text = $"Role: {reader["Role"]}";
                            label1.Text = $"Username: {reader["Username"]}";
                            label2.Text = $"Full Name: {reader["FullName"]}";
                            label3.Text = $"Email: {reader["Email"]}";
                            label4.Text = $"Phone Number: {reader["PhoneNumber"]}";
                            label5.Text = $"Address: {reader["Address"]}";

                            // Check if there is a profile picture and load it if available
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
                            // Handle case if no data is found for the username
                            MessageBox.Show("User data could not be found. Please ensure the user exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during database interaction
                MessageBox.Show($"Failed to load user data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void UserProfile_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }
    }
}
