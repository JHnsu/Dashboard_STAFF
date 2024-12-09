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
        public delegate void ItemEditedEventHandler();
        public event ItemEditedEventHandler ItemEdited;

        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        public EditItem_ADMIN()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string stockStatus = "In Stock";
                    int quantity = (int)numericUpDown1.Value;
                    int minimumStockLevel = (int)numericUpDown3.Value;


                    if (quantity == 0)
                    {
                        stockStatus = "Out of Stock";
                    }
                    else if (quantity > 0 && quantity <= minimumStockLevel)
                    {
                        stockStatus = "Low Stock";
                    }

                    string query = @"UPDATE Inventory SET 
                                Category = @Category, 
                                ItemName = @ItemName,
                                Brand = @Brand, 
                                StockLevel = @StockLevel, 
                                MinimumStockLevel = @MinimumStockLevel, 
                                UnitPrice = @UnitPrice, 
                                StockStatus = @StockStatus
                             WHERE ItemID = @ItemID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemID", inventory_dataGridView.SelectedRows[0].Cells["Item ID"].Value);
                        cmd.Parameters.AddWithValue("@Category", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@ItemName", textBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@Brand", textBox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@StockLevel", numericUpDown1.Value);
                        cmd.Parameters.AddWithValue("@MinimumStockLevel", numericUpDown3.Value);
                        cmd.Parameters.AddWithValue("@UnitPrice", numericUpDown2.Value);
                        cmd.Parameters.AddWithValue("@StockStatus", stockStatus);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadInventoryData();
                            ClearFormFields();
                            ItemEdited?.Invoke();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update item. Please ensure the Item ID is correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Brand, 
                    StockLevel AS 'Quantity', 
                    MinimumStockLevel AS 'Minimum Stock Level', 
                    UnitPrice AS 'Price', 
                    StockStatus AS 'Stock Status'
                FROM Inventory;";

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

        private void EditItem_ADMIN_Load(object sender, EventArgs e)
        {
            LoadInventoryData();
        }

        private void inventory_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = inventory_dataGridView.Rows[e.RowIndex];

                textBox3.Text = row.Cells["Item Name"].Value?.ToString();
                textBox2.Text = row.Cells["Type"].Value?.ToString();
                textBox4.Text = row.Cells["Brand"].Value?.ToString();
                numericUpDown1.Value = Convert.ToDecimal(row.Cells["Quantity"].Value ?? 0);
                numericUpDown3.Value = Convert.ToDecimal(row.Cells["Minimum Stock Level"].Value ?? 0);
                numericUpDown2.Value = Convert.ToDecimal(row.Cells["Price"].Value ?? 0);
            }
        }
    }
}
