﻿namespace Dashboard_STAFF
{
    partial class PurchaseOrders
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            panel3 = new Panel();
            panel4 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            button2 = new Button();
            button6 = new Button();
            pictureBox7 = new PictureBox();
            panel6 = new Panel();
            pictureBox3 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox8 = new PictureBox();
            purchaseOrders_btn = new Button();
            salesOrders_btn = new Button();
            inventory_btn = new Button();
            home_btn = new Button();
            label1 = new Label();
            panel5 = new Panel();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            flowLayoutPanel4 = new FlowLayoutPanel();
            orgName_label = new Label();
            search_textBox = new TextBox();
            panel1 = new Panel();
            groupBox2 = new GroupBox();
            purchaseOrders_dataGridView = new DataGridView();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label5 = new Label();
            label6 = new Label();
            timercheckNotifications = new System.Windows.Forms.Timer(components);
            notify_pictureBox = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            panel5.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)purchaseOrders_dataGridView).BeginInit();
            groupBox1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)notify_pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(43, 42, 76);
            splitContainer1.Panel1.Controls.Add(panel3);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel5);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            splitContainer1.Size = new Size(1370, 749);
            splitContainer1.SplitterDistance = 312;
            splitContainer1.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 11, 71);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(pictureBox6);
            panel3.Controls.Add(pictureBox5);
            panel3.Controls.Add(pictureBox8);
            panel3.Controls.Add(purchaseOrders_btn);
            panel3.Controls.Add(salesOrders_btn);
            panel3.Controls.Add(inventory_btn);
            panel3.Controls.Add(home_btn);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(312, 749);
            panel3.TabIndex = 44;
            // 
            // panel4
            // 
            panel4.Controls.Add(tableLayoutPanel2);
            panel4.Controls.Add(pictureBox7);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 628);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Size = new Size(312, 121);
            panel4.TabIndex = 61;
            panel4.Paint += panel4_Paint;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(button2, 0, 0);
            tableLayoutPanel2.Controls.Add(button6, 0, 1);
            tableLayoutPanel2.Location = new Point(101, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 44.6280975F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 55.3719025F));
            tableLayoutPanel2.Size = new Size(209, 121);
            tableLayoutPanel2.TabIndex = 32;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(3, 27);
            button2.Name = "button2";
            button2.Size = new Size(203, 24);
            button2.TabIndex = 32;
            button2.Text = "Full Name";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI Light", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.White;
            button6.Location = new Point(3, 57);
            button6.Name = "button6";
            button6.Size = new Size(203, 48);
            button6.TabIndex = 33;
            button6.Text = "example@gmail.com";
            button6.TextAlign = ContentAlignment.MiddleLeft;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.BorderStyle = BorderStyle.FixedSingle;
            pictureBox7.Image = Properties.Resources._1564534_customer_man_user_account_profile_icon;
            pictureBox7.Location = new Point(15, 25);
            pictureBox7.Margin = new Padding(15, 3, 3, 3);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(80, 80);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 31;
            pictureBox7.TabStop = false;
            pictureBox7.Click += pictureBox7_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(99, 218, 255);
            panel6.Location = new Point(3, 421);
            panel6.MaximumSize = new Size(18, 60);
            panel6.MinimumSize = new Size(18, 60);
            panel6.Name = "panel6";
            panel6.Size = new Size(18, 60);
            panel6.TabIndex = 60;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.basket_removebg_preview;
            pictureBox3.Location = new Point(15, 434);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(50, 30);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 58;
            pictureBox3.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.imgbin_shopping_cart_computer_icons_white_cart_simple_white_shopping_cart_illustration_nDJVn3nE6gpyZGMq8spPi2dy0_removebg_preview;
            pictureBox6.Location = new Point(15, 349);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(50, 30);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 57;
            pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.stock_inventory_icon_15;
            pictureBox5.Location = new Point(15, 274);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(50, 30);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 56;
            pictureBox5.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = Properties.Resources.whitebtn;
            pictureBox8.Location = new Point(15, 198);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(50, 30);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 55;
            pictureBox8.TabStop = false;
            // 
            // purchaseOrders_btn
            // 
            purchaseOrders_btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            purchaseOrders_btn.FlatAppearance.BorderSize = 0;
            purchaseOrders_btn.FlatStyle = FlatStyle.Flat;
            purchaseOrders_btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            purchaseOrders_btn.ForeColor = Color.White;
            purchaseOrders_btn.Location = new Point(3, 430);
            purchaseOrders_btn.Name = "purchaseOrders_btn";
            purchaseOrders_btn.Size = new Size(304, 36);
            purchaseOrders_btn.TabIndex = 53;
            purchaseOrders_btn.Text = "            Purchase Orders";
            purchaseOrders_btn.TextAlign = ContentAlignment.MiddleLeft;
            purchaseOrders_btn.UseVisualStyleBackColor = true;
            purchaseOrders_btn.Click += purchaseOrders_btn_Click;
            // 
            // salesOrders_btn
            // 
            salesOrders_btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            salesOrders_btn.FlatAppearance.BorderSize = 0;
            salesOrders_btn.FlatStyle = FlatStyle.Flat;
            salesOrders_btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            salesOrders_btn.ForeColor = Color.White;
            salesOrders_btn.Location = new Point(4, 349);
            salesOrders_btn.Name = "salesOrders_btn";
            salesOrders_btn.Size = new Size(303, 36);
            salesOrders_btn.TabIndex = 52;
            salesOrders_btn.Text = "            Sales Orders";
            salesOrders_btn.TextAlign = ContentAlignment.MiddleLeft;
            salesOrders_btn.UseVisualStyleBackColor = true;
            salesOrders_btn.Click += salesOrders_btn_Click;
            // 
            // inventory_btn
            // 
            inventory_btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            inventory_btn.FlatAppearance.BorderSize = 0;
            inventory_btn.FlatStyle = FlatStyle.Flat;
            inventory_btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            inventory_btn.ForeColor = Color.White;
            inventory_btn.Location = new Point(4, 270);
            inventory_btn.Name = "inventory_btn";
            inventory_btn.Size = new Size(303, 36);
            inventory_btn.TabIndex = 51;
            inventory_btn.Text = "            Inventory";
            inventory_btn.TextAlign = ContentAlignment.MiddleLeft;
            inventory_btn.UseVisualStyleBackColor = true;
            inventory_btn.Click += inventory_btn_Click;
            // 
            // home_btn
            // 
            home_btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            home_btn.FlatAppearance.BorderSize = 0;
            home_btn.FlatStyle = FlatStyle.Flat;
            home_btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            home_btn.ForeColor = Color.White;
            home_btn.Location = new Point(3, 195);
            home_btn.Name = "home_btn";
            home_btn.Size = new Size(304, 36);
            home_btn.TabIndex = 50;
            home_btn.Text = "            Home";
            home_btn.TextAlign = ContentAlignment.MiddleLeft;
            home_btn.UseVisualStyleBackColor = true;
            home_btn.Click += home_btn_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(4, 5);
            label1.Name = "label1";
            label1.Size = new Size(303, 30);
            label1.TabIndex = 0;
            label1.Text = "INVENTORY MANAGEMENT";
            // 
            // panel5
            // 
            panel5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel5.Controls.Add(comboBox2);
            panel5.Controls.Add(comboBox1);
            panel5.Controls.Add(flowLayoutPanel4);
            panel5.Controls.Add(search_textBox);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(0);
            panel5.Name = "panel5";
            panel5.Size = new Size(1054, 48);
            panel5.TabIndex = 4;
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            comboBox2.ForeColor = Color.FromArgb(0, 11, 71);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Year", "Month", "Week" });
            comboBox2.Location = new Point(482, 12);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(120, 23);
            comboBox2.TabIndex = 10;
            comboBox2.Text = "Filter";
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            comboBox1.ForeColor = Color.FromArgb(0, 11, 71);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Year", "Month", "Week" });
            comboBox1.Location = new Point(348, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(120, 23);
            comboBox1.TabIndex = 9;
            comboBox1.Text = "Sort";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel4.Controls.Add(orgName_label);
            flowLayoutPanel4.Controls.Add(notify_pictureBox);
            flowLayoutPanel4.Controls.Add(pictureBox1);
            flowLayoutPanel4.Dock = DockStyle.Right;
            flowLayoutPanel4.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel4.Location = new Point(737, 0);
            flowLayoutPanel4.Margin = new Padding(0);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Padding = new Padding(10, 5, 10, 0);
            flowLayoutPanel4.Size = new Size(317, 48);
            flowLayoutPanel4.TabIndex = 8;
            // 
            // orgName_label
            // 
            orgName_label.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            orgName_label.AutoSize = true;
            orgName_label.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            orgName_label.Location = new Point(223, 10);
            orgName_label.Margin = new Padding(3, 5, 3, 0);
            orgName_label.Name = "orgName_label";
            orgName_label.RightToLeft = RightToLeft.Yes;
            orgName_label.Size = new Size(71, 19);
            orgName_label.TabIndex = 2;
            orgName_label.Text = "C-SHARK";
            // 
            // search_textBox
            // 
            search_textBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            search_textBox.ForeColor = Color.FromArgb(0, 11, 71);
            search_textBox.Location = new Point(9, 12);
            search_textBox.Name = "search_textBox";
            search_textBox.PlaceholderText = "Search";
            search_textBox.Size = new Size(318, 23);
            search_textBox.TabIndex = 1;
            search_textBox.TextChanged += search_textBox_TextChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 50, 0, 0);
            panel1.Size = new Size(1054, 749);
            panel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox2.Controls.Add(purchaseOrders_dataGridView);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 147);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(5, 20, 5, 5);
            groupBox2.Size = new Size(1054, 602);
            groupBox2.TabIndex = 22;
            groupBox2.TabStop = false;
            groupBox2.Text = "Purchase List";
            // 
            // purchaseOrders_dataGridView
            // 
            purchaseOrders_dataGridView.AllowUserToAddRows = false;
            purchaseOrders_dataGridView.AllowUserToDeleteRows = false;
            purchaseOrders_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            purchaseOrders_dataGridView.BackgroundColor = Color.White;
            purchaseOrders_dataGridView.BorderStyle = BorderStyle.None;
            purchaseOrders_dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(0, 11, 71);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 93, 217);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            purchaseOrders_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            purchaseOrders_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(0, 11, 71);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(0, 93, 217);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            purchaseOrders_dataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            purchaseOrders_dataGridView.Dock = DockStyle.Fill;
            purchaseOrders_dataGridView.Location = new Point(5, 42);
            purchaseOrders_dataGridView.Name = "purchaseOrders_dataGridView";
            purchaseOrders_dataGridView.ReadOnly = true;
            purchaseOrders_dataGridView.RowHeadersVisible = false;
            purchaseOrders_dataGridView.RowHeadersWidth = 51;
            purchaseOrders_dataGridView.ScrollBars = ScrollBars.Horizontal;
            purchaseOrders_dataGridView.Size = new Size(1044, 555);
            purchaseOrders_dataGridView.TabIndex = 13;
            purchaseOrders_dataGridView.CellContentClick += purchaseOrders_dataGridView_CellContentClick;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.BackColor = Color.FromArgb(0, 11, 71);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 137);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(10);
            flowLayoutPanel1.Size = new Size(1054, 10);
            flowLayoutPanel1.TabIndex = 21;
            // 
            // groupBox1
            // 
            groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox1.Controls.Add(flowLayoutPanel2);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 50);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1054, 87);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "Summary";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(label5);
            flowLayoutPanel2.Controls.Add(label6);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(3, 25);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(0, 10, 0, 0);
            flowLayoutPanel2.Size = new Size(1048, 59);
            flowLayoutPanel2.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 10);
            label5.Margin = new Padding(21, 0, 10, 0);
            label5.Name = "label5";
            label5.Size = new Size(171, 21);
            label5.TabIndex = 2;
            label5.Text = "Your Total Purchases:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(202, 10);
            label6.Margin = new Padding(0, 0, 52, 0);
            label6.Name = "label6";
            label6.Size = new Size(19, 21);
            label6.TabIndex = 3;
            label6.Text = "0";
            label6.Click += label6_Click;
            // 
            // notify_pictureBox
            // 
            notify_pictureBox.BackColor = Color.Transparent;
            notify_pictureBox.Cursor = Cursors.Hand;
            notify_pictureBox.Image = Properties.Resources._2203538_alarm_bell_notification_ring_icon;
            notify_pictureBox.Location = new Point(170, 8);
            notify_pictureBox.Margin = new Padding(3, 3, 20, 3);
            notify_pictureBox.Name = "notify_pictureBox";
            notify_pictureBox.Size = new Size(30, 30);
            notify_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            notify_pictureBox.TabIndex = 6;
            notify_pictureBox.TabStop = false;
            notify_pictureBox.Click += notify_pictureBox_Click_1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.OliveDrab;
            pictureBox1.Location = new Point(154, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(10, 10);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // PurchaseOrders
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(1370, 749);
            Controls.Add(splitContainer1);
            ForeColor = Color.FromArgb(0, 11, 71);
            Name = "PurchaseOrders";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PurchaseOrders";
            Load += PurchaseOrders_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            panel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)purchaseOrders_dataGridView).EndInit();
            groupBox1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)notify_pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private SplitContainer splitContainer1;
        private PictureBox profile_pictureBox;
        private Panel panel3;
        private Panel panel4;
        private TableLayoutPanel tableLayoutPanel2;
        private Button button2;
        private Button button6;
        private PictureBox pictureBox7;
        private Panel panel6;
        private PictureBox pictureBox3;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox8;
        private Button purchaseOrders_btn;
        private Button salesOrders_btn;
        private Button inventory_btn;
        private Button home_btn;
        private Label label1;
        private Panel panel1;
        private GroupBox groupBox2;
        private DataGridView purchaseOrders_dataGridView;
        private GroupBox groupBox1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label5;
        private Label label6;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel5;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private FlowLayoutPanel flowLayoutPanel4;
        private Label orgName_label;
        private TextBox search_textBox;
        private PictureBox notify_pictureBox;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timercheckNotifications;
    }
}