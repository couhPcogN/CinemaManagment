using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVeXemPhim
{
    public static class Program
    {
        public static string CurrentUserName = "";
        public static int CurrentUserPoints = 0;
        //  Biến dùng để truyền role từ LoginForm (admin/staff/user)
        public static string CurrentRole = string.Empty;

        //  Biến toàn cục giữ thông tin vé đã chọn (phục vụ thanh toán)
        public static string SelectedMovieName;
        public static string SelectedGenre;
        public static string SelectedDuration;
        public static string SelectedRoom;
        public static string SelectedShowtime;
        public static List<string> SelectedSeatsGlobal = new List<string>();

        public static object LoginForm { get; internal set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ✨ Mở form đăng nhập đầu tiên
            LoginForm loginForm = new LoginForm();
            Application.Run(loginForm);

            // ⏩ Nếu người dùng đã đăng nhập thành công (role đã set)
            if (string.IsNullOrEmpty(CurrentRole)) return;

            if (CurrentRole == "admin")
            {
                Application.Run(new AdminForm(CurrentRole)); // truyền role vào AdminForm
            }
            else if (CurrentRole == "staff")
            {
                Application.Run(new StaffForm());
            }
            else if (CurrentRole == "user")
            {
                Application.Run(new DashboardForm());
            }
        }
    }
}
