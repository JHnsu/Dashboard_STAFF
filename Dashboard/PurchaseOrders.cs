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
using static Dashboard_STAFF.LogInForm;
using Timer = System.Windows.Forms.Timer;

namespace Dashboard_STAFF
{
    public partial class PurchaseOrders : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        private DataTable purchaseOrdersTable;
        private int lastNotificationCount = 0;
        public PurchaseOrders()
        {
            InitializeComponent();
            InitializeNotificationIndicator();
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
            this.Show();
        }
        private void purchaseOrders_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PurchaseOrders_Load(object sender, EventArgs e)
        {
            Timer checkNotificationsTimer = new Timer
            {
                Interval = 10000
            };
            checkNotificationsTimer.Tick += CheckNewNotificationsTimer_Tick;
            checkNotificationsTimer.Start();

            pictureBox1.Visible = false;
            lastNotificationCount = GetNotificationCount();


            LoadPurchaseOrders();
            CountTotalPurchases();
            PopulateFilters();

            button2.Text = CurrentUser.FirstName + " " + CurrentUser.LastName;
            button6.Text = LogInForm.CurrentUser.Email;

            if (CurrentUser.ProfilePicture != null && CurrentUser.ProfilePicture.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(CurrentUser.ProfilePicture))
                    {
                        pictureBox7.Image = Image.FromStream(ms);
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Error loading profile picture: " + ex.Message);
                    pictureBox7.Image = null;
                }
            }
            else
            {
                pictureBox7.Image = null;
            }
        }


        private void InitializeNotificationIndicator()
        {
            pictureBox1.Visible = false;
        }

        private void CheckNewNotificationsTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (HasNewNotifications())
                {
                    pictureBox1.Visible = true;
                }
                else
                {
                    pictureBox1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for new notifications: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool HasNewNotifications()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Notifications";

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        int currentNotificationCount = Convert.ToInt32(cmd.ExecuteScalar());

                        if (currentNotificationCount > lastNotificationCount)
                        {
                            lastNotificationCount = currentNotificationCount;
                            return true;
                        }
                        else if (currentNotificationCount == 0)
                        {
                            lastNotificationCount = 0;
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for new notifications: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private int GetNotificationCount()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Notifications";

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching notification count: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void MarkNotificationsAsRead()
        {
            try
            {
                string query = "UPDATE Notifications SET IsRead = 1 WHERE IsRead = 0";

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                pictureBox1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error marking notifications as read: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadPurchaseOrders()
        {
            string query = @"
            SELECT 
                ItemID AS 'Item ID',
                ItemName AS 'Item Name', 
                Brand, 
                Quantity AS 'Quantity', 
                TotalPrice AS 'Total Price', 
                DATE(PurchaseDate) AS 'Purchase Date'
            FROM PurchaseOrders;";

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

        private byte[] GetProfilePictureFromDatabase(int userId)
        {
            byte[] imageBytes = null;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT ProfilePicture FROM users WHERE UserId = @UserId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        imageBytes = (byte[])result;
                    }
                }
            }

            return imageBytes;
        }
        private void CountTotalPurchases()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM PurchaseOrders";
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

        private void PopulateFilters()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("No Filter");
            comboBox2.Items.Add("Item ID");
            comboBox2.Items.Add("Item Name");
            comboBox2.Items.Add("Brand");
            comboBox2.Items.Add("Quantity");
            comboBox2.Items.Add("Total Price");
            comboBox2.Items.Add("Purchase Date");
            comboBox2.SelectedIndex = 0;
            comboBox1.Enabled = false;
            comboBox1.Items.Clear();

            LoadPurchaseOrders();
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
                            TotalPrice AS 'Total Price',
                            DATE(PurchaseDate) AS 'Purchase Date'
                        FROM PurchaseOrders
                        WHERE 
                            (
                                ItemID LIKE @SearchQuery OR
                                ItemName LIKE @SearchQuery OR
                                Brand LIKE @SearchQuery OR
                                Quantity LIKE @SearchQuery OR
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

        private void search_textBox_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = search_textBox.Text.Trim();
            SearchAll(searchQuery);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (CurrentUser.ProfilePicture != null && CurrentUser.ProfilePicture.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(CurrentUser.ProfilePicture))
                    {
                        pictureBox7.Image = Image.FromStream(ms);
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Error loading profile picture: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No profile picture found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void notify_pictureBox_Click(object sender, EventArgs e)
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
                            Brand, 
                            Quantity AS 'Quantity',  
                            TotalPrice AS 'Total Price', 
                            DATE(PurchaseDate) AS 'Purchase Date' 
                        FROM PurchaseOrders";

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


            if (selectedFilter == "No Filter")
            {
                LoadPurchaseOrders();
                return;
            }

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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void purchaseOrders_dataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = CurrentUser.FirstName + " " + CurrentUser.LastName;

            UserProfile userDetailsForm = new UserProfile(CurrentUser.FirstName + " " + CurrentUser.LastName, CurrentUser.Email);
            userDetailsForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Text = CurrentUser.Email;

            UserProfile userDetailsForm = new UserProfile(CurrentUser.FirstName + " " + CurrentUser.LastName, CurrentUser.Email);
            userDetailsForm.Show();
        }

        private void notify_pictureBox_Click_1(object sender, EventArgs e)
        {
            Notifications popup = new Notifications();
            popup.Show();

            pictureBox1.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoadPurchaseOrders();
            CountTotalPurchases();
            PopulateFilters();
        }
    }
}
