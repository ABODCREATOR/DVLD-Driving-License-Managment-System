using Driving_License_Management_System.DVLD_Business;
using Driving_License_Management_System.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Management_System.People
{
    public partial class FrmAddEdit : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an Event Using The Delegate
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0 , Update = 1};
        public enum enGender { Male = 1 , Female= 0 };
        private enMode _Mode;

        private int _PersonID = -1;
        private clsPerson _Person;

        // Note You Can OverLoad Constructors in The Windows Forms in The Presentation Layer this is an Property Of Any Constructor
        public FrmAddEdit()
        {
            InitializeComponent();
            _Person = new clsPerson();
            _Mode = enMode.AddNew;
        }


        public FrmAddEdit(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _PersonID = PersonID;
        }
        private void _FillCountriesInComboBox()
        {
            foreach (DataRow r in clsCountry.GetAllCountries().Rows)
                cbCountries.Items.Add(r["CountryName"]);
        }
        private void FrmAddEdit_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }
        private void _ResetDefaultValues()
        {
            _FillCountriesInComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else lblTitle.Text = "Update Person";

            if (rbMale.Checked) pbPersonImage.BackgroundImage = Resources.Male_512;
            else pbPersonImage.BackgroundImage = Resources.Female_512;

            llremove.Visible = (pbPersonImage.ImageLocation != null);
            // We Should Handle That You Can't Add Age Less Than 18 Years
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            // We Shouldn't Allow Adding Age More Than 100 Years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-80);

            cbCountries.SelectedIndex = cbCountries.FindString("Egypt");

            rbMale.Checked = true;
            txtfirst.Text = ""; 
            txtsecond.Text = "";
            txtthird.Text = "";
            txtlast.Text = "";
            txtnationalno.Text = "";
            txtphone.Text = "";
            txtemail.Text = "";
            txtAddress.Text = "";

        }
        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person With ID = " + _PersonID, "Person Not Found :-(",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblPersonID.Text = _PersonID.ToString();
            txtfirst.Text = _Person.FirstName;
            txtsecond.Text = _Person.SecondName;
            txtthird.Text = _Person.ThirdName;
            txtlast.Text = _Person.LastName;
            txtnationalno.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;

            if (_Person.Gendor == 1)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            txtAddress.Text = _Person.Address;
            txtphone.Text = _Person.Phone;
            txtemail.Text = _Person.Email;

            if (_Person.CountryInfo != null)
            {
                cbCountries.SelectedIndex = cbCountries.FindString(_Person.CountryInfo.CountryName);
            }
            else
            {
                cbCountries.SelectedIndex = cbCountries.FindString("Egypt");
            }

            if (!string.IsNullOrEmpty(_Person.ImagePath))
                pbPersonImage.ImageLocation = _Person.ImagePath;

            llremove.Visible = (!string.IsNullOrEmpty(_Person.ImagePath));

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields are not valid :-(" , "Error !" , 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Person.NationalNo = txtnationalno.Text.Trim();
            _Person.FirstName = txtfirst.Text.Trim();
            _Person.LastName = txtlast.Text.Trim();
            _Person.SecondName = txtsecond.Text.Trim();
            _Person.ThirdName = txtthird.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.Email = txtemail.Text.Trim();
            _Person.Phone = txtphone.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            if (rbMale.Checked) _Person.Gendor = (short)enGender.Male;
            else _Person.Gendor = (short)enGender.Female;
            _Person.NationalityCountryID = clsCountry.Find(cbCountries.Text).ID;
            if (pbPersonImage.ImageLocation != null) _Person.ImagePath = pbPersonImage.ImageLocation; 
            else _Person.ImagePath = "";
            
            if (_Person._Save())
            {
                lblPersonID.Text = _Person.PersonID.ToString();
                _Mode = enMode.Update;
                lblTitle.Text = "Update Person";
                MessageBox.Show("Data Saved Successfully .", "Saved", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                // Trigeering Data Back Event to send to the caller form
                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
                MessageBox.Show("Error : Data isn't Saved Successfully :-(", "Error !", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedfilepath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedfilepath);llremove.Visible = true;
            }

        }
        private void llremove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            if (rbMale.Checked) pbPersonImage.BackgroundImage = Resources.Male_512;else pbPersonImage.BackgroundImage= Resources.Female_512;
            llremove.Visible = false;
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.BackgroundImage = Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.BackgroundImage = Resources.Female_512;
        }

        private void cbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
