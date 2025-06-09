using System;
using System.IO;
using System.Windows.Forms;

namespace QuanLyVeXemPhim
{
    public partial class AdminDashboardForm : Form
    {
        private readonly IAdminDashboardManager dashboardManager;

        public AdminDashboardForm()
        {
            InitializeComponent();

            // Tạo đường dẫn đến các file dữ liệu
            string invoicePath = Path.Combine(Application.StartupPath, "invoices");
            string moviePath = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"..\..\DATA\movies.csv"));
            string userPath = Path.Combine(Application.StartupPath, "DATA", "User.csv");

            // Khởi tạo manager áp dụng OOP
            dashboardManager = new AdminDashboardManager(invoicePath, moviePath, userPath);

            // Load dữ liệu lên giao diện
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                lblValueTicketsSold.Text = dashboardManager.GetTotalTicketsSold().ToString();
                lblValueMoviesShowing.Text = dashboardManager.GetTotalMoviesShowing().ToString();
                lblValueUserCount.Text = dashboardManager.GetTotalUsers().ToString();
                lblValueRevenueToday.Text = dashboardManager.GetTotalRevenue().ToString("N0") + " VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu dashboard: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
