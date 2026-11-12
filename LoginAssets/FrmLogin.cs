using Driving_License_Management_System.DVLD_Business;
using Driving_License_Management_System.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Driving_License_Management_System.Login___Assets
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        bool FlagLogged = false;
        private void chkpass_CheckedChanged(object sender, EventArgs e)
        {
            txtpass.UseSystemPasswordChar = !chkpass.Checked;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            // This is a bool Function That Makes 
            clsUser user = clsUser.FindUserByUserNameAndPassword(txtuser.Text,txtpass.Text);
            
            if (user != null)
            {
                clsGlobal.CurrentUser = user;
                FlagLogged = true;
                MessageBox.Show("User Logged Successfully :-)", "Success :-)" , MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error UserName or Password :-(", "Error :-(", MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
            }
            if (FlagLogged)
            {
                DashBoard dsh = new DashBoard(txtuser.Text);
                dsh.Show();
                this.Hide();
            }    

        }

        private void chkRemember_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRemember.Checked)
                clsGlobal.RememberUserNameAndPassword(txtuser.Text, txtpass.Text);
            else
                clsGlobal.RememberUserNameAndPassword("", "");
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            string username = "", password = "";
            if (clsGlobal.GetStoredCredential(ref username, ref password))
            {
                 txtuser.Text = username ;  txtpass.Text = password ;
                chkRemember.Checked = true;
            }
            else
            {
                username = ""; password = "";
                chkRemember.Checked = false;
                txtuser.Focus();
            }
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
