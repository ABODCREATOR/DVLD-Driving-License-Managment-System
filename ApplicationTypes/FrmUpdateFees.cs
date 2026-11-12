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
    public partial class FrmUpdateFees : Form
    {
        
        public FrmUpdateFees(int ID)
        {
            InitializeComponent();
            ApplicationID.Text = ID.ToString();
        }
        

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (clsApplicationTypes.UpdateApplicationType(Convert.ToInt32(ApplicationID.Text),
                txttitle.Text , Convert.ToSingle(txtfees.Text)))
            {
                MessageBox.Show("Application Updated Successfully :-)" , "Success :-)",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error in Updating Application :-(" , "Error :-(" ,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    
        }

        private void txtfees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void FrmUpdateFees_Load(object sender, EventArgs e)
        {

        }
    }
}
