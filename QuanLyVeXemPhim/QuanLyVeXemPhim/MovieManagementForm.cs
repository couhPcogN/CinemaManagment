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
        private int movieCounter = 1;

        // Hàm tạo mã phim dạng P001, P002...
        private string GenerateMovieID()
        {
            return "P" + movieCounter++.ToString("D3");
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các ô nhập
            string movieID = txtMovieID.Text.Trim();
            string movieName = txtMovieName.Text.Trim();
            string genre = cmbGenre.Text;
            string duration = txtDuration.Text.Trim();
            string showDate = dtpShowDate.Value.ToShortDateString();
            string room = cmbRoom.Text;
            string showtime = cmbShowtime.Text;

            // Kiểm tra nhập thiếu
            if (string.IsNullOrEmpty(movieID) || string.IsNullOrEmpty(movieName) ||
                string.IsNullOrEmpty(genre) || string.IsNullOrEmpty(duration) ||
                string.IsNullOrEmpty(room) || string.IsNullOrEmpty(showtime))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin phim!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm dòng mới vào DataGridView
            dgvMovies.Rows.Add(movieID, movieName, genre, duration, showDate, room, showtime);

            // Xoá trắng form
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
            // ComboBox dữ liệu
            cmbGenre.Items.AddRange(new string[] { "Action", "Comedy", "Drama", "Horror", "Animation" });
            cmbRoom.Items.AddRange(new string[] { "Room 1", "Room 2", "Room 3" });
            cmbShowtime.Items.AddRange(new string[] { "10:00", "13:00", "15:30", "18:00", "20:00" });

            // Cột của DataGridView
            dgvMovies.ColumnCount = 7;
            dgvMovies.Columns[0].Name = "Movie ID";
            dgvMovies.Columns[1].Name = "Movie Name";
            dgvMovies.Columns[2].Name = "Genre";
            dgvMovies.Columns[3].Name = "Duration";
            dgvMovies.Columns[4].Name = "Show Date";
            dgvMovies.Columns[5].Name = "Room";
            dgvMovies.Columns[6].Name = "Showtime";
        }

        private void dgvMovies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMovies.Rows[e.RowIndex];

                txtMovieID.Text = row.Cells[0].Value.ToString(); // Movie ID
                txtMovieName.Text = row.Cells[1].Value.ToString();
                cmbGenre.Text = row.Cells[2].Value.ToString();
                txtDuration.Text = row.Cells[3].Value.ToString();
                dtpShowDate.Value = DateTime.Parse(row.Cells[4].Value.ToString());
                cmbRoom.Text = row.Cells[5].Value.ToString();
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
                txtMovieID.Text = GenerateMovieID(); // Reset lại mã phim nếu muốn thêm mới
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
                    txtMovieID.Text = GenerateMovieID();
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
            txtMovieID.Text = GenerateMovieID(); // Nếu bạn dùng tự sinh mã phim
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
    }
}
