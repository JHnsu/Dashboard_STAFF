﻿using MySql.Data.MySqlClient;
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
    public partial class PurchaseOrders_ADMIN : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        public PurchaseOrders_ADMIN()
        {
            InitializeComponent();
        }

        private void home_btn_Click(object sender, EventArgs e)
        {
            Form1_ADMIN form1_ADMIN = new Form1_ADMIN();
            form1_ADMIN.Show();
            this.Hide();
        }

        private void purchaseOrders_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void search_textBox_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = search_textBox.Text.Trim();
            SearchAll(searchQuery);
        }

        private void PurchaseOrders_ADMIN_Load(object sender, EventArgs e)
        {
            LoadPurchaseOrders();
            CountPendingRequests();
            CountTotalPurchases();
            PopulateFilters();
        }
        private void PopulateFilters()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Item ID");
            comboBox2.Items.Add("Item Name");
            comboBox2.Items.Add("Brand");
            comboBox2.Items.Add("Quantity");
            comboBox2.Items.Add("Receiver");
            comboBox2.Items.Add("Total Price");
            comboBox2.Items.Add("Purchase Date");
            comboBox2.SelectedIndex = 0;
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
                            ItemID AS 'Item ID',
                            ItemName AS 'Item Name',
                            Brand,
                            Quantity AS 'Quantity',
                            Receiver,
                            TotalPrice AS 'Total Price',
                            DATE(PurchaseDate) AS 'Purchase Date'
                        FROM PurchaseOrders
                        WHERE 
                            Status = 'Completed' AND
                            (
                                ItemID LIKE @SearchQuery OR
                                ItemName LIKE @SearchQuery OR
                                Brand LIKE @SearchQuery OR
                                Quantity LIKE @SearchQuery OR
                                Receiver LIKE @SearchQuery OR
                                TotalPrice LIKE @SearchQuery OR
                                PurchaseDate LIKE @SearchQuery
                            );";

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
            }
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
            Reports_ADMIN reports = new Reports_ADMIN();
            reports.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RestockReqApproval_ADMIN restockReqApproval_ADMIN = new RestockReqApproval_ADMIN();
            restockReqApproval_ADMIN.Show();

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
            UserProfile userprofile = new UserProfile();
            userprofile.Show();
            this.Hide();
        }
        private void LoadPurchaseOrders()
        {
            string query = @"
                SELECT 
                    ItemID AS 'Item ID',
                    ItemName AS 'Item Name', 
                    Brand, 
                    Quantity AS 'Quantity', 
                    Receiver AS 'Receiver', 
                    TotalPrice AS 'Total Price', 
                    DATE(PurchaseDate) AS 'Purchase Date'
                FROM PurchaseOrders
                WHERE Status = 'Completed';";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

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
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //sort
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
                    Brand, 
                    Quantity AS 'Quantity',  
                    Receiver AS 'Receiver', 
                    TotalPrice AS 'Total Price', 
                    DATE(PurchaseDate) AS 'Purchase Date' 
                FROM PurchaseOrders 
                WHERE Status = 'Completed'";

                    switch (filter)
                    {
                        case "Item ID":
                            query += " ORDER BY ItemID";
                            break;
                        case "Item Name":
                            query += " ORDER BY ItemName";
                            break;
                        case "Brand":
                            query += " ORDER BY Brand";
                            break;
                        case "Quantity":
                            query += " ORDER BY Quantity";
                            break;
                        case "Receiver":
                            query += " ORDER BY Receiver";
                            break;
                        case "Total Price":
                            query += " ORDER BY TotalPrice";
                            break;
                        case "Purchase Date":
                            query += " ORDER BY PurchaseDate";
                            break;
                    }

                    if (filter == "Item ID" || filter == "Total Price" || filter == "Quantity")
                    {
                        if (sort.Contains("Ascending") || sort.Contains("Lowest to Highest"))
                            query += " ASC";
                        else if (sort.Contains("Descending") || sort.Contains("Highest to Lowest"))
                            query += " DESC";
                    }
                    else
                    {
                        if (sort.Contains("A-Z"))
                            query += " ASC";
                        else if (sort.Contains("Z-A"))
                            query += " DESC";
                        else if (sort.Contains("Newest"))
                            query += " DESC";
                        else if (sort.Contains("Oldest"))
                            query += " ASC";
                    }

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
                    case "Brand":
                        comboBox1.Items.Add("Brand (A-Z)");
                        comboBox1.Items.Add("Brand (Z-A)");
                        break;
                    case "Quantity":
                        comboBox1.Items.Add("Quantity (Ascending)");
                        comboBox1.Items.Add("Quantity (Descending)");
                        break;
                    case "Receiver":
                        comboBox1.Items.Add("Receiver (A-Z)");
                        comboBox1.Items.Add("Receiver (Z-A)");
                        break;
                    case "Total Price":
                        comboBox1.Items.Add("Lowest to Highest");
                        comboBox1.Items.Add("Highest to Lowest");
                        break;
                    case "Purchase Date":
                        comboBox1.Items.Add("Newest");
                        comboBox1.Items.Add("Oldest");
                        break;
                }

                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.Enabled = true;
                    comboBox1.SelectedIndex = 0;
                }
            }
        }


        private void notify_pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            //pending request
        }

        private void label6_Click(object sender, EventArgs e)
        {
            //total purchases
        }
        private void CountPendingRequests()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM PurchaseOrders WHERE Status = 'Pending'";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int pendingCount = Convert.ToInt32(cmd.ExecuteScalar());
                        label4.Text = pendingCount.ToString();
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

        private void CountTotalPurchases()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM PurchaseOrders WHERE Status = 'Completed'";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int totalPurchases = Convert.ToInt32(cmd.ExecuteScalar());
                        label6.Text = totalPurchases.ToString();
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
            CountPendingRequests();
            CountTotalPurchases();
            PopulateFilters();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


