// [CÁC using KHÔNG ĐỔI]
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyVeXemPhim
{
    public partial class PaymentForm : Form
    {
        public string BuyerName { get; set; } // Tên người mua (user hoặc staff)
        public int BuyerPoints { get; set; }  // Số điểm tích lũy hiện tại
        // Khai báo label thông tin phim
        private Label labelMovieName, lblMovieNameValue;
        private Label labelGenre, lblGenreValue;
        private Label labelDuration, lblDurationValue;
        private Label lblRoom, lblShowtime;

        private Label lblTitle, lblSelectedSeats, lblPopcorn, lblPepsi, lblCoca, lblSprite, lblFoodTotal, lblGrandTotal;
        private Label lblQtyPopcorn, lblQtyPepsi, lblQtyCoca, lblQtySprite, lblComboTotal, lblAllTotal;
        private Button btnBack, btnConfirm;
        private Form parentForm;
        private List<string> selectedSeats;
        private Dictionary<string, int> selectedFoods;

        public string SelectedMovieName { get; set; }
        public string SelectedGenre { get; set; }
        public string SelectedDuration { get; set; }
        public string SelectedRoom { get; set; }
        public string SelectedShowtime { get; set; }

        private Dictionary<string, int> seatPrices = new Dictionary<string, int>
        {
            {"Thường", 75000},
            {"VIP", 90000},
            {"Đôi", 120000}
        };

        private Dictionary<string, int> foodPrices = new Dictionary<string, int>
        {
            {"Popcorn", 50000},
            {"Pepsi", 20000},
            {"Coca", 20000},
            {"Sprite", 20000}
        };

        public PaymentForm(Form parent,List<string> seatNames, Dictionary<string, int> foodSelected)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(633, 567);
            this.BackColor = Color.HotPink;
            this.Font = new Font("Comic Sans MS", 10, FontStyle.Bold);
            this.StartPosition = FormStartPosition.CenterScreen;

            selectedSeats = seatNames;
            selectedFoods = foodSelected;
            parentForm = parent;

            InitializeUI();
            this.Load += PaymentForm_Load; // 👈 THÊM DÒNG NÀY
        }
        private void PaymentForm_Load(object sender, EventArgs e)
        {
            LoadPaymentInfo();
        }


        private void InitializeUI()
        {
            lblTitle = new Label()
            {
                Text = "PAYMENT",
                Font = new Font("Comic Sans MS", 16, FontStyle.Bold),
                ForeColor = Color.Aqua,
                Location = new Point(250, 20),
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            Button btnClose = new Button()
            {
                Text = "X",
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                BackColor = Color.White,
                ForeColor = Color.Black,
                Location = new Point(600, 5),
                Size = new Size(30, 30)
            };
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);

            // Thông tin phim
            int yInfo = 60;
            labelMovieName = new Label() { Text = "Movie Name:", Location = new Point(50, yInfo), AutoSize = true };
            lblMovieNameValue = new Label() { Location = new Point(170, yInfo), AutoSize = true };
            this.Controls.Add(labelMovieName); this.Controls.Add(lblMovieNameValue);

            labelGenre = new Label() { Text = "Genre:", Location = new Point(50, yInfo += 25), AutoSize = true };
            lblGenreValue = new Label() { Location = new Point(170, yInfo), AutoSize = true };
            this.Controls.Add(labelGenre); this.Controls.Add(lblGenreValue);

            labelDuration = new Label() { Text = "Duration:", Location = new Point(50, yInfo += 25), AutoSize = true };
            lblDurationValue = new Label() { Location = new Point(170, yInfo), AutoSize = true };
            this.Controls.Add(labelDuration); this.Controls.Add(lblDurationValue);

            lblRoom = new Label() { Text = "Room: " + SelectedRoom, Location = new Point(50, yInfo += 25), AutoSize = true };
            lblShowtime = new Label() { Text = "Showtime: " + SelectedShowtime, Location = new Point(50, yInfo += 25), AutoSize = true };
            this.Controls.Add(lblRoom); this.Controls.Add(lblShowtime);

            // Ghế
            lblSelectedSeats = new Label()
            {
                Text = "Selected Seat:",
                Location = new Point(50, yInfo += 30),
                ForeColor = Color.Black,
                AutoSize = true
            };
            this.Controls.Add(lblSelectedSeats);

            // Combo
            lblPopcorn = CreateFoodRow("Popcorn", yInfo += 30);
            lblPepsi = CreateFoodRow("Pepsi", yInfo += 50);
            lblCoca = CreateFoodRow("Coca", yInfo += 50);
            lblSprite = CreateFoodRow("Sprite", yInfo += 50);

            Label lblFoodText = new Label()
            {
                Text = "Total Combo:",
                Location = new Point(50, yInfo += 50),
                AutoSize = true
            };
            this.Controls.Add(lblFoodText);

            lblComboTotal = new Label()
            {
                Text = "0 VND",
                Location = new Point(170, yInfo),
                AutoSize = true
            };
            this.Controls.Add(lblComboTotal);

            Label lblTotalText = new Label()
            {
                Text = "Total:",
                Location = new Point(400, yInfo),
                Font = new Font("Comic Sans MS", 11, FontStyle.Bold),
                AutoSize = true
            };
            this.Controls.Add(lblTotalText);

            lblAllTotal = new Label()
            {
                Text = "0 VND",
                Location = new Point(470, yInfo),
                AutoSize = true
            };
            this.Controls.Add(lblAllTotal);

            btnBack = new Button()
            {
                Text = "BACK",
                Location = new Point(100, yInfo += 50),
                Size = new Size(120, 40),
                BackColor = Color.LightSkyBlue
            };
            btnBack.Click += BtnBack_Click;
            this.Controls.Add(btnBack);

            btnConfirm = new Button()
            {
                Text = "CONFIRM PAYMENT",
                Location = new Point(350, yInfo),
                Size = new Size(180, 40),
                BackColor = Color.LightSkyBlue
            };
            btnConfirm.Click += BtnConfirmPayment_Click;
            this.Controls.Add(btnConfirm);
        }

        private Label CreateFoodRow(string name, int y)
        {
            PictureBox pic = new PictureBox()
            {
                Location = new Point(50, y),
                Size = new Size(40, 40),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            string path = Path.Combine(Application.StartupPath, "images", name.ToLower() + ".png");
            if (File.Exists(path)) pic.Image = Image.FromFile(path);
            this.Controls.Add(pic);

            Label lblText = new Label()
            {
                Text = name + ":",
                Location = new Point(100, y + 10),
                AutoSize = true
            };
            this.Controls.Add(lblText);

            Label lblQty = new Label()
            {
                Name = $"lblQty{name}",
                Text = "x0",
                Location = new Point(180, y + 10),
                AutoSize = true
            };
            this.Controls.Add(lblQty);
            return lblQty;
        }

        private void LoadPaymentInfo()
        {
            lblMovieNameValue.Text = SelectedMovieName;
            lblGenreValue.Text = SelectedGenre;
            lblDurationValue.Text = SelectedDuration;
            lblRoom.Text = "Room: " + SelectedRoom;
            lblShowtime.Text = "Showtime: " + SelectedShowtime;

            lblSelectedSeats.Text = "Selected Seat: " + string.Join(", ", selectedSeats);

            int comboTotal = 0;
            foreach (var item in selectedFoods)
            {
                string key = item.Key;
                int qty = item.Value;
                comboTotal += qty * foodPrices[key];
                Controls[$"lblQty{key}"].Text = "x" + qty;
            }
            lblComboTotal.Text = comboTotal.ToString("N0") + " VND";

            int seatTotal = 0;
            foreach (string seat in selectedSeats)
            {
                string type = GetSeatType(seat);
                seatTotal += seatPrices[type];
            }
            int grandTotal = seatTotal + comboTotal;
            lblAllTotal.Text = grandTotal.ToString("N0") + " VND";
        }

        private string GetSeatType(string seat)
        {
            if ((seat.StartsWith("D") || seat.StartsWith("E") || seat.StartsWith("F")) &&
                int.TryParse(seat.Substring(1), out int num) && num >= 4 && num <= 8)
                return "VIP";
            if (seat.StartsWith("G")) return "Đôi";
            return "Thường";
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            FoodSelectionForm foodForm = new FoodSelectionForm(this, Program.SelectedSeatsGlobal);
            foodForm.ShowDialog();
            this.Hide();
        }
        private void SaveBookedSeats()
        {
            try
            {
                string filePath = Path.Combine(Application.StartupPath, "DATA", "booked_seats.csv");
                string directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                // Tạo header nếu file chưa tồn tại
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, "MovieName,ShowDate,Room,Seat,Showtime\n");
                }
                // Lưu các ghế đã chọn
                foreach (string seat in Program.SelectedSeatsGlobal)
                {
                    string line = $"{Program.SelectedMovieName}," +
                                $"{Program.SelectedShowDate}," +
                                $"{Program.SelectedRoom}," +
                                $"{seat}," +
                                $"{Program.SelectedShowtime}\n";
                    File.AppendAllText(filePath, line);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu danh sách ghế đã đặt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnConfirmPayment_Click(object sender, EventArgs e)
        {
            int totalSeat = selectedSeats.Sum(seat => seatPrices[GetSeatType(seat)]);
            int totalFood = selectedFoods.Sum(item => foodPrices[item.Key] * item.Value);
            int total = totalSeat + totalFood;

            // Tích lũy điểm
            int newPoints = BuyerPoints + 1;
            string khuyenMai = "";
            if (newPoints >= 3)
            {
                khuyenMai = "\n*** Chúc mừng! Bạn đã nhận được 1 ly Pepsi miễn phí! ***\n";
                newPoints = 0; // Reset điểm sau khi nhận quà
            }

            string invoice = "===== HÓA ĐƠN THANH TOÁN =====\n";
            invoice += $"Thời gian mua: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n";
            invoice += $"Người mua: {BuyerName}\n";
            invoice += $"Tên phim: {SelectedMovieName}\n";
            invoice += $"Thể loại: {SelectedGenre}\n";
            invoice += $"Thời lượng: {SelectedDuration}\n";
            invoice += $"Phòng chiếu: {SelectedRoom}\n";
            invoice += $"Suất chiếu: {SelectedShowtime}\n";
            invoice += $"Ghế đã chọn: {string.Join(", ", selectedSeats)}\n";
            invoice += $"Tiền ghế: {totalSeat.ToString("N0")} VND\n";
            invoice += $"Tiền combo: {totalFood.ToString("N0")} VND\n";
            invoice += $"TỔNG CỘNG: {total.ToString("N0")} VND\n";
            invoice += $"Điểm tích lũy hiện tại: {newPoints}/10\n";
            invoice += khuyenMai;
            invoice += "==============================";

            string invoiceDir = Path.Combine(Application.StartupPath, "invoices");
            if (!Directory.Exists(invoiceDir)) Directory.CreateDirectory(invoiceDir);

            string fileName = $"invoice_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string filePath = Path.Combine(invoiceDir, fileName);

            File.WriteAllText(filePath, invoice);
            SaveBookedSeats();

            // Cập nhật lại điểm tích lũy cho user hiện tại
            Program.CurrentUserPoints = newPoints;
            // Nếu muốn lưu vào file user.csv, bạn có thể gọi hàm cập nhật ở đây

            DialogResult result = MessageBox.Show("Thanh toán thành công!\nBạn có muốn in hóa đơn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) Process.Start("notepad.exe", filePath);

            this.Close();
        }
    }
}
