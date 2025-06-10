using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVeXemPhim
{
    public interface IAccountManager
    {
        void Add(User user);
        void Edit(User user);
        void Delete(string username);
        List<User> GetAll();
        void Save(List<User> users);
    }
}