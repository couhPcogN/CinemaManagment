using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVeXemPhim
{
    public partial class DoanhThuForm : Form
    {
        private readonly IDoanhThuManager doanhThuManager;

        public DoanhThuForm()
        {
            InitializeComponent();
            doanhThuManager = new DoanhThuManager(Path.Combine(Application.StartupPath, "invoices"));
            cmbLoaiThongKe.SelectedIndex = 0; // Chọn mặc định là By Day
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string loai = cmbLoaiThongKe.SelectedItem.ToString();
            DateTime ngayChon = dtpThoiGian.Value;

            List<HoaDon> hoaDons = new List<HoaDon>(); // danh sách hóa đơn đọc từ file
            if (loai == "By Day")
                hoaDons = doanhThuManager.LocTheoNgay(ngayChon);
            else if (loai == "By Month")
                hoaDons = doanhThuManager.LocTheoThang(ngayChon.Month, ngayChon.Year);
            else if (loai == "By Quarter")
            {
                int quy = (ngayChon.Month - 1) / 3 + 1;
                hoaDons = doanhThuManager.LocTheoQuy(quy, ngayChon.Year);
            }
            else if (loai == "By Year")
                hoaDons = doanhThuManager.LocTheoNam(ngayChon.Year);

            // chuyển từ HoaDon sang DoanhThu (nếu bạn vẫn dùng DoanhThu như một model riêng)
            List<DoanhThu> danhSach = hoaDons.Select(h => new DoanhThu
            {
                Ngay = h.NgayTao,
                SoVe = h.SoVe,
                SoCombo = h.SoCombo,
                TongTien = h.TongTien
            }).ToList();


            dgvDoanhThu.DataSource = danhSach.OrderByDescending(d => d.Ngay).ToList();

            lblValueTicket.Text = danhSach.Sum(x => x.SoVe).ToString();
            lblValueCombo.Text = danhSach.Sum(x => x.SoCombo).ToString();
            lblValueVisitor.Text = danhSach.Count.ToString();
            lblValueRevenue.Text = danhSach.Sum(x => x.TongTien).ToString("N0") + " VND";
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            
        }

    }
}
