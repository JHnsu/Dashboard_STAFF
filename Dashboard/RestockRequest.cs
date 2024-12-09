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
    public partial class RestockRequest : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        public RestockRequest()
        {
            InitializeComponent();
            textBox1.Text = CurrentUser.Username;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string serialNumber = textBox2.Text.Trim();
            int quantity = (int)numericUpDown1.Value;


            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string validationQuery = @"
                SELECT COUNT(*) 
                FROM Inventory 
                WHERE SerialNumber = @SerialNumber AND ItemName = @ItemName AND Brand = @Brand";

                    using (MySqlCommand cmd = new MySqlCommand(validationQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 0)
                        {
                            MessageBox.Show("Invalid Serial Number, Item Name, or Brand. Please check your inputs.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    MessageBox.Show("Restock Request Submitted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string insertQuery = @"
                    INSERT INTO RestockRequests (RequestedBy, QuantityRequested, RequestStatus, ItemName, Brand, SerialNumber)
                    VALUES (@RequestedBy, @QuantityRequested, 'Pending', @ItemName, @Brand, @SerialNumber)";

                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@RequestedBy", CurrentUser.Username);
                        insertCmd.Parameters.AddWithValue("@QuantityRequested", quantity);
                        insertCmd.Parameters.AddWithValue("@SerialNumber", serialNumber);

                        insertCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void inventory_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
