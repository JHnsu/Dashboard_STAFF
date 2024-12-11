using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static Dashboard_STAFF.LogInForm;

namespace Dashboard_STAFF
{
    public partial class RestockRequest : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";

        public RestockRequest()
        {
            InitializeComponent();
            string username = CurrentUser.Username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string itemName = textBox2.Text.Trim();
            int quantity = (int)numericUpDown1.Value;
            decimal unitPrice = 0;

            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string validationQuery = @"
                        SELECT COUNT(*) 
                        FROM Inventory 
                        WHERE ItemName = @ItemName";

                    using (MySqlCommand cmd = new MySqlCommand(validationQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemName", itemName);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 0)
                        {
                            MessageBox.Show("Invalid Item Name. Please check your inputs.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    MessageBox.Show("Restock Request Submitted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string insertQuery = @"
                        INSERT INTO RestockRequests (RequestedBy, QuantityRequested, RequestStatus, ItemName, Price)
                        VALUES (@RequestedBy, @QuantityRequested, 'Pending', @ItemName, @Price)";

                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@RequestedBy", CurrentUser.Username);
                        insertCmd.Parameters.AddWithValue("@QuantityRequested", quantity);
                        insertCmd.Parameters.AddWithValue("@ItemName", itemName);
                        insertCmd.Parameters.AddWithValue("@Price", unitPrice);

                        insertCmd.ExecuteNonQuery();
                    }

                    textBox2.Clear();
                    numericUpDown1.Value = 0;
                    textBox1.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void LoadInventoryData()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            ItemID AS 'Item ID',
                            ItemName AS 'Item Name', 
                            Category AS 'Type', 
                            UnitPrice AS 'Price', 
                            StockLevel AS 'Quantity', 
                            StockStatus AS 'Stock Status'
                        FROM Inventory
                        WHERE StockLevel <= 0;";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        inventory_dataGridView.DataSource = dataTable;
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

        private void RestockRequest_Load(object sender, EventArgs e)
        {
            LoadInventoryData();
        }

        private void inventory_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = inventory_dataGridView.Rows[e.RowIndex];

                string itemName = row.Cells["Item Name"].Value.ToString();
                decimal unitPrice = Convert.ToDecimal(row.Cells["Price"].Value);
                int stockLevel = Convert.ToInt32(row.Cells["Quantity"].Value);

                textBox2.Text = itemName;
                textBox1.Text = unitPrice.ToString("F2");
                numericUpDown1.Value = stockLevel > 0 ? stockLevel : 1;
            }
        }

        private void inventory_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
