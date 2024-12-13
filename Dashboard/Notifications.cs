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
using System.Data.SqlClient;

namespace Dashboard_STAFF
{
    public partial class Notifications : Form
    {
        string connectionString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        public Notifications()
        {
            InitializeComponent();
            LoadNotifications();
        }


        private void LoadNotifications()
        {
            try
            {
                // Query to fetch notifications
                string query = "SELECT Type, Item, Details, Timestamp FROM Notifications ORDER BY Timestamp DESC";

                // Create a connection and command
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    // Fill a DataTable with data
                    DataTable notificationsTable = new DataTable();
                    adapter.Fill(notificationsTable);

                    // Bind the DataTable to the DataGridView
                    notif_dataGridView.DataSource = notificationsTable;

                    // Customize DataGridView appearance
                    notif_dataGridView.Columns["Details"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    notif_dataGridView.Columns["Timestamp"].DefaultCellStyle.Format = "g"; // General date/time format
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading notifications: " + ex.Message);
            }
        }

        // Function to check and insert stock-related notifications
        private void CheckAndAddNotifications()
        {
            try
            {
                // Check stock levels for low stock or out of stock
                string stockQuery = "SELECT ItemName, Quantity FROM Inventory WHERE Quantity <= 5"; // Adjust threshold based on requirement

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                using (MySqlCommand cmd = new MySqlCommand(stockQuery, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemName = reader.GetString("ItemName");
                            int quantity = reader.GetInt32("Quantity");

                            // If stock is low or out of stock, create a notification
                            string notificationType = quantity == 0 ? "Out of Stock" : "Low Stock";
                            string details = $"{itemName} has {quantity} units left in stock.";

                            // Insert notification into the Notifications table
                            InsertNotification(notificationType, itemName, details);
                        }
                    }
                }

                // Check for new stock requests
                string requestQuery = "SELECT RequestID, Item, Status FROM StockRequests WHERE Status = 'Pending'"; // Assuming 'Pending' requests need notification

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                using (MySqlCommand cmd = new MySqlCommand(requestQuery, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int requestId = reader.GetInt32("RequestID");
                            string itemName = reader.GetString("Item");

                            // Insert notification about new request
                            string details = $"New request for {itemName} (Request # {requestId}) is pending.";
                            InsertNotification("New Request", itemName, details);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking stock or requests: " + ex.Message);
            }
        }

        // Insert a new notification into the Notifications table
        private void InsertNotification(string type, string item, string details)
        {
            try
            {
                string query = "INSERT INTO Notifications (Type, Item, Details, Timestamp) VALUES (@Type, @Item, @Details, @Timestamp)";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.Parameters.AddWithValue("@Item", item);
                    cmd.Parameters.AddWithValue("@Details", details);
                    cmd.Parameters.AddWithValue("@Timestamp", DateTime.Now);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting notification: " + ex.Message);
            }
        }

        // This method can be called periodically (e.g., with a timer) to check for stock issues and new requests
        private void timer_Tick(object sender, EventArgs e)
        {
            // Check and add notifications for low stock, out of stock, and new requests
            CheckAndAddNotifications();
            LoadNotifications(); // Reload notifications after adding new ones
        }

        private void Notifications_Load(object sender, EventArgs e)
        {
            LoadNotifications();

            timer1.Start();
        }

        private void notif_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //TYPE, ITEM, DETAILS, TIMESTAMP
            //CREATE TABLE Notifications (ID INT PRIMARY KEY IDENTITY,Type NVARCHAR(50),Item NVARCHAR(100),Details NVARCHAR(255),Timestamp DATETIME);
            //SAMPLE OUTPUT: INSERT INTO Notifications (Type, Item, Details, Timestamp) VALUES ('Restock Alert', 'Item A', 'Low stock', GETDATE()),('Request Status', 'Request #123', 'Approved', GETDATE() - 1),('Item Return', 'Item B', 'Returned by User X', GETDATE() - 2);
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

    }
}
