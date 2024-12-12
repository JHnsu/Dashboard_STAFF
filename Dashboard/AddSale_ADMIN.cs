using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Dashboard_STAFF
{
    public partial class AddSale_ADMIN : Form
    {
        private int selectedItemID;
        private List<SaleProcess> saleProcesses = new List<SaleProcess>();
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";

        public AddSale_ADMIN()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string itemName = textBox1.Text;
            int quantity = (int)numericUpDown2.Value;
            string receiverName = textBox4.Text;
            DateTime deliveryDate = dateTimePicker1.Value.Date;
            DateTime orderDate = DateTime.Now;

            if (string.IsNullOrWhiteSpace(itemName) || quantity <= 0 || string.IsNullOrWhiteSpace(receiverName) || selectedItemID <= 0)
            {
                MessageBox.Show("Please fill in all fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                try
                {
                    connection.Open();

                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        string fetchQuery = "SELECT Brand, UnitPrice, StockLevel FROM Inventory WHERE ItemID = @ItemID LIMIT 1;";
                        using (MySqlCommand fetchCommand = new MySqlCommand(fetchQuery, connection, transaction))
                        {
                            fetchCommand.Parameters.AddWithValue("@ItemID", selectedItemID);

                            using (MySqlDataReader reader = fetchCommand.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    MessageBox.Show("Item not found in Inventory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                string brand = reader["Brand"].ToString();
                                decimal price = Convert.ToDecimal(reader["UnitPrice"]);
                                int stockLevel = Convert.ToInt32(reader["StockLevel"]);

                                if (stockLevel < quantity)
                                {
                                    MessageBox.Show("Not enough stock to process this sale.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                reader.Close();

                                string updateInventoryQuery = @"
                            UPDATE Inventory
                            SET StockLevel = StockLevel - @Quantity
                            WHERE ItemID = @ItemID";
                                using (MySqlCommand updateCommand = new MySqlCommand(updateInventoryQuery, connection, transaction))
                                {
                                    updateCommand.Parameters.AddWithValue("@Quantity", quantity);
                                    updateCommand.Parameters.AddWithValue("@ItemID", selectedItemID);

                                    updateCommand.ExecuteNonQuery();
                                }

                                string insertSaleQuery = @"
                            INSERT INTO Sales (ItemID, ItemName, Brand, Quantity, Price, Receiver, OrderStatus, SaleDate, DeliveryDate)
                            VALUES (@ItemID, @ItemName, @Brand, @Quantity, @Price, @Receiver, @OrderStatus, @SaleDate, @DeliveryDate);";
                                using (MySqlCommand insertCommand = new MySqlCommand(insertSaleQuery, connection, transaction))
                                {
                                    insertCommand.Parameters.AddWithValue("@ItemID", selectedItemID);
                                    insertCommand.Parameters.AddWithValue("@ItemName", itemName);
                                    insertCommand.Parameters.AddWithValue("@Brand", brand);
                                    insertCommand.Parameters.AddWithValue("@Quantity", quantity);
                                    insertCommand.Parameters.AddWithValue("@Price", price);
                                    insertCommand.Parameters.AddWithValue("@Receiver", receiverName);
                                    insertCommand.Parameters.AddWithValue("@OrderStatus", "Pending");
                                    insertCommand.Parameters.AddWithValue("@SaleDate", orderDate);
                                    insertCommand.Parameters.AddWithValue("@DeliveryDate", deliveryDate);

                                    insertCommand.ExecuteNonQuery();
                                }

                                transaction.Commit();
                                stopwatch.Stop();

                                DisplayPrioritySchedulingResult();

                                LoadInventoryData();
                                ClearInputFields();

                                MessageBox.Show("Sale added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private class SaleProcess
        {
            public int ItemID { get; set; }
            public string ItemName { get; set; }
            public long BurstTime { get; set; }
            public DateTime OrderDate { get; set; }
        }


        private void DisplayPrioritySchedulingResult()
        {
            var processes = GetSalesAsProcesses();
            int n = processes.Length;

            PriorityScheduling ps = new PriorityScheduling();
            var result = ps.RunPriorityScheduling(processes, n);

            string resultMessage = "\nProcesses  Burst time  Waiting time  Turn around time\n";
            int totalWt = 0, totalTat = 0;

            foreach (var process in result)
            {
                totalWt += process.WaitingTime;
                totalTat += process.TurnAroundTime;
                resultMessage += $"{process.Pid}\t\t{process.Bt}\t\t{process.WaitingTime}\t\t{process.TurnAroundTime}\n";
            }

            resultMessage += $"Average waiting time = {(float)totalWt / n}\n";
            resultMessage += $"Average turn around time = {(float)totalTat / n}";

            MessageBox.Show(resultMessage, "Priority Scheduling Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Process[] GetSalesAsProcesses()
        {
            var processes = new System.Collections.Generic.List<Process>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ItemID, Quantity, OrderStatus FROM Sales WHERE OrderStatus = 'Pending'";

                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int itemID = Convert.ToInt32(reader["ItemID"]);
                            int quantity = Convert.ToInt32(reader["Quantity"]);
                            string orderStatus = reader["OrderStatus"].ToString();

                            int priority = orderStatus == "Pending" ? 1 : 0;  // Example priority (Pending = high priority)

                            processes.Add(new Process
                            {
                                Pid = itemID,
                                Bt = quantity,
                                Prior = priority
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving sales data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return processes.ToArray();
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
                    Brand, 
                    StockLevel AS 'Quantity', 
                    UnitPrice AS 'Price' 
                FROM Inventory;";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        addSale_dataGridView.DataSource = dataTable;
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

        private void ClearInputFields()
        {
            textBox1.Clear();
            textBox4.Clear();
            numericUpDown2.Value = 1;
            dateTimePicker1.Value = DateTime.Now;
            selectedItemID = 0;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(99, 218, 255);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(0, 93, 217);
        }

        private void addSale_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = addSale_dataGridView.Rows[e.RowIndex];

                textBox1.Text = selectedRow.Cells["Item Name"].Value?.ToString();

                if (int.TryParse(selectedRow.Cells["Item ID"].Value?.ToString(), out int itemID))
                {
                    selectedItemID = itemID;
                }
                else
                {
                    selectedItemID = 0;
                }

                if (decimal.TryParse(selectedRow.Cells["Quantity"].Value?.ToString(), out decimal quantity))
                {
                    numericUpDown2.Value = quantity;
                }
                else
                {
                    numericUpDown2.Value = 0;
                }
            }
        }

        private void AddSale_ADMIN_Load(object sender, EventArgs e)
        {
            LoadInventoryData();
        }
    }

    public class Process
    {
        public int Pid { get; set; }  
        public int Bt { get; set; }   
        public int Prior { get; set; }  
        public int WaitingTime { get; set; }
        public int TurnAroundTime { get; set; }
    }

    public class PriorityScheduling
    {
        public Process[] RunPriorityScheduling(Process[] proc, int n)
        {

            var sortedProc = proc.OrderByDescending(p => p.Prior).ToArray();

            int[] wt = new int[n], tat = new int[n];
            FindWaitingTime(sortedProc, n, wt);
            FindTurnAroundTime(sortedProc, n, wt, tat);

            for (int i = 0; i < n; i++)
            {
                sortedProc[i].WaitingTime = wt[i];
                sortedProc[i].TurnAroundTime = tat[i];
            }

            return sortedProc;
        }

        private void FindWaitingTime(Process[] proc, int n, int[] wt)
        {
            wt[0] = 0;
            for (int i = 1; i < n; i++)
            {
                wt[i] = proc[i - 1].Bt + wt[i - 1];
            }
        }

        private void FindTurnAroundTime(Process[] proc, int n, int[] wt, int[] tat)
        {
            for (int i = 0; i < n; i++)
            {
                tat[i] = proc[i].Bt + wt[i];
            }
        }
    }
}