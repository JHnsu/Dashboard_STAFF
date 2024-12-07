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
                string query = "SELECT Type, Item, Details, Timestamp FROM Notifications";

                // Create a connection and command
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    // Fill a DataTable with data
                    DataTable notificationsTable = new DataTable();
                    adapter.Fill(notificationsTable);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = notificationsTable;

                    // Customize DataGridView appearance
                    dataGridView1.Columns["Details"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns["Timestamp"].DefaultCellStyle.Format = "g"; // General date/time format
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading notifications: " + ex.Message);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
