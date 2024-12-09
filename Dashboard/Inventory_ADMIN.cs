using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using PdfSharp.Pdf.Filters;

namespace Dashboard_STAFF
{
    public partial class Inventory_ADMIN : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        public Inventory_ADMIN()
        {
            InitializeComponent();
        }

        private void home_btn_Click(object sender, EventArgs e)
        {
            Form1_ADMIN form1_ADMIN = new Form1_ADMIN();
            form1_ADMIN.Show();
            this.Hide();


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
                i.ItemID  AS 'Item ID',
                i.Category AS 'Type',
                i.ItemName AS 'Item Name',
                i.Brand,
                i.StockLevel AS 'Quantity',
                i.UnitPrice AS 'Price',
                i.StockStatus AS 'Stock Status'
            FROM Inventory i
            WHERE 
                i.ItemID LIKE @SearchQuery OR
                i.Category LIKE @SearchQuery OR
                i.ItemName LIKE @SearchQuery OR
                i.Brand LIKE @SearchQuery OR
                i.StockLevel LIKE @SearchQuery OR
                i.UnitPrice LIKE @SearchQuery OR
                i.StockStatus LIKE @SearchQuery;"; 


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

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Inventory_ADMIN_Load(object sender, EventArgs e)
        {
            LoadInventoryData();
            TotalItemsCount();
            LowStockCount();
            OutofStockCount();
            PopulateFilters();

        }
        private void PopulateFilters()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Item ID");
            comboBox2.Items.Add("Item Name");
            comboBox2.Items.Add("Category");
            comboBox2.Items.Add("Brand");
            comboBox2.Items.Add("Stock Status");
            comboBox2.Items.Add("Price");
            comboBox2.SelectedIndex = 0; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddItem_ADMIN addItem_ADMIN = new AddItem_ADMIN();
            addItem_ADMIN.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditItem_ADMIN editItem_ADMIN = new EditItem_ADMIN();
            editItem_ADMIN.Show();
        }

        private void inventory_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = inventory_dataGridView.Columns[e.ColumnIndex].Name;
            if (columnName == "Item ID")  
            {
                LoadInventoryData();
            }
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
                    UnitPrice AS 'Price', 
                    StockStatus AS 'Stock Status'
                FROM Inventory;";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable); 
                        inventory_dataGridView.DataSource = dataTable;  
                    }
                    TotalItemsCount();
                    LowStockCount();
                    OutofStockCount();
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

        private void splitContainer1_Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (inventory_dataGridView.SelectedRows.Count > 0)
            {
                DialogResult confirmDelete = MessageBox.Show(
                    "Are you sure you want to delete the selected items?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmDelete == DialogResult.Yes)
                {
                    List<int> itemIDsToDelete = new List<int>();
                    foreach (DataGridViewRow row in inventory_dataGridView.SelectedRows)
                    {
                        if (row.Cells["Item ID"].Value != null)  
                        {
                            itemIDsToDelete.Add(Convert.ToInt32(row.Cells["Item ID"].Value));
                        }
                    }

                    if (itemIDsToDelete.Count > 0)
                    {
                        DeleteItems(itemIDsToDelete);  
                        LoadInventoryData();
                        TotalItemsCount();
                        LowStockCount();
                        OutofStockCount();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select items to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteItems(List<int> itemIDs)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = $"DELETE FROM Inventory WHERE ItemID IN ({string.Join(",", itemIDs)})";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();  
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



        private void profile_pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void salesOrders_btn_Click(object sender, EventArgs e)
        {
            SalesOrder_ADMIN salesorder = new SalesOrder_ADMIN();
            salesorder.Show();
            this.Hide();
        }

        private void inventory_btn_Click(object sender, EventArgs e)
        {
            Inventory_ADMIN inventoryAdmin = new Inventory_ADMIN();
            inventoryAdmin.Show();
            this.Hide();
        }



        private void salesReturns_btn_Click(object sender, EventArgs e)
        {
            SalesReturn_ADMIN salesreturn = new SalesReturn_ADMIN();
            salesreturn.Show();
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
            Reports_ADMIN reportsAdmin = new Reports_ADMIN();
            reportsAdmin.Show();
            this.Hide();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = comboBox2.SelectedItem?.ToString();
            string selectedSort = comboBox1.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedFilter) && !string.IsNullOrEmpty(selectedSort))
            {
                ApplyFilterAndSort(selectedFilter, selectedSort);
            }
        }
        private void ApplyFilterAndSort(string filter, string sort)
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
                    UnitPrice AS 'Price', 
                    StockStatus AS 'Stock Status'
                FROM Inventory 
                WHERE 1=1";
                    /*string query = @"
                    SELECT 
                        ItemID AS 'Item ID',
                        ItemName AS 'Item Name',
                        Category AS 'Type',
                        Brand,
                        StockLevel AS 'Quantity',
                        StockStatus AS 'Stock Status',
                        CreatedAt AS 'Created At'
                    FROM Inventory 
                    WHERE 1=1";*/


                    switch (filter)
                    {
                        case "Item ID":
                            query += " ORDER BY ItemID";
                            break;
                        case "Item Name":
                            query += " ORDER BY ItemName";
                            break;
                        case "Category":
                            query += " ORDER BY Category";
                            break;
                        case "Brand":
                            query += " ORDER BY Brand";
                            break;
                        case "Stock Status":
                            query += " ORDER BY StockStatus";
                            break;
                        case "Price":
                            query += " ORDER BY UnitPrice";
                            break;
                    }

                    if (filter == "Item ID" || filter == "Price")
                    {
                        if (sort.Contains("Ascending") || sort.Contains("Low to High"))
                            query += " ASC";
                        else if (sort.Contains("Descending") || sort.Contains("High to Low"))
                            query += " DESC";
                    }
                    else
                    {
                        if (sort.Contains("A-Z"))
                            query += " ASC";
                        else if (sort.Contains("Z-A"))
                            query += " DESC";
                        /*else if (sort.Contains("Newest"))
                            query += " DESC";
                        else if (sort.Contains("Oldest"))
                            query += " ASC";*/
                    }

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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = comboBox2.SelectedItem?.ToString();

            comboBox1.Items.Clear();  
            comboBox1.Enabled = false;  

            if (!string.IsNullOrEmpty(selectedFilter))
            {
                switch (selectedFilter)
                {
                    case "Item ID":
                        comboBox1.Items.Add("Item ID (Ascending)");
                        comboBox1.Items.Add("Item ID (Descending)");
                        break;

                    case "Item Name":
                        comboBox1.Items.Add("Item Name (A-Z)");
                        comboBox1.Items.Add("Item Name (Z-A)");
                        break;

                    case "Category":
                        comboBox1.Items.Add("Category (A-Z)");
                        comboBox1.Items.Add("Category (Z-A)");
                        break;

                    case "Brand":
                        comboBox1.Items.Add("Brand (A-Z)");
                        comboBox1.Items.Add("Brand (Z-A)");
                        break;

                    case "Price":
                        comboBox1.Items.Add("Lowest to Highest");
                        comboBox1.Items.Add("Highest to Lowest");
                        break;

                    case "Stock Status":
                        comboBox1.Items.Add("In Stock");
                        comboBox1.Items.Add("Out of Stock");
                        comboBox1.Items.Add("Low Stock");
                        break;

                    default:
                        MessageBox.Show("Invalid filter selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }

                comboBox1.Enabled = true; 
                comboBox1.SelectedIndex = 0;
            }
        }

    }
}

