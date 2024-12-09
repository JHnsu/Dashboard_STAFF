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
    public partial class SalesOrder : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";

        public SalesOrder()
        {
            InitializeComponent();
        }

        private void home_btn_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void salesOrder_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //id, item, brand, quantity, price, receiver, order status, date
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

        private void SalesOrder_Load(object sender, EventArgs e)
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void notify_pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(99, 218, 255);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(0, 93, 217);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
   
