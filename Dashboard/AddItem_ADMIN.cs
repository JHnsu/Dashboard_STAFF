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

namespace Dashboard_STAFF
{
    public partial class AddItem_ADMIN : Form
    {
        public delegate void ItemAddedEventHandler();
        public event ItemAddedEventHandler ItemAdded;
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        public AddItem_ADMIN()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text.Trim()) ||
                  string.IsNullOrEmpty(textBox3.Text.Trim()) ||
                  string.IsNullOrEmpty(textBox4.Text.Trim()) ||
                  numericUpDown1.Value == 0 ||   
                  numericUpDown2.Value == 0 ||
                  numericUpDown3.Value == 0)
            {
                MessageBox.Show("Please fill all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            string stockStatus = "In Stock";
            decimal quantity = numericUpDown1.Value;
            decimal minimumStockLevel = numericUpDown3.Value;

            if (quantity == 0)
            {
                stockStatus = "Out of Stock";
            }
            else if (quantity > 0 && quantity <= minimumStockLevel)
            {
                stockStatus = "Low Stock";
            }

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO Inventory (Category, ItemName, Brand, StockLevel, UnitPrice, MinimumStockLevel, StockStatus) " +
                                   "VALUES (@Category, @ItemName, @Brand, @StockLevel, @UnitPrice, @MinimumStockLevel, @StockStatus)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@Category", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@ItemName", textBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@Brand", textBox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@StockLevel", numericUpDown1.Value);
                        cmd.Parameters.AddWithValue("@UnitPrice", numericUpDown2.Value);
                        cmd.Parameters.AddWithValue("@MinimumStockLevel", numericUpDown3.Value);
                        cmd.Parameters.AddWithValue("@StockStatus", stockStatus);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);   
                            ItemAdded?.Invoke();
                            ClearFormFields();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void ClearFormFields()
        {
            textBox3.Clear();
            textBox2.Clear();
            textBox4.Clear();
            numericUpDown1.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown2.Value = 0;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(99, 218, 255);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(0, 93, 217);
        }
    }
}
