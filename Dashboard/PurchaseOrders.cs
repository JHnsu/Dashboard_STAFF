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
    public partial class PurchaseOrders : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        private DataTable purchaseOrdersTable;
        public PurchaseOrders()
        {
            InitializeComponent();
        }

        private void home_btn_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void purchaseOrders_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string orderId = purchaseOrders_dataGridView.Rows[e.RowIndex].Cells["Order ID"].Value.ToString();
                MessageBox.Show($"Order ID: {orderId}", "Selected Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PurchaseOrders_Load(object sender, EventArgs e)
        {
            LoadPurchaseOrders();
        }
        private void LoadPurchaseOrders()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            PurchaseOrderID AS 'Order ID',
                            ItemName AS 'Item Name',
                            Brand,
                            Quantity,
                            TotalPrice AS 'Total Price',
                            OrderDate AS 'Order Date'
                        FROM PurchaseOrders";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        purchaseOrders_dataGridView.DataSource = dataTable;
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
                            PurchaseOrderID AS 'Order ID',
                            ItemName AS 'Item Name',
                            Brand,
                            Quantity,
                            TotalPrice AS 'Total Price',
                            OrderDate AS 'Order Date'
                        FROM PurchaseOrders
                        WHERE 
                            PurchaseOrderID LIKE @SearchQuery OR
                            ItemName LIKE @SearchQuery OR
                            Brand LIKE @SearchQuery OR
                            Quantity LIKE @SearchQuery OR
                            TotalPrice LIKE @SearchQuery OR
                            OrderDate LIKE @SearchQuery";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@SearchQuery", $"%{searchQuery}%");

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        purchaseOrders_dataGridView.DataSource = dataTable;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadPurchaseOrders();
        }

        private void inventory_btn_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            inventory.Show();
            this.Hide();
        }

        

        private void salesOrders_btn_Click(object sender, EventArgs e)
        {
            SalesReturn salesreturn = new SalesReturn();
            salesreturn.Show();
            this.Hide();
        }

        private void salesReturns_btn_Click(object sender, EventArgs e)
        {
            SalesReturn salesreturn = new SalesReturn();
            salesreturn.Show();
            this.Hide();
        }

        private void purchaseOrders_btn_Click(object sender, EventArgs e)
        {
            PurchaseOrders purchaseOrders = new PurchaseOrders();
            purchaseOrders.Show();
            this.Hide();
        }
    }
}
