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
using static Dashboard_STAFF.LogInForm;

namespace Dashboard_STAFF
{
    public partial class EditUserProfile : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        string username = CurrentUser.Username;
        public EditUserProfile()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //change profile picture
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

        private void button1_Click(object sender, EventArgs e)
        {
            //save button
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
                    string query = "UPDATE Users SET Email = @Email, PhoneNumber = @PhoneNumber, Address = @Address, ProfilePicture = @ProfilePicture WHERE Username = @Username";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", textBox3.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Address", textBox6.Text);
                    cmd.Parameters.AddWithValue("@ProfilePicture", (object)pictureData ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Username", textBox1.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profile updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No changes made.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating profile: " + ex.Message);
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
            Form1_ADMIN form1_ADMIN = new Form1_ADMIN();
            form1_ADMIN.Show();
            this.Hide();
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
            LoadUserProfile();
            string username = CurrentUser.Username;
            string role = CurrentUser.Role;
        }
        private void LoadUserProfile()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT Username, Role, Email, PhoneNumber, Address, ProfilePicture FROM Users WHERE Username = @username";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", CurrentUser.Username);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                        if (reader.Read())
                    {
                        textBox1.Text = reader["Username"].ToString();
                        label6.Text = reader["Role"].ToString();
                        textBox3.Text = reader["Email"].ToString();
                        textBox5.Text = reader["PhoneNumber"].ToString();
                        textBox6.Text = reader["Address"].ToString();

                        if (reader["ProfilePicture"] != DBNull.Value)
                        {
                            byte[] pictureData = (byte[])reader["ProfilePicture"];
                            MemoryStream ms = new MemoryStream(pictureData);
                            pictureBox2.Image = Image.FromStream(ms);
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
