namespace Dashboard_STAFF
{
    partial class AddOrder_ADMIN
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
            label7 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox4 = new TextBox();
            button3 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            numericUpDown2 = new NumericUpDown();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label7.Location = new Point(40, 26);
            label7.Name = "label7";
            label7.Size = new Size(261, 54);
            label7.TabIndex = 20;
            label7.Text = "NEW ORDER";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(28, 10);
            label1.Name = "label1";
            label1.Size = new Size(108, 25);
            label1.TabIndex = 0;
            label1.Text = "Item name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(28, 89);
            label2.Name = "label2";
            label2.Size = new Size(68, 25);
            label2.TabIndex = 2;
            label2.Text = "Brand:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(28, 168);
            label3.Name = "label3";
            label3.Size = new Size(92, 25);
            label3.TabIndex = 4;
            label3.Text = "Quantity:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(28, 247);
            label4.Name = "label4";
            label4.Size = new Size(157, 25);
            label4.TabIndex = 6;
            label4.Text = "Receiver's Name:";
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 9F);
            textBox4.Location = new Point(28, 275);
            textBox4.Margin = new Padding(3, 3, 3, 20);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(446, 31);
            textBox4.TabIndex = 7;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button3.ForeColor = Color.FromArgb(43, 42, 76);
            button3.Location = new Point(140, 504);
            button3.Name = "button3";
            button3.Size = new Size(231, 34);
            button3.TabIndex = 19;
            button3.Text = "SUBMIT";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(textBox2);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(numericUpDown2);
            flowLayoutPanel1.Controls.Add(label4);
            flowLayoutPanel1.Controls.Add(textBox4);
            flowLayoutPanel1.Controls.Add(label5);
            flowLayoutPanel1.Controls.Add(dateTimePicker1);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Font = new Font("Segoe UI", 9F);
            flowLayoutPanel1.Location = new Point(12, 75);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(25, 10, 25, 3);
            flowLayoutPanel1.Size = new Size(524, 405);
            flowLayoutPanel1.TabIndex = 15;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(28, 196);
            numericUpDown2.Margin = new Padding(3, 3, 40, 20);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(96, 31);
            numericUpDown2.TabIndex = 10;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(28, 326);
            label5.Name = "label5";
            label5.Size = new Size(133, 25);
            label5.TabIndex = 12;
            label5.Text = "Delivery Date:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(28, 354);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 31);
            dateTimePicker1.TabIndex = 11;
            dateTimePicker1.Value = new DateTime(2024, 12, 3, 21, 38, 19, 0);
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 9F);
            textBox1.Location = new Point(28, 38);
            textBox1.Margin = new Padding(3, 3, 3, 20);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(446, 31);
            textBox1.TabIndex = 13;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 9F);
            textBox2.Location = new Point(28, 117);
            textBox2.Margin = new Padding(3, 3, 3, 20);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(446, 31);
            textBox2.TabIndex = 14;
            // 
            // AddOrder_ADMIN
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(43, 42, 76);
            ClientSize = new Size(553, 565);
            Controls.Add(label7);
            Controls.Add(button3);
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.White;
            Name = "AddOrder_ADMIN";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddOrder_ADMIN";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox4;
        private Button button3;
        private FlowLayoutPanel flowLayoutPanel1;
        private NumericUpDown numericUpDown2;
        private Label label5;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}