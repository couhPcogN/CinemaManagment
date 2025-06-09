using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVeXemPhim
{
    public interface IDoanhThuManager
    {
        List<HoaDon> LayTatCaHoaDon();
        List<HoaDon> LocTheoNgay(DateTime ngay);
        List<HoaDon> LocTheoThang(int thang, int nam);
        List<HoaDon> LocTheoQuy(int quy, int nam);
        List<HoaDon> LocTheoNam(int nam);
    }
}
