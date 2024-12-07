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

namespace Dashboard_STAFF
{
    public partial class EditItem_ADMIN : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        public EditItem_ADMIN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Select an Image"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                pictureBox1.Tag = openFileDialog.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("Serial Number is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] imageData = null;
            if (pictureBox1.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    imageData = ms.ToArray();
                }
            }

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string query = "UPDATE Inventory SET " +
                                   "Category = @Category, " +
                                   "ItemName = @ItemName, " +
                                   "Brand = @Brand, " +
                                   "StockLevel = @StockLevel, " +
                                   "UnitPrice = @UnitPrice, " +
                                   "ItemImage = @ItemImage " +
                                   "WHERE SerialNumber = @SerialNumber";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SerialNumber", textBox1.Text.Trim()); // Serial Number as key to find the item
                        cmd.Parameters.AddWithValue("@Category", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@ItemName", textBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@Brand", textBox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@StockLevel", numericUpDown1.Value);
                        cmd.Parameters.AddWithValue("@UnitPrice", numericUpDown2.Value);
                        cmd.Parameters.AddWithValue("@ItemImage", imageData ?? (object)DBNull.Value); // Handle the image as nullable (if no image, it will store NULL)

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to update item. Please ensure the Serial Number is correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
