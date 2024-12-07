namespace Dashboard_STAFF
{
    partial class LogInForm
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
            panel1 = new Panel();
            label4 = new Label();
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            label3 = new Label();
            button1 = new Button();
            checkBox1 = new CheckBox();
            textBox2 = new TextBox();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            textBox1 = new TextBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(238, 226, 222);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(linkLabel2);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(201, 110);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.MaximumSize = new Size(1090, 649);
            panel1.MinimumSize = new Size(1090, 649);
            panel1.Name = "panel1";
            panel1.Size = new Size(1090, 649);
            panel1.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Blue;
            label4.Location = new Point(262, 601);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 11;
            label4.Text = "New?";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(673, 601);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(138, 20);
            linkLabel2.TabIndex = 10;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Forgot Password?";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked_1;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.ForeColor = SystemColors.ControlText;
            linkLabel1.Location = new Point(316, 601);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(105, 20);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Register here";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(238, 226, 222);
            label3.Location = new Point(87, 603);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 8;
            label3.Text = "label3";
            // 
            // button1
            // 
            button1.BackColor = Color.DarkRed;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(457, 520);
            button1.Name = "button1";
            button1.Size = new Size(155, 41);
            button1.TabIndex = 1;
            button1.Text = "LOGIN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.FlatStyle = FlatStyle.Flat;
            checkBox1.Location = new Point(370, 463);
            checkBox1.Margin = new Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(142, 24);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Show password";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // textBox2
            // 
            textBox2.Cursor = Cursors.IBeam;
            textBox2.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold);
            textBox2.ForeColor = Color.DarkGray;
            textBox2.Location = new Point(370, 402);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(325, 35);
            textBox2.TabIndex = 5;
            textBox2.Text = "Enter Password";
            textBox2.Enter += textBox2_Enter;
            textBox2.Leave += textBox2_Leave;
            textBox2.Validating += textBox2_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(43, 42, 76);
            label2.Location = new Point(366, 375);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 6;
            label2.Text = "Password";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(238, 226, 222);
            pictureBox2.Image = Properties.Resources.wordpress_custom_login_page_form_330x220_removebg_preview11;
            pictureBox2.Location = new Point(475, 66);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(134, 149);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Cursor = Cursors.IBeam;
            textBox1.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold);
            textBox1.ForeColor = Color.DarkGray;
            textBox1.Location = new Point(370, 296);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(325, 35);
            textBox1.TabIndex = 3;
            textBox1.Text = "Enter Username";
            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textbox1_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(43, 42, 76);
            label1.Location = new Point(366, 269);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 4;
            label1.Text = "Username";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.image_removebg_preview;
            pictureBox1.Location = new Point(1436, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(44, 39);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_1;
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(43, 42, 76);
            ClientSize = new Size(1492, 869);
            ControlBox = false;
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Font = new Font("Microsoft Sans Serif", 8F);
            Margin = new Padding(3, 2, 3, 2);
            Name = "LogInForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            WindowState = FormWindowState.Minimized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBox1;
        private Label label1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button button1;
        private CheckBox checkBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private System.Windows.Forms.Timer timer1;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel1;
        private Label label4;
    }
}