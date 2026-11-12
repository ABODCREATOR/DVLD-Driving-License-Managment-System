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

namespace Driving_License_Management_System.Drivers
{
    public partial class FrmDrivers : Form
    {
        private DataTable _dtAllDrivers = clsDriver.GetAllDrivers();
        public FrmDrivers()
        {
            InitializeComponent();
        }

        private void FrmDrivers_Load(object sender, EventArgs e)
        {
            dgvList.DataSource = _dtAllDrivers;
        }
    }
}
