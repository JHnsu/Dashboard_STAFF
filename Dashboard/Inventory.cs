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
    public partial class Inventory : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        public Inventory()
        {
            InitializeComponent();
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
        private void profile_pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void search_textBox_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = search_textBox.Text.Trim();
            SearchAll(searchQuery);
        }

        private void SearchAll(string searchQuery)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                        po.PurchaseOrderID AS 'Order ID',
                        i.SerialNumber AS 'Serial No',
                        i.Category AS 'Type',
                        i.ItemName AS 'Item Name',
                        i.Brand,
                        i.StockLevel AS 'Quantity',
                        i.UnitPrice AS 'Price',
                        i.StockStatus AS 'Stock Status',
                        po.Status AS 'Order Status',
                        po.OrderDate AS 'Order Date'
                    FROM PurchaseOrders po
                    INNER JOIN Inventory i ON po.ItemID = i.ItemID
                    WHERE 
                        po.PurchaseOrderID LIKE @SearchQuery OR
                        i.SerialNumber LIKE @SearchQuery OR
                        i.Category LIKE @SearchQuery OR
                        i.ItemName LIKE @SearchQuery OR
                        i.Brand LIKE @SearchQuery OR
                        i.StockLevel LIKE @SearchQuery OR
                        i.UnitPrice LIKE @SearchQuery OR
                        i.StockStatus LIKE @SearchQuery OR
                        po.Status LIKE @SearchQuery OR
                        po.OrderDate LIKE @SearchQuery;";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@SearchQuery", $"%{searchQuery}%");

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
        private void notify_pictureBox_Click(object sender, EventArgs e)
        {

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
                    SerialNumber AS 'Serial No', 
                    Category AS 'Type', 
                    ItemName AS 'Item Name', 
                    Brand, 
                    StockLevel AS 'Quantity', 
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

        private void TotalItemsCount()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Inventory;";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int totalInventory = Convert.ToInt32(cmd.ExecuteScalar());
                        label4.Text = totalInventory.ToString();
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

        private void OutofStockCount()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM inventory WHERE StockLevel = 0;";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int outOfStockItems = Convert.ToInt32(cmd.ExecuteScalar());
                        label6.Text = outOfStockItems.ToString();
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

        private void LowStockCount()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Inventory WHERE StockLevel < MinimumStockLevel;";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int lowStockItems = Convert.ToInt32(cmd.ExecuteScalar());
                        label8.Text = lowStockItems.ToString();
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
        private void inventory_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadInventoryData();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            TotalItemsCount();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            OutofStockCount();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LowStockCount();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadInventoryData();
            TotalItemsCount();
            OutofStockCount();
            LowStockCount();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            LoadInventoryData();

            comboBox1.Items.AddRange(new string[]
           {
                "Item Name (A-Z)",
                "Stock Level (Highest to Lowest)",
                "Most Recent"
           });

            comboBox2.Items.AddRange(new string[]
            {
                "Category",
                "Brand",
                "Stock Status"
            });

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySortAndFilter();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySortAndFilter();
        }
        private void ApplySortAndFilter()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string sortBy = comboBox1.SelectedItem?.ToString();
                    string filterBy = comboBox2.SelectedItem?.ToString();

                    string query = @"
                    SELECT 
                        SerialNumber AS 'Serial No',
                        Category AS 'Type',
                        ItemName AS 'Item Name',
                        Brand,
                        StockLevel AS 'Quantity',
                        UnitPrice AS 'Price',
                        StockStatus AS 'Stock Status',
                        CreatedAt AS 'Date Added'
                    FROM Inventory";

                    string filterCondition = "";
                    if (!string.IsNullOrEmpty(filterBy))
                    {
                        if (filterBy == "Category")
                        {
                            filterCondition = " WHERE Category = @FilterValue";
                        }
                        else if (filterBy == "Brand")
                        {
                            filterCondition = " WHERE Brand = @FilterValue";
                        }
                        else if (filterBy == "Stock Status")
                        {
                            filterCondition = " WHERE StockStatus = @FilterValue";
                        }
                    }

                    string sortCondition = "";
                    if (!string.IsNullOrEmpty(sortBy))
                    {
                        if (sortBy == "Item Name (A-Z)")
                        {
                            sortCondition = " ORDER BY ItemName ASC";
                        }
                        else if (sortBy == "Stock Level (Highest to Lowest)")
                        {
                            sortCondition = " ORDER BY StockLevel DESC";
                        }
                        else if (sortBy == "Most Recent")
                        {
                            sortCondition = " ORDER BY CreatedAt DESC";
                        }
                    }

                    query += filterCondition + sortCondition;

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(filterBy))
                        {
                            cmd.Parameters.AddWithValue("@FilterValue", comboBox2.Text);
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            inventory_dataGridView.DataSource = dataTable;
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

        private void button3_Click(object sender, EventArgs e)
        {
            RestockRequest restockRequest = new RestockRequest();
            restockRequest.Show();
            this.Hide();
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
