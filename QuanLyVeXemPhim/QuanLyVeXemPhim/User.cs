using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVeXemPhim
{
    public class User : Account
    {
        public int Points { get; set; }

        public User() : base() { }

        public User(string username, string password, string role, int points = 0)
            : base(username, password, role)
        {
            Points = points;
        }
    }
}