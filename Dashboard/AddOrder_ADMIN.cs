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

namespace Dashboard_STAFF
{
    public partial class AddOrder_ADMIN : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        public AddOrder_ADMIN()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string itemName = textBox1.Text;   
            string brandName = textBox2.Text;  
            int quantity = (int)numericUpDown2.Value;
            string receiverName = textBox4.Text;
            DateTime orderDate = dateTimePicker1.Value;

            if (string.IsNullOrWhiteSpace(itemName) || string.IsNullOrWhiteSpace(brandName) ||
                quantity <= 0 || string.IsNullOrWhiteSpace(receiverName))
            {
                MessageBox.Show("Please fill in all fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                try
                {
                    connection.Open();

                    string query = @"INSERT INTO PurchaseOrders 
                             (ItemName, Brand, Quantity, Receiver, OrderDate, Status) 
                             VALUES (@ItemName, @Brand, @Quantity, @Receiver, @OrderDate, @Status)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemName", itemName);
                        command.Parameters.AddWithValue("@Brand", brandName);
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        command.Parameters.AddWithValue("@Receiver", receiverName);
                        command.Parameters.AddWithValue("@OrderDate", orderDate);
                        command.Parameters.AddWithValue("@Status", "Pending");

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Order added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to add the order. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //for item name
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //for brand name
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            //for quantity
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //for receivers name
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //for date and time
        }
    }
}
