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
            LoadComboBoxData();
            textBox1.Text = CurrentUser.Username;
        }

        private void LoadComboBoxData()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string itemQuery = "SELECT DISTINCT ItemName FROM Inventory";
                    using (MySqlCommand itemCmd = new MySqlCommand(itemQuery, conn))
                    using (MySqlDataReader itemReader = itemCmd.ExecuteReader())
                    {
                        while (itemReader.Read())
                        {
                            comboBox1.Items.Add(itemReader["ItemName"].ToString());
                        }
                    }

                    string brandQuery = "SELECT DISTINCT Brand FROM Inventory";
                    using (MySqlCommand brandCmd = new MySqlCommand(brandQuery, conn))
                    {
                        using (MySqlDataReader brandReader = brandCmd.ExecuteReader())
                        {
                            while (brandReader.Read())
                            {
                                comboBox2.Items.Add(brandReader["Brand"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string serialNumber = textBox2.Text.Trim();
            string selectedItemName = comboBox1.SelectedItem?.ToString();
            string selectedBrandName = comboBox2.SelectedItem?.ToString();
            int quantity = (int)numericUpDown1.Value;

            if (string.IsNullOrEmpty(selectedItemName) || string.IsNullOrEmpty(selectedBrandName))
            {
                MessageBox.Show("Please select a valid Item Name and Brand Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                        cmd.Parameters.AddWithValue("@ItemName", selectedItemName);
                        cmd.Parameters.AddWithValue("@Brand", selectedBrandName);

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
                        insertCmd.Parameters.AddWithValue("@ItemName", selectedItemName);
                        insertCmd.Parameters.AddWithValue("@Brand", selectedBrandName);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // COMBOBOX ITEM NAME
            string selectedItemName = comboBox1.SelectedItem?.ToString();
            MessageBox.Show("Selected Item Name: " + selectedItemName);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //COMBOBOX BRAND NAME
            string selectedBrandName = comboBox2.SelectedItem?.ToString();
            MessageBox.Show("Selected Brand Name: " + selectedBrandName);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //requested by
        }
    }
}
