namespace Dashboard_STAFF
{
    partial class RestockRequest
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label3 = new Label();
            textBox2 = new TextBox();
            label5 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            panel2 = new Panel();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            inventory_dataGridView = new DataGridView();
            splitContainer1 = new SplitContainer();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            panel2.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inventory_dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 3);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 5;
            label3.Text = "Selected Item:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(7, 21);
            textBox2.Margin = new Padding(3, 3, 50, 15);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(295, 23);
            textBox2.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 59);
            label5.Name = "label5";
            label5.Size = new Size(107, 15);
            label5.TabIndex = 18;
            label5.Text = "Request Quantity:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(textBox2);
            flowLayoutPanel1.Controls.Add(label5);
            flowLayoutPanel1.Controls.Add(numericUpDown1);
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            flowLayoutPanel1.Location = new Point(7, 34);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(4, 3, 4, 3);
            flowLayoutPanel1.Size = new Size(312, 217);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(7, 77);
            numericUpDown1.Margin = new Padding(3, 3, 3, 15);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(152, 23);
            numericUpDown1.TabIndex = 23;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 115);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 24;
            label1.Text = "Total Price Per Item:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(7, 133);
            textBox1.Margin = new Padding(3, 3, 50, 15);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(295, 23);
            textBox1.TabIndex = 25;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 93, 217);
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(28, 20);
            button1.Name = "button1";
            button1.Size = new Size(256, 38);
            button1.TabIndex = 18;
            button1.Text = "SUBMIT";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            button1.MouseEnter += button1_MouseHover;
            button1.MouseLeave += button1_MouseLeave;
            button1.MouseHover += button1_MouseHover;
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(7, 251);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(28, 20, 28, 26);
            panel2.Size = new Size(312, 229);
            panel2.TabIndex = 4;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(panel2);
            groupBox2.Controls.Add(flowLayoutPanel1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.FlatStyle = FlatStyle.Flat;
            groupBox2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(11, 7);
            groupBox2.Margin = new Padding(0);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(7);
            groupBox2.Size = new Size(326, 487);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Restock Request Form";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(inventory_dataGridView);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(11, 7);
            groupBox1.Margin = new Padding(0);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(7);
            groupBox1.Size = new Size(802, 487);
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
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 93, 217);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            inventory_dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            inventory_dataGridView.Dock = DockStyle.Fill;
            inventory_dataGridView.Location = new Point(7, 34);
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
            dataGridViewCellStyle4.ForeColor = Color.Black;
            inventory_dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            inventory_dataGridView.ScrollBars = ScrollBars.Horizontal;
            inventory_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            inventory_dataGridView.Size = new Size(788, 446);
            inventory_dataGridView.TabIndex = 19;
            inventory_dataGridView.CellClick += inventory_dataGridView_CellClick;
            inventory_dataGridView.CellContentClick += inventory_dataGridView_CellContentClick;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1.Padding = new Padding(11, 7, 11, 10);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Panel2.Padding = new Padding(11, 7, 11, 10);
            splitContainer1.Size = new Size(1176, 504);
            splitContainer1.SplitterDistance = 824;
            splitContainer1.TabIndex = 3;
            // 
            // RestockRequest
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(0, 11, 71);
            ClientSize = new Size(1176, 504);
            Controls.Add(splitContainer1);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "RestockRequest";
            StartPosition = FormStartPosition.CenterScreen;
            Load += RestockRequest_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            panel2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)inventory_dataGridView).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private TextBox textBox2;
        private Label label5;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button1;
        private Panel panel2;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private SplitContainer splitContainer1;
        private DataGridView inventory_dataGridView;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private TextBox textBox1;
    }
}