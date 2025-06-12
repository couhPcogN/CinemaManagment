using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyVeXemPhim
{
    public partial class FoodSelectionForm : Form
    {
        private Label lblTitle, lblTotal;
        private Button btnContinue, btnBack, btnClose;
        private Dictionary<string, (Label lblQty, int price)> foodControls = new Dictionary<string, (Label, int)>();
        private Form parentForm;
        public FoodSelectionForm(Form parent,List<string> seatNames)
        {
            parentForm = parent;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(573, 559);
            this.BackColor = Color.HotPink;
            this.Font = new Font("Comic Sans MS", 10, FontStyle.Bold);
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeUI();
        }

        private void InitializeUI()
        {
            lblTitle = new Label()
            {
                Text = "FOODS AND DRINKS",
                Font = new Font("Comic Sans MS", 14, FontStyle.Bold),
                ForeColor = Color.Aqua,
                Location = new Point(180, 20),
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            btnClose = new Button()
            {
                Text = "X",
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                ForeColor = Color.Black,
                Size = new Size(30, 30),
                Location = new Point(this.Width - 40, 10),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);

            string[] items = { "Popcorn", "Pepsi", "Coca", "Sprite" };
            int[] prices = { 50000, 20000, 20000, 20000 };
            string[] icons = { "popcorn.png", "pepsi.png", "cocacola.png", "sprite.png" };

            for (int i = 0; i < items.Length; i++)
            {
                AddFoodRow(50, 80 + i * 70, items[i], prices[i], icons[i]);
            }

            Label lblInvoice = new Label()
            {
                Text = "Provisional Invoice:",
                Location = new Point(50, 370),
                ForeColor = Color.Navy,
                AutoSize = true
            };
            this.Controls.Add(lblInvoice);

            lblTotal = new Label()
            {
                Text = "0 VND",
                Location = new Point(210, 370),
                AutoSize = true,
                ForeColor = Color.Blue
            };
            this.Controls.Add(lblTotal);

            btnBack = new Button()
            {
                Text = "BACK",
                Size = new Size(100, 40),
                Location = new Point(50, 420),
                BackColor = Color.LightSkyBlue
            };
            btnBack.Click += btnBack_Click;
            this.Controls.Add(btnBack);

            btnContinue = new Button()
            {
                Text = "Continue",
                Size = new Size(100, 40),
                Location = new Point(180, 420),
                BackColor = Color.LightSkyBlue
            };
            btnContinue.Click += BtnContinue_Click;
            this.Controls.Add(btnContinue);
        }

        private void AddFoodRow(int x, int y, string name, int price, string icon)
        {
            PictureBox pic = new PictureBox()
            {
                Location = new Point(x, y),
                Size = new Size(40, 40),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            string path = System.IO.Path.Combine(Application.StartupPath, "images", icon);
            if (System.IO.File.Exists(path))
            {
                pic.Image = Image.FromFile(path);
            }

            this.Controls.Add(pic);

            Label lbl = new Label()
            {
                Text = name + "  " + price.ToString("N0") + " VND",
                Location = new Point(x + 50, y),
                AutoSize = true
            };
            this.Controls.Add(lbl);

            Button btnPlus = new Button()
            {
                Text = "+",
                Location = new Point(x + 260, y),
                Size = new Size(30, 30)
            };

            Button btnMinus = new Button()
            {
                Text = "-",
                Location = new Point(x + 320, y),
                Size = new Size(30, 30)
            };

            Label lblQty = new Label()
            {
                Text = "0",
                Location = new Point(x + 295, y + 5),
                AutoSize = true
            };

            btnPlus.Click += (s, e) => { UpdateQty(name, 1); };
            btnMinus.Click += (s, e) => { UpdateQty(name, -1); };

            this.Controls.Add(btnPlus);
            this.Controls.Add(btnMinus);
            this.Controls.Add(lblQty);

            foodControls[name] = (lblQty, price);
        }

        private void UpdateQty(string name, int delta)
        {
            var (label, price) = foodControls[name];
            int current = int.Parse(label.Text);
            int newQty = Math.Max(0, current + delta);
            label.Text = newQty.ToString();
            UpdateTotal();
        }

        private void FoodSelectionForm_Load(object sender, EventArgs e)
        {

        }

        private void UpdateTotal()
        {
            int total = 0;
            foreach (var kvp in foodControls)
            {
                int qty = int.Parse(kvp.Value.lblQty.Text);
                total += qty * kvp.Value.price;
            }
            lblTotal.Text = total.ToString("N0") + " VND";
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            if (Program.SelectedSeatsGlobal == null || Program.SelectedSeatsGlobal.Count == 0)
            {
                MessageBox.Show("Không tìm thấy ghế đã chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedFoods = foodControls.ToDictionary(
                f => f.Key,
                f => int.Parse(f.Value.lblQty.Text)
            );

            // Giả sử các thông tin phim/lịch chiếu được lưu tạm ở Program (nếu không thì lấy lại từ form trước đó)
            PaymentForm payForm = new PaymentForm(this, Program.SelectedSeatsGlobal, selectedFoods)
            {
                SelectedMovieName = Program.SelectedMovieName,
                SelectedGenre = Program.SelectedGenre,
                SelectedDuration = Program.SelectedDuration,
                SelectedRoom = Program.SelectedRoom,
                SelectedShowtime = Program.SelectedShowtime,
                BuyerName = Program.CurrentUserName,
                BuyerPoints = Program.CurrentUserPoints
            };

            this.Hide();
            payForm.ShowDialog();
            this.Close();
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            //// Quay lại chọn ghế
            //SeatSelectionForm seatForm = new SeatSelectionForm();
            //seatForm.Show();
            //this.Hide(); // KHÔNG dùng this.Close()
            this.Close(); // Đóng form hiện tại, không mở lại FoodSelectionForm nữa
        }

    }
}
