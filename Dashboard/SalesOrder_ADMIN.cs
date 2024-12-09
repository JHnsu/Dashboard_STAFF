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
    public partial class SalesOrder_ADMIN : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        public SalesOrder_ADMIN()
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
            Reports_ADMIN reports = new Reports_ADMIN();
            reports.Show();
            this.Hide();
        }

        private void salesOrder_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string orderId = salesOrder_dataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                string itemName = salesOrder_dataGridView.Rows[e.RowIndex].Cells["Item"].Value.ToString();
                string receiver = salesOrder_dataGridView.Rows[e.RowIndex].Cells["Receiver"].Value.ToString();
                string status = salesOrder_dataGridView.Rows[e.RowIndex].Cells["Order Status"].Value.ToString();

                MessageBox.Show($"Order ID: {orderId}\nItem Name: {itemName}\nReceiver: {receiver}\nStatus: {status}",
                                "Selected Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SalesOrder_ADMIN_Load(object sender, EventArgs e)
        {
            LoadSalesOrders();
        }
        private void LoadSalesOrders()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            s.SaleID AS 'ID',
                            s.ItemName AS 'Item',
                            s.Brand AS 'Brand',
                            s.Quantity AS 'Quantity',
                            s.Price AS 'Price',
                            s.Receiver AS 'Receiver',
                            s.OrderStatus AS 'Order Status',
                            s.SaleDate AS 'Date'
                        FROM Sales s";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        salesOrder_dataGridView.DataSource = dataTable;
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
                    s.SaleID AS 'ID',
                    s.ItemName AS 'Item',
                    s.Brand AS 'Brand',
                    s.Quantity AS 'Quantity',
                    s.Price AS 'Price',
                    s.Receiver AS 'Receiver',
                    s.OrderStatus AS 'Order Status',
                    s.SaleDate AS 'Date'
                FROM Sales s
                WHERE 
                    s.SaleID LIKE @SearchQuery OR
                    s.ItemName LIKE @SearchQuery OR
                    s.Brand LIKE @SearchQuery OR
                    s.Quantity LIKE @SearchQuery OR
                    s.Price LIKE @SearchQuery OR
                    s.Receiver LIKE @SearchQuery OR
                    s.OrderStatus LIKE @SearchQuery OR
                    s.SaleDate LIKE @SearchQuery";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@SearchQuery", $"%{searchQuery}%");

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        salesOrder_dataGridView.DataSource = dataTable;
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
            AddSale_ADMIN addOrder_ADMIN = new AddSale_ADMIN();
            addOrder_ADMIN.Show();
        }
        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(99, 218, 255);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(0, 93, 217);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
