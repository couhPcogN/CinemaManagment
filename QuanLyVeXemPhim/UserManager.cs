using QuanLyVeXemPhim;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class UserManager : IAccountManager
{
    // Đường dẫn tới file CSV chứa danh sách user
    private readonly string filePath = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"..\..\DATA\User.csv"));

    // Thêm user mới
    public void Add(User user)
    {
        var users = GetAll();
        users.Add(user);
        Save(users);
    }

    // Sửa thông tin user (dựa vào Username là duy nhất)
    public void Edit(User user)
    {
        var users = GetAll();
        var target = users.FirstOrDefault(u => u.Username == user.Username);
        if (target != null)
        {
            target.Password = user.Password;
            target.Role = user.Role;
            Save(users);
        }
    }

    // Xóa user dựa vào Username
    public void Delete(string username)
    {
        var users = GetAll();
        users.RemoveAll(u => u.Username == username);
        Save(users);
    }

    // Lấy toàn bộ danh sách user từ file CSV
    public List<User> GetAll()
    {
        var users = new List<User>();
        if (!File.Exists(filePath)) return users;

        var lines = File.ReadAllLines(filePath).Skip(1); // bỏ dòng tiêu đề
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length == 3)
            {
                users.Add(new User(parts[0], parts[1], parts[2]));
            }
        }
        return users;
    }

    // Ghi danh sách user trở lại file CSV
    public void Save(List<User> users)
    {
        var lines = new List<string> { "Username,Password,Role" };
        lines.AddRange(users.Select(u => $"{u.Username},{u.Password},{u.Role}"));
        File.WriteAllLines(filePath, lines);
    }
}
