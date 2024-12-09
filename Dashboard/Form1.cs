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
using Org.BouncyCastle.Asn1.Crmf;

namespace Dashboard_STAFF
{
    public partial class Dashboard : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        public Dashboard()
        {
            InitializeComponent();

            LoadLowStockItems();
            LoadTotalRestockCount();
            LoadTotalShippedCount();
            LoadRestockRequests();
            search_textBox.TextChanged += search_textBox_TextChanged;


        }
        private void home_btn_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void inventory_btn_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            inventory.Show();
            this.Hide();
        }


        private void salesOrders_btn_Click(object sender, EventArgs e)
        {
            SalesOrder salesorder = new SalesOrder();
            salesorder.Show();
            this.Hide();
        }

        private void purchaseOrders_btn_Click(object sender, EventArgs e)
        {
            PurchaseOrders purchaseOrders = new PurchaseOrders();
            purchaseOrders.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
        private void notify_pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void SearchItems(string searchQuery)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    string query = @"SELECT ItemName, StockLevel 
                    FROM Inventory 
                    WHERE ItemName LIKE @searchQuery 
                    OR Category LIKE @searchQuery 
                    OR CAST(StockLevel AS CHAR) LIKE @searchQuery";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            lowItems_dataGridView.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadRestockRequests(string searchQuery = "")
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            rr.RequestID,
                            rr.ItemName,
                            rr.Brand,
                            rr.SerialNumber,
                            CONCAT(u.firstName, ' ', u.lastName) AS StaffName,
                            rr.QuantityRequested,
                            rr.RequestStatus
                        FROM RestockRequests rr
                        JOIN Users u ON rr.RequestedBy = u.UserID
                        WHERE rr.ItemName LIKE @searchQuery
                        OR rr.Brand LIKE @searchQuery
                        OR rr.SerialNumber LIKE @searchQuery
                        OR CONCAT(u.firstName, ' ', u.lastName) LIKE @searchQuery
                        OR rr.RequestStatus LIKE @searchQuery";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            requests_dataGridView.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchAll(string searchQuery)
        {
            LoadRestockRequests(searchQuery);

            SearchItems(searchQuery);
        }

        private void lowItems_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadLowStockItems();
        }


        private void LoadTotalRestockCount()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    string query = @"SELECT COUNT(*) 
                                     FROM Inventory 
                                     WHERE StockLevel < MinimumStockLevel";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int totalRestockCount = Convert.ToInt32(cmd.ExecuteScalar());
                        totalRestocked_label.Text = totalRestockCount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTotalShippedCount()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    string query = @"SELECT COUNT(*) 
                             FROM shipmentdetails 
                             WHERE ShippingStatus = 'Pending'";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int totalShippedCount = Convert.ToInt32(cmd.ExecuteScalar());
                        totalShipped_label.Text = totalShippedCount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadLowStockItems()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    string query = @"SELECT ItemName, StockLevel
                                     FROM inventory
                                     WHERE StockLevel < MinimumStockLevel";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        lowItems_dataGridView.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void search_textBox_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = search_textBox.Text.Trim();
            SearchAll(searchQuery);
        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadLowStockItems();
            LoadTotalRestockCount();
            LoadTotalShippedCount();
            LoadRestockRequests();

        }

        private void requests_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}