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

namespace Driving_License_Management_System.Local_Driving_License_Applications
{
    public partial class FrmListLocalDrivingLicenseApplications : Form
    {
        public FrmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
            dgvList.DataSource = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvList.DataSource = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
        }

        private void FrmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }
    }
}
