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
        private int LayDiemTichLuyTuFile(string username)
        {
            string filePath = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"..\..\DATA\user.csv"));
            if (!File.Exists(filePath)) return 0;
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split(',');
                if (parts[0] == username)
                {
                    if (parts.Length > 3 && int.TryParse(parts[3], out int points))
                        return points;
                    else
                        return 0;
                }
            }
            return 0;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            Program.CurrentUserName = txtUsername.Text; // hoặc tên textbox chứa username
            Program.CurrentUserPoints = LayDiemTichLuyTuFile(txtUsername.Text); // Hàm này bạn tự viết để lấy điểm từ file user.csv

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập Username và Password!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string userFilePath = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"..\..\DATA\User.csv"));

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

        //private void btnRegister_Click_1(object sender, EventArgs e)
        //{
        //    LoginForm loginForm = new LoginForm();
        //    loginForm.Show();
        //    this.Hide();
        //}

        private void chkShowPassword_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void btnSignuphere(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
    }

        private void label2_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {

                Application.Exit();// Hiển thị lại form LoginForm
            }
        }
    }
}
