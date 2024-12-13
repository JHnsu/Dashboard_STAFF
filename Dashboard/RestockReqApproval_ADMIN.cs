using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Dashboard_STAFF.LogInForm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Dashboard_STAFF
{
    public partial class RestockReqApproval_ADMIN : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        int selectedRequestID = 0;

        public int ItemID { get; private set; }

        public RestockReqApproval_ADMIN()
        {
            InitializeComponent();
            LoadRestockRequests();

            string username = CurrentUser.Username;

            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
        }
        private void LoadRestockRequests()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT RequestID, ItemName, QuantityRequested, RequestedBy, RequestDate, RequestStatus FROM RestockRequests WHERE RequestStatus = 'Pending'";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    requests_dataGridView.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void GetCurrentStock(string ItemID)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT StockLevel FROM Inventory WHERE ItemID = @ItemID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ItemID", ItemID);

                    object result = cmd.ExecuteScalar();
                    textBox2.Text = result != null ? result.ToString() : "0";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching stock level: " + ex.Message);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedRequestID == 0)
            {
                MessageBox.Show("Please select a request to approve or reject.");
                return;
            }

            string status = radioButton1.Checked ? "Approved" : radioButton2.Checked ? "Rejected" : "";

            if (string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Please select either 'Approve' or 'Reject'.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // Update the restock request
                    string query = @"
            UPDATE RestockRequests 
            SET RequestStatus = @Status, 
                ApprovalDate = CURRENT_TIMESTAMP, 
                ApprovedBy = @ApprovedBy 
            WHERE RequestID = @RequestID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@ApprovedBy", CurrentUser.Username);
                    cmd.Parameters.AddWithValue("@RequestID", selectedRequestID);
                    cmd.ExecuteNonQuery();

                    if (status == "Approved")
                    {
                        int requestedQuantity = int.Parse(textBox4.Text);
                        string itemName = textBox3.Text;

                        // Check if item name is empty or null
                        if (string.IsNullOrEmpty(itemName))
                        {
                            MessageBox.Show("Item name cannot be empty.");
                            return;
                        }

                        // Fetch the item details (including Brand and Price) from the Inventory table
                        string inventoryQuery = @"
                SELECT ItemID, Brand, UnitPrice AS Price 
                FROM Inventory 
                WHERE ItemName = @ItemName";
                        MySqlCommand inventoryCmd = new MySqlCommand(inventoryQuery, conn);
                        inventoryCmd.Parameters.AddWithValue("@ItemName", itemName);

                        using (MySqlDataReader reader = inventoryCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int itemID = reader.GetInt32("ItemID");
                                string brand = reader.GetString("Brand");
                                decimal price = reader.GetDecimal("Price");

                                // Check if the Brand or Price is null or empty
                                if (string.IsNullOrEmpty(brand) || price == 0)
                                {
                                    MessageBox.Show("Brand or Price is missing for the selected item in the Inventory table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                // After reader is closed, proceed with updating stock and inserting purchase order
                                reader.Close();

                                // Update the stock level in Inventory
                                string stockUpdateQuery = @"
                        UPDATE Inventory 
                        SET StockLevel = StockLevel + @Quantity 
                        WHERE ItemName = @ItemName AND ItemID = @ItemID";
                                MySqlCommand stockCmd = new MySqlCommand(stockUpdateQuery, conn);
                                stockCmd.Parameters.AddWithValue("@Quantity", requestedQuantity);
                                stockCmd.Parameters.AddWithValue("@ItemName", itemName);
                                stockCmd.Parameters.AddWithValue("@ItemID", itemID);
                                stockCmd.ExecuteNonQuery();

                                decimal totalPrice = requestedQuantity * price;

                                // Insert the purchase order
                                string purchaseOrderQuery = @"
                        INSERT INTO PurchaseOrders (ItemID, ItemName, Brand, Quantity, RequestedBy, TotalPrice, PurchaseDate)
                        VALUES (@ItemID, @ItemName, @Brand, @Quantity, @RequestedBy, @TotalPrice, CURRENT_TIMESTAMP)";
                                using (MySqlCommand purchaseCmd = new MySqlCommand(purchaseOrderQuery, conn))
                                {
                                    purchaseCmd.Parameters.AddWithValue("@ItemID", itemID);
                                    purchaseCmd.Parameters.AddWithValue("@ItemName", itemName);
                                    purchaseCmd.Parameters.AddWithValue("@Brand", brand);  // Brand is now included
                                    purchaseCmd.Parameters.AddWithValue("@Quantity", requestedQuantity);
                                    purchaseCmd.Parameters.AddWithValue("@RequestedBy", textBox5.Text);
                                    purchaseCmd.Parameters.AddWithValue("@TotalPrice", totalPrice);
                                    purchaseCmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Item not found in Inventory. Please check the item name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    MessageBox.Show($"Request {status} successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRestockRequests();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
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
        private void ClearFields()
        {
            selectedRequestID = 0;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //approved
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //reject
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void requests_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                MessageBox.Show("Please select a valid row from the list.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = requests_dataGridView.Rows[e.RowIndex];
                selectedRequestID = Convert.ToInt32(row.Cells["RequestID"].Value);
                textBox2.Text = row.Cells["RequestID"].Value.ToString();
                textBox3.Text = row.Cells["ItemName"].Value.ToString();
                textBox4.Text = row.Cells["QuantityRequested"].Value.ToString();
                textBox5.Text = row.Cells["RequestedBy"].Value.ToString();
            }
        }

        private void RestockReqApproval_ADMIN_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
    
}
