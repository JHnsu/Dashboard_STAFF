using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Dashboard_STAFF
{
    public partial class SalesReturn_ADMIN : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        private DataTable originalDataTable; // Store the original data

        public SalesReturn_ADMIN()
        {
            InitializeComponent();
        }

        private void home_btn_Click_1(object sender, EventArgs e)
        {
            Form1_ADMIN form1_ADMIN = new Form1_ADMIN();
            form1_ADMIN.Show();
            this.Hide();
        }

        private void reports_btn_Click(object sender, EventArgs e)
        {
            Reports_ADMIN form1_ADMIN = new Reports_ADMIN();
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

        private void salesReturns_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string returnId = salesReturns_dataGridView.Rows[e.RowIndex].Cells["Return ID"].Value.ToString();
                string itemName = salesReturns_dataGridView.Rows[e.RowIndex].Cells["Item Name"].Value.ToString();
                string reason = salesReturns_dataGridView.Rows[e.RowIndex].Cells["Return Reason"].Value.ToString();

                MessageBox.Show($"Return ID: {returnId}\nItem Name: {itemName}\nReason: {reason}",
                                "Selected Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SalesReturn_ADMIN_Load(object sender, EventArgs e)
        {
            LoadSalesReturns();
        }

        private void LoadSalesReturns()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            sr.ReturnID AS 'Return ID',
                            sr.ItemName AS 'Item Name',
                            sr.Brand AS 'Brand',
                            sr.Quantity AS 'Quantity',
                            sr.TotalPrice AS 'Total Price',
                            sr.ReturnDate AS 'Return Date',
                            sr.Reason AS 'Return Reason'
                        FROM SalesReturn sr";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        originalDataTable = new DataTable();
                        adapter.Fill(originalDataTable);

                        salesReturns_dataGridView.DataSource = originalDataTable;
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
                    sr.ReturnID AS 'Return ID',
                    sr.ItemName AS 'Item Name',
                    sr.Brand AS 'Brand',
                    sr.Quantity AS 'Quantity',
                    sr.TotalPrice AS 'Total Price',
                    sr.ReturnDate AS 'Return Date',
                    sr.Reason AS 'Return Reason'
                FROM SalesReturn sr
                WHERE 
                    sr.ReturnID LIKE @SearchQuery OR
                    sr.ItemName LIKE @SearchQuery OR
                    sr.Brand LIKE @SearchQuery OR
                    sr.Quantity LIKE @SearchQuery OR
                    sr.TotalPrice LIKE @SearchQuery OR
                    sr.ReturnDate LIKE @SearchQuery OR
                    sr.Reason LIKE @SearchQuery";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@SearchQuery", $"%{searchQuery}%");

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        salesReturns_dataGridView.DataSource = dataTable;
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
