
namespace Dashboard_STAFF
{
    partial class Inventory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            profile_pictureBox = new PictureBox();
            orgName_label = new Label();
            search_textBox = new TextBox();
            splitContainer1 = new SplitContainer();
            purchaseOrders_btn = new Button();
            salesReturns_btn = new Button();
            salesOrders_btn = new Button();
            itemGrp_btn = new Button();
            inventory_btn = new Button();
            home_btn = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            flowLayoutPanel4 = new FlowLayoutPanel();
            button3 = new Button();
            inventory_dataGridView = new DataGridView();
            flowLayoutPanel3 = new FlowLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            notify_pictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)profile_pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inventory_dataGridView).BeginInit();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)notify_pictureBox).BeginInit();
            SuspendLayout();
            // 
            // profile_pictureBox
            // 
            profile_pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            profile_pictureBox.BorderStyle = BorderStyle.FixedSingle;
            profile_pictureBox.Image = (Image)resources.GetObject("profile_pictureBox.Image");
            profile_pictureBox.Location = new Point(1434, 15);
            profile_pictureBox.Margin = new Padding(19, 4, 4, 4);
            profile_pictureBox.Name = "profile_pictureBox";
            profile_pictureBox.Size = new Size(62, 62);
            profile_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            profile_pictureBox.TabIndex = 1;
            profile_pictureBox.TabStop = false;
            // 
            // orgName_label
            // 
            orgName_label.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            orgName_label.AutoSize = true;
            orgName_label.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            orgName_label.Location = new Point(1305, 35);
            orgName_label.Margin = new Padding(4, 0, 4, 0);
            orgName_label.Name = "orgName_label";
            orgName_label.RightToLeft = RightToLeft.Yes;
            orgName_label.Size = new Size(98, 28);
            orgName_label.TabIndex = 2;
            orgName_label.Text = "C-SHARK";
            // 
            // search_textBox
            // 
            search_textBox.Font = new Font("Segoe UI", 9F);
            search_textBox.ForeColor = Color.FromArgb(43, 42, 76);
            search_textBox.Location = new Point(15, 15);
            search_textBox.Margin = new Padding(4);
            search_textBox.Name = "search_textBox";
            search_textBox.PlaceholderText = "Search";
            search_textBox.Size = new Size(396, 31);
            search_textBox.TabIndex = 0;
            search_textBox.TextChanged += search_textBox_TextChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(43, 42, 76);
            splitContainer1.Panel1.Controls.Add(purchaseOrders_btn);
            splitContainer1.Panel1.Controls.Add(salesReturns_btn);
            splitContainer1.Panel1.Controls.Add(salesOrders_btn);
            splitContainer1.Panel1.Controls.Add(itemGrp_btn);
            splitContainer1.Panel1.Controls.Add(inventory_btn);
            splitContainer1.Panel1.Controls.Add(home_btn);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pictureBox1);
            splitContainer1.Panel2.Controls.Add(flowLayoutPanel4);
            splitContainer1.Panel2.Controls.Add(inventory_dataGridView);
            splitContainer1.Panel2.Controls.Add(flowLayoutPanel3);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(flowLayoutPanel2);
            splitContainer1.Panel2.Controls.Add(flowLayoutPanel1);
            splitContainer1.Panel2.Controls.Add(notify_pictureBox);
            splitContainer1.Panel2.Controls.Add(orgName_label);
            splitContainer1.Panel2.Controls.Add(profile_pictureBox);
            splitContainer1.Panel2.Controls.Add(search_textBox);
            splitContainer1.Panel2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            splitContainer1.Size = new Size(1924, 1050);
            splitContainer1.SplitterDistance = 392;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 1;
            // 
            // purchaseOrders_btn
            // 
            purchaseOrders_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            purchaseOrders_btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            purchaseOrders_btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            purchaseOrders_btn.Location = new Point(15, 386);
            purchaseOrders_btn.Margin = new Padding(4);
            purchaseOrders_btn.Name = "purchaseOrders_btn";
            purchaseOrders_btn.Size = new Size(366, 45);
            purchaseOrders_btn.TabIndex = 6;
            purchaseOrders_btn.Text = "Purchase Orders";
            purchaseOrders_btn.TextAlign = ContentAlignment.MiddleLeft;
            purchaseOrders_btn.UseVisualStyleBackColor = true;
            purchaseOrders_btn.Click += purchaseOrders_btn_Click;
            // 
            // salesReturns_btn
            // 
            salesReturns_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            salesReturns_btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            salesReturns_btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            salesReturns_btn.Location = new Point(15, 334);
            salesReturns_btn.Margin = new Padding(4);
            salesReturns_btn.Name = "salesReturns_btn";
            salesReturns_btn.Size = new Size(366, 45);
            salesReturns_btn.TabIndex = 5;
            salesReturns_btn.Text = "Sales Returns";
            salesReturns_btn.TextAlign = ContentAlignment.MiddleLeft;
            salesReturns_btn.UseVisualStyleBackColor = true;
            salesReturns_btn.Click += salesReturns_btn_Click;
            // 
            // salesOrders_btn
            // 
            salesOrders_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            salesOrders_btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            salesOrders_btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            salesOrders_btn.Location = new Point(15, 281);
            salesOrders_btn.Margin = new Padding(4);
            salesOrders_btn.Name = "salesOrders_btn";
            salesOrders_btn.Size = new Size(366, 45);
            salesOrders_btn.TabIndex = 4;
            salesOrders_btn.Text = "Sales Orders";
            salesOrders_btn.TextAlign = ContentAlignment.MiddleLeft;
            salesOrders_btn.UseVisualStyleBackColor = true;
            salesOrders_btn.Click += salesOrders_btn_Click;
            
            // 
            // inventory_btn
            // 
            inventory_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            inventory_btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            inventory_btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            inventory_btn.Location = new Point(15, 145);
            inventory_btn.Margin = new Padding(4);
            inventory_btn.Name = "inventory_btn";
            inventory_btn.Size = new Size(366, 45);
            inventory_btn.TabIndex = 2;
            inventory_btn.Text = "Inventory";
            inventory_btn.TextAlign = ContentAlignment.MiddleLeft;
            inventory_btn.UseVisualStyleBackColor = true;
            inventory_btn.Click += inventory_btn_Click;
            // 
            // home_btn
            // 
            home_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            home_btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            home_btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            home_btn.Location = new Point(15, 69);
            home_btn.Margin = new Padding(4);
            home_btn.Name = "home_btn";
            home_btn.Size = new Size(366, 45);
            home_btn.TabIndex = 1;
            home_btn.Text = "Home";
            home_btn.TextAlign = ContentAlignment.MiddleLeft;
            home_btn.UseVisualStyleBackColor = true;
            home_btn.Click += home_btn_Click_1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(15, 11);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(359, 36);
            label1.TabIndex = 0;
            label1.Text = "INVENTORY MANAGEMENT";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._860820__1_;
            pictureBox1.Location = new Point(1475, 145);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 28);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(button3);
            flowLayoutPanel4.Location = new Point(1356, 301);
            flowLayoutPanel4.Margin = new Padding(4);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(198, 156);
            flowLayoutPanel4.TabIndex = 9;
            // 
            // button3
            // 
            button3.Location = new Point(19, 38);
            button3.Margin = new Padding(19, 38, 4, 4);
            button3.Name = "button3";
            button3.Size = new Size(161, 92);
            button3.TabIndex = 0;
            button3.Text = "Request Restock";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // inventory_dataGridView
            // 
            inventory_dataGridView.AllowUserToAddRows = false;
            inventory_dataGridView.AllowUserToDeleteRows = false;
            inventory_dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            inventory_dataGridView.BackgroundColor = Color.FromArgb(238, 226, 222);
            inventory_dataGridView.BorderStyle = BorderStyle.None;
            inventory_dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            inventory_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            inventory_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(43, 42, 76);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            inventory_dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            inventory_dataGridView.Location = new Point(19, 301);
            inventory_dataGridView.Margin = new Padding(4);
            inventory_dataGridView.Name = "inventory_dataGridView";
            inventory_dataGridView.ReadOnly = true;
            inventory_dataGridView.RowHeadersVisible = false;
            inventory_dataGridView.RowHeadersWidth = 51;
            inventory_dataGridView.ScrollBars = ScrollBars.Horizontal;
            inventory_dataGridView.Size = new Size(1273, 875);
            inventory_dataGridView.TabIndex = 8;
            inventory_dataGridView.CellContentClick += inventory_dataGridView_CellContentClick;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel3.Controls.Add(button1);
            flowLayoutPanel3.Controls.Add(button2);
            flowLayoutPanel3.Location = new Point(1050, 186);
            flowLayoutPanel3.Margin = new Padding(4);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(447, 108);
            flowLayoutPanel3.TabIndex = 7;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.Location = new Point(4, 12);
            button1.Margin = new Padding(4, 12, 50, 4);
            button1.Name = "button1";
            button1.Size = new Size(185, 76);
            button1.TabIndex = 0;
            button1.Text = "Export as PDF";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button2.Location = new Point(243, 12);
            button2.Margin = new Padding(4, 12, 4, 4);
            button2.Name = "button2";
            button2.Size = new Size(185, 76);
            button2.TabIndex = 1;
            button2.Text = "Export as CSV";
            button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(15, 148);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(138, 32);
            label2.TabIndex = 0;
            label2.Text = "SUMMARY";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label3);
            flowLayoutPanel2.Controls.Add(label4);
            flowLayoutPanel2.Controls.Add(label5);
            flowLayoutPanel2.Controls.Add(label6);
            flowLayoutPanel2.Controls.Add(label7);
            flowLayoutPanel2.Controls.Add(label8);
            flowLayoutPanel2.Location = new Point(19, 186);
            flowLayoutPanel2.Margin = new Padding(4);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(0, 25, 0, 0);
            flowLayoutPanel2.Size = new Size(1000, 108);
            flowLayoutPanel2.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 25);
            label3.Margin = new Padding(25, 0, 12, 0);
            label3.Name = "label3";
            label3.Size = new Size(146, 32);
            label3.TabIndex = 0;
            label3.Text = "Total items:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(183, 25);
            label4.Margin = new Padding(0, 0, 62, 0);
            label4.Name = "label4";
            label4.Size = new Size(28, 32);
            label4.TabIndex = 1;
            label4.Text = "0";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(298, 25);
            label5.Margin = new Padding(25, 0, 12, 0);
            label5.Name = "label5";
            label5.Size = new Size(162, 32);
            label5.TabIndex = 2;
            label5.Text = "Out of stock:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(472, 25);
            label6.Margin = new Padding(0, 0, 62, 0);
            label6.Name = "label6";
            label6.Size = new Size(28, 32);
            label6.TabIndex = 3;
            label6.Text = "0";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(587, 25);
            label7.Margin = new Padding(25, 0, 12, 0);
            label7.Name = "label7";
            label7.Size = new Size(135, 32);
            label7.TabIndex = 4;
            label7.Text = "Low stock:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(734, 25);
            label8.Margin = new Padding(0, 0, 62, 0);
            label8.Name = "label8";
            label8.Size = new Size(28, 32);
            label8.TabIndex = 5;
            label8.Text = "0";
            label8.Click += label8_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(comboBox1);
            flowLayoutPanel1.Controls.Add(comboBox2);
            flowLayoutPanel1.Location = new Point(15, 85);
            flowLayoutPanel1.Margin = new Padding(4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1539, 42);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            comboBox1.ForeColor = Color.FromArgb(43, 42, 76);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(4, 4);
            comboBox1.Margin = new Padding(4, 4, 50, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(188, 33);
            comboBox1.TabIndex = 0;
            comboBox1.Text = "SORT";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            comboBox2.ForeColor = Color.FromArgb(43, 42, 76);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(246, 4);
            comboBox2.Margin = new Padding(4);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(188, 33);
            comboBox2.TabIndex = 1;
            comboBox2.Text = "FILTER";
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // notify_pictureBox
            // 
            notify_pictureBox.BackColor = Color.Transparent;
            notify_pictureBox.Cursor = Cursors.Hand;
            notify_pictureBox.Image = Properties.Resources._565422;
            notify_pictureBox.Location = new Point(1311, 26);
            notify_pictureBox.Margin = new Padding(4);
            notify_pictureBox.Name = "notify_pictureBox";
            notify_pictureBox.Size = new Size(38, 38);
            notify_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            notify_pictureBox.TabIndex = 4;
            notify_pictureBox.TabStop = false;
            // 
            // Inventory
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 226, 222);
            ClientSize = new Size(1924, 1050);
            Controls.Add(splitContainer1);
            ForeColor = Color.FromArgb(43, 42, 76);
            Margin = new Padding(4);
            Name = "Inventory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inventory";
            Load += Inventory_Load;
            ((System.ComponentModel.ISupportInitialize)profile_pictureBox).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)inventory_dataGridView).EndInit();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)notify_pictureBox).EndInit();
            ResumeLayout(false);
        }



        #endregion
        private PictureBox profile_pictureBox;
        private Label orgName_label;
        private TextBox search_textBox;
        private SplitContainer splitContainer1;
        private Button purchaseOrders_btn;
        private Button salesReturns_btn;
        private Button salesOrders_btn;
        private Button itemGrp_btn;
        private Button inventory_btn;
        private Button home_btn;
        private Label label1;
        private PictureBox notify_pictureBox;
        private FlowLayoutPanel flowLayoutPanel1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button button1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button button2;
        private DataGridView inventory_dataGridView;
        private FlowLayoutPanel flowLayoutPanel4;
        private Button button3;
        private PictureBox pictureBox1;
    }
}