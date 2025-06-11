using System;

namespace QuanLyVeXemPhim
{
    public interface IAdminDashboardManager
    {
        int GetTotalTicketsSold();
        int GetTotalMoviesShowing();
        int GetTotalUsers();
        int GetTotalRevenue();
    }
}

