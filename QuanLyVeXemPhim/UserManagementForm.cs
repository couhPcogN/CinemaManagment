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
            this.Activated += UserManagementForm_Activated;
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
        private void UserManagementForm_Activated(object sender, EventArgs e)
        {
            LoadUsers(); // Tự reload khi quay lại form
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
            dgvUsers.AutoGenerateColumns = true;
            dgvUsers.DataSource = null;
            var allUsers = manager.GetAll();

            // Ẩn mật khẩu khi load dữ liệu
            foreach (var user in allUsers)
            {
                user.Password = new string('*', user.Password.Length);
            }

            if (CurrentUserRole == "staff")
            {
                dgvUsers.DataSource = allUsers.Where(u => u.Role == "user").ToList();
            }
            else
            {
                dgvUsers.DataSource = allUsers;
                if (!dgvUsers.Columns.Contains("Show Password"))
                {
                    var eyeColumn = new DataGridViewButtonColumn();
                    eyeColumn.Name = "Show Password";
                    eyeColumn.HeaderText = "Show Password";
                    eyeColumn.Text = "👁️";
                    eyeColumn.UseColumnTextForButtonValue = true;
                    dgvUsers.Columns.Add(eyeColumn);
                }
            }

            // Ẩn cột Points và Show Password ngay khi load
            if (dgvUsers.Columns.Contains("Points"))
            {
                dgvUsers.Columns["Points"].Visible = false;
            }
            if (dgvUsers.Columns.Contains("Show Password"))
            {
                dgvUsers.Columns["Show Password"].Visible = false;
            }
        }





        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ẩn cột Points và Show Password
            if (dgvUsers.Columns.Contains("Points"))
            {
                dgvUsers.Columns["Points"].Visible = false;
            }
            if (dgvUsers.Columns.Contains("Show Password"))
            {
                dgvUsers.Columns["Show Password"].Visible = false;
            }

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
                cmbRole.Text = row.Cells["Role"].Value.ToString();

                // Kiểm tra nếu người dùng nhấn vào cột "Show Password"
                if (dgvUsers.Columns.Contains("Show Password") &&
                    e.ColumnIndex == dgvUsers.Columns["Show Password"].Index)
                {
                    if (CurrentUserRole == "admin")
                    {
                        string originalPassword = manager.GetAll()
                            .FirstOrDefault(u => u.Username == txtUsername.Text)?.Password;

                        if (originalPassword != null)
                        {
                            txtPassword.Text = originalPassword;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhân viên không có quyền xem mật khẩu thực!");
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CurrentUserRole == "staff" && cmbRole.Text != "user")
            {
                MessageBox.Show("Staff chỉ được thêm user thường!");
                return;
            }

            var all = manager.GetAll();
            if (all.Any(u => u.Username == txtUsername.Text))
            {
                MessageBox.Show("Username đã tồn tại, hãy chọn tên khác!");
                return;
            }

            var user = new User(txtUsername.Text, txtPassword.Text, cmbRole.Text);
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

            var all = manager.GetAll();
            if (!all.Any(u => u.Username == txtUsername.Text))
            {
                MessageBox.Show("Không tìm thấy user để sửa!");
                return;
            }

            var user = new User(txtUsername.Text, txtPassword.Text, cmbRole.Text);
            manager.Edit(user);
            LoadUsers();
            ClearFields();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            var all = manager.GetAll();
            var user = all.FirstOrDefault(u => u.Username == txtUsername.Text);

            if (user == null)
            {
                MessageBox.Show("Không tìm thấy user để xóa!");
                return;
            }

            if (CurrentUserRole == "staff" && user.Role != "user")
            {
                MessageBox.Show("Staff chỉ được xóa user thường!");
                return;
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

        //private void dgvUsers_CellClick1(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
        //        txtUsername.Text = row.Cells["Username"].Value.ToString();
        //        txtPassword.Text = row.Cells["Password"].Value.ToString();
        //        cmbRole.Text = row.Cells["Role"].Value.ToString();

        //        // Nếu người dùng nhấn vào cột "Show Password"
        //        if (e.ColumnIndex == dgvUsers.Columns["Show Password"].Index)
        //        {
        //            // Kiểm tra nếu người dùng là Admin
        //            if (CurrentUserRole == "admin")
        //            {
        //                string originalPassword = manager.GetAll()
        //                    .FirstOrDefault(u => u.Username == txtUsername.Text)?.Password;

        //                // Hiển thị mật khẩu thực nếu có
        //                if (originalPassword != null)
        //                {
        //                    txtPassword.Text = originalPassword;
        //                }
        //            }
        //            else
        //            {
        //                // Nhân viên không thể xem mật khẩu thực
        //                MessageBox.Show("Nhân viên không có quyền xem mật khẩu thực!");
        //            }
        //        }

        //        // Nếu là Admin, ẩn cột Points
        //        if (Program.CurrentRole == "admin")
        //        {
        //            dgvUsers.Columns["Points"].Visible = false; // Ẩn cột Points
        //        }
        //        else
        //        {
        //            dgvUsers.Columns["Points"].Visible = true; // Hiển thị cột Points
        //        }
        //    }
        //}



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