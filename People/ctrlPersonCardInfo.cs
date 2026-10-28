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
using Driving_License_Management_System.Utilities;

namespace Driving_License_Management_System.People
{

    // This File is a User Control That You Can Build it and Reuse it with your entire solution in winforms 
    public partial class ctrlPersonCardInfo : UserControl
    {
        private clsPerson _Person;
        public string FullName
        {
            get {
                if (_Person == null) return "";    
                return _Person.FirstName + " " + _Person.LastName; 
            }
        }
       
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
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetPersonInfo();
            }
            else
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
            _Person = null;
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
        private void _FillPersonInfo(int personID)
        {
            _Person = clsPerson.Find(personID); // هات الشخص الأول

            if (_Person == null)
            {
                MessageBox.Show("No person with ID = " + personID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // وبعدين املأ البيانات عادي جداً زي الكود اللي فوق...
            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalNo.Text = _Person.NationalNo.ToString();
            lblname.Text = _Person.FullName;
            lbladdress.Text = _Person.Address;
            lblGendor.Text = (_Person.Gendor == 0) ? "Male" : "Female";
            lblemail.Text = _Person.Email;
            lblphone.Text = _Person.Phone;

            clsCountry country = clsCountry.Find(_Person.NationalityCountryID);
            lblCountry.Text = (country != null) ? country.CountryName : "Unknown";

            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
        }

        private void ctrlPersonCardInfo_Load(object sender, EventArgs e)
        {
            //if (clsGlobal.CurrentUser.PersonInfo != null)
            //{
            //    LoadPersonInfo(clsGlobal.CurrentUser.PersonInfo.PersonID);
            //    return;
            //}
            //else
            //{
            //    _ResetPersonInfo();
            //}

            //if (_Person == null)
            //{
            //    _ResetPersonInfo();
            //    return;
            //}

            //if (clsGlobal.CurrentUser.PersonInfo == null)
            //{
            //    _ResetPersonInfo();
            //    return;
            //}

        }

        private void pbPersonImage_Click(object sender, EventArgs e)
        {

        }
    }
}
