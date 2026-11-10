using Driving_License_Management_System.DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Management_System.Users
{
    public partial class FrmAddNewUser : Form
    {
        public FrmAddNewUser()
        {
            InitializeComponent();
        }

        private bool Confirmed(string Password , string ConfirmedPassword)
        {
            return Password == ConfirmedPassword;
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if(clsUser.isUserNameExists(txtuser.Text.Trim()))
            {
                MessageBox.Show("This UserName is Already Exists Try Another One:-(" , "Error :-(",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Confirmed(txtpass.Text.Trim() , txtconfirmpass.Text.Trim()))
            {
                if (clsUser.AddNewUser(txtuser.Text.Trim(), txtpass.Text.Trim(),Convert.ToInt32(txtpersonID.Text)))
                {
                    MessageBox.Show("User Added Suucessfully:-)", "Success :-)",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("There's an error in adding New User:-(", "Error :-(",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("The Confirmed password must be same as the original password:-(", "Error :-(",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtpass.UseSystemPasswordChar = !chkShow.Checked;
            txtconfirmpass.UseSystemPasswordChar = !chkShow.Checked;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtpersonID_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void FrmAddNewUser_Load(object sender, EventArgs e)
        {

        }
    }
}
