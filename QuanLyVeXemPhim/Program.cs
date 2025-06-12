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
        public static string SelectedShowDate;
        public static List<string> SelectedSeatsGlobal = new List<string>();

        public static object LoginForm { get; internal set; }
        public static string CurrentUsername { get; set; }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                // Mở form đăng nhập
                LoginForm loginForm = new LoginForm();
                Application.Run(loginForm);

                // Nếu không đăng nhập thành công (CurrentRole rỗng), thoát chương trình
                if (string.IsNullOrEmpty(CurrentRole)) break;

                // Mở form chính theo role
                if (CurrentRole == "admin")
                {
                    Application.Run(new AdminForm(CurrentRole));
                }
                else if (CurrentRole == "staff")
                {
                    Application.Run(new StaffForm());
                }
                else if (CurrentRole == "user")
                {
                    Application.Run(new DashboardForm());
                }

                // Sau khi form chính đóng, reset lại role để quay lại đăng nhập
                CurrentRole = string.Empty;
            }
        }
    }
}
