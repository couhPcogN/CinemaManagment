using QuanLyVeXemPhim;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class DoanhThuManager : IDoanhThuManager
{
    private readonly string folderPath;

    public DoanhThuManager(string folderPath)
    {
        this.folderPath = folderPath;
    }

    public List<HoaDon> LayTatCaHoaDon()
    {
        var hoadons = new List<HoaDon>();
        var files = Directory.GetFiles(folderPath, "invoice_*.txt");

        foreach (var file in files)
        {
            var lines = File.ReadAllLines(file);
            try
            {
                DateTime ngayTao = File.GetCreationTime(file);
                string tenPhim = lines.FirstOrDefault(l => l.StartsWith("Tên phim:"))?.Split(':')[1].Trim();
                int soVe = lines.FirstOrDefault(l => l.StartsWith("Ghế đã chọn:"))?.Split(',').Length ?? 0;
                int tienCombo = ParseTien(lines.FirstOrDefault(l => l.StartsWith("Tiền combo:")));
                int tongTien = ParseTien(lines.FirstOrDefault(l => l.StartsWith("TỔNG CỘNG:")));

                hoadons.Add(new HoaDon(ngayTao, tenPhim, soVe, tienCombo > 0 ? 1 : 0, tongTien));
            }
            catch { continue; }
        }

        return hoadons;
    }

    private int ParseTien(string line)
    {
        if (string.IsNullOrEmpty(line)) return 0;
        var so = new string(line.Where(char.IsDigit).ToArray());
        return int.TryParse(so, out int result) ? result : 0;
    }

    public List<HoaDon> LocTheoNgay(DateTime ngay)
        => LayTatCaHoaDon().Where(h => h.NgayTao.Date == ngay.Date).ToList();

    public List<HoaDon> LocTheoThang(int thang, int nam)
        => LayTatCaHoaDon().Where(h => h.NgayTao.Month == thang && h.NgayTao.Year == nam).ToList();

    public List<HoaDon> LocTheoQuy(int quy, int nam)
    {
        return LayTatCaHoaDon().Where(h =>
        {
            int thang = h.NgayTao.Month;
            int quyHoaDon = (thang - 1) / 3 + 1;
            return quyHoaDon == quy && h.NgayTao.Year == nam;
        }).ToList();
    }

    public List<HoaDon> LocTheoNam(int nam)
        => LayTatCaHoaDon().Where(h => h.NgayTao.Year == nam).ToList();
}
