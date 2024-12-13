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
using static Dashboard_STAFF.LogInForm;
using Timer = System.Windows.Forms.Timer;

namespace Dashboard_STAFF
{
    public partial class Inventory : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        private int lastNotificationCount = 0;
        public Inventory()
        {
            InitializeComponent();
            InitializeNotificationIndicator();
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
            if (CurrentUser.ProfilePicture != null && CurrentUser.ProfilePicture.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(CurrentUser.ProfilePicture))
                    {
                        profile_pictureBox.Image = Image.FromStream(ms);
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

            if (CurrentUser.ProfilePicture != null && CurrentUser.ProfilePicture.Length > 0)
            {
                try
                {
                    string filePath = Path.Combine(Application.StartupPath, "temp_image.jpg");
                    File.WriteAllBytes(filePath, CurrentUser.ProfilePicture);

                    profile_pictureBox.Image = Image.FromFile(filePath);
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
        private void notify_pictureBox_Click(object sender, EventArgs e)
        {
            Notifications popup = new Notifications();
            popup.Show();

            notify_pictureBox.Visible = false;
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
                    string query = "SELECT COUNT(*) FROM Inventory WHERE StockLevel > 0 AND StockLevel <= MinimumStockLevel;";
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

        private void Inventory_Load(object sender, EventArgs e)
        {
            Timer checkNotificationsTimer = new Timer
            {
                Interval = 10000
            };
            checkNotificationsTimer.Tick += CheckNewNotificationsTimer_Tick;
            checkNotificationsTimer.Start();

            pictureBox1.Visible = false;
            lastNotificationCount = GetNotificationCount();

            LoadInventoryData();
            TotalItemsCount();
            LowStockCount();
            OutofStockCount();
            PopulateFilters();

            button4.Text = CurrentUser.FirstName + " " + CurrentUser.LastName;
            button6.Text = LogInForm.CurrentUser.Email;

            if (CurrentUser.ProfilePicture != null && CurrentUser.ProfilePicture.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(CurrentUser.ProfilePicture))
                    {
                        profile_pictureBox.Image = Image.FromStream(ms);
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Error loading profile picture: " + ex.Message);
                    profile_pictureBox.Image = null;
                }
            }
            else
            {
                profile_pictureBox.Image = null;
            }
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

                    if (filter == "Stock Status")
                    {
                        switch (sort)
                        {
                            case "In Stock":
                                query += " AND StockStatus = 'In Stock'";
                                break;
                            case "Out of Stock":
                                query += " AND StockStatus = 'Out of Stock'";
                                break;
                            case "Low Stock":
                                query += " AND StockStatus = 'Low Stock'";
                                break;
                        }
                    }

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

        private void button3_Click(object sender, EventArgs e)
        {
            RestockRequest restockRequest = new RestockRequest();
            restockRequest.Show();
        }
        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(99, 218, 255);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(0, 93, 217);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = CurrentUser.FirstName + " " + CurrentUser.LastName;

            UserProfile userDetailsForm = new UserProfile(CurrentUser.FirstName + " " + CurrentUser.LastName, CurrentUser.Email);
            userDetailsForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Text = CurrentUser.Email;

            UserProfile userDetailsForm = new UserProfile(CurrentUser.FirstName + " " + CurrentUser.LastName, CurrentUser.Email);
            userDetailsForm.Show();
            this.Hide();
        }

        private void notify_pictureBox_Click_1(object sender, EventArgs e)
        {
            Notifications popup = new Notifications();
            popup.Show();

            pictureBox1.Visible = false;
        }
    }
}
