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

        private void inventory_btn_Click(object sender, EventArgs e)
        {
            Inventory_ADMIN inventoryAdmin = new Inventory_ADMIN();
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
            Reports_ADMIN reportsAdmin = new Reports_ADMIN();
            reportsAdmin.Show();
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

        private void Inventory_ADMIN_Load(object sender, EventArgs e)
        {
            LoadInventoryData();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddItem_ADMIN addItem_ADMIN = new AddItem_ADMIN();
            addItem_ADMIN.Show();
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(99, 218, 255);
        }
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(0, 93, 217);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            EditItem_ADMIN editItem_ADMIN = new EditItem_ADMIN();
            editItem_ADMIN.Show();
        }
        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(99, 218, 255);
        }
        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(0, 93, 217);
        }

        private void inventory_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadInventoryData();
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
            LoadInventoryData();
            TotalItemsCount();
            LowStockCount();
            OutofStockCount();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (inventory_dataGridView.SelectedRows.Count > 0)
            {
                string serialNumber = inventory_dataGridView.SelectedRows[0].Cells["Serial No"].Value.ToString();

                DialogResult confirmDelete = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmDelete == DialogResult.Yes)
                {
                    DeleteItem(serialNumber);
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(99, 218, 255);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(0, 93, 217);
        }

        private void DeleteItem(string serialNumber)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string query = "DELETE FROM Inventory WHERE SerialNumber = @SerialNumber";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadInventoryData();
                        }
                        else
                        {
                            MessageBox.Show("Error: Item could not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
