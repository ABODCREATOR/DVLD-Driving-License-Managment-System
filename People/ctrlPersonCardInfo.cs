using Driving_License_Management_System.DVLD_Business;
using Driving_License_Management_System.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Driving_License_Management_System.People
{
    public partial class ctrlPersonCardInfo : UserControl
    {
        private clsPerson _Person;
        private int _PersonID = -1;

        public string FullName
        {
            get { return _Person.FirstName + " " + _Person.LastName; }
        }
        private Action<int> OnPersonSelected;
        public ctrlPersonCardInfo()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                MessageBox.Show("There's Not Person Exists With PersonID = " + PersonID, "Error !",
                MessageBoxButtons.OK, MessageBoxIcon.Error);return;
            }

            _FillPersonInfo(PersonID);
        }
        private void _ResetPersonInfo()
        {
            lblPersonID.Text = "[???]"; lblGendor.Text = "[???]";
            lblemail.Text = "[???]";lbladdress.Text = "[???]";
            lblname.Text = "[???]";lblDateOfBirth.Text = "[???]";
            lblphone.Text = "[???]";lblCountry.Text = "[???]";
            lblNationalNo.Text = "[???]";
            lblDateOfBirth.Text = "[???]";
        }
        private void _LoadPersonImage()
        {
            if (_Person.Gendor == 1) pbPersonImage.BackgroundImage = Resources.Male_512;
            else pbPersonImage.BackgroundImage = Resources.Female_512;

            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))pbPersonImage.ImageLocation = ImagePath;
            else 
                    MessageBox.Show("Couldn't Find This Image :-(" + ImagePath , "Error !" , 
                        MessageBoxButtons.OK ,MessageBoxIcon.Error);
        }
        private void _FillPersonInfo(int PersonID)
        {
            PersonID = _Person.PersonID;
            lblPersonID.Text = PersonID.ToString();
            lblname.Text = FullName;
            lbladdress.Text = _Person.Address;
            lblGendor.Text = (_Person.Gendor == 1) ? "Male" : "Female";
            lblemail.Text = _Person.Email;
            lbladdress.Text = _Person.Address;
            lblphone.Text = _Person.Phone;
            lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
        }
       
        private void ctrlPersonCardInfo_Load(object sender, EventArgs e)
        {

        }

       
    }
}
