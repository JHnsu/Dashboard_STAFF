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

namespace Dashboard_STAFF
{
    public partial class RestockReqApproval_ADMIN : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        int selectedRequestID = 0;
        public RestockReqApproval_ADMIN()
        {
            InitializeComponent();
            LoadRestockRequests();
        }
        private void LoadRestockRequests()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT RequestID, SerialNumber, ItemName, QuantityRequested, RequestDate, RequestStatus FROM RestockRequests WHERE RequestStatus = 'Pending'";
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

        private void GetCurrentStock(string serialNumber)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT StockLevel FROM Inventory WHERE SerialNumber = @SerialNumber";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);

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
            string approvedBy = CurrentUser.Username;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string query = "UPDATE RestockRequests SET RequestStatus = @Status, ApprovalDate = CURRENT_TIMESTAMP, ApprovedBy = @ApprovedBy WHERE RequestID = @RequestID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@ApprovedBy", approvedBy);
                    cmd.Parameters.AddWithValue("@RequestID", selectedRequestID);
                    cmd.ExecuteNonQuery();

                    if (status == "Approved")
                    {
                        string serialNumber = textBox2.Text;
                        int requestedQuantity = int.Parse(textBox5.Text);

                        string stockUpdateQuery = "UPDATE Inventory SET StockLevel = StockLevel + @Quantity WHERE SerialNumber = @SerialNumber";
                        MySqlCommand stockCmd = new MySqlCommand(stockUpdateQuery, conn);
                        stockCmd.Parameters.AddWithValue("@Quantity", requestedQuantity);
                        stockCmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
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

        private void requests_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                textBox5.Text = row.Cells["QuantityRequested"].Value.ToString();
                textBox4.Text = row.Cells["RequestDate"].Value.ToString();

                GetCurrentStock(row.Cells["SerialNumber"].Value.ToString());
            }
        }
    }
}
