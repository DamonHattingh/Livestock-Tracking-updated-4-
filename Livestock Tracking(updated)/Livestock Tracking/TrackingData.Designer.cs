namespace Livestock_Tracking
{
    partial class TrackingData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrackingData));
            this.cbDatesList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.btnCows = new System.Windows.Forms.Button();
            this.btnHorse = new System.Windows.Forms.Button();
            this.btnSheep = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.controlBox = new System.Windows.Forms.Panel();
            this.btnMinimise = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvTrackingData = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSheep1 = new System.Windows.Forms.Button();
            this.btnHorses1 = new System.Windows.Forms.Button();
            this.btnCows1 = new System.Windows.Forms.Button();
            this.btnOverall = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel7.SuspendLayout();
            this.controlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackingData)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDatesList
            // 
            this.cbDatesList.ForeColor = System.Drawing.Color.Black;
            this.cbDatesList.FormattingEnabled = true;
            this.cbDatesList.Location = new System.Drawing.Point(512, 450);
            this.cbDatesList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDatesList.Name = "cbDatesList";
            this.cbDatesList.Size = new System.Drawing.Size(185, 24);
            this.cbDatesList.TabIndex = 8;
            this.cbDatesList.SelectedIndexChanged += new System.EventHandler(this.cbDatesList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(507, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Search by date";
            // 
            // btnViewAll
            // 
            this.btnViewAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnViewAll.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnViewAll.Location = new System.Drawing.Point(512, 491);
            this.btnViewAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(187, 37);
            this.btnViewAll.TabIndex = 10;
            this.btnViewAll.Text = "View all";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // btnCows
            // 
            this.btnCows.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCows.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCows.Location = new System.Drawing.Point(1033, 462);
            this.btnCows.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCows.Name = "btnCows";
            this.btnCows.Size = new System.Drawing.Size(115, 37);
            this.btnCows.TabIndex = 11;
            this.btnCows.Text = "Cows";
            this.btnCows.UseVisualStyleBackColor = true;
            this.btnCows.Click += new System.EventHandler(this.btnCows_Click);
            // 
            // btnHorse
            // 
            this.btnHorse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnHorse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnHorse.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnHorse.Location = new System.Drawing.Point(912, 462);
            this.btnHorse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHorse.Name = "btnHorse";
            this.btnHorse.Size = new System.Drawing.Size(115, 37);
            this.btnHorse.TabIndex = 12;
            this.btnHorse.Text = "Horses";
            this.btnHorse.UseVisualStyleBackColor = false;
            this.btnHorse.Click += new System.EventHandler(this.btnHorse_Click);
            // 
            // btnSheep
            // 
            this.btnSheep.BackColor = System.Drawing.Color.Orange;
            this.btnSheep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSheep.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSheep.Location = new System.Drawing.Point(791, 462);
            this.btnSheep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSheep.Name = "btnSheep";
            this.btnSheep.Size = new System.Drawing.Size(115, 37);
            this.btnSheep.TabIndex = 13;
            this.btnSheep.Text = "Sheeps";
            this.btnSheep.UseVisualStyleBackColor = false;
            this.btnSheep.Click += new System.EventHandler(this.btnSheep_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.controlBox);
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1200, 37);
            this.panel7.TabIndex = 14;
            // 
            // controlBox
            // 
            this.controlBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.controlBox.Controls.Add(this.btnMinimise);
            this.controlBox.Controls.Add(this.btnClose);
            this.controlBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlBox.Location = new System.Drawing.Point(1000, 0);
            this.controlBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.controlBox.Name = "controlBox";
            this.controlBox.Size = new System.Drawing.Size(200, 37);
            this.controlBox.TabIndex = 0;
            // 
            // btnMinimise
            // 
            this.btnMinimise.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnMinimise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimise.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMinimise.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimise.Image")));
            this.btnMinimise.Location = new System.Drawing.Point(108, 4);
            this.btnMinimise.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMinimise.Name = "btnMinimise";
            this.btnMinimise.Size = new System.Drawing.Size(40, 28);
            this.btnMinimise.TabIndex = 2;
            this.btnMinimise.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(155, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(37, 28);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvTrackingData
            // 
            this.dgvTrackingData.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvTrackingData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrackingData.GridColor = System.Drawing.Color.Teal;
            this.dgvTrackingData.Location = new System.Drawing.Point(717, 111);
            this.dgvTrackingData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTrackingData.Name = "dgvTrackingData";
            this.dgvTrackingData.RowHeadersWidth = 51;
            this.dgvTrackingData.RowTemplate.Height = 24;
            this.dgvTrackingData.Size = new System.Drawing.Size(431, 249);
            this.dgvTrackingData.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnSheep1);
            this.panel1.Controls.Add(this.btnHorses1);
            this.panel1.Controls.Add(this.btnCows1);
            this.panel1.Controls.Add(this.btnOverall);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 574);
            this.panel1.TabIndex = 15;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 510);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(273, 42);
            this.btnLogout.TabIndex = 20;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnSheep1
            // 
            this.btnSheep1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSheep1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSheep1.Location = new System.Drawing.Point(0, 366);
            this.btnSheep1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSheep1.Name = "btnSheep1";
            this.btnSheep1.Size = new System.Drawing.Size(273, 42);
            this.btnSheep1.TabIndex = 19;
            this.btnSheep1.Text = "Sheep";
            this.btnSheep1.UseVisualStyleBackColor = true;
            // 
            // btnHorses1
            // 
            this.btnHorses1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHorses1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHorses1.Location = new System.Drawing.Point(0, 318);
            this.btnHorses1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHorses1.Name = "btnHorses1";
            this.btnHorses1.Size = new System.Drawing.Size(273, 42);
            this.btnHorses1.TabIndex = 18;
            this.btnHorses1.Text = "Horses";
            this.btnHorses1.UseVisualStyleBackColor = true;
            // 
            // btnCows1
            // 
            this.btnCows1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCows1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCows1.Location = new System.Drawing.Point(0, 270);
            this.btnCows1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCows1.Name = "btnCows1";
            this.btnCows1.Size = new System.Drawing.Size(273, 42);
            this.btnCows1.TabIndex = 17;
            this.btnCows1.Text = "Cows";
            this.btnCows1.UseVisualStyleBackColor = true;
            // 
            // btnOverall
            // 
            this.btnOverall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOverall.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOverall.Location = new System.Drawing.Point(0, 222);
            this.btnOverall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOverall.Name = "btnOverall";
            this.btnOverall.Size = new System.Drawing.Size(273, 42);
            this.btnOverall.TabIndex = 16;
            this.btnOverall.Text = "Overall";
            this.btnOverall.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(56, 21);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 167);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // TrackingData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 574);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.btnSheep);
            this.Controls.Add(this.btnHorse);
            this.Controls.Add(this.btnCows);
            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDatesList);
            this.Controls.Add(this.dgvTrackingData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TrackingData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrackingData";
            this.Load += new System.EventHandler(this.TrackingData_Load);
            this.panel7.ResumeLayout(false);
            this.controlBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackingData)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbDatesList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Button btnCows;
        private System.Windows.Forms.Button btnHorse;
        private System.Windows.Forms.Button btnSheep;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel controlBox;
        private System.Windows.Forms.Button btnMinimise;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvTrackingData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnSheep1;
        private System.Windows.Forms.Button btnHorses1;
        private System.Windows.Forms.Button btnCows1;
        private System.Windows.Forms.Button btnOverall;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}