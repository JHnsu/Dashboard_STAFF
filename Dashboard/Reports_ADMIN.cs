using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Pdf.Canvas;
using System.IO;
using MySql.Data.MySqlClient;

namespace Dashboard_STAFF
{
    public partial class Reports_ADMIN : Form
    {
        public Reports_ADMIN()
        {
            InitializeComponent();
        }

        private void home_btn_Click(object sender, EventArgs e)
        {
            Form1_ADMIN form1_ADMIN = new Form1_ADMIN();
            form1_ADMIN.Show();
            this.Hide();
        }

        private void reports_btn_Click(object sender, EventArgs e)
        {
            Reports_ADMIN reports_ADMIN = new Reports_ADMIN();
            reports_ADMIN.Show();
            this.Hide();
        }

        private void inventory_btn_Click(object sender, EventArgs e)
        {
            Inventory inventoryAdmin = new Inventory();
            inventoryAdmin.Show();
            this.Hide();
        }



        private void salesOrders_btn_Click(object sender, EventArgs e)
        {
            SalesOrder_ADMIN salesorder = new SalesOrder_ADMIN();
            salesorder.Show();
            this.Hide();
        }


        private void purchaseOrders_btn_Click(object sender, EventArgs e)
        {
            PurchaseOrders_ADMIN purchaseOrders = new PurchaseOrders_ADMIN();
            purchaseOrders.Show();
            this.Hide();
        }
        private void orderPDF_button_Click(object sender, EventArgs e)
        {
            //orders report
            try
            {
                string ordersReportData = GetOrdersReportData();

                string filePath = @"C:\Reports\OrdersReport.pdf";
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {

                    PdfWriter writer = new PdfWriter(fs);

                    PdfDocument pdf = new PdfDocument(writer);

                    Document document = new Document(pdf);

                    document.Add(new Paragraph("Orders Report")
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                        .SetFontSize(18));

                    document.Add(new Paragraph(ordersReportData)
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                        .SetFontSize(12));

                    document.Close();
                }

                MessageBox.Show("Orders report saved successfully as PDF!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while generating the PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GetOrdersReportData()
        {
            StringBuilder reportData = new StringBuilder();


            string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";


            string query = "SELECT OrderID, CustomerName, ItemName, Quantity, Price FROM Orders";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        reportData.AppendLine("Order ID | Customer Name | Item Name | Quantity | Price");
                        reportData.AppendLine("-------------------------------------------------------------");

                        while (reader.Read())
                        {

                            int orderId = reader.GetInt32("OrderID");
                            string customerName = reader.GetString("CustomerName");
                            string itemName = reader.GetString("ItemName");
                            int quantity = reader.GetInt32("Quantity");
                            decimal price = reader.GetDecimal("Price");

                            reportData.AppendLine($"{orderId} | {customerName} | {itemName} | {quantity} | ${price:F2}");
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data from the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return reportData.ToString();
        }
        private void orderPDF_button_MouseHover(object sender, EventArgs e)
        {
            orderPDF_button.BackColor = Color.FromArgb(99, 218, 255);
        }

        private void orderPDF_button_MouseLeave(object sender, EventArgs e)
        {
            orderPDF_button.BackColor = Color.FromArgb(0, 93, 217);
        }

        private void notify_pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            UserProfile userprofile = new UserProfile();
            userprofile.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(99, 218, 255);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(0, 93, 217);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(99, 218, 255);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(0, 93, 217);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EditUserProfile editUserProfile = new EditUserProfile();
            editUserProfile.Show();
            this.Hide();
        }
        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(99, 218, 255);
        }
        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(0, 93, 217);
        }
        private void button7_Click(object sender, EventArgs e)
        {

        }
        private void button7_MouseHover(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(99, 218, 255);
        }
        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(0, 93, 217);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
