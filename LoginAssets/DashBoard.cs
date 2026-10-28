using Driving_License_Management_System.ApplicationTypes;
using Driving_License_Management_System.Drivers;
using Driving_License_Management_System.People;
using Driving_License_Management_System.Tests;
using Driving_License_Management_System.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Management_System.Login___Assets
{
    public partial class DashBoard : Form
    {
        public DashBoard(string UserName)
        {
            InitializeComponent();
            lbluser.Text = UserName;
        }

        private void lbluser_Click(object sender, EventArgs e)
        {

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
           BackgroundImage =  clsUtil.SetImageOpacity(BackgroundImage, 45);
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin log = new FrmLogin();
            log.ShowDialog();
            
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManagePeople man = new FrmManagePeople();
            man.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListUsers frmlist = new FrmListUsers();
            frmlist.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListApplications FRMLISTAPP = new FrmListApplications();
            FRMLISTAPP.ShowDialog();
            
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListTestTypes frmListTest = new FrmListTestTypes();
            frmListTest.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDrivers fd = new FrmDrivers();
            fd.ShowDialog();
        }
    }
}
