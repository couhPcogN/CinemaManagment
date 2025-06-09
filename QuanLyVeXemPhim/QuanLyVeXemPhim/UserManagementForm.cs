using System;
using System.Collections.Generic;
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

            if (CurrentUserRole == "staff")
            {
                btnDelete.Visible = false;
                btnEdit.Visible = false;
            }

            LoadUsers();
            cmbRole.Items.AddRange(new string[] { "admin", "staff", "user" });
            cmbRole.SelectedIndex = 0;
        }

        private void LoadUsers()
        {
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = manager.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
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
            var user = new User(txtUsername.Text, txtPassword.Text, cmbRole.Text);
            manager.Edit(user);
            LoadUsers();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
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

    }
}
