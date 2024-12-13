using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.IO.Colors;
using MySql.Data.MySqlClient;
using static Dashboard_STAFF.LogInForm;

namespace Dashboard_STAFF
{
    public partial class EditUserProfile : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";

        private int userID;
        private string username;
        private string role;
        private string fullName;
        private string email;
        private string contactNumber;
        private string address;
        private string phoneNumber;
        private System.Drawing.Image profilePicture;

        public byte[] ProfilePicture { get; }

        public EditUserProfile(int userID, string username, string role, string fullName, string email, string contactNumber, string address, Image profilePicture)
        {
            InitializeComponent();

            this.userID = userID;
            this.username = username;
            this.role = role;  
            this.fullName = fullName;
            this.email = email;
            this.contactNumber = contactNumber;  
            this.address = address;  
            this.profilePicture = profilePicture;

            textBox1.Text = username;

            string[] nameParts = fullName.Split(' ');
            if (nameParts.Length >= 2)
            {
                textBox2.Text = nameParts[0];  
                textBox4.Text = string.Join(" ", nameParts.Skip(1)); 
            }
            else
            {
                textBox2.Text = fullName;
                textBox4.Text = string.Empty;
            }

            textBox3.Text = email;
            textBox5.Text = contactNumber; 
            textBox6.Text = address;  

            if (profilePicture != null)
            {
                pictureBox2.Image = profilePicture;
            }
        }


        public EditUserProfile(int userID, string? username, string role, string fullName)
        {
            InitializeComponent();
        }
        public EditUserProfile(int userID, string? username, string role, string fullName, string email, string phoneNumber, string address, byte[] profilePicture1) : this(userID, username, role, fullName)
        {
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.address = address;
            ProfilePicture = profilePicture1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(99, 218, 255);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(0, 93, 217);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //delete profile picture
            pictureBox2.Image = null;
        }
        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(99, 218, 255);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(0, 93, 217);
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            pictureBox2.Image = null; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || 
            string.IsNullOrWhiteSpace(textBox2.Text) || 
            string.IsNullOrWhiteSpace(textBox4.Text) ||
            string.IsNullOrWhiteSpace(textBox3.Text) || 
            string.IsNullOrWhiteSpace(textBox5.Text) || 
            string.IsNullOrWhiteSpace(textBox6.Text) || 
            pictureBox2.Image == null) 
                {
                    MessageBox.Show("All fields must be filled out, including the profile picture.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            try
            {
                byte[] pictureData = null;
                if (pictureBox2.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
                        pictureData = ms.ToArray();
                    }
                }

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string query = @"UPDATE Users 
                             SET Email = @Email, 
                                 PhoneNumber = @PhoneNumber, 
                                 FirstName = @FirstName, 
                                 LastName = @LastName, 
                                 Address = @Address, 
                                 ProfilePicture = @ProfilePicture 
                             WHERE Username = @Username";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", textBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@PhoneNumber", textBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@FirstName", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", textBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", textBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@ProfilePicture", (object)pictureData ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Username", textBox1.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        LoadUserProfile(CurrentUser.Username);
                        CurrentUser.Username = textBox1.Text.Trim();
                        CurrentUser.FullName = textBox2.Text.Trim() + " " + textBox4.Text.Trim();
                        CurrentUser.Email = textBox3.Text.Trim();
                        CurrentUser.PhoneNumber = textBox5.Text.Trim();
                        CurrentUser.Address = textBox6.Text.Trim();

                        MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("No changes were detected in the profile. Please modify the fields and try again.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (CurrentUser.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
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
                MessageBox.Show("Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            //role
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //username
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //first name
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //last name
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //email
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //phone number
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //address
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //picture
        }

        private void EditUserProfile_Load(object sender, EventArgs e)
        {
            string username = CurrentUser.Username;
            string role = CurrentUser.Role;

            if (userID != 0)
            {
                LoadUserProfile(userID);
            }
            else
            {
                LoadUserProfile(CurrentUser.Username);
            }
        }
        private void LoadUserProfile(int userID)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string query = @"SELECT Username, FirstName, LastName, Role, Email, PhoneNumber, Address, ProfilePicture 
                             FROM Users WHERE UserID = @userID"; 
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userID", userID);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox1.Text = reader["Username"].ToString();
                            textBox2.Text = reader["FirstName"].ToString();
                            textBox4.Text = reader["LastName"].ToString();
                            label6.Text = reader["Role"].ToString();
                            textBox3.Text = reader["Email"].ToString();
                            textBox5.Text = reader["PhoneNumber"].ToString();
                            textBox6.Text = reader["Address"].ToString();

                            if (reader["ProfilePicture"] != DBNull.Value)
                            {
                                byte[] pictureData = (byte[])reader["ProfilePicture"];
                                CurrentUser.ProfilePicture = pictureData;
                                MemoryStream ms = new MemoryStream(pictureData);
                                pictureBox2.Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user profile: " + ex.Message);
            }
        }

        private void LoadUserProfile(string username)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string query = @"SELECT Username, FirstName, LastName, Role, Email, PhoneNumber, Address, ProfilePicture 
                             FROM Users WHERE Username = @username";  // Use Username to query for the logged-in user
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox1.Text = reader["Username"].ToString();
                            textBox2.Text = reader["FirstName"].ToString();
                            textBox4.Text = reader["LastName"].ToString();
                            label6.Text = reader["Role"].ToString();
                            textBox3.Text = reader["Email"].ToString();
                            textBox5.Text = reader["PhoneNumber"].ToString();
                            textBox6.Text = reader["Address"].ToString();

                            if (reader["ProfilePicture"] != DBNull.Value)
                            {
                                byte[] pictureData = (byte[])reader["ProfilePicture"];
                                CurrentUser.ProfilePicture = pictureData;
                                MemoryStream ms = new MemoryStream(pictureData);
                                pictureBox2.Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user profile: " + ex.Message);
            }
        }

    }
}
