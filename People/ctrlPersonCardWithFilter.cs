using Driving_License_Management_System.DVLD_Business;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Management_System.People
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
            cbFilter.Items.Add("PersonID");cbFilter.Items.Add("NationalNo");
            // Be Default I assign an Index Selected By Default index 1 Which Load National Number
            cbFilter.SelectedIndex = 1;
        }
        private clsPerson _Person = new clsPerson();
        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {

        }
        
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            // We Allow Numbers In Case Person ID is Selected 
            if (cbFilter.Text == "PersonID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            _Person = clsPerson.Find(txtFilter.Text);
            if (_Person != null)
            {
                ctrlPersonCardInfo1.LoadPersonInfo(_Person.PersonID);
            }
        }
    }
}
