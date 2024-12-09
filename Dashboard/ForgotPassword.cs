using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Dashboard_STAFF
{
    public partial class ForgotPassword : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        private string generatedOtp;
        public ForgotPassword()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newPassword = textBox3.Text.Trim();
            string confirmPassword = textBox4.Text.Trim();
            string recipientEmail = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill out both password fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    string checkEmailQuery = "SELECT COUNT(*) FROM users WHERE Email = @recipientEmail";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkEmailQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@recipientEmail", recipientEmail);
                        int emailCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (emailCount == 0)
                        {
                            MessageBox.Show("Email not found in the database. Please check the email address and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();

                            textBox3.Enabled = false;
                            textBox4.Enabled = false;

                            textBox3.Focus();
                            return;
                        }
                    }

                    string query = "UPDATE users SET AccountPassword = @password WHERE Email = @recipientEmail";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@password", newPassword);
                        cmd.Parameters.AddWithValue("@recipientEmail", recipientEmail);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();

                            textBox3.Enabled = false;
                            textBox4.Enabled = false;

                            textBox3.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update password. Please ensure the email is correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the password. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button2_Click(object sender, EventArgs e)
        {
            string enteredOtp = textBox2.Text;

            if (string.IsNullOrEmpty(enteredOtp))
            {
                MessageBox.Show("Please enter the OTP.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (enteredOtp == generatedOtp)
            {
                MessageBox.Show("OTP verified successfully! You can now reset your password.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
            else
            {
                MessageBox.Show("Incorrect OTP. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string recipientEmail = textBox1.Text.Trim();

                if (string.IsNullOrEmpty(recipientEmail))
                {
                    MessageBox.Show("Please enter your email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!IsValidEmail(recipientEmail))
                {
                    MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Random random = new Random();
                generatedOtp = random.Next(100000, 999999).ToString();

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("info.cshark@gmail.com", "cebebwgubjvxtywp"),
                    EnableSsl = true
                };

                MailMessage mail = new MailMessage
                {
                    From = new MailAddress("info.cshark@gmail.com"),
                    Subject = "Password Reset OTP",
                    Body = $"Your OTP is: {generatedOtp}",
                    IsBodyHtml = false
                };

                mail.To.Add(recipientEmail);

                smtpClient.Send(mail);
                MessageBox.Show("OTP sent successfully. Please check your email.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(99, 218, 255);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(0, 93, 217);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LogInForm login = new LogInForm();
            login.Show();
            this.Close();
        }
    }
}
