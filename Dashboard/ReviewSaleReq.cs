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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Dashboard_STAFF.LogInForm;

namespace Dashboard_STAFF
{
    public partial class ReviewSaleReq : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        public ReviewSaleReq()
        {
            InitializeComponent();
        }
        private void ClearFields()
        {
            textBox1.Clear();
            numericUpDown2.Value = 0;
            textBox4.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox1.ReadOnly = false;
            textBox4.ReadOnly = false;
            numericUpDown2.Enabled = true;
            dateTimePicker1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Please select a pending order to review.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Please select 'Approve' or 'Reject'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ItemID = pendingOrders_dataGridView.SelectedRows[0].Cells["Item ID"].Value.ToString();
            string orderStatus = radioButton1.Checked ? "Shipped" : "Cancelled";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        UPDATE Sales 
                        SET OrderStatus = @OrderStatus, ApprovedBy = @ApprovedBy 
                        WHERE ItemID = @ItemID;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderStatus", orderStatus);
                        cmd.Parameters.AddWithValue("@ApprovedBy", CurrentUser.Username);
                        cmd.Parameters.AddWithValue("@ItemID", ItemID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Order successfully {orderStatus.ToLower()}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                            LoadPendingOrders();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update the order. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(99, 218, 255);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(0, 93, 217);
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //approve
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //reject
        }

        private void ReviewSaleReq_Load(object sender, EventArgs e)
        {
            LoadPendingOrders();
        }
        private void LoadPendingOrders()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            s.ItemID AS 'Item ID',
                            s.ItemName AS 'Item Name',
                            s.Brand AS 'Brand',
                            s.Quantity AS 'Quantity',
                            s.Price AS 'Price',
                            s.Receiver AS 'Receiver',
                            s.DeliveryDate AS 'Delivery Date'
                        FROM Sales s
                        WHERE s.OrderStatus = 'Pending'";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        pendingOrders_dataGridView.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pendingOrders_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = pendingOrders_dataGridView.Rows[e.RowIndex];

                textBox1.Text = row.Cells["Item Name"].Value.ToString();
                numericUpDown2.Value = Convert.ToInt32(row.Cells["Quantity"].Value);
                textBox4.Text = row.Cells["Receiver"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["Delivery Date"].Value);

                textBox1.ReadOnly = true;
                textBox4.ReadOnly = true;
                numericUpDown2.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
        }
    }
}
