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
    public partial class FrmUpdateTestType : Form
    {
        private clsTestType _TestType;
        private clsTestType.enTestTypes _TestTypeID = clsTestType.enTestTypes.Vision;
        public FrmUpdateTestType(clsTestType.enTestTypes ID)
        {
            InitializeComponent();
            _TestTypeID = ID;
            // Mixed Casting
            TestTypeID.Text = ((int)_TestTypeID).ToString();  
        }
        private void LoadData()
        {
            _TestType = clsTestType.Find((int)_TestTypeID);
            if (_TestType != null)
            {
                  txttitle.Text = _TestType.Title;
                  txtdesc.Text = _TestType.Description;
                  txtfees.Text = _TestType.Fees.ToString();
            }
            else
            {
                MessageBox.Show("Error ! Couldn't Find Test with Test Type ID " + _TestTypeID + ":-(",
                "Error ! " , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void FrmUpdateTestType_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            _TestType.Title = txttitle.Text;
            _TestType.Description = txtdesc.Text;
            _TestType.Fees = Convert.ToSingle(txtfees.Text);
            if (_TestType.Save())
            {
                MessageBox.Show("Data Saved Successfully :-)", "Success :-)",
                    MessageBoxButtons.OK , MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error ! Couldn't Save Data :-(",
                "Error ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtfees_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtfees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
