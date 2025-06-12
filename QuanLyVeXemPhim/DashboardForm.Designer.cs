namespace QuanLyVeXemPhim
{
    partial class DashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.labelMovieName = new System.Windows.Forms.Label();
            this.labelGenre = new System.Windows.Forms.Label();
            this.labelDuration = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.lblMovieNameValue = new System.Windows.Forms.Label();
            this.lblGenreValue = new System.Windows.Forms.Label();
            this.lblDurationValue = new System.Windows.Forms.Label();
            this.comboBoxRoom = new System.Windows.Forms.ComboBox();
            this.comboBoxShowtime = new System.Windows.Forms.ComboBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.lblShowtime = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.dtpShowDate = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSearch.Location = new System.Drawing.Point(458, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(617, 32);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 724);
            this.panel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightBlue;
            this.button2.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(12, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 50);
            this.button2.TabIndex = 5;
            this.button2.Text = "Welcome User";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.PowderBlue;
            this.btnLogout.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(12, 614);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(173, 48);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(49, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Movie Ticket";
            // 
            // picSearch
            // 
            this.picSearch.Image = ((System.Drawing.Image)(resources.GetObject("picSearch.Image")));
            this.picSearch.Location = new System.Drawing.Point(402, 7);
            this.picSearch.Name = "picSearch";
            this.picSearch.Size = new System.Drawing.Size(40, 40);
            this.picSearch.TabIndex = 3;
            this.picSearch.TabStop = false;
            this.picSearch.Click += new System.EventHandler(this.picSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Silver;
            this.dataGridView1.Location = new System.Drawing.Point(220, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(855, 671);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(1126, 22);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(150, 220);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // labelMovieName
            // 
            this.labelMovieName.AutoSize = true;
            this.labelMovieName.BackColor = System.Drawing.Color.LightBlue;
            this.labelMovieName.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMovieName.ForeColor = System.Drawing.Color.Black;
            this.labelMovieName.Location = new System.Drawing.Point(1095, 265);
            this.labelMovieName.Name = "labelMovieName";
            this.labelMovieName.Size = new System.Drawing.Size(141, 29);
            this.labelMovieName.TabIndex = 6;
            this.labelMovieName.Text = "Movie Name:";
            // 
            // labelGenre
            // 
            this.labelGenre.AutoSize = true;
            this.labelGenre.BackColor = System.Drawing.Color.LightBlue;
            this.labelGenre.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGenre.ForeColor = System.Drawing.Color.Black;
            this.labelGenre.Location = new System.Drawing.Point(1158, 310);
            this.labelGenre.Name = "labelGenre";
            this.labelGenre.Size = new System.Drawing.Size(78, 29);
            this.labelGenre.TabIndex = 7;
            this.labelGenre.Text = "Genre:";
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.BackColor = System.Drawing.Color.LightBlue;
            this.labelDuration.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDuration.ForeColor = System.Drawing.Color.Black;
            this.labelDuration.Location = new System.Drawing.Point(1133, 358);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(103, 29);
            this.labelDuration.TabIndex = 8;
            this.labelDuration.Text = "Duration:";
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.LightBlue;
            this.btnContinue.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.ForeColor = System.Drawing.Color.Black;
            this.btnContinue.Location = new System.Drawing.Point(1100, 551);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(334, 55);
            this.btnContinue.TabIndex = 10;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // lblMovieNameValue
            // 
            this.lblMovieNameValue.AutoSize = true;
            this.lblMovieNameValue.BackColor = System.Drawing.Color.LightBlue;
            this.lblMovieNameValue.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieNameValue.Location = new System.Drawing.Point(1274, 265);
            this.lblMovieNameValue.Name = "lblMovieNameValue";
            this.lblMovieNameValue.Size = new System.Drawing.Size(69, 29);
            this.lblMovieNameValue.TabIndex = 11;
            this.lblMovieNameValue.Text = "label3";
            // 
            // lblGenreValue
            // 
            this.lblGenreValue.AutoSize = true;
            this.lblGenreValue.BackColor = System.Drawing.Color.LightBlue;
            this.lblGenreValue.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenreValue.Location = new System.Drawing.Point(1275, 310);
            this.lblGenreValue.Name = "lblGenreValue";
            this.lblGenreValue.Size = new System.Drawing.Size(69, 29);
            this.lblGenreValue.TabIndex = 12;
            this.lblGenreValue.Text = "label4";
            this.lblGenreValue.Click += new System.EventHandler(this.lblGenreValue_Click);
            // 
            // lblDurationValue
            // 
            this.lblDurationValue.AutoSize = true;
            this.lblDurationValue.BackColor = System.Drawing.Color.LightBlue;
            this.lblDurationValue.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurationValue.Location = new System.Drawing.Point(1274, 358);
            this.lblDurationValue.Name = "lblDurationValue";
            this.lblDurationValue.Size = new System.Drawing.Size(69, 29);
            this.lblDurationValue.TabIndex = 13;
            this.lblDurationValue.Text = "label5";
            this.lblDurationValue.Click += new System.EventHandler(this.lblDurationValue_Click);
            // 
            // comboBoxRoom
            // 
            this.comboBoxRoom.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRoom.FormattingEnabled = true;
            this.comboBoxRoom.Items.AddRange(new object[] {
            "Phòng 1",
            "Phòng 2",
            "Phòng 3",
            "Phòng 4"});
            this.comboBoxRoom.Location = new System.Drawing.Point(1270, 403);
            this.comboBoxRoom.Name = "comboBoxRoom";
            this.comboBoxRoom.Size = new System.Drawing.Size(121, 37);
            this.comboBoxRoom.TabIndex = 15;
            // 
            // comboBoxShowtime
            // 
            this.comboBoxShowtime.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxShowtime.FormattingEnabled = true;
            this.comboBoxShowtime.Items.AddRange(new object[] {
            "09:00 – 11:00",
            "12:00 – 14:30",
            "15:00 – 17:00",
            "18:00 – 20:50",
            "21:00 – 23:10"});
            this.comboBoxShowtime.Location = new System.Drawing.Point(1270, 450);
            this.comboBoxShowtime.Name = "comboBoxShowtime";
            this.comboBoxShowtime.Size = new System.Drawing.Size(121, 37);
            this.comboBoxShowtime.TabIndex = 16;
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.BackColor = System.Drawing.Color.LightBlue;
            this.lblRoom.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoom.ForeColor = System.Drawing.Color.Black;
            this.lblRoom.Location = new System.Drawing.Point(1163, 403);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(73, 29);
            this.lblRoom.TabIndex = 17;
            this.lblRoom.Text = "Room:";
            // 
            // lblShowtime
            // 
            this.lblShowtime.AutoSize = true;
            this.lblShowtime.BackColor = System.Drawing.Color.LightBlue;
            this.lblShowtime.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowtime.ForeColor = System.Drawing.Color.Black;
            this.lblShowtime.Location = new System.Drawing.Point(1121, 450);
            this.lblShowtime.Name = "lblShowtime";
            this.lblShowtime.Size = new System.Drawing.Size(115, 29);
            this.lblShowtime.TabIndex = 18;
            this.lblShowtime.Text = "Showtime:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1451, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 40);
            this.button1.TabIndex = 19;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.LightBlue;
            this.btnback.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.Location = new System.Drawing.Point(1199, 626);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(173, 47);
            this.btnback.TabIndex = 20;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // dtpShowDate
            // 
            this.dtpShowDate.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpShowDate.CalendarTitleBackColor = System.Drawing.Color.LightBlue;
            this.dtpShowDate.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpShowDate.Location = new System.Drawing.Point(1117, 493);
            this.dtpShowDate.Name = "dtpShowDate";
            this.dtpShowDate.Size = new System.Drawing.Size(274, 35);
            this.dtpShowDate.TabIndex = 21;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1460, 724);
            this.Controls.Add(this.dtpShowDate);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblShowtime);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.comboBoxShowtime);
            this.Controls.Add(this.comboBoxRoom);
            this.Controls.Add(this.lblDurationValue);
            this.Controls.Add(this.lblGenreValue);
            this.Controls.Add(this.lblMovieNameValue);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.labelDuration);
            this.Controls.Add(this.labelGenre);
            this.Controls.Add(this.labelMovieName);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.picSearch);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashboardForm";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label labelMovieName;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label lblMovieNameValue;
        private System.Windows.Forms.Label lblGenreValue;
        private System.Windows.Forms.Label lblDurationValue;
        private System.Windows.Forms.ComboBox comboBoxRoom;
        private System.Windows.Forms.ComboBox comboBoxShowtime;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblShowtime;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.DateTimePicker dtpShowDate;
    }
}