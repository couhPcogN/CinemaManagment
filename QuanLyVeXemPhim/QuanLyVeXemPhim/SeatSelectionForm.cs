// SeatSelectionForm.cs (cập nhật logic hàng VIP ở giữa, ghế đôi ở G, và chỉ định ghế đã đặt bất kỳ)
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyVeXemPhim
{
    public partial class SeatSelectionForm : Form
    {
        private bool isFoodFormOpened = false;

        private List<Button> selectedSeats = new List<Button>();
        private Dictionary<string, string> seatTypes = new Dictionary<string, string>();
        private List<string> bookedSeats = new List<string> { "B03", "C05", "D06", "E04", "F05" }; // đã đặt

        private readonly Dictionary<string, int> seatPrices = new Dictionary<string, int>()
        {
            { "Thường", 75000 },
            { "VIP", 90000 },
            { "Đôi", 120000 }
        };

        private Panel panelSeats;
        private Label lblTotal;
        private Button btnBack, btnContinue;

        public SeatSelectionForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(991, 624);
            this.BackColor = Color.Black;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            InitializeControls();
            GenerateSeats();
        }

        private void InitializeControls()
        {
            panelSeats = new Panel()
            {
                Location = new Point(50, 40),
                Size = new Size(900, 400),
                BackColor = Color.Black,
                AutoScroll = false
            };
            this.Controls.Add(panelSeats);

            lblTotal = new Label()
            {
                Text = "Tạm tính: 0 VND",
                ForeColor = Color.Cyan,
                Location = new Point(420, 460),
                AutoSize = true,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold)
            };
            this.Controls.Add(lblTotal);

            btnBack = new Button()
            {
                Text = "BACK",
                Location = new Point(50, 560),
                Size = new Size(100, 40),
                BackColor = Color.MediumOrchid,
                ForeColor = Color.White,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold)
            };
            btnBack.Click += (s, e) => this.Close();
            this.Controls.Add(btnBack);

            btnContinue = new Button()
            {
                Text = "CONTINUE",
                Location = new Point(820, 560),
                Size = new Size(120, 40),
                BackColor = Color.HotPink,
                ForeColor = Color.White,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold)
            };
            btnContinue.Click += BtnContinue_Click;
            this.Controls.Add(btnContinue);

            AddColorLegend(200, 510, Color.Gray, "Ghế đã đặt");
            AddColorLegend(350, 510, Color.LightSkyBlue, "Ghế bạn chọn");
            AddColorLegend(520, 510, Color.DarkViolet, "Ghế thường");
            AddColorLegend(670, 510, Color.Red, "Ghế VIP");
            AddColorLegend(790, 510, Color.HotPink, "Ghế đôi");
        }

        private void AddColorLegend(int x, int y, Color color, string label)
        {
            Panel colorBox = new Panel()
            {
                Location = new Point(x, y),
                Size = new Size(20, 20),
                BackColor = color
            };
            this.Controls.Add(colorBox);

            Label lbl = new Label()
            {
                Text = label,
                Location = new Point(x + 25, y - 2),
                ForeColor = Color.White,
                AutoSize = true
            };
            this.Controls.Add(lbl);
        }

        private void GenerateSeats()
        {
            string[] rows = { "A", "B", "C", "D", "E", "F", "G" };
            int columns = 10;
            int startX = 40;
            int startY = 0;
            int spacingX = 70;
            int spacingY = 45;

            for (int r = 0; r < rows.Length; r++)
            {
                for (int c = 1; c <= columns; c++)
                {
                    string seatName = rows[r] + c.ToString("D2");

                    Button btn = new Button()
                    {
                        Text = seatName,
                        Size = new Size(60, 40),
                        Font = new Font("Comic Sans MS", 8, FontStyle.Bold),
                        Location = new Point(startX + (c - 1) * spacingX, startY + r * spacingY),
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance = { BorderSize = 0 },
                        UseVisualStyleBackColor = false
                    };

                    // Mặc định loại ghế
                    string type = "Thường";
                    if ((rows[r] == "D" || rows[r] == "E" || rows[r] == "F") && c >= 4 && c <= 8)
                        type = "VIP";
                    else if (rows[r] == "G")
                        type = "Đôi";

                    seatTypes[seatName] = type;

                    if (bookedSeats.Contains(seatName))
                    {
                        btn.BackColor = Color.Gray;
                        btn.ForeColor = Color.White;
                        btn.Enabled = false;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                    }

                    else
                    {
                        btn.BackColor = GetColorByType(type);
                        btn.Click += Seat_Click; // chỉ gán nếu chưa đặt
                    }

                    panelSeats.Controls.Add(btn);
                }
            }
        }


        private void Seat_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string seatName = btn.Text;

            if (btn.BackColor == Color.LightSkyBlue)
            {
                btn.BackColor = GetColorByType(seatTypes[seatName]);
                selectedSeats.Remove(btn);
            }
            else
            {
                btn.BackColor = Color.LightSkyBlue;
                selectedSeats.Add(btn);
            }

            UpdateTotal();
        }

        private Color GetColorByType(string type)
        {
            switch (type)
            {
                case "VIP": return Color.Red;
                case "Đôi": return Color.HotPink;
                default: return Color.DarkViolet;
            }
        }

        private void UpdateTotal()
        {
            int total = selectedSeats.Sum(b => seatPrices[seatTypes[b.Text]]);
            lblTotal.Text = "Tạm tính: " + total.ToString("N0") + " VND";
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            if (selectedSeats.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lưu ghế vào biến toàn cục
            Program.SelectedSeatsGlobal = selectedSeats.Select(b => b.Text).ToList();


            // Mở FoodSelectionForm và ẩn luôn SeatForm
            FoodSelectionForm foodForm = new FoodSelectionForm(Program.SelectedSeatsGlobal);
            foodForm.Show();
            this.Hide(); // KHÔNG mở lại sau này nữa
        }


    }
}