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
    public partial class SalesReturn : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        public SalesReturn()
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

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void salesReturns_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //id, item name, brand, quantity, total price, return date, reason
            if (e.RowIndex >= 0)
            {
                string returnId = salesReturns_dataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                string itemName = salesReturns_dataGridView.Rows[e.RowIndex].Cells["Item Name"].Value.ToString();
                string brand = salesReturns_dataGridView.Rows[e.RowIndex].Cells["Brand"].Value.ToString();
                string quantity = salesReturns_dataGridView.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
                string totalPrice = salesReturns_dataGridView.Rows[e.RowIndex].Cells["Total Price"].Value.ToString();
                string returnDate = salesReturns_dataGridView.Rows[e.RowIndex].Cells["Return Date"].Value.ToString();
                string reason = salesReturns_dataGridView.Rows[e.RowIndex].Cells["Reason"].Value.ToString();

                MessageBox.Show($"Return ID: {returnId}\nItem: {itemName}\nBrand: {brand}\nQuantity: {quantity}\nTotal Price: {totalPrice}\nReturn Date: {returnDate}\nReason: {reason}",
                                "Sales Return Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SalesReturn_Load(object sender, EventArgs e)
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
                            sr.ReturnID AS 'ID',
                            sr.ItemName AS 'Item Name',
                            sr.Brand AS 'Brand',
                            sr.Quantity AS 'Quantity',
                            sr.TotalPrice AS 'Total Price',
                            sr.ReturnDate AS 'Return Date',
                            sr.Reason AS 'Reason'
                        FROM SalesReturn sr";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
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
