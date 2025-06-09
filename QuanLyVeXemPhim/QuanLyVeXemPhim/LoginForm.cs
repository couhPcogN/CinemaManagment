using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyVeXemPhim
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true; // Ẩn mật khẩu ban đầu
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập Username và Password!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string userFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\DATA\User.csv"));

            if (!File.Exists(userFilePath))
            {
                MessageBox.Show("Không tìm thấy file User.csv!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var lines = File.ReadAllLines(userFilePath).Skip(1); // Bỏ dòng tiêu đề

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length >= 3)
                {
                    string fileUser = parts[0].Trim();
                    string filePass = parts[1].Trim();
                    string fileRole = parts[2].Trim();

                    if (username == fileUser && password == filePass)
                    {
                        MessageBox.Show($"Đăng nhập thành công!\nWelcome {fileRole.ToUpper()}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Gán vào biến toàn cục của Program.cs
                        Program.CurrentRole = fileRole.ToLower();

                        this.Close(); // Đóng form login
                        return;
                    }
                }
            }

            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.Show();
            this.Hide();
        }
    }
}
