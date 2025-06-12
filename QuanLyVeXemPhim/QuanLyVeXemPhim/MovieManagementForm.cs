using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; 

namespace QuanLyVeXemPhim
{
    public partial class MovieManagementForm : Form
    {
        public MovieManagementForm()
        {
            InitializeComponent();
        }

        private void lblRoom_Click(object sender, EventArgs e)
        {

        }
        // Biến đếm để sinh mã phim
        private void LoadMoviesFromCSV()
        {
            string filePath = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"..\..\DATA\movies_detail.csv"));
            if (!File.Exists(filePath))
                return;

            string[] lines = File.ReadAllLines(filePath);

            for (int i = 1; i < lines.Length; i++) // bỏ dòng tiêu đề
            {
                string[] values = lines[i].Split(',');

                if (values.Length == 7)
                {
                    string id = values[0];
                    string name = values[1];
                    string genre = values[2];
                    string duration = values[3];
                    string showDate = values[4];     // ✅ lấy ngày chiếu từ file
                    string room = values[5];
                    string showtime = values[6];

                    dgvMovies.Rows.Add(id, name, genre, duration, showDate, room, showtime);
                }
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            string movieID = txtMovieID.Text.Trim();
            string movieName = txtMovieName.Text.Trim();
            string genre = cmbGenre.Text;
            string duration = txtDuration.Text.Trim();
            string showDate = dtpShowDate.Value.ToShortDateString();
            string room = cmbRoom.Text;
            string showtime = cmbShowtime.Text;

            string imagePath = "noimages.jpg";  // Ảnh mặc định

            // Kiểm tra nhập liệu
            if (string.IsNullOrWhiteSpace(movieName) || string.IsNullOrWhiteSpace(genre) ||
                string.IsNullOrWhiteSpace(duration) || string.IsNullOrWhiteSpace(room) || string.IsNullOrWhiteSpace(showtime))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin phim!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(duration, out int dur) || dur < 30)
            {
                MessageBox.Show("Thời lượng phải là số nguyên ≥ 30 phút!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra trùng lịch chiếu
            if (IsShowtimeOverlapping(room, showDate, showtime, dur))
            {
                MessageBox.Show("Lịch chiếu bị trùng hoặc không đủ thời gian giãn cách 15 phút!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thêm vào DataGridView
            dgvMovies.Rows.Add(movieID, movieName, genre, dur.ToString(), showDate, room, showtime);

            try
            {
                // Đường dẫn tuyệt đối
                string baseDir = Path.Combine(Application.StartupPath, "DATA");
                string pathMovies = Path.Combine(baseDir, "movies.csv");
                string pathDetails = Path.Combine(baseDir, "movies_detail.csv");

                // Tạo thư mục nếu chưa có
                Directory.CreateDirectory(baseDir);

                // Kiểm tra và tạo file movies.csv nếu chưa tồn tại
                if (!File.Exists(pathMovies))
                {
                    string headerMovies = "MovieID,MovieName,Genre,Duration,ImagePath";
                    File.WriteAllText(pathMovies, headerMovies + Environment.NewLine);
                }

                // Kiểm tra và tạo file movies_detail.csv nếu chưa tồn tại
                if (!File.Exists(pathDetails))
                {
                    string headerDetails = "MovieID,MovieName,Genre,Duration,ShowDate,Room,Showtime";
                    File.WriteAllText(pathDetails, headerDetails + Environment.NewLine);
                }

                // Ghi vào movies.csv (5 cột)
                string[] rowBasic = { movieID, movieName, genre, dur.ToString(), imagePath };
                File.AppendAllText(pathMovies, string.Join(",", rowBasic) + Environment.NewLine);

                // Ghi vào movie_detail.csv (7 cột)
                string[] rowDetail = { movieID, movieName, genre, dur.ToString(), showDate, room, showtime };
                File.AppendAllText(pathDetails, string.Join(",", rowDetail) + Environment.NewLine);

                MessageBox.Show("Thêm phim thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ghi file: " + ex.Message + "\nĐường dẫn: " + Application.StartupPath, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ClearForm();
        }



        private void ClearForm()
        {
            txtMovieID.Clear();
            txtMovieName.Clear();
            cmbGenre.SelectedIndex = -1;
            txtDuration.Clear();
            cmbRoom.SelectedIndex = -1;
            cmbShowtime.SelectedIndex = -1;
            dtpShowDate.Value = DateTime.Today;
        }
        private void MovieManagementForm_Load(object sender, EventArgs e)
        {
            dgvMovies.Columns.Clear();

            //dgvMovies.Columns.Add("colID", "Movie ID");
            //dgvMovies.Columns.Add("colName", "Movie Name");
            //dgvMovies.Columns.Add("colGenre", "Genre");
            //dgvMovies.Columns.Add("colDuration", "Duration");
            //dgvMovies.Columns.Add("colDate", "Show Date");
            //dgvMovies.Columns.Add("colRoom", "Room");
            //dgvMovies.Columns.Add("colTime", "Showtime");

            //dgvMovies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvMovies.AllowUserToAddRows = false;
            //dgvMovies.ReadOnly = true;
            //dgvMovies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Cập nhật Font toàn diện
            Font bodyFont = new Font("Comic Sans MS", 12, FontStyle.Regular);
            Font headerFont = new Font("Comic Sans MS", 13, FontStyle.Bold);

            // Áp dụng cho tất cả cell trong bảng
            dgvMovies.DefaultCellStyle.Font = bodyFont;
            dgvMovies.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Áp dụng cho từng cột riêng lẻ
            foreach (DataGridViewColumn col in dgvMovies.Columns)
            {
                col.DefaultCellStyle.Font = bodyFont;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                col.HeaderCell.Style.Font = headerFont;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Header toàn bảng
            dgvMovies.ColumnHeadersDefaultCellStyle.Font = headerFont;
            dgvMovies.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Load dữ liệu
            LoadMoviesFromCSV();

            // Đảm bảo hiển thị
            dgvMovies.Refresh();
        }

        private void dgvMovies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMovies.Rows[e.RowIndex];

                // Kiểm tra dữ liệu hợp lệ
                if (row.Cells[0].Value != null)
                    txtMovieID.Text = row.Cells[0].Value.ToString();

                if (row.Cells[1].Value != null)
                    txtMovieName.Text = row.Cells[1].Value.ToString();

                if (row.Cells[2].Value != null)
                    cmbGenre.Text = row.Cells[2].Value.ToString();

                if (row.Cells[3].Value != null)
                    txtDuration.Text = row.Cells[3].Value.ToString();

                if (row.Cells[4].Value != null)
                {
                    if (DateTime.TryParse(row.Cells[4].Value.ToString(), out DateTime date))
                        dtpShowDate.Value = date;
                }

                if (row.Cells[5].Value != null)
                    cmbRoom.Text = row.Cells[5].Value.ToString();

                if (row.Cells[6].Value != null)
                    cmbShowtime.Text = row.Cells[6].Value.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMovies.CurrentRow != null)
            {
                string movieName = txtMovieName.Text.Trim();
                string genre = cmbGenre.Text;
                string duration = txtDuration.Text.Trim();
                string showDate = dtpShowDate.Value.ToShortDateString();
                string room = cmbRoom.Text;
                string showtime = cmbShowtime.Text;

                // Kiểm tra đầu vào
                if (string.IsNullOrEmpty(movieName) || string.IsNullOrEmpty(genre) ||
                    string.IsNullOrEmpty(duration) || string.IsNullOrEmpty(room) || string.IsNullOrEmpty(showtime))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                    return;
                }

                if (!int.TryParse(duration, out int dur) || dur < 30)
                {
                    MessageBox.Show("Thời lượng phải là số ≥ 30 phút!", "Lỗi");
                    return;
                }

                // Cập nhật dòng đang chọn
                dgvMovies.CurrentRow.Cells[1].Value = movieName;
                dgvMovies.CurrentRow.Cells[2].Value = genre;
                dgvMovies.CurrentRow.Cells[3].Value = dur;
                dgvMovies.CurrentRow.Cells[4].Value = showDate;
                dgvMovies.CurrentRow.Cells[5].Value = room;
                dgvMovies.CurrentRow.Cells[6].Value = showtime;

                MessageBox.Show("Cập nhật thành công!", "Thông báo");

                ClearForm();
             //   txtMovieID.Text = GenerateMovieID(); // Reset lại mã phim nếu muốn thêm mới
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMovies.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xoá phim này không?",
                    "Xác nhận xoá",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dgvMovies.Rows.RemoveAt(dgvMovies.CurrentRow.Index);
                    ClearForm();

                    // Sinh lại mã mới cho việc thêm tiếp theo nếu cần
                //    txtMovieID.Text = GenerateMovieID();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
         //   txtMovieID.Text = GenerateMovieID(); // Nếu bạn dùng tự sinh mã phim
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblMovieID_Click(object sender, EventArgs e)
        {

        }

        private void lblMovieName_Click(object sender, EventArgs e)
        {

        }

        private void lblGenre_Click(object sender, EventArgs e)
        {

        }

        private void lblDuration_Click(object sender, EventArgs e)
        {

        }

        private void lblShowDate_Click(object sender, EventArgs e)
        {

        }

        private void txtMovieID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMovieName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDuration_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbGenre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpShowDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbShowtime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // ... existing code ...

        private bool IsShowtimeOverlapping(string room, string showDate, string newShowtime, int duration)
        {
            try
            {
                // Parse the new showtime
                string[] timeParts = newShowtime.Split('-');
                if (timeParts.Length != 2) return false;

                DateTime newStartTime = DateTime.Parse(timeParts[0].Trim());
                DateTime newEndTime = DateTime.Parse(timeParts[1].Trim());

                // Add 15 minutes buffer
                newStartTime = newStartTime.AddMinutes(15);
                newEndTime = newEndTime.AddMinutes(-15);

                // Check against existing showtimes in the same room and date
                foreach (DataGridViewRow row in dgvMovies.Rows)
                {
                    if (row.Cells[5].Value?.ToString() == room && // Room matches
                        row.Cells[4].Value?.ToString() == showDate) // Date matches
                    {
                        string existingShowtime = row.Cells[6].Value?.ToString();
                        if (string.IsNullOrEmpty(existingShowtime)) continue;

                        string[] existingTimeParts = existingShowtime.Split('-');
                        if (existingTimeParts.Length != 2) continue;

                        DateTime existingStartTime = DateTime.Parse(existingTimeParts[0].Trim());
                        DateTime existingEndTime = DateTime.Parse(existingTimeParts[1].Trim());

                        // Add 15 minutes buffer to existing showtime
                        existingStartTime = existingStartTime.AddMinutes(15);
                        existingEndTime = existingEndTime.AddMinutes(-15);

                        // Check for overlap
                        if ((newStartTime >= existingStartTime && newStartTime < existingEndTime) ||
                            (newEndTime > existingStartTime && newEndTime <= existingEndTime) ||
                            (newStartTime <= existingStartTime && newEndTime >= existingEndTime))
                        {
                            return true; // Overlapping found
                        }
                    }
                }
                return false; // No overlap found
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra trùng lịch chiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Return true to prevent adding in case of error
            }
        }

        // ... existing code ...
    }
}

