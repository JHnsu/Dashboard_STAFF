namespace Dashboard_STAFF
{
    partial class SalesOrder_ADMIN
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            salesOrder_dataGridView = new DataGridView();
            notify_pictureBox = new PictureBox();
            purchaseOrders_btn = new Button();
            salesReturns_btn = new Button();
            salesOrders_btn = new Button();
            inventory_btn = new Button();
            home_btn = new Button();
            splitContainer1 = new SplitContainer();
            button2 = new Button();
            button1 = new Button();
            profile_pictureBox = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox5 = new PictureBox();
            reports_btn = new Button();
            label1 = new Label();
            flowLayoutPanel4 = new FlowLayoutPanel();
            button3 = new Button();
            button5 = new Button();
            orgName_label = new Label();
            search_textBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)salesOrder_dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)notify_pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)profile_pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            flowLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // salesOrder_dataGridView
            // 
            salesOrder_dataGridView.AllowUserToAddRows = false;
            salesOrder_dataGridView.AllowUserToDeleteRows = false;
            salesOrder_dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            salesOrder_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            salesOrder_dataGridView.BackgroundColor = Color.FromArgb(238, 226, 222);
            salesOrder_dataGridView.BorderStyle = BorderStyle.None;
            salesOrder_dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            salesOrder_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            salesOrder_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(43, 42, 76);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            salesOrder_dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            salesOrder_dataGridView.Location = new Point(12, 66);
            salesOrder_dataGridView.Name = "salesOrder_dataGridView";
            salesOrder_dataGridView.ReadOnly = true;
            salesOrder_dataGridView.RowHeadersVisible = false;
            salesOrder_dataGridView.RowHeadersWidth = 51;
            salesOrder_dataGridView.ScrollBars = ScrollBars.Horizontal;
            salesOrder_dataGridView.Size = new Size(1176, 649);
            salesOrder_dataGridView.TabIndex = 9;
            salesOrder_dataGridView.CellContentClick += salesOrder_dataGridView_CellContentClick;
            // 
            // notify_pictureBox
            // 
            notify_pictureBox.BackColor = Color.Transparent;
            notify_pictureBox.Cursor = Cursors.Hand;
            notify_pictureBox.Image = Properties.Resources._565422;
            notify_pictureBox.Location = new Point(1049, 21);
            notify_pictureBox.Name = "notify_pictureBox";
            notify_pictureBox.Size = new Size(30, 30);
            notify_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            notify_pictureBox.TabIndex = 4;
            notify_pictureBox.TabStop = false;
            // 
            // purchaseOrders_btn
            // 
            purchaseOrders_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            purchaseOrders_btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            purchaseOrders_btn.FlatAppearance.BorderSize = 0;
            purchaseOrders_btn.FlatStyle = FlatStyle.Flat;
            purchaseOrders_btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            purchaseOrders_btn.ForeColor = Color.White;
            purchaseOrders_btn.Location = new Point(3, 422);
            purchaseOrders_btn.Name = "purchaseOrders_btn";
            purchaseOrders_btn.Size = new Size(291, 36);
            purchaseOrders_btn.TabIndex = 6;
            purchaseOrders_btn.Text = "          Purchase Orders";
            purchaseOrders_btn.TextAlign = ContentAlignment.MiddleLeft;
            purchaseOrders_btn.UseVisualStyleBackColor = true;
            purchaseOrders_btn.Click += purchaseOrders_btn_Click;
            // 
            // salesReturns_btn
            // 
            salesReturns_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            salesReturns_btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            salesReturns_btn.FlatAppearance.BorderSize = 0;
            salesReturns_btn.FlatStyle = FlatStyle.Flat;
            salesReturns_btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            salesReturns_btn.ForeColor = Color.White;
            salesReturns_btn.Location = new Point(0, 344);
            salesReturns_btn.Name = "salesReturns_btn";
            salesReturns_btn.Size = new Size(291, 36);
            salesReturns_btn.TabIndex = 5;
            salesReturns_btn.Text = "           Sales Returns";
            salesReturns_btn.TextAlign = ContentAlignment.MiddleLeft;
            salesReturns_btn.UseVisualStyleBackColor = true;
            salesReturns_btn.Click += salesReturns_btn_Click;
            // 
            // salesOrders_btn
            // 
            salesOrders_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            salesOrders_btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            salesOrders_btn.FlatAppearance.BorderSize = 0;
            salesOrders_btn.FlatStyle = FlatStyle.Flat;
            salesOrders_btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            salesOrders_btn.ForeColor = Color.White;
            salesOrders_btn.Location = new Point(3, 267);
            salesOrders_btn.Name = "salesOrders_btn";
            salesOrders_btn.Size = new Size(308, 36);
            salesOrders_btn.TabIndex = 4;
            salesOrders_btn.Text = "          Sales Orders";
            salesOrders_btn.TextAlign = ContentAlignment.MiddleLeft;
            salesOrders_btn.UseVisualStyleBackColor = true;
            salesOrders_btn.Click += salesOrders_btn_Click;
            // 
            // inventory_btn
            // 
            inventory_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            inventory_btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            inventory_btn.FlatAppearance.BorderSize = 0;
            inventory_btn.FlatStyle = FlatStyle.Flat;
            inventory_btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            inventory_btn.ForeColor = Color.White;
            inventory_btn.Location = new Point(0, 190);
            inventory_btn.Name = "inventory_btn";
            inventory_btn.Size = new Size(294, 36);
            inventory_btn.TabIndex = 2;
            inventory_btn.Text = "           Inventory";
            inventory_btn.TextAlign = ContentAlignment.MiddleLeft;
            inventory_btn.UseVisualStyleBackColor = true;
            inventory_btn.Click += inventory_btn_Click;
            // 
            // home_btn
            // 
            home_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            home_btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            home_btn.FlatAppearance.BorderSize = 0;
            home_btn.FlatStyle = FlatStyle.Flat;
            home_btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            home_btn.ForeColor = Color.White;
            home_btn.Location = new Point(0, 113);
            home_btn.Name = "home_btn";
            home_btn.Size = new Size(305, 36);
            home_btn.TabIndex = 1;
            home_btn.Text = "           Home";
            home_btn.TextAlign = ContentAlignment.MiddleLeft;
            home_btn.UseVisualStyleBackColor = true;
            home_btn.Click += home_btn_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(43, 42, 76);
            splitContainer1.Panel1.Controls.Add(button2);
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Controls.Add(profile_pictureBox);
            splitContainer1.Panel1.Controls.Add(pictureBox4);
            splitContainer1.Panel1.Controls.Add(pictureBox3);
            splitContainer1.Panel1.Controls.Add(purchaseOrders_btn);
            splitContainer1.Panel1.Controls.Add(pictureBox2);
            splitContainer1.Panel1.Controls.Add(pictureBox6);
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            splitContainer1.Panel1.Controls.Add(pictureBox5);
            splitContainer1.Panel1.Controls.Add(reports_btn);
            splitContainer1.Panel1.Controls.Add(salesReturns_btn);
            splitContainer1.Panel1.Controls.Add(salesOrders_btn);
            splitContainer1.Panel1.Controls.Add(inventory_btn);
            splitContainer1.Panel1.Controls.Add(home_btn);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(flowLayoutPanel4);
            splitContainer1.Panel2.Controls.Add(salesOrder_dataGridView);
            splitContainer1.Panel2.Controls.Add(notify_pictureBox);
            splitContainer1.Panel2.Controls.Add(orgName_label);
            splitContainer1.Panel2.Controls.Add(search_textBox);
            splitContainer1.Panel2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            splitContainer1.Size = new Size(1539, 840);
            splitContainer1.SplitterDistance = 314;
            splitContainer1.TabIndex = 3;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(124, 738);
            button2.Name = "button2";
            button2.Size = new Size(153, 36);
            button2.TabIndex = 53;
            button2.Text = "Shaine Bambico";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Light", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(116, 752);
            button1.Name = "button1";
            button1.Size = new Size(179, 76);
            button1.TabIndex = 54;
            button1.Text = "shaineangeloubambico\r\n@gmail.com";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = true;
            // 
            // profile_pictureBox
            // 
            profile_pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            profile_pictureBox.BorderStyle = BorderStyle.FixedSingle;
            profile_pictureBox.Image = Properties.Resources.c29b44ca_e825_4217_b7e6_f6825e0fa03a;
            profile_pictureBox.Location = new Point(18, 741);
            profile_pictureBox.Margin = new Padding(15, 3, 3, 3);
            profile_pictureBox.Name = "profile_pictureBox";
            profile_pictureBox.Size = new Size(92, 87);
            profile_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            profile_pictureBox.TabIndex = 52;
            profile_pictureBox.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.report_removebg_preview1;
            pictureBox4.Location = new Point(12, 501);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(50, 30);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 51;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.basket_removebg_preview;
            pictureBox3.Location = new Point(12, 423);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(50, 30);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 50;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.returns_removebg_preview;
            pictureBox2.Location = new Point(12, 344);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(50, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 49;
            pictureBox2.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.imgbin_shopping_cart_computer_icons_white_cart_simple_white_shopping_cart_illustration_nDJVn3nE6gpyZGMq8spPi2dy0_removebg_preview;
            pictureBox6.Location = new Point(12, 267);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(50, 30);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 48;
            pictureBox6.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.stock_inventory_icon_15;
            pictureBox1.Location = new Point(12, 192);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 47;
            pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.whitebtn;
            pictureBox5.Location = new Point(12, 116);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(50, 30);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 46;
            pictureBox5.TabStop = false;
            // 
            // reports_btn
            // 
            reports_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            reports_btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            reports_btn.FlatAppearance.BorderSize = 0;
            reports_btn.FlatStyle = FlatStyle.Flat;
            reports_btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            reports_btn.ForeColor = Color.White;
            reports_btn.Location = new Point(0, 499);
            reports_btn.Name = "reports_btn";
            reports_btn.Size = new Size(311, 36);
            reports_btn.TabIndex = 11;
            reports_btn.Text = "           Reports";
            reports_btn.TextAlign = ContentAlignment.MiddleLeft;
            reports_btn.UseVisualStyleBackColor = true;
            reports_btn.Click += reports_btn_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(359, 36);
            label1.TabIndex = 0;
            label1.Text = "INVENTORY MANAGEMENT";
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(button3);
            flowLayoutPanel4.Controls.Add(button5);
            flowLayoutPanel4.Location = new Point(3, 734);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Padding = new Padding(20);
            flowLayoutPanel4.Size = new Size(799, 94);
            flowLayoutPanel4.TabIndex = 10;
            // 
            // button3
            // 
            button3.Location = new Point(23, 23);
            button3.Margin = new Padding(3, 3, 3, 18);
            button3.Name = "button3";
            button3.Size = new Size(142, 50);
            button3.TabIndex = 0;
            button3.Text = "Add Order";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.Location = new Point(171, 23);
            button5.Margin = new Padding(3, 3, 3, 18);
            button5.Name = "button5";
            button5.Size = new Size(142, 50);
            button5.TabIndex = 2;
            button5.Text = "Delete Order";
            button5.UseVisualStyleBackColor = true;
            // 
            // orgName_label
            // 
            orgName_label.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            orgName_label.AutoSize = true;
            orgName_label.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            orgName_label.Location = new Point(1090, 24);
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
            search_textBox.Location = new Point(12, 12);
            search_textBox.Name = "search_textBox";
            search_textBox.PlaceholderText = "Search";
            search_textBox.Size = new Size(318, 31);
            search_textBox.TabIndex = 0;
            search_textBox.TextChanged += search_textBox_TextChanged;
            // 
            // SalesOrder_ADMIN
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(238, 226, 222);
            ClientSize = new Size(1539, 840);
            Controls.Add(splitContainer1);
            ForeColor = Color.FromArgb(43, 42, 76);
            MaximumSize = new Size(1561, 896);
            Name = "SalesOrder_ADMIN";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SalesOrder_ADMIN";
            Load += SalesOrder_ADMIN_Load;
            ((System.ComponentModel.ISupportInitialize)salesOrder_dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)notify_pictureBox).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)profile_pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            flowLayoutPanel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DataGridView salesOrder_dataGridView;
        private PictureBox notify_pictureBox;
        private Button purchaseOrders_btn;
        private Button salesReturns_btn;
        private Button salesOrders_btn;
        private Button inventory_btn;
        private Button home_btn;
        private SplitContainer splitContainer1;
        private Label label1;
        private Label orgName_label;
        private TextBox search_textBox;
        private Button reports_btn;
        private FlowLayoutPanel flowLayoutPanel4;
        private Button button3;
        private Button button5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox6;
        private PictureBox pictureBox1;
        private PictureBox pictureBox5;
        private Button button2;
        private Button button1;
        private PictureBox profile_pictureBox;
    }
}