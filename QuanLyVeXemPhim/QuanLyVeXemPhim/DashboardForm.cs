using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuanLyVeXemPhim
{
    public partial class DashboardForm : Form
    {
        public string CurrentRole { get; set; } = "user";
        public DashboardForm()
        {
            InitializeComponent();
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            this.Load += DashboardForm_Load;

        }
        private void LoadMoviesFromCSV()
        {
            string filePath = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"..\..\DATA\movies.csv"));

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File movies.csv không tồn tại!");
                return;
            }

            DataTable dt = new DataTable();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header.Trim());
                }

                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    dt.Rows.Add(rows);
                }
            }

            dataGridView1.DataSource = dt;
        }
        public DashboardForm(string role = "user")
        {
            InitializeComponent();
            this.CurrentRole = role;
            this.Load += DashboardForm_Load;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadMoviesFromCSV();
            string path = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"..\..\DATA\movies.csv"));

            if (!File.Exists(path))
            {
                MessageBox.Show("File movies.csv không tồn tại!");
                return;
            }
            if (CurrentRole != "user")
            {
                panel1.Visible = false; // hoặc panel1.Visible = false;
            }

            DataTable dt = new DataTable();
            string[] lines = File.ReadAllLines(path);
            if (lines.Length > 0)
            {
                // Thêm cột từ dòng đầu
                string firstLine = lines[0];
                string[] headerLabels = firstLine.Split(',');
                foreach (string headerWord in headerLabels)
                {
                    dt.Columns.Add(new DataColumn(headerWord.Trim()));  // Trim để xóa khoảng trắng dư
                }
                foreach (DataColumn col in dt.Columns)
                {
                    Console.WriteLine("Tên cột: [" + col.ColumnName + "]");
                }

                moviesTable = dt;
                dataGridView1.DataSource = moviesTable;
                // Thêm dữ liệu
                for (int r = 1; r < lines.Length; r++)
                {
                    string[] dataWords = lines[r].Split(',');
                    dt.Rows.Add(dataWords);
                }
                // Khởi tạo dữ liệu cho comboBoxRoom
                comboBoxRoom.Items.Clear();
                comboBoxRoom.Items.AddRange(new string[] { "Phòng 1", "Phòng 2", "Phòng 3", "Phòng 4" });
                comboBoxRoom.SelectedIndex = 0; // Chọn mặc định

                // Khởi tạo dữ liệu cho comboBoxShowtime
                comboBoxShowtime.Items.Clear();
                comboBoxShowtime.Items.AddRange(new string[]
                 {
                            "10:00 - 12:00",
                            "12:30 - 14:30",
                            "15:00 - 17:00",
                            "17:30 - 19:30",
                            "20:00 - 22:00"
                 });
                comboBoxShowtime.SelectedIndex = 0;


                dataGridView1.DataSource = dt;

                // ✨ Tuỳ chỉnh giao diện:
                dataGridView1.Font = new Font("Comic Sans MS", 10, FontStyle.Bold);
                dataGridView1.DefaultCellStyle.BackColor = Color.White;
                dataGridView1.DefaultCellStyle.ForeColor = Color.DeepSkyBlue;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Navy;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.DeepSkyBlue;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Comic Sans MS", 10, FontStyle.Bold);
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblGenreValue_Click(object sender, EventArgs e)
        {

        }

        private void lblDurationValue_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (row.Cells["ImagePath"] != null && row.Cells["ImagePath"].Value != null)
                {
                    string imagePath = row.Cells["ImagePath"].Value.ToString();
                    string fullPath = Path.Combine(Application.StartupPath, imagePath);

                    if (File.Exists(fullPath))
                    {
                        pictureBox4.Image = Image.FromFile(fullPath);
                        pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        pictureBox1.Image = null;
                        MessageBox.Show("Ảnh không tồn tại: " + fullPath);
                    }
                }

                lblMovieNameValue.Text = row.Cells["MovieName"].Value.ToString();
                lblGenreValue.Text = row.Cells["Genre"].Value.ToString();
                lblDurationValue.Text = row.Cells["Duration"].Value.ToString() + " phút";
              //  lblPriceValue.Text = row.Cells["Price"].Value.ToString() + " VND";
            }
        }

        private void picSearch_Click(object sender, EventArgs e)
        {
            SearchMovies();
        }
        private DataTable moviesTable;
        private void SearchMovies()
        {
            if (moviesTable == null) return;

            string keyword = txtSearch.Text.ToLower();

            DataView dv = moviesTable.DefaultView;
            if (string.IsNullOrWhiteSpace(keyword))
            {
                dv.RowFilter = ""; // Hiện tất cả
            }
            else
            {
                dv.RowFilter = $"MovieName LIKE '%{keyword}%'";
            }
            dataGridView1.DataSource = dv;
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchMovies(); // Gọi sự kiện tìm kiếm
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }


        private void txtSearch_KeyDown_1(object sender, KeyEventArgs e)
        {
            txtSearch_KeyDown(sender, e);

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            // Gán dữ liệu phim đang chọn vào biến toàn cục (Program)
            Program.SelectedMovieName = lblMovieNameValue.Text;
            Program.SelectedGenre = lblGenreValue.Text;
            Program.SelectedDuration = lblDurationValue.Text;
            Program.SelectedRoom = comboBoxRoom.SelectedItem?.ToString() ?? "";
            Program.SelectedShowtime = comboBoxShowtime.SelectedItem?.ToString() ?? "";

            // Ẩn form hiện tại
            this.Hide();

            // Mở form chọn ghế
            SeatSelectionForm seatForm = new SeatSelectionForm();
            seatForm.ShowDialog();

            // Sau khi chọn ghế xong, gán danh sách ghế mẫu vào (nếu có)
            if (Program.SelectedSeatsGlobal == null || Program.SelectedSeatsGlobal.Count == 0)
            {
                // Ví dụ mẫu (có thể bỏ nếu bạn đã truyền ghế từ SeatSelectionForm)
                Program.SelectedSeatsGlobal = new List<string> { "B03", "C05", "D06", "E04", "F05" };
            }

            // Mở form chọn bắp và nước
            FoodSelectionForm foodForm = new FoodSelectionForm(Program.SelectedSeatsGlobal);
            foodForm.ShowDialog();

            // Mở lại dashboard
            this.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {

                LoginForm loginForm = new LoginForm();
                loginForm.Show(); // Hiển thị lại form LoginForm
                this.Hide(); // Ẩn form 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {

                Application.Exit();// Hiển thị lại form LoginForm
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn DashboardForm

            // Mở lại AdminForm hoặc StaffForm tùy theo vai trò
            if (CurrentRole == "admin")
            {
                AdminForm adminForm = new AdminForm("admin");
                adminForm.ShowDialog();
            }
            else if (CurrentRole == "staff")
            {
                StaffForm staffForm = new StaffForm();
                staffForm.ShowDialog();
            }
            // Nếu là user thì có thể không cần quay lại

            this.Close(); // Đóng DashboardForm sau khi trở về trang chủ
        }
    }
}
