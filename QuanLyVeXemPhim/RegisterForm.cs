using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVeXemPhim
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string username = textBox1.Text.Trim();
        //    string password = regPassword.Text.Trim();
        //    string confirmPassword = regcPassword.Text.Trim();

        //    string filePath = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"..\..\DATA\user.csv"));

        //    // Kiểm tra rỗng
        //    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
        //    {
        //        MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
        //        return;
        //    }

        //    // Kiểm tra khớp mật khẩu
        //    if (password != confirmPassword)
        //    {
        //        MessageBox.Show("Mật khẩu xác nhận không đúng!");
        //        return;
        //    }

        //    // Tạo file nếu chưa có
        //    if (!File.Exists(filePath))
        //    {
        //        File.WriteAllText(filePath, "username,password,role\n");
        //    }

        //    // Kiểm tra trùng username
        //    var lines = File.ReadAllLines(filePath);
        //    foreach (var line in lines.Skip(1)) // bỏ dòng tiêu đề
        //    {
        //        var parts = line.Split(',');
        //        if (parts.Length >= 1 && parts[0] == username)
        //        {
        //            MessageBox.Show("Tên người dùng đã tồn tại!");
        //            return;
        //        }
        //    }

        //    // Ghi vào file
        //    using (StreamWriter sw = File.AppendText(filePath))
        //    {
        //        sw.WriteLine($"{username},{password},user");
        //    }

        //    MessageBox.Show("Đăng ký thành công!");
        //    this.Close(); // quay lại login
        //}

        private void regShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            regPassword.PasswordChar = regShowPassword.Checked ? '\0' : '*';
            regcPassword.PasswordChar = regShowPassword.Checked ? '\0' : '*';
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSiginhere_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = regPassword.Text.Trim();
            string confirmPassword = regcPassword.Text.Trim();

            // Kiểm tra rỗng
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Kiểm tra khớp mật khẩu
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không đúng!");
                return;
            }

            // Sử dụng UserManager để thêm user
            var manager = new UserManager();
            var allUsers = manager.GetAll();
            if (allUsers.Any(u => u.Username == username))
            {
                MessageBox.Show("Tên người dùng đã tồn tại!");
                return;
            }

            var newUser = new User(username, password, "user");
            manager.Add(newUser);

            MessageBox.Show("Đăng ký thành công!");
            this.Close(); // quay lại login
        }
    }
    
}