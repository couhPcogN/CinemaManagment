using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVeXemPhim
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public Account() { }

        public Account(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}