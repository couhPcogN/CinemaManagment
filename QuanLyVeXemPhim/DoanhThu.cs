using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyVeXemPhim
{
    public class DoanhThu
    {
        public int TongVe { get; set; }
        public int TongCombo { get; set; }
        public int LuotKhach { get; set; }
        public int TongTien { get; set; }

        public DoanhThu(List<HoaDon> danhSach)
        {
            TongVe = danhSach.Sum(h => h.SoVe);
            TongCombo = danhSach.Sum(h => h.SoCombo);
            LuotKhach = danhSach.Count;
            TongTien = danhSach.Sum(h => h.TongTien);
        }
    }
}
