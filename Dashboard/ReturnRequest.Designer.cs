namespace Dashboard_STAFF
{
    partial class ReturnRequest
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            label3 = new Label();
            comboBox3 = new ComboBox();
            label4 = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            comboBox2 = new ComboBox();
            label5 = new Label();
            numericUpDown1 = new NumericUpDown();
            label7 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(comboBox3);
            flowLayoutPanel1.Controls.Add(label4);
            flowLayoutPanel1.Controls.Add(comboBox1);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(comboBox2);
            flowLayoutPanel1.Controls.Add(label5);
            flowLayoutPanel1.Controls.Add(numericUpDown1);
            flowLayoutPanel1.Controls.Add(label7);
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(12, 26);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(20);
            flowLayoutPanel1.Size = new Size(629, 314);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(23, 20);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 0, 0, 15);
            label1.Size = new Size(248, 47);
            label1.TabIndex = 0;
            label1.Text = "Return Item Request";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 67);
            label3.Name = "label3";
            label3.Size = new Size(99, 25);
            label3.TabIndex = 3;
            label3.Text = "Serial No.:";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(23, 95);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(260, 33);
            comboBox3.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 131);
            label4.Name = "label4";
            label4.Size = new Size(111, 25);
            label4.TabIndex = 5;
            label4.Text = "Item Name:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(23, 159);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(260, 33);
            comboBox1.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 195);
            label2.Name = "label2";
            label2.Size = new Size(123, 25);
            label2.TabIndex = 14;
            label2.Text = "Brand Name:";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(23, 223);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(260, 33);
            comboBox2.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 259);
            label5.Name = "label5";
            label5.Size = new Size(155, 25);
            label5.TabIndex = 7;
            label5.Text = "Return Quantity:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(289, 23);
            numericUpDown1.Margin = new Padding(3, 3, 3, 15);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(84, 31);
            numericUpDown1.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(316, 111);
            label7.Margin = new Padding(30, 42, 3, 0);
            label7.Name = "label7";
            label7.Size = new Size(167, 25);
            label7.TabIndex = 19;
            label7.Text = "Reason for return:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(316, 139);
            textBox1.Margin = new Padding(30, 3, 3, 3);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(306, 137);
            textBox1.TabIndex = 17;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.ForeColor = Color.FromArgb(43, 42, 76);
            button1.Location = new Point(374, 368);
            button1.Name = "button1";
            button1.Size = new Size(260, 40);
            button1.TabIndex = 4;
            button1.Text = "SUBMIT";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ReturnRequest
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(43, 42, 76);
            ClientSize = new Size(653, 431);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button1);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ForeColor = Color.White;
            Name = "ReturnRequest";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReturnRequest";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label2;
        private ComboBox comboBox2;
        private Label label5;
        private NumericUpDown numericUpDown1;
        private Button button1;
        private ComboBox comboBox3;
        private ComboBox comboBox1;
        private Label label7;
        private TextBox textBox1;
    }
}