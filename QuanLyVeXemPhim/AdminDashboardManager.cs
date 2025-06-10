using System;
using System.IO;
using System.Linq;

namespace QuanLyVeXemPhim
{
    public class AdminDashboardManager : IAdminDashboardManager
    {
        private readonly string invoiceDirectory;
        private readonly string movieFile;
        private readonly string userFile;

        public AdminDashboardManager(string invoiceDir, string movieFilePath, string userFilePath)
        {
            invoiceDirectory = invoiceDir;
            movieFile = movieFilePath;
            userFile = userFilePath;
        }

        public int GetTotalTicketsSold()
        {
            int total = 0;
            foreach (var file in Directory.GetFiles(invoiceDirectory, "*.txt"))
            {
                var lines = File.ReadAllLines(file);
                foreach (var line in lines)
                {
                    if (line.StartsWith("Ghế đã chọn:"))
                    {
                        string[] seats = line.Split(':')[1].Split(',');
                        total += seats.Length;
                        break;
                    }
                }
            }
            return total;
        }

        public int GetTotalMoviesShowing()
        {
            if (!File.Exists(movieFile)) return 0;
            return File.ReadAllLines(movieFile).Length - 1; // bỏ dòng tiêu đề CSV
        }

        public int GetTotalUsers()
        {
            if (!File.Exists(userFile)) return 0;
            return File.ReadAllLines(userFile).Length - 1; // bỏ dòng tiêu đề CSV
        }

        public int GetTotalRevenue()
        {
            int total = 0;
            foreach (var file in Directory.GetFiles(invoiceDirectory, "*.txt"))
            {
                var lines = File.ReadAllLines(file);
                foreach (var line in lines)
                {
                    if (line.StartsWith("TỔNG CỘNG:"))
                    {
                        string number = new string(line.Where(char.IsDigit).ToArray());
                        if (int.TryParse(number, out int money))
                        {
                            total += money;
                        }
                        break;
                    }
                }
            }
            return total;
        }
    }
}
