using System;
using System.Windows.Forms;

public class StaffForm : Form
{
    private void btnQuanLyUser_Click(object sender, EventArgs e)
    {
        UserManagementForm userForm = new UserManagementForm();
        userForm.IsStaffMode = true; // Truyền chế độ staff
        userForm.ShowDialog();
    }
} 