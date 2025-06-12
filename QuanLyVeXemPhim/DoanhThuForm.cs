using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyVeXemPhim
{
    public partial class DoanhThuForm : Form
    {
        private IDoanhThuManager doanhThuManager;

        public DoanhThuForm()
        {
            InitializeComponent();

            doanhThuManager = new DoanhThuManager(System.IO.Path.Combine(Application.StartupPath, "invoices")); // Đường dẫn thư mục chứa hóa đơn

            comboBoxStatType.Items.AddRange(new string[] { "Ngày", "Tháng", "Quý", "Năm" });
            comboBoxStatType.SelectedIndex = 0;

            dtpThoiGian.Format = DateTimePickerFormat.Custom;
            dtpThoiGian.CustomFormat = "dd/MM/yyyy";

            comboBoxStatType.SelectedIndexChanged += comboBoxStatType_SelectedIndexChanged;
            btnThongKe.Click += btnThongKe_Click;
        }

        private void comboBoxStatType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBoxStatType.SelectedItem.ToString();
            switch (selected)
            {
                case "Ngày":
                    dtpThoiGian.Format = DateTimePickerFormat.Custom;
                    dtpThoiGian.CustomFormat = "dd/MM/yyyy";
                    break;
                case "Tháng":
                    dtpThoiGian.Format = DateTimePickerFormat.Custom;
                    dtpThoiGian.CustomFormat = "MM/yyyy";
                    break;
                case "Quý":
                    dtpThoiGian.Format = DateTimePickerFormat.Custom;
                    dtpThoiGian.CustomFormat = "MM/yyyy";
                    break;
                case "Năm":
                    dtpThoiGian.Format = DateTimePickerFormat.Custom;
                    dtpThoiGian.CustomFormat = "yyyy";
                    break;
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string loai = comboBoxStatType.SelectedItem?.ToString();
            DateTime thoiGian = dtpThoiGian.Value;
            List<HoaDon> danhSach = new List<HoaDon>();

            switch (loai)
            {
                case "Ngày":
                    danhSach = doanhThuManager.LocTheoNgay(thoiGian);
                    break;
                case "Tháng":
                    danhSach = doanhThuManager.LocTheoThang(thoiGian.Month, thoiGian.Year);
                    break;
                case "Quý":
                    int quy = (thoiGian.Month - 1) / 3 + 1;
                    danhSach = doanhThuManager.LocTheoQuy(quy, thoiGian.Year);
                    break;
                case "Năm":
                    danhSach = doanhThuManager.LocTheoNam(thoiGian.Year);
                    break;
            }

            // Cập nhật bảng DataGridView
            dataGridViewResults.DataSource = danhSach.Select(h => new
            {
                Ngay = h.NgayTao.ToString("dd/MM/yyyy"),
                h.TenPhim,
                SoVe = h.SoVe,
                SoCombo = h.SoCombo,
                TongTien = h.TongTien.ToString("N0")
            }).ToList();

            // Tổng hợp doanh thu
            DoanhThu thongKe = new DoanhThu(danhSach);

            lblValueTicket.Text = thongKe.TongVe.ToString();
            lblValueCombo.Text = thongKe.TongCombo.ToString();
            lblValueVisitor.Text = thongKe.LuotKhach.ToString();
            lblValueRevenue.Text = thongKe.TongTien.ToString("N0");

            chartRevenu.Series.Clear();
            var series = chartRevenu.Series.Add("Doanh thu");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            if (loai == "Tháng")
            {
                var revenueByDay = danhSach
                    .GroupBy(hd => hd.NgayTao.Day)
                    .ToDictionary(g => g.Key, g => g.Sum(hd => hd.TongTien));
                int daysInMonth = DateTime.DaysInMonth(dtpThoiGian.Value.Year, dtpThoiGian.Value.Month);
                for (int day = 1; day <= daysInMonth; day++)
                {
                    decimal value = revenueByDay.ContainsKey(day) ? revenueByDay[day] : 0;
                    series.Points.AddXY($"Ngày {day}", value);
                }
            }
            else if (loai == "Năm")
            {
                var revenueByMonth = danhSach
                    .GroupBy(hd => hd.NgayTao.Month)
                    .ToDictionary(g => g.Key, g => g.Sum(hd => hd.TongTien));
                for (int month = 1; month <= 12; month++)
                {
                    decimal value = revenueByMonth.ContainsKey(month) ? revenueByMonth[month] : 0;
                    series.Points.AddXY($"Tháng {month}", value);
                }
            }
        }

        private void btnThongKe_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
