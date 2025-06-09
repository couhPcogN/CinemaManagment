namespace QuanLyVeXemPhim
{
    partial class DoanhThuForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbLoaiThongKe = new System.Windows.Forms.ComboBox();
            this.dtpThoiGian = new System.Windows.Forms.DateTimePicker();
            this.btnRevenue = new System.Windows.Forms.Button();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTong = new System.Windows.Forms.Label();
            this.lblSoVe = new System.Windows.Forms.Label();
            this.lblSoCombo = new System.Windows.Forms.Label();
            this.lblLuotKhach = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblValueTicket = new System.Windows.Forms.Label();
            this.lblValueCombo = new System.Windows.Forms.Label();
            this.lblValueVisitor = new System.Windows.Forms.Label();
            this.lblValueRevenue = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(383, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Revenue Over Time";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnRevenue);
            this.panel1.Controls.Add(this.dtpThoiGian);
            this.panel1.Controls.Add(this.cmbLoaiThongKe);
            this.panel1.Location = new System.Drawing.Point(0, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1045, 143);
            this.panel1.TabIndex = 1;
            // 
            // cmbLoaiThongKe
            // 
            this.cmbLoaiThongKe.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiThongKe.FormattingEnabled = true;
            this.cmbLoaiThongKe.Items.AddRange(new object[] {
            "By Day",
            "By Month",
            "By Quarter",
            "By Year"});
            this.cmbLoaiThongKe.Location = new System.Drawing.Point(275, 17);
            this.cmbLoaiThongKe.Name = "cmbLoaiThongKe";
            this.cmbLoaiThongKe.Size = new System.Drawing.Size(292, 43);
            this.cmbLoaiThongKe.TabIndex = 0;
            // 
            // dtpThoiGian
            // 
            this.dtpThoiGian.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpThoiGian.Location = new System.Drawing.Point(275, 87);
            this.dtpThoiGian.Name = "dtpThoiGian";
            this.dtpThoiGian.Size = new System.Drawing.Size(200, 41);
            this.dtpThoiGian.TabIndex = 1;
            // 
            // btnRevenue
            // 
            this.btnRevenue.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevenue.ForeColor = System.Drawing.Color.Black;
            this.btnRevenue.Location = new System.Drawing.Point(594, 87);
            this.btnRevenue.Name = "btnRevenue";
            this.btnRevenue.Size = new System.Drawing.Size(137, 41);
            this.btnRevenue.TabIndex = 2;
            this.btnRevenue.Text = "Revenue";
            this.btnRevenue.UseVisualStyleBackColor = true;
            this.btnRevenue.Click += new System.EventHandler(this.btnRevenue_Click);
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKetQua.Location = new System.Drawing.Point(445, 217);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(171, 35);
            this.lblKetQua.TabIndex = 2;
            this.lblKetQua.Text = "Results Table";
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.AllowUserToAddRows = false;
            this.dgvDoanhThu.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThu.Location = new System.Drawing.Point(144, 274);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.ReadOnly = true;
            this.dgvDoanhThu.RowHeadersWidth = 62;
            this.dgvDoanhThu.RowTemplate.Height = 28;
            this.dgvDoanhThu.Size = new System.Drawing.Size(747, 164);
            this.dgvDoanhThu.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 35);
            this.label2.TabIndex = 3;
            this.label2.Text = "Statistical Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(169, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 35);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time:";
            // 
            // lblTong
            // 
            this.lblTong.AutoSize = true;
            this.lblTong.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTong.Location = new System.Drawing.Point(12, 453);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(119, 31);
            this.lblTong.TabIndex = 4;
            this.lblTong.Text = "Summary:";
            this.lblTong.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblSoVe
            // 
            this.lblSoVe.AutoSize = true;
            this.lblSoVe.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoVe.Location = new System.Drawing.Point(90, 508);
            this.lblSoVe.Name = "lblSoVe";
            this.lblSoVe.Size = new System.Drawing.Size(182, 25);
            this.lblSoVe.TabIndex = 5;
            this.lblSoVe.Text = "Total Tickets Sold:";
            // 
            // lblSoCombo
            // 
            this.lblSoCombo.AutoSize = true;
            this.lblSoCombo.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoCombo.Location = new System.Drawing.Point(90, 545);
            this.lblSoCombo.Name = "lblSoCombo";
            this.lblSoCombo.Size = new System.Drawing.Size(172, 25);
            this.lblSoCombo.TabIndex = 6;
            this.lblSoCombo.Text = "Total Combo Sold:";
            this.lblSoCombo.Click += new System.EventHandler(this.label6_Click);
            // 
            // lblLuotKhach
            // 
            this.lblLuotKhach.AutoSize = true;
            this.lblLuotKhach.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLuotKhach.Location = new System.Drawing.Point(90, 584);
            this.lblLuotKhach.Name = "lblLuotKhach";
            this.lblLuotKhach.Size = new System.Drawing.Size(139, 25);
            this.lblLuotKhach.TabIndex = 7;
            this.lblLuotKhach.Text = "Total Visitors:";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.Location = new System.Drawing.Point(90, 620);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(142, 25);
            this.lblTongTien.TabIndex = 8;
            this.lblTongTien.Text = "Total Revenue:";
            // 
            // lblValueTicket
            // 
            this.lblValueTicket.AutoSize = true;
            this.lblValueTicket.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueTicket.Location = new System.Drawing.Point(325, 508);
            this.lblValueTicket.Name = "lblValueTicket";
            this.lblValueTicket.Size = new System.Drawing.Size(23, 25);
            this.lblValueTicket.TabIndex = 9;
            this.lblValueTicket.Text = "0";
            // 
            // lblValueCombo
            // 
            this.lblValueCombo.AutoSize = true;
            this.lblValueCombo.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueCombo.Location = new System.Drawing.Point(325, 545);
            this.lblValueCombo.Name = "lblValueCombo";
            this.lblValueCombo.Size = new System.Drawing.Size(23, 25);
            this.lblValueCombo.TabIndex = 9;
            this.lblValueCombo.Text = "0";
            // 
            // lblValueVisitor
            // 
            this.lblValueVisitor.AutoSize = true;
            this.lblValueVisitor.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueVisitor.Location = new System.Drawing.Point(325, 584);
            this.lblValueVisitor.Name = "lblValueVisitor";
            this.lblValueVisitor.Size = new System.Drawing.Size(23, 25);
            this.lblValueVisitor.TabIndex = 9;
            this.lblValueVisitor.Text = "0";
            // 
            // lblValueRevenue
            // 
            this.lblValueRevenue.AutoSize = true;
            this.lblValueRevenue.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueRevenue.Location = new System.Drawing.Point(325, 620);
            this.lblValueRevenue.Name = "lblValueRevenue";
            this.lblValueRevenue.Size = new System.Drawing.Size(23, 25);
            this.lblValueRevenue.TabIndex = 9;
            this.lblValueRevenue.Text = "0";
            // 
            // DoanhThuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1046, 670);
            this.Controls.Add(this.lblValueRevenue);
            this.Controls.Add(this.lblValueVisitor);
            this.Controls.Add(this.lblValueCombo);
            this.Controls.Add(this.lblValueTicket);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.lblLuotKhach);
            this.Controls.Add(this.lblSoCombo);
            this.Controls.Add(this.lblSoVe);
            this.Controls.Add(this.lblTong);
            this.Controls.Add(this.dgvDoanhThu);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DoanhThuForm";
            this.Text = "DoanhThuForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRevenue;
        private System.Windows.Forms.DateTimePicker dtpThoiGian;
        private System.Windows.Forms.ComboBox cmbLoaiThongKe;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Label lblSoVe;
        private System.Windows.Forms.Label lblSoCombo;
        private System.Windows.Forms.Label lblLuotKhach;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblValueTicket;
        private System.Windows.Forms.Label lblValueCombo;
        private System.Windows.Forms.Label lblValueVisitor;
        private System.Windows.Forms.Label lblValueRevenue;
    }
}