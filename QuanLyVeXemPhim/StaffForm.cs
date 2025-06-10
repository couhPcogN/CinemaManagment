using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVeXemPhim
{
    public partial class StaffForm : Form
    {
        public class Staff : Account
        {
            // Có thể thêm thuộc tính riêng cho staff nếu cần
            public Staff(string username, string password)
                : base(username, password, "staff") { }
        }
        public StaffForm()
        {
            InitializeComponent();
        }

        private void btnManageUsersStaff_Click(object sender, EventArgs e)
        {
            UserManagementForm userForm = new UserManagementForm("staff");
            userForm.ShowDialog();
        }

        private void btnBuyTickets_Click(object sender, EventArgs e)
        {
            DashboardForm dashboardForm = new DashboardForm("staff");
            dashboardForm.ShowDialog();
        }
    }
}
