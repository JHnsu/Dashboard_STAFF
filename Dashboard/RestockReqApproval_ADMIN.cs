using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Dashboard_STAFF.LogInForm;

namespace Dashboard_STAFF
{
    public partial class RestockReqApproval_ADMIN : Form
    {
        private List<RestockProcess> restockProcesses = new List<RestockProcess>();
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        int selectedRequestID = 0;

        public int ItemID { get; private set; }

        public RestockReqApproval_ADMIN()
        {
            InitializeComponent();
            LoadRestockRequests();

            string username = CurrentUser.Username;

            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
        }
        private void LoadRestockRequests()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT RequestID, ItemName, QuantityRequested, RequestedBy, RequestDate, RequestStatus FROM RestockRequests WHERE RequestStatus = 'Pending'";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    requests_dataGridView.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void GetCurrentStock(string ItemID)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT StockLevel FROM Inventory WHERE ItemID = @ItemID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ItemID", ItemID);

                    object result = cmd.ExecuteScalar();
                    textBox2.Text = result != null ? result.ToString() : "0";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching stock level: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            if (selectedRequestID == 0)
            {
                MessageBox.Show("Please select a request to approve or reject.");
                return;
            }

            string status = radioButton1.Checked ? "Approved" : radioButton2.Checked ? "Rejected" : "";

            if (string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Please select either 'Approve' or 'Reject'.");
                return;
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                UPDATE RestockRequests 
                SET RequestStatus = @Status, 
                    ApprovalDate = CURRENT_TIMESTAMP, 
                    ApprovedBy = @ApprovedBy 
                WHERE RequestID = @RequestID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@ApprovedBy", CurrentUser.Username);
                    cmd.Parameters.AddWithValue("@RequestID", selectedRequestID);
                    cmd.ExecuteNonQuery();

                    if (status == "Approved")
                    {
                        int requestedQuantity = int.Parse(textBox4.Text);
                        string stockUpdateQuery = @"
                    UPDATE Inventory 
                    SET StockLevel = StockLevel + @Quantity 
                    WHERE ItemName = @ItemName";
                        MySqlCommand stockCmd = new MySqlCommand(stockUpdateQuery, conn);
                        stockCmd.Parameters.AddWithValue("@Quantity", requestedQuantity);
                        stockCmd.Parameters.AddWithValue("@ItemName", textBox3.Text);
                        stockCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Request {status} successfully!");
                    LoadRestockRequests();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            stopwatch.Stop();

            string getItemIDQuery = @"
                SELECT i.ItemID 
                FROM RestockRequests rr
                JOIN Inventory i ON rr.ItemName = i.ItemName
                WHERE rr.RequestID = @RequestID";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand getItemIDCmd = new MySqlCommand(getItemIDQuery, conn);
                getItemIDCmd.Parameters.AddWithValue("@RequestID", selectedRequestID);
                object result = getItemIDCmd.ExecuteScalar();

                if (result != null)
                {
                    ItemID = Convert.ToInt32(result);
                }
                else
                {
                    // Handle the case where ItemID is not found
                    MessageBox.Show("ItemID not found for the item.");
                    ItemID = 0; // Or assign a default value
                }
            }
            restockProcesses.Add(new RestockProcess
            {
                ItemID = ItemID,
                ItemName = textBox3.Text,
                BurstTime = stopwatch.ElapsedMilliseconds,
                ArrivalTime = restockProcesses.Count == 0 ? 0 : restockProcesses.Last().ArrivalTime + restockProcesses.Last().BurstTime
            });

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(99, 218, 255);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(0, 93, 217);
        }
        private void ClearFields()
        {
            selectedRequestID = 0;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
        private class RestockProcess
        {
            public int ItemID { get; set; }
            public string ItemName { get; set; }
            public long BurstTime { get; set; }
            public DateTime OrderDate { get; set; }
            public long ArrivalTime { get; set; }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //approved
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //reject
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void requests_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                MessageBox.Show("Please select a valid row from the list.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = requests_dataGridView.Rows[e.RowIndex];
                selectedRequestID = Convert.ToInt32(row.Cells["RequestID"].Value);
                textBox2.Text = row.Cells["RequestID"].Value.ToString();
                textBox3.Text = row.Cells["ItemName"].Value.ToString();
                textBox4.Text = row.Cells["QuantityRequested"].Value.ToString();
                textBox5.Text = row.Cells["RequestedBy"].Value.ToString();
            }
        }

        private void RestockReqApproval_ADMIN_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (restockProcesses.Count == 0)
            {
                MessageBox.Show("No request to schedule.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var sortedProcesses = restockProcesses.OrderBy(p => p.ArrivalTime).ToList(); 
            int totalWaitTime = 0;
            int totalTurnaroundTime = 0;
            int currentTime = 0;

            StringBuilder output = new StringBuilder();
            output.AppendLine("Processes | Arrival Time | Burst Time | Waiting Time");

            foreach (var process in sortedProcesses)
            {
                int waitTime = currentTime;

                totalWaitTime += waitTime;

                output.AppendLine($"{process.ItemID} | {process.ArrivalTime} | {process.BurstTime} | {waitTime}");

                currentTime += (int)process.BurstTime;
            }

            output.AppendLine($"Average Waiting Time: {(float)totalWaitTime / restockProcesses.Count}");

            MessageBox.Show(output.ToString(), "FCFS Scheduling Output", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    
}
