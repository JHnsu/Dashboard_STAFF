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
    public partial class Form1_ADMIN : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        public Form1_ADMIN()
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
            this.Show();
        }

        private void inventory_btn_Click(object sender, EventArgs e)
        {
            Inventory inventoryAdmin = new Inventory();
            inventoryAdmin.Show();
            this.Hide();
        }


        private void salesOrders_btn_Click(object sender, EventArgs e)
        {
            SalesOrder_ADMIN salesorder = new SalesOrder_ADMIN();
            salesorder.Show();
            this.Hide();
        }

        private void purchaseOrders_btn_Click(object sender, EventArgs e)
        {
            PurchaseOrders_ADMIN purchaseOrders = new PurchaseOrders_ADMIN();
            purchaseOrders.Show();
            this.Hide();
        }

        private void reports_btn_Click(object sender, EventArgs e)
        {
            Reports_ADMIN reports_ADMIN = new Reports_ADMIN();
            reports_ADMIN.Show();
            this.Hide();
        }

        private void search_textBox_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = search_textBox.Text.Trim();
            SearchAll(searchQuery);
        }

        private void SearchAll(string searchQuery)
        {
            FilterLowStockItems(searchQuery);
            FilterTopSellingItems(searchQuery);
            FilterRestockRequests(searchQuery);
        }

        private void FilterLowStockItems(string searchQuery)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    string query = @"SELECT 
                            ItemName AS 'Item Name', 
                            StockLevel AS 'Current Stock'
                            FROM inventory
                            WHERE StockLevel < MinimumStockLevel 
                            AND ItemName LIKE @searchQuery";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");

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

        private void FilterTopSellingItems(string searchQuery)
        {
            try
            {
                string query = @"SELECT ItemName AS 'Item Name', SUM(Quantity) AS TotalSold, 
                        SUM(Quantity * Price) AS TotalPrice, DATE(SaleDate) AS 'Sale Date'
                        FROM Sales
                        WHERE ItemName LIKE @searchQuery
                        GROUP BY ItemName, SaleDate
                        ORDER BY TotalSold DESC";

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterRestockRequests(string searchQuery)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    string query = @"SELECT RequestID, RequestedBy, QuantityRequested, RequestStatus, 
                             ItemName, Brand, Price 
                             FROM restockrequests
                             WHERE ItemName LIKE @searchQuery
                             OR RequestedBy LIKE @searchQuery
                             OR RequestID LIKE @searchQuery";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        requests_dataGridView.DataSource = dt;

                        requests_dataGridView.Columns["RequestID"].HeaderText = "Request ID";
                        requests_dataGridView.Columns["RequestedBy"].HeaderText = "Requested By";
                        requests_dataGridView.Columns["QuantityRequested"].HeaderText = "Quantity Requested";
                        requests_dataGridView.Columns["RequestStatus"].HeaderText = "Status";
                        requests_dataGridView.Columns["ItemName"].HeaderText = "Item Name";
                        requests_dataGridView.Columns["Brand"].HeaderText = "Brand";
                        requests_dataGridView.Columns["Price"].HeaderText = "Price";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lowItems_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                             FROM sales
                             WHERE OrderStatus = 'Shipped'";

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

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadQuantityProgress();
            LoadLowStockItems();
            LoadTotalRestockCount();
            LoadTotalShippedCount();
            LoadRestockRequests();

            comboBox1.Items.Add("This Week");
            comboBox1.Items.Add("This Month");
            comboBox1.Items.Add("This Year");

            comboBox1.SelectedItem = "This Year";
        }

        private void LoadLowStockItems()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    string query = @"SELECT 
                                    ItemName AS 'Item Name', 
                                    StockLevel AS 'Current Stock'
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
        private void LoadQuantityProgress()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    string inHandQuery = @"SELECT SUM(StockLevel) AS TotalStock FROM Inventory WHERE StockLevel >= MinimumStockLevel";
                    using (MySqlCommand cmd = new MySqlCommand(inHandQuery, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        int totalStock = (result != DBNull.Value) ? Convert.ToInt32(result) : 0;

                        string maxStockQuery = @"SELECT SUM(MinimumStockLevel) AS TotalMinimumStock FROM Inventory";
                        using (MySqlCommand maxCmd = new MySqlCommand(maxStockQuery, conn))
                        {
                            object maxResult = maxCmd.ExecuteScalar();
                            int maxStock = (maxResult != DBNull.Value) ? Convert.ToInt32(maxResult) : 1;
                            int percentageInHand = Math.Clamp((int)((totalStock / (float)maxStock) * 100), 0, 100);

                            quantityHand_progressBar.Maximum = maxStock;
                            quantityHand_progressBar.Value = Math.Min(totalStock, maxStock);
                            percentHand_label.Text = $"{percentageInHand}%";

                            quantityHand_progressBar.ForeColor = percentageInHand < 20 ? Color.Red :
                                                                percentageInHand < 75 ? Color.Orange :
                                                                Color.Green;
                        }
                    }

                    string toReceiveQuery = @"SELECT SUM(Quantity) AS TotalToReceive FROM PurchaseOrders WHERE Status = 'Pending'";
                    using (MySqlCommand cmd = new MySqlCommand(toReceiveQuery, conn))
                    {
                        object resultToReceive = cmd.ExecuteScalar();
                        int totalToReceive = (resultToReceive != DBNull.Value) ? Convert.ToInt32(resultToReceive) : 0;

                        string maxReceiveQuery = @"SELECT SUM(Quantity) AS TotalExpectedReceive FROM PurchaseOrders WHERE Status = 'Pending'";
                        using (MySqlCommand maxReceiveCmd = new MySqlCommand(maxReceiveQuery, conn))
                        {
                            object maxReceiveResult = maxReceiveCmd.ExecuteScalar();
                            int maxReceive = (maxReceiveResult != DBNull.Value) ? Convert.ToInt32(maxReceiveResult) : 1;
                            int percentageToReceive = Math.Clamp((int)((totalToReceive / (float)maxReceive) * 100), 0, 100);

                            quantityReceived_progressBar.Maximum = maxReceive;
                            quantityReceived_progressBar.Value = Math.Min(totalToReceive, maxReceive);
                            percentReceived_label.Text = $"{percentageToReceive}%";

                            quantityReceived_progressBar.ForeColor = percentageToReceive < 20 ? Color.Red :
                                                                         percentageToReceive < 75 ? Color.Orange :
                                                                         Color.Green;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void requests_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void notify_pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lowItems_dataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            LoadLowStockItems();
        }

        private void quantityHand_progressBar_Click(object sender, EventArgs e)
        {

        }

        private void totalShipped_label_Click(object sender, EventArgs e)
        {
            //TO BE SHIPPED
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //TO BE RESTOCKED
        }

        private void requests_dataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // show all restock request
        }

        private void LoadRestockRequests()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    string query = @"SELECT RequestID, RequestedBy, QuantityRequested, RequestStatus, 
                             ItemName, Brand, Price 
                             FROM restockrequests";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        requests_dataGridView.DataSource = dt;

                        requests_dataGridView.Columns["RequestID"].HeaderText = "Request ID";
                        requests_dataGridView.Columns["RequestedBy"].HeaderText = "Requested By";
                        requests_dataGridView.Columns["QuantityRequested"].HeaderText = "Quantity Requested";
                        requests_dataGridView.Columns["RequestStatus"].HeaderText = "Status";
                        requests_dataGridView.Columns["ItemName"].HeaderText = "Item Name";
                        requests_dataGridView.Columns["Brand"].HeaderText = "Brand";
                        requests_dataGridView.Columns["Price"].HeaderText = "Price";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //item name, total shipped, total price, date
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPeriod = comboBox1.SelectedItem.ToString();
            LoadTopSellingItems(selectedPeriod);
        }
        private void LoadTopSellingItems(string period)
        {
            try
            {
                string query = string.Empty;

                if (period == "This Week")
                {
                    query = @"SELECT ItemName AS 'Item Name', SUM(Quantity) AS TotalSold, SUM(Quantity * Price) AS TotalPrice, 
                      DATE(SaleDate) AS 'Sale Date'
                      FROM Sales
                      WHERE YEARWEEK(SaleDate, 1) = YEARWEEK(CURDATE(), 1)
                      GROUP BY ItemName, SaleDate
                      ORDER BY TotalSold DESC";
                }
                else if (period == "This Month")
                {
                    query = @"SELECT ItemName AS 'Item Name', SUM(Quantity) AS TotalSold, SUM(Quantity * Price) AS TotalPrice, 
                      DATE(SaleDate) AS 'Sale Date'
                      FROM Sales
                      WHERE YEAR(SaleDate) = YEAR(CURDATE()) AND MONTH(SaleDate) = MONTH(CURDATE())
                      GROUP BY ItemName, SaleDate
                      ORDER BY TotalSold DESC";
                }
                else if (period == "This Year")
                {
                    query = @"SELECT ItemName AS 'Item Name', SUM(Quantity) AS TotalSold, SUM(Quantity * Price) AS TotalPrice, 
                      DATE(SaleDate) AS 'Sale Date'
                      FROM Sales
                      WHERE YEAR(SaleDate) = YEAR(CURDATE())
                      GROUP BY ItemName, SaleDate
                      ORDER BY TotalSold DESC";
                }

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt;

                        dataGridView1.Columns["Item Name"].HeaderText = "Item Name";
                        dataGridView1.Columns["TotalSold"].HeaderText = "Total Sold";
                        dataGridView1.Columns["TotalPrice"].HeaderText = "Total Price";
                        dataGridView1.Columns["Sale Date"].HeaderText = "Sale Date";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            UserProfile userprofile = new UserProfile();
            userprofile.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
