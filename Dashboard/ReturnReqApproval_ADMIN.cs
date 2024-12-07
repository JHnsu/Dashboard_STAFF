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

namespace Dashboard_STAFF
{
    public partial class ReturnReqApproval_ADMIN : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        int selectedRequestID = 0;
        public ReturnReqApproval_ADMIN()
        {
            InitializeComponent();
        }
        private void LoadReturnRequests()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT RequestID, SerialNumber, ItemName, QuantityReturned, RequestDate, RequestStatus FROM ReturnRequests WHERE RequestStatus = 'Pending'";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
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

                    string query = "UPDATE ReturnRequests SET RequestStatus = @Status, ApprovalDate = CURRENT_TIMESTAMP, ApprovedBy = @ApprovedBy WHERE RequestID = @RequestID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@ApprovedBy", approvedBy);
                    cmd.Parameters.AddWithValue("@RequestID", selectedRequestID);
                    cmd.ExecuteNonQuery();

                    if (status == "Approved")
                    {
                        string serialNumber = textBox2.Text;
                        int returnedQuantity = int.Parse(textBox5.Text);

                        string stockUpdateQuery = "UPDATE Inventory SET StockLevel = StockLevel + @Quantity WHERE SerialNumber = @SerialNumber";
                        MySqlCommand stockCmd = new MySqlCommand(stockUpdateQuery, conn);
                        stockCmd.Parameters.AddWithValue("@Quantity", returnedQuantity);
                        stockCmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                        stockCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Request {status} successfully!");
                    LoadReturnRequests(); 
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void ClearFields()
        {
            selectedRequestID = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //show return requests
            if (e.RowIndex < 0)
            {
                MessageBox.Show("Please select a valid row from the list.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedRequestID = Convert.ToInt32(row.Cells["RequestID"].Value);
                textBox1.Text = row.Cells["RequestID"].Value.ToString();
                textBox2.Text = row.Cells["SerialNumber"].Value.ToString();
                textBox3.Text = row.Cells["ItemName"].Value.ToString();
                textBox5.Text = row.Cells["QuantityReturned"].Value.ToString();
                textBox4.Text = row.Cells["RequestDate"].Value.ToString();
            }
        }
    }
}
    

