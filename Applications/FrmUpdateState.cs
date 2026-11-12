using Driving_License_Management_System.DVLD_Business;
using Driving_License_Management_System.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Management_System.Applications
{
    public partial class FrmUpdateState : Form
    {
        int _ApplicationID = -1;

        public FrmUpdateState(int ApplicationID)
        {
            InitializeComponent();
            _ApplicationID = ApplicationID;
            lblApplicationID.Text = _ApplicationID.ToString();
            btnNew.Enabled = false;
        }

        private void FrmUpdateState_Load(object sender, EventArgs e)
        {
            clsApplications CurrentApplication = clsApplications.Find(_ApplicationID);
            if (CurrentApplication == null)
            {
                MessageBox.Show("Sorry This Application is Null You Cannot Update :-(" , "Error :-(",
                MessageBoxButtons.OK, MessageBoxIcon.Error);return;
            }

        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            clsApplications CurrentApplication = clsApplications.Find(_ApplicationID);
            if (CurrentApplication != null)
            {
                if (CurrentApplication.SetComplete())
                {
                    CurrentApplication.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
                    btnNew.Enabled = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsApplications CurrentApplication = clsApplications.Find(_ApplicationID);
            if (CurrentApplication != null)
            {
                if (CurrentApplication.Cancel())
                {
                    CurrentApplication.ApplicationStatus = clsApplications.enApplicationStatus.Cancelled;
                    btnNew.Enabled = true;
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clsApplications CurrentApplication = clsApplications.Find(_ApplicationID);
            if (CurrentApplication != null)
            {
                CurrentApplication.ApplicationStatus = clsApplications.enApplicationStatus.New;
            }
        }
    }
}
