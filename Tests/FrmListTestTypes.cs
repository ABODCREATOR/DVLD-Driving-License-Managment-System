using Driving_License_Management_System.DataAccess;
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

namespace Driving_License_Management_System.Tests
{
    public partial class FrmListTestTypes : Form
    {
        private DataTable _dtAllTesttypes  = clsTestType.GetAllTestTypes();
        public FrmListTestTypes()
        {
            InitializeComponent();
        }

        private void FrmListTestTypes_Load(object sender, EventArgs e)
        {
            dgvList.DataSource = _dtAllTesttypes;
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUpdateTestType frmUp = new FrmUpdateTestType((clsTestType.enTestTypes)
                dgvList.SelectedRows[0].Cells["TestTypeID"].Value);
            frmUp.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvList.DataSource = clsTestTypeData.GetAllTestTypes();
        }
    }
}
