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

        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có muốn đăng xuất không?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Program.CurrentRole = string.Empty;
                this.Close();
            }
            // Nếu chọn No thì không làm gì cả
        }
    }
}
