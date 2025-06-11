using System;

namespace QuanLyVeXemPhim
{
    public class HoaDon
    {
        public DateTime NgayTao { get; set; }
        public string TenPhim { get; set; }
        public int SoVe { get; set; }
        public int SoCombo { get; set; }
        public int TongTien { get; set; }

        public HoaDon(DateTime ngayTao, string tenPhim, int soVe, int soCombo, int tongTien)
        {
            NgayTao = ngayTao;
            TenPhim = tenPhim;
            SoVe = soVe;
            SoCombo = soCombo;
            TongTien = tongTien;
        }
    }
}
