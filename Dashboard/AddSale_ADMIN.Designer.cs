﻿namespace Dashboard_STAFF
{
    partial class AddSale_ADMIN
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            inventory_dataGridView = new DataGridView();
            ItemNo = new DataGridViewTextBoxColumn();
            ItemName = new DataGridViewTextBoxColumn();
            Brand = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            UnitPrice = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            panel2 = new Panel();
            button3 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            numericUpDown2 = new NumericUpDown();
            label4 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inventory_dataGridView).BeginInit();
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1.Padding = new Padding(15, 10, 15, 15);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Panel2.Padding = new Padding(15, 10, 15, 15);
            splitContainer1.Size = new Size(1176, 504);
            splitContainer1.SplitterDistance = 748;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(inventory_dataGridView);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(15, 10);
            groupBox1.Margin = new Padding(0);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(10);
            groupBox1.Size = new Size(718, 479);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Current Inventory";
            // 
            // inventory_dataGridView
            // 
            inventory_dataGridView.AllowUserToAddRows = false;
            inventory_dataGridView.AllowUserToDeleteRows = false;
            inventory_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            inventory_dataGridView.BackgroundColor = Color.White;
            inventory_dataGridView.BorderStyle = BorderStyle.None;
            inventory_dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(0, 11, 71);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 93, 217);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            inventory_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            inventory_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            inventory_dataGridView.Columns.AddRange(new DataGridViewColumn[] { ItemNo, ItemName, Brand, Quantity, UnitPrice });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 93, 217);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            inventory_dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            inventory_dataGridView.Dock = DockStyle.Fill;
            inventory_dataGridView.Location = new Point(10, 44);
            inventory_dataGridView.Name = "inventory_dataGridView";
            inventory_dataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(0, 11, 71);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 93, 217);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            inventory_dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            inventory_dataGridView.RowHeadersWidth = 51;
            inventory_dataGridView.ScrollBars = ScrollBars.Horizontal;
            inventory_dataGridView.Size = new Size(698, 425);
            inventory_dataGridView.TabIndex = 19;
            inventory_dataGridView.CellContentClick += inventory_dataGridView_CellContentClick;
            // 
            // ItemNo
            // 
            ItemNo.HeaderText = "Item No.";
            ItemNo.MinimumWidth = 6;
            ItemNo.Name = "ItemNo";
            ItemNo.ReadOnly = true;
            ItemNo.Visible = false;
            // 
            // ItemName
            // 
            ItemName.HeaderText = "Item Name";
            ItemName.MinimumWidth = 6;
            ItemName.Name = "ItemName";
            ItemName.ReadOnly = true;
            // 
            // Brand
            // 
            Brand.HeaderText = "Brand";
            Brand.MinimumWidth = 6;
            Brand.Name = "Brand";
            Brand.ReadOnly = true;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // UnitPrice
            // 
            UnitPrice.HeaderText = "Unit Price";
            UnitPrice.MinimumWidth = 6;
            UnitPrice.Name = "UnitPrice";
            UnitPrice.ReadOnly = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(panel2);
            groupBox2.Controls.Add(flowLayoutPanel1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.FlatStyle = FlatStyle.Flat;
            groupBox2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(15, 10);
            groupBox2.Margin = new Padding(0);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(10);
            groupBox2.Size = new Size(394, 479);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Order Form";
            // 
            // panel2
            // 
            panel2.Controls.Add(button3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(10, 331);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(40, 30, 40, 40);
            panel2.Size = new Size(374, 138);
            panel2.TabIndex = 4;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(0, 93, 217);
            button3.Dock = DockStyle.Top;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(40, 30);
            button3.Name = "button3";
            button3.Size = new Size(294, 37);
            button3.TabIndex = 18;
            button3.Text = "SUBMIT";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            button3.MouseEnter += button3_MouseHover;
            button3.MouseLeave += button3_MouseLeave;
            button3.MouseHover += button3_MouseHover;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(numericUpDown2);
            flowLayoutPanel1.Controls.Add(label4);
            flowLayoutPanel1.Controls.Add(textBox4);
            flowLayoutPanel1.Controls.Add(label5);
            flowLayoutPanel1.Controls.Add(dateTimePicker1);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            flowLayoutPanel1.Location = new Point(10, 44);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(5);
            flowLayoutPanel1.Size = new Size(374, 287);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(8, 5);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 14;
            label1.Text = "Selected Item:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 9F);
            textBox1.Location = new Point(8, 28);
            textBox1.Margin = new Padding(3, 3, 3, 20);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(359, 27);
            textBox1.TabIndex = 15;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(8, 75);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 16;
            label3.Text = "Quantity:";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(8, 98);
            numericUpDown2.Margin = new Padding(3, 3, 40, 20);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(108, 27);
            numericUpDown2.TabIndex = 17;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(8, 145);
            label4.Name = "label4";
            label4.Size = new Size(128, 20);
            label4.TabIndex = 18;
            label4.Text = "Receiver's Name:";
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 9F);
            textBox4.Location = new Point(8, 168);
            textBox4.Margin = new Padding(3, 3, 3, 20);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(359, 27);
            textBox4.TabIndex = 19;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(8, 215);
            label5.Name = "label5";
            label5.Size = new Size(108, 20);
            label5.TabIndex = 21;
            label5.Text = "Delivery Date:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(8, 238);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(359, 27);
            dateTimePicker1.TabIndex = 20;
            dateTimePicker1.Value = new DateTime(2024, 12, 8, 0, 0, 0, 0);
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // AddOrder_ADMIN
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(0, 11, 71);
            ClientSize = new Size(1176, 504);
            Controls.Add(splitContainer1);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "AddOrder_ADMIN";
            StartPosition = FormStartPosition.CenterScreen;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)inventory_dataGridView).EndInit();
            groupBox2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private DataGridView inventory_dataGridView;
        private GroupBox groupBox2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private TextBox textBox1;
        private Label label3;
        private NumericUpDown numericUpDown2;
        private DataGridViewTextBoxColumn ItemNo;
        private DataGridViewTextBoxColumn ItemName;
        private DataGridViewTextBoxColumn Brand;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn UnitPrice;
        private Label label4;
        private TextBox textBox4;
        private Label label5;
        private DateTimePicker dateTimePicker1;
        private Panel panel2;
        private Button button3;
    }
}