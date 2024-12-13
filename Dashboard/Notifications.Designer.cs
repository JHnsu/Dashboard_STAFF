namespace Dashboard_STAFF
{
    partial class Notifications
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            notif_dataGridView = new DataGridView();
            timer2 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)notif_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(531, 598);
            panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(notif_dataGridView);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(0, 11, 71);
            groupBox1.Location = new Point(10, 10);
            groupBox1.Margin = new Padding(0);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(10);
            groupBox1.Size = new Size(511, 578);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Notifications";
            // 
            // notif_dataGridView
            // 
            notif_dataGridView.AllowUserToAddRows = false;
            notif_dataGridView.AllowUserToDeleteRows = false;
            notif_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            notif_dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            notif_dataGridView.BackgroundColor = Color.White;
            notif_dataGridView.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(0, 11, 71);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 93, 217);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            notif_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            notif_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(0, 11, 71);
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 93, 217);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            notif_dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            notif_dataGridView.Dock = DockStyle.Fill;
            notif_dataGridView.Location = new Point(10, 32);
            notif_dataGridView.Margin = new Padding(0);
            notif_dataGridView.Name = "notif_dataGridView";
            notif_dataGridView.ReadOnly = true;
            notif_dataGridView.RowHeadersVisible = false;
            notif_dataGridView.RowHeadersWidth = 51;
            notif_dataGridView.Size = new Size(491, 536);
            notif_dataGridView.TabIndex = 3;
            notif_dataGridView.CellContentClick += notif_dataGridView_CellContentClick;
            // 
            // timer2
            // 
            timer2.Interval = 10000;
            timer2.Tick += timer2_Tick;
            // 
            // Notifications
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(531, 598);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MaximumSize = new Size(552, 653);
            Name = "Notifications";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)notif_dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox1;
        private DataGridView notif_dataGridView;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}