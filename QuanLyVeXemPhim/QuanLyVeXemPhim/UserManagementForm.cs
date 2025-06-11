using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyVeXemPhim
{
    public partial class UserManagementForm : Form
    {
        private readonly UserManager manager = new UserManager();
        private string CurrentUserRole;

        public UserManagementForm(string role)
        {
            InitializeComponent();
            CurrentUserRole = role;
            btnClose.Visible = (CurrentUserRole == "staff");
            btnBack.Visible = (CurrentUserRole == "staff");
            // Đặt font cho toàn bộ form và control
            this.Font = new Font("Comic Sans MS", 8, FontStyle.Bold);
            SetAllControlsFont(this.Controls, this.Font);

            if (CurrentUserRole == "staff")
            {
                this.Font = new Font("Comic Sans MS", 8, FontStyle.Bold);
                SetAllControlsFont(this.Controls, this.Font);

                cmbRole.Items.Clear();
                cmbRole.Items.Add("user");
                cmbRole.SelectedIndex = 0;
               
            }
            else
            {
                // Admin giữ nguyên giao diện, font, kích thước
                cmbRole.Items.AddRange(new string[] { "admin", "staff", "user" });
                cmbRole.SelectedIndex = 0;
                this.Size = new Size(1046, 670); // Đặt lại size như cũ nếu cần
            }


            LoadUsers();
        }

        private void SetAllControlsFont(Control.ControlCollection controls, Font font)
        {
            foreach (Control c in controls)
            {
                c.Font = font;
                if (c.HasChildren)
                    SetAllControlsFont(c.Controls, font);
            }
        }

        private void LoadUsers()
        {
            dgvUsers.DataSource = null;
            var allUsers = manager.GetAll();
            if (CurrentUserRole == "staff")
            {
                // Staff chỉ xem được user thường
                dgvUsers.DataSource = allUsers.Where(u => u.Role == "user").ToList();
            }
            else
            {
                dgvUsers.DataSource = allUsers;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CurrentUserRole == "staff" && cmbRole.Text != "user")
            {
                MessageBox.Show("Staff chỉ được thêm user thường!");
                return;
            }

            var user = new User(txtUsername.Text, txtPassword.Text, cmbRole.Text);
            var all = manager.GetAll();
            if (all.Any(u => u.Username == txtUsername.Text))
            {
                MessageBox.Show("Username đã tồn tại, hãy chọn tên khác!");
                return;
            }

            manager.Add(user);
            LoadUsers();
            ClearFields();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CurrentUserRole == "staff" && cmbRole.Text != "user")
            {
                MessageBox.Show("Staff chỉ được sửa user thường!");
                return;
            }

            var user = new User(txtUsername.Text, txtPassword.Text, cmbRole.Text);
            manager.Edit(user);
            LoadUsers();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CurrentUserRole == "staff")
            {
                var all = manager.GetAll();
                var user = all.FirstOrDefault(u => u.Username == txtUsername.Text);
                if (user == null || user.Role != "user")
                {
                    MessageBox.Show("Staff chỉ được xóa user thường!");
                    return;
                }
            }

            manager.Delete(txtUsername.Text);
            LoadUsers();
            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = 0;
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
                cmbRole.Text = row.Cells["Role"].Value.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower();
            var allUsers = manager.GetAll();

            if (CurrentUserRole == "staff")
            {
                allUsers = allUsers.Where(u => u.Role == "user").ToList();
            }

            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = allUsers;
            }
            else
            {
                var filtered = allUsers
                    .Where(u => u.Username.ToLower().Contains(keyword))
                    .ToList();

                dgvUsers.DataSource = null;
                dgvUsers.DataSource = filtered;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}