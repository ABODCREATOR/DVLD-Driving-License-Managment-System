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

namespace Driving_License_Management_System.ApplicationTypes
{
    public partial class FrmListApplicationTypes : Form
    {
        private DataTable _dtAllApplications = clsApplicationTypes.GetAllApplicationTypes();
        public FrmListApplicationTypes()
        {
            InitializeComponent();
            dgvList.DataSource = _dtAllApplications;
        }

        private void FrmListApplications_Load(object sender, EventArgs e)
        {

        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedid = (int)dgvList.SelectedRows[0].Cells["ApplicationTypeID"].Value;
            FrmUpdateFees frmUpdate = new FrmUpdateFees(selectedid);
            frmUpdate.ShowDialog();

        }

        private void addApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature isn't Implemented Yet :-(" , "Note !" , MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvList.DataSource = clsApplicationTypes.GetAllApplicationTypes();
        }
    }
}
