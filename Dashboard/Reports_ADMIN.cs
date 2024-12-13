using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static Dashboard_STAFF.LogInForm;
using Timer = System.Windows.Forms.Timer;
using MySql.Data.MySqlClient;
using PdfSharp.Pdf;
using PdfSharp.Drawing;



namespace Dashboard_STAFF
{
    public partial class Reports_ADMIN : Form
    {
        string connString = "server=localhost;port=3306;database=techinventorydb;user=root;password=";
        private int lastNotificationCount = 0;

        public Reports_ADMIN()
        {
            InitializeComponent();
            InitializeNotificationIndicator();
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
            Inventory_ADMIN inventoryAdmin = new Inventory_ADMIN();
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
            // Order report
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT * FROM purchaseorders";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable inventoryData = new DataTable();
                    adapter.Fill(inventoryData);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveFileDialog.DefaultExt = "pdf";
                    saveFileDialog.FileName = "Orders_Report_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedPath = saveFileDialog.FileName;

                        PdfDocument pdf = new PdfDocument();
                        pdf.Info.Title = "Orders Report";

                        PdfPage page = pdf.AddPage();
                        XGraphics gfx = XGraphics.FromPdfPage(page);
                        XFont font = new XFont("Verdana", 10);
                        XFont boldFont = new XFont("Arial", 12, XFontStyleEx.Bold);

                        double leftMargin = 72; // 1 inch
                        double rightMargin = page.Width - 72; // 1 inch
                        double availableWidth = rightMargin - leftMargin;
                        double yPoint = 30;
                        double columnPadding = 25;

                        yPoint += 30;

                        // Centered Title
                        string title = "Orders Report";
                        double titleWidth = gfx.MeasureString(title, boldFont).Width;
                        double titleX = (page.Width - titleWidth) / 2;
                        gfx.DrawString(title, boldFont, XBrushes.Black, new XPoint(titleX, yPoint));
                        yPoint += 50; // Margin under the title

                        // Date Generated
                        string dateGenerated = "Date Generated: " + DateTime.Now.ToString("MMMM dd, yyyy");
                        gfx.DrawString(dateGenerated, font, XBrushes.Black, new XPoint(leftMargin, yPoint));
                        yPoint += 30;

                        // Table Header
                        string[] headers = { "Item ID", "Item Name", "Brand", "Quantity", "Total Price", "Purchase Date" };
                        int numColumns = headers.Length;

                        // Determine column widths based on the longest content
                        double[] columnWidths = new double[numColumns];
                        for (int i = 0; i < headers.Length; i++)
                        {
                            columnWidths[i] = gfx.MeasureString(headers[i], boldFont).Width;
                            foreach (DataRow row in inventoryData.Rows)
                            {
                                double contentWidth = gfx.MeasureString(row[headers[i].Replace(" ", "")].ToString(), font).Width;
                                columnWidths[i] = Math.Max(columnWidths[i], contentWidth);
                            }
                            columnWidths[i] += columnPadding; // Add padding
                        }

                        // Scale column widths proportionally to fit within the available width
                        double totalWidth = columnWidths.Sum();
                        for (int i = 0; i < columnWidths.Length; i++)
                        {
                            columnWidths[i] = (columnWidths[i] / totalWidth) * availableWidth;
                        }

                        // Draw header row
                        double xPoint = leftMargin;
                        for (int i = 0; i < headers.Length; i++)
                        {
                            gfx.DrawString(headers[i], boldFont, XBrushes.Black, new XPoint(xPoint, yPoint));
                            xPoint += columnWidths[i];
                        }
                        yPoint += 20; // Space below headers

                        // Initialize total counters
                        double totalPurchasePrice = 0;
                        int totalItemsPurchased = 0;

                        // Add Data Rows
                        // Add Data Rows
                        foreach (DataRow row in inventoryData.Rows)
                        {
                            xPoint = leftMargin; // Reset X for each row
                            for (int i = 0; i < headers.Length; i++)
                            {
                                string cellText = row[headers[i].Replace(" ", "")].ToString();
                                double columnWidth = columnWidths[i];

                                // Wrap text logic
                                string[] words = cellText.Split(' ');
                                string currentLine = "";
                                foreach (string word in words)
                                {
                                    if (gfx.MeasureString(currentLine + " " + word, font).Width <= columnWidth)
                                    {
                                        currentLine += (currentLine == "" ? "" : " ") + word;
                                    }
                                    else
                                    {
                                        gfx.DrawString(currentLine, font, XBrushes.Black, new XPoint(xPoint, yPoint));
                                        yPoint += 15; // Move to the next line
                                        currentLine = word;
                                    }
                                }
                                gfx.DrawString(currentLine, font, XBrushes.Black, new XPoint(xPoint, yPoint));
                                xPoint += columnWidth; // Move to the next column
                            }
                            yPoint += 20; // Move to the next row

                            // Calculate total purchase price and items
                            double totalPrice = Convert.ToDouble(row["TotalPrice"]);
                            totalPurchasePrice += totalPrice;
                            totalItemsPurchased += Convert.ToInt32(row["Quantity"]);

                            // Prevent overflow by checking yPoint
                            if (yPoint > page.Height - 40)
                            {
                                page = pdf.AddPage(); // Add a new page if content exceeds the height
                                gfx = XGraphics.FromPdfPage(page);
                                yPoint = 30; // Reset yPoint for new page

                                // Redraw headers on new page
                                xPoint = leftMargin;
                                for (int i = 0; i < headers.Length; i++)
                                {
                                    gfx.DrawString(headers[i], boldFont, XBrushes.Black, new XPoint(xPoint, yPoint));
                                    xPoint += columnWidths[i];
                                }
                                yPoint += 20; // Space below headers
                            }
                        }

                        // Add Footer Here
                        yPoint += 30;

                        // Check if there's enough space for the footer, otherwise create a new page
                        if (yPoint > page.Height - 40)
                        {
                            page = pdf.AddPage(); // Add a new page if content exceeds the height
                            gfx = XGraphics.FromPdfPage(page);
                            yPoint = 30; // Reset yPoint for the new page
                        }

                        // Draw the footer
                        gfx.DrawString("Total Items Purchased: " + totalItemsPurchased, boldFont, XBrushes.Black, new XPoint(leftMargin, yPoint));
                        yPoint += 20;
                        gfx.DrawString("Total Purchase Amount: ₱" + totalPurchasePrice.ToString("N2"), boldFont, XBrushes.Black, new XPoint(leftMargin, yPoint));

                        pdf.Save(selectedPath);

                        MessageBox.Show("PDF saved successfully to: " + selectedPath, "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        /*private void GeneratePurchaseOrdersReport()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT * FROM PurchaseOrders";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable purchaseOrdersData = new DataTable();
                adapter.Fill(purchaseOrdersData);

                // Create a SaveFileDialog to allow the user to choose the location to save the PDF
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Save Purchase Orders Report";

                // Show the dialog and check if the user clicked "Save"
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = saveFileDialog.FileName;
                    PdfDocument pdfDocument = new PdfDocument();
                    pdfDocument.Info.Title = "Purchase Orders Report";

                    PdfPage page = pdfDocument.AddPage();

                    XFont font = new XFont("Arial", 10, XFontStyleEx.Regular);
                    XFont boldFont = new XFont("Arial", 12, XFontStyleEx.Bold);

                    XGraphics gfx = XGraphics.FromPdfPage(page);

                    // Title
                    gfx.DrawString("Purchase Orders Report", new XFont("Arial", 12, XFontStyleEx.Bold), XBrushes.Black, new XPoint(200, 30));

                    // Table Header
                    int yPoint = 70;
                    string[] headers = { "Order ID", "Item Name", "Brand", "Quantity", "Receiver", "Total Price", "Purchase Date", "Status" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        gfx.DrawString(headers[i], boldFont, XBrushes.Black, new XPoint(50 + (i * 80), yPoint));
                    }

                    // Add Data Rows
                    yPoint += 20;
                    foreach (DataRow row in purchaseOrdersData.Rows)
                    {
                        // Each row will be formatted to appear in the same column as the headers
                        gfx.DrawString(row["OrderID"].ToString(), font, XBrushes.Black, new XPoint(50, yPoint));
                        gfx.DrawString(row["ItemName"].ToString(), font, XBrushes.Black, new XPoint(130, yPoint));
                        gfx.DrawString(row["Brand"].ToString(), font, XBrushes.Black, new XPoint(210, yPoint));
                        gfx.DrawString(row["Quantity"].ToString(), font, XBrushes.Black, new XPoint(290, yPoint));
                        gfx.DrawString(row["Receiver"].ToString(), font, XBrushes.Black, new XPoint(370, yPoint));
                        gfx.DrawString(row["TotalPrice"].ToString(), font, XBrushes.Black, new XPoint(470, yPoint));
                        gfx.DrawString(row["PurchaseDate"].ToString(), font, XBrushes.Black, new XPoint(550, yPoint));
                        gfx.DrawString(row["Status"].ToString(), font, XBrushes.Black, new XPoint(630, yPoint));

                        // Move to the next row
                        yPoint += 20;
                    }

                    // Save PDF to the selected path
                    pdfDocument.Save(saveFileDialog.FileName);


                    // Optionally, open the file after saving
                    System.Diagnostics.Process.Start(selectedPath);

                    // Show success message
                    MessageBox.Show("Purchase Orders Report has been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }*/

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            if (LogInForm.CurrentUser.ProfilePicture != null && LogInForm.CurrentUser.ProfilePicture.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(LogInForm.CurrentUser.ProfilePicture))
                    {
                        pictureBox7.Image = System.Drawing.Image.FromStream(ms);
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Error loading profile picture: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No profile picture found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private byte[] GetProfilePictureFromDatabase(int userId)
        {
            byte[] imageBytes = null;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT ProfilePicture FROM Users WHERE UserID = @UserID";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        imageBytes = (byte[])result;
                    }
                }
            }

            return imageBytes;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // inventory report
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Inventory";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable inventoryData = new DataTable();
                    adapter.Fill(inventoryData);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveFileDialog.DefaultExt = "pdf";
                    saveFileDialog.FileName = "Inventory_Report_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedPath = saveFileDialog.FileName;

                        PdfDocument pdf = new PdfDocument();
                        pdf.Info.Title = "Inventory Report";

                        PdfPage page = pdf.AddPage();
                        XGraphics gfx = XGraphics.FromPdfPage(page);
                        XFont font = new XFont("Verdana", 10);
                        XFont boldFont = new XFont("Arial", 12, XFontStyleEx.Bold);

                        double leftMargin = 72; // 1 inch
                        double rightMargin = page.Width - 72; // 1 inch
                        double availableWidth = rightMargin - leftMargin;
                        double yPoint = 30;
                        double columnPadding = 25;

                        yPoint += 30;

                        // Centered Title
                        string title = "Inventory Report";
                        double titleWidth = gfx.MeasureString(title, boldFont).Width;
                        double titleX = (page.Width - titleWidth) / 2;
                        gfx.DrawString(title, boldFont, XBrushes.Black, new XPoint(titleX, yPoint));
                        yPoint += 50; // Margin under the title

                        // Date Generated
                        string dateGenerated = "Date Generated: " + DateTime.Now.ToString("MMMM dd, yyyy");
                        gfx.DrawString(dateGenerated, font, XBrushes.Black, new XPoint(leftMargin, yPoint));
                        yPoint += 30;

                        // Table Header
                        string[] headers = { "Item ID", "Item Name", "Brand", "Category", "Stock Level", "Unit Price", "Stock Status" };
                        int numColumns = headers.Length;

                        // Determine column widths based on the longest content
                        double[] columnWidths = new double[numColumns];
                        for (int i = 0; i < headers.Length; i++)
                        {
                            columnWidths[i] = gfx.MeasureString(headers[i], boldFont).Width;
                            foreach (DataRow row in inventoryData.Rows)
                            {
                                double contentWidth = gfx.MeasureString(row[headers[i].Replace(" ", "")].ToString(), font).Width;
                                columnWidths[i] = Math.Max(columnWidths[i], contentWidth);
                            }
                            columnWidths[i] += columnPadding; // Add padding
                        }

                        // Scale column widths proportionally to fit within the available width
                        double totalWidth = columnWidths.Sum();
                        for (int i = 0; i < columnWidths.Length; i++)
                        {
                            columnWidths[i] = (columnWidths[i] / totalWidth) * availableWidth;
                        }

                        // Draw header row
                        double xPoint = leftMargin;
                        for (int i = 0; i < headers.Length; i++)
                        {
                            gfx.DrawString(headers[i], boldFont, XBrushes.Black, new XPoint(xPoint, yPoint));
                            xPoint += columnWidths[i];
                        }
                        yPoint += 20; // Space below headers

                        // Counters for stock status
                        int totalItems = 0;
                        int lowStockItems = 0;
                        int inStockItems = 0;
                        int outOfStockItems = 0;

                        // Add Data Rows
                        foreach (DataRow row in inventoryData.Rows)
                        {
                            xPoint = leftMargin; // Reset X for each row
                            for (int i = 0; i < headers.Length; i++)
                            {
                                string cellText = row[headers[i].Replace(" ", "")].ToString();
                                double columnWidth = columnWidths[i];

                                // Wrap text logic
                                string[] words = cellText.Split(' ');
                                string currentLine = "";
                                foreach (string word in words)
                                {
                                    if (gfx.MeasureString(currentLine + " " + word, font).Width <= columnWidth)
                                    {
                                        currentLine += (currentLine == "" ? "" : " ") + word;
                                    }
                                    else
                                    {
                                        gfx.DrawString(currentLine, font, XBrushes.Black, new XPoint(xPoint, yPoint));
                                        yPoint += 15; // Move to the next line
                                        currentLine = word;
                                    }
                                }
                                gfx.DrawString(currentLine, font, XBrushes.Black, new XPoint(xPoint, yPoint));
                                xPoint += columnWidth; // Move to the next column
                            }
                            yPoint += 20; // Move to the next row

                            // Track stock status
                            totalItems++;
                            string stockStatus = row["StockStatus"].ToString();
                            if (stockStatus.ToLower() == "low stock") lowStockItems++;
                            if (stockStatus.ToLower() == "in stock") inStockItems++;
                            if (stockStatus.ToLower() == "out of stock") outOfStockItems++;

                            // Prevent overflow by checking yPoint
                            if (yPoint > page.Height - 40)
                            {
                                page = pdf.AddPage(); // Add a new page if content exceeds the height
                                gfx = XGraphics.FromPdfPage(page);
                                yPoint = 30; // Reset yPoint for new page

                                // Redraw headers on new page
                                xPoint = leftMargin;
                                for (int i = 0; i < headers.Length; i++)
                                {
                                    gfx.DrawString(headers[i], boldFont, XBrushes.Black, new XPoint(xPoint, yPoint));
                                    xPoint += columnWidths[i];
                                }
                                yPoint += 20; // Space below headers
                            }
                        }

                        // Footer: Total items, low stock, in stock, out of stock
                        yPoint += 30; // Space before footer

                        gfx.DrawString($"Total Items: {totalItems}", font, XBrushes.Black, new XPoint(leftMargin, yPoint));
                        yPoint += 20; 

                        gfx.DrawString($"Low Stock: {lowStockItems}", font, XBrushes.Black, new XPoint(leftMargin, yPoint));
                        yPoint += 20;

                        gfx.DrawString($"In Stock: {inStockItems}", font, XBrushes.Black, new XPoint(leftMargin, yPoint));
                        yPoint += 20; 

                        gfx.DrawString($"Out of Stock: {outOfStockItems}", font, XBrushes.Black, new XPoint(leftMargin, yPoint));

                        pdf.Save(selectedPath);

                        MessageBox.Show("PDF saved successfully to: " + selectedPath, "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button2_Click(object sender, EventArgs e)
        {
            //sales re[ort
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT * FROM sales";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable inventoryData = new DataTable();
                    adapter.Fill(inventoryData);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveFileDialog.DefaultExt = "pdf";
                    saveFileDialog.FileName = "Sales_Report_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedPath = saveFileDialog.FileName;

                        PdfDocument pdf = new PdfDocument();
                        pdf.Info.Title = "Sales Report";

                        PdfPage page = pdf.AddPage();
                        XGraphics gfx = XGraphics.FromPdfPage(page);
                        XFont font = new XFont("Verdana", 10);
                        XFont boldFont = new XFont("Arial", 12, XFontStyleEx.Bold);

                        double leftMargin = 72; // 1 inch
                        double rightMargin = page.Width - 72; // 1 inch
                        double availableWidth = rightMargin - leftMargin;
                        double yPoint = 30;
                        double columnPadding = 25;

                        yPoint += 30;

                        // Centered Title
                        string title = "Sales Report";
                        double titleWidth = gfx.MeasureString(title, boldFont).Width;
                        double titleX = (page.Width - titleWidth) / 2;
                        gfx.DrawString(title, boldFont, XBrushes.Black, new XPoint(titleX, yPoint));
                        yPoint += 50; // Margin under the title

                        // Date Generated
                        string dateGenerated = "Date Generated: " + DateTime.Now.ToString("MMMM dd, yyyy");
                        gfx.DrawString(dateGenerated, font, XBrushes.Black, new XPoint(leftMargin, yPoint));
                        yPoint += 30;

                        // Table Header
                        string[] headers = { "Item ID", "Item Name", "Brand", "Quantity", "Total Price", "Sale Date" };
                        int numColumns = headers.Length;

                        // Determine column widths based on the longest content
                        double[] columnWidths = new double[numColumns];
                        for (int i = 0; i < headers.Length; i++)
                        {
                            columnWidths[i] = gfx.MeasureString(headers[i], boldFont).Width;
                            foreach (DataRow row in inventoryData.Rows)
                            {
                                double contentWidth = gfx.MeasureString(row[headers[i].Replace(" ", "")].ToString(), font).Width;
                                columnWidths[i] = Math.Max(columnWidths[i], contentWidth);
                            }
                            columnWidths[i] += columnPadding; // Add padding
                        }

                        // Scale column widths proportionally to fit within the available width
                        double totalWidth = columnWidths.Sum();
                        for (int i = 0; i < columnWidths.Length; i++)
                        {
                            columnWidths[i] = (columnWidths[i] / totalWidth) * availableWidth;
                        }

                        // Draw header row
                        double xPoint = leftMargin;
                        for (int i = 0; i < headers.Length; i++)
                        {
                            gfx.DrawString(headers[i], boldFont, XBrushes.Black, new XPoint(xPoint, yPoint));
                            xPoint += columnWidths[i];
                        }
                        yPoint += 20; // Space below headers

                        // Initialize total counters
                        double totalSalesAmount = 0;
                        int totalItemsSold = 0;

                        // Add Data Rows
                        foreach (DataRow row in inventoryData.Rows)
                        {
                            xPoint = leftMargin; // Reset X for each row
                            for (int i = 0; i < headers.Length; i++)
                            {
                                string cellText = row[headers[i].Replace(" ", "")].ToString();
                                double columnWidth = columnWidths[i];

                                // Wrap text logic
                                string[] words = cellText.Split(' ');
                                string currentLine = "";
                                foreach (string word in words)
                                {
                                    if (gfx.MeasureString(currentLine + " " + word, font).Width <= columnWidth)
                                    {
                                        currentLine += (currentLine == "" ? "" : " ") + word;
                                    }
                                    else
                                    {
                                        gfx.DrawString(currentLine, font, XBrushes.Black, new XPoint(xPoint, yPoint));
                                        yPoint += 15; // Move to the next line
                                        currentLine = word;
                                    }
                                }
                                gfx.DrawString(currentLine, font, XBrushes.Black, new XPoint(xPoint, yPoint));
                                xPoint += columnWidth; // Move to the next column
                            }
                            yPoint += 20; // Move to the next row

                            // Calculate total sales amount and items sold
                            double totalPrice = Convert.ToDouble(row["TotalPrice"]);
                            totalSalesAmount += totalPrice;
                            totalItemsSold += Convert.ToInt32(row["Quantity"]);

                            // Prevent overflow by checking yPoint
                            if (yPoint > page.Height - 40)
                            {
                                page = pdf.AddPage(); // Add a new page if content exceeds the height
                                gfx = XGraphics.FromPdfPage(page);
                                yPoint = 30; // Reset yPoint for new page

                                // Redraw headers on new page
                                xPoint = leftMargin;
                                for (int i = 0; i < headers.Length; i++)
                                {
                                    gfx.DrawString(headers[i], boldFont, XBrushes.Black, new XPoint(xPoint, yPoint));
                                    xPoint += columnWidths[i];
                                }
                                yPoint += 20; // Space below headers
                            }
                        }

                        // Add Footer Here
                        yPoint += 30;

                        // Check if there's enough space for the footer, otherwise create a new page
                        if (yPoint > page.Height - 40)
                        {
                            page = pdf.AddPage(); // Add a new page if content exceeds the height
                            gfx = XGraphics.FromPdfPage(page);
                            yPoint = 30; // Reset yPoint for the new page
                        }

                        // Draw the footer
                        gfx.DrawString("Total Items Sold: " + totalItemsSold, boldFont, XBrushes.Black, new XPoint(leftMargin, yPoint));
                        yPoint += 20;
                        gfx.DrawString("Total Sales Amount: ₱" + totalSalesAmount.ToString("N2"), boldFont, XBrushes.Black, new XPoint(leftMargin, yPoint));

                        pdf.Save(selectedPath);

                        MessageBox.Show("PDF saved successfully to: " + selectedPath, "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int userID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);
                string username = selectedRow.Cells["Username"].Value.ToString();
                string role = selectedRow.Cells["Role"].Value.ToString();
                string fullName = selectedRow.Cells["FullName"].Value.ToString();
                string email = selectedRow.Cells["Email"].Value.ToString();
                string contactNumber = selectedRow.Cells["ContactNumber"].Value.ToString();
                string address = selectedRow.Cells["Address"].Value.ToString();

                byte[] profilePictureData = GetProfilePictureFromDatabase(userID);
                System.Drawing.Image profilePicture = null;

                if (profilePictureData != null)
                {
                    using (MemoryStream ms = new MemoryStream(profilePictureData))
                    {
                        profilePicture = System.Drawing.Image.FromStream(ms);
                    }
                }

                EditUserProfile editForm = new EditUserProfile(userID, username, role, fullName, email, contactNumber, address, profilePicture);
                editForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a single user to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int userID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this account?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteAccount(userID);
                }
            }
            else
            {
                MessageBox.Show("Please select a single user to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DeleteAccount(int userID)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Users WHERE UserID = @UserID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Account deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUserData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete the account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //profile picture, username, full name, email address, sontact number
        }

        private void LoadUserData()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                                UserID,
                                Username,
                                Role,
                                CONCAT(FirstName, ' ', LastName) AS FullName,
                                Email,
                                PhoneNumber AS ContactNumber,
                                Address
                             FROM Users";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;

                        dataGridView1.Columns["Username"].HeaderText = "Username";
                        dataGridView1.Columns["Role"].HeaderText = "Role";
                        dataGridView1.Columns["FullName"].HeaderText = "Full Name";
                        dataGridView1.Columns["Email"].HeaderText = "Email Address";
                        dataGridView1.Columns["ContactNumber"].HeaderText = "Contact Number";
                        dataGridView1.Columns["Address"].HeaderText = "Address";

                        dataGridView1.Columns["UserID"].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading user data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Reports_ADMIN_Load(object sender, EventArgs e)
        {
            Timer checkNotificationsTimer = new Timer
            {
                Interval = 10000
            };
            checkNotificationsTimer.Tick += CheckNewNotificationsTimer_Tick;
            checkNotificationsTimer.Start();

            pictureBox1.Visible = false;
            lastNotificationCount = GetNotificationCount(); 
            
            LoadUserData();

            button4.Text = CurrentUser.FirstName + " " + CurrentUser.LastName;
            button5.Text = LogInForm.CurrentUser.Email;

            if (CurrentUser.ProfilePicture != null && CurrentUser.ProfilePicture.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(CurrentUser.ProfilePicture))
                    {
                        pictureBox7.Image = System.Drawing.Image.FromStream(ms);
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Error loading profile picture: " + ex.Message);
                    pictureBox7.Image = null;
                }
            }
            else
            {
                pictureBox7.Image = null;
            }
        }

        private void InitializeNotificationIndicator()
        {
            pictureBox1.Visible = false;
        }

        private void CheckNewNotificationsTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (HasNewNotifications())
                {
                    pictureBox1.Visible = true;
                }
                else
                {
                    pictureBox1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for new notifications: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool HasNewNotifications()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Notifications";

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        int currentNotificationCount = Convert.ToInt32(cmd.ExecuteScalar());

                        if (currentNotificationCount > lastNotificationCount)
                        {
                            lastNotificationCount = currentNotificationCount;
                            return true;
                        }
                        else if (currentNotificationCount == 0)
                        {
                            lastNotificationCount = 0;
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for new notifications: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private int GetNotificationCount()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Notifications";

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching notification count: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void MarkNotificationsAsRead()
        {
            try
            {
                string query = "UPDATE Notifications SET IsRead = 1 WHERE IsRead = 0";

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                pictureBox1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error marking notifications as read: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = CurrentUser.FirstName + " " + CurrentUser.LastName;

            UserProfile userDetailsForm = new UserProfile(CurrentUser.FirstName + " " + CurrentUser.LastName, CurrentUser.Email);
            userDetailsForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Text = CurrentUser.Email;

            UserProfile userDetailsForm = new UserProfile(CurrentUser.FirstName + " " + CurrentUser.LastName, CurrentUser.Email);
            userDetailsForm.Show();
        }

        private void notify_pictureBox_Click_1(object sender, EventArgs e)
        {
            Notifications popup = new Notifications();
            popup.Show();

            pictureBox1.Visible = false;
        }
    }
}
