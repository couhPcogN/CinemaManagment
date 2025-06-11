using System;
using System.Drawing;
using System.Windows.Forms;

public class UserManagementForm : Form
{
    public bool IsStaffMode = false;

    private void UserManagementForm_Load(object sender, EventArgs e)
    {
        this.Font = new Font("Comic Sans MS", 10, FontStyle.Bold);
        SetAllControlsFont(this.Controls, this.Font);
        if (IsStaffMode)
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("user");
            cmbRole.SelectedIndex = 0;
        }
    }

    private void SetAllControlsFont(Control.ControlCollection controls, Font font)
    {
        foreach (Control c in controls)
        {
            c.Font = font;
            if (c.HasChildren)
                SetAllControlsFont(c.Controls, font);
        }
    }

    private void dgvUser_SelectionChanged(object sender, EventArgs e)
    {
        if (IsStaffMode && cmbRole.Text == "admin")
        {
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        else
        {
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (IsStaffMode && cmbRole.Text == "admin")
        {
            MessageBox.Show("Staff không được sửa admin!");
            return;
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (IsStaffMode && cmbRole.Text == "admin")
        {
            MessageBox.Show("Staff không được xóa admin!");
            return;
        }
    }
} 