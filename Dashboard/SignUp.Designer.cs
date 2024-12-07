namespace Dashboard_STAFF
{
    partial class SignUp
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            checkBox1 = new CheckBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold);
            textBox1.Location = new Point(249, 297);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(429, 35);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold);
            textBox2.Location = new Point(810, 297);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(429, 35);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold);
            textBox3.Location = new Point(249, 455);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(429, 35);
            textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold);
            textBox4.Location = new Point(810, 616);
            textBox4.Name = "textBox4";
            textBox4.PasswordChar = '*';
            textBox4.Size = new Size(429, 35);
            textBox4.TabIndex = 3;
            // 
            // textBox5
            // 
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold);
            textBox5.Location = new Point(249, 616);
            textBox5.Name = "textBox5";
            textBox5.PasswordChar = '*';
            textBox5.Size = new Size(429, 35);
            textBox5.TabIndex = 4;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.FlatStyle = FlatStyle.Flat;
            checkBox1.Location = new Point(249, 692);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(157, 29);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Show Password";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Admin", "Staff" });
            comboBox1.Location = new Point(810, 455);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 36);
            comboBox1.TabIndex = 6;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkRed;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(622, 777);
            button1.Name = "button1";
            button1.Size = new Size(234, 43);
            button1.TabIndex = 7;
            button1.Text = "CREATE ACCOUNT";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(43, 42, 76);
            label1.Location = new Point(249, 260);
            label1.Name = "label1";
            label1.Size = new Size(96, 20);
            label1.TabIndex = 8;
            label1.Text = "First Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(43, 42, 76);
            label2.Location = new Point(810, 260);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 9;
            label2.Text = "Last Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(43, 42, 76);
            label3.Location = new Point(249, 420);
            label3.Name = "label3";
            label3.Size = new Size(124, 20);
            label3.TabIndex = 10;
            label3.Text = "Email Address";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(43, 42, 76);
            label4.Location = new Point(810, 420);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 11;
            label4.Text = "Role";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(43, 42, 76);
            label5.Location = new Point(249, 578);
            label5.Name = "label5";
            label5.Size = new Size(145, 20);
            label5.TabIndex = 12;
            label5.Text = "Create Password";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(43, 42, 76);
            label6.Location = new Point(810, 578);
            label6.Name = "label6";
            label6.Size = new Size(153, 20);
            label6.TabIndex = 13;
            label6.Text = "Confirm Password";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(43, 42, 76);
            label7.Location = new Point(486, 72);
            label7.Name = "label7";
            label7.Size = new Size(544, 108);
            label7.TabIndex = 14;
            label7.Text = "REGISTER";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.arrow;
            pictureBox1.Location = new Point(22, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(51, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 226, 222);
            ClientSize = new Size(1492, 869);
            ControlBox = false;
            Controls.Add(pictureBox1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(checkBox1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "SignUp";
            Text = "SignUp";
            Load += SignUp_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private CheckBox checkBox1;
        private ComboBox comboBox1;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private PictureBox pictureBox1;
    }
}