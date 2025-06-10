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
    public partial class AdminForm : Form
    {
        private string currentRole; // Đặt ở đây là đúng

        public AdminForm(string role)
        {
            InitializeComponent();
            currentRole = role;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {

               LoginForm loginForm = new LoginForm();
                loginForm.Show(); // Hiển thị lại form LoginForm
                this.Hide(); // Ẩn form AdminForm
            }
        }
        private Form currentForm = null;

        private void LoadChildForm(Form childForm)
        {
            if (currentForm != null)
                currentForm.Close();

            currentForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(childForm);
            childForm.Show();
        }


        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadChildForm(new AdminDashboardForm());
        }
        //private void btnManageMovies_Click(object sender, EventArgs e)
        //{
        //    LoadChildForm(new MovieManagementForm());
        //    }
        //private void btnDoanhThu_Click(object sender, EventArgs e)
        //{
        //    LoadChildForm(new DoanhThuForm());
        //}

        private void panelMain_Click(object sender, EventArgs e)
        {

        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            LoadChildForm(new UserManagementForm(currentRole));
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            LoadChildForm(new DoanhThuForm());
        }

        private void btnManageMovies_Click_1(object sender, EventArgs e)
        {
            LoadChildForm(new MovieManagementForm());
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {

                Application.Exit();// Hiển thị lại form LoginForm
            }
        }

        private void btnBuyTickets_Click(object sender, EventArgs e)
        {
            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.ShowDialog();
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            DashboardForm dashboardForm = new DashboardForm("admin");
            dashboardForm.ShowDialog();
        }
    }
}

