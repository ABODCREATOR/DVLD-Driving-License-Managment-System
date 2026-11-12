using Driving_License_Management_System.DVLD_Business;
using Driving_License_Management_System.Utilities;
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
    public partial class FrmAddNewLocalDrivingLicenseApplication : Form
    {

        public enum enMode { AddNew , Update}
        private clsLicenseClass CurrentLicenseClass;
        private int _ApplicationID = -1;
        // That State Has Two Modes
        private clsLocalDrivingLicenseApplication CurrentLocalDrivingLicenseApplication;
        private clsApplications CurrentApplication;
        int _PersonID = -1;
        private enMode _Mode;
        int FlagIndexer = -1; // This Flag Checks The Current IDs in The Dictionary 
        // With It's Assigned Class Name Values
        // After Inserting Event Selected Index Changed in The Combo Box
        // We Will Assign Current Key Dictionary To The Flag Indexer and Push it
        // as Application Type ID To Find it From The Class clsApplicationTypes
        public FrmAddNewLocalDrivingLicenseApplication(int PersonID , int ApplicationID)
        {
         
            InitializeComponent();
            _PersonID = PersonID;
            _ApplicationID = ApplicationID;
            //if (_ApplicationID == -1)
            //    _Mode = enMode.AddNew;
            //else
            //    _Mode = enMode.Update;

            // Using Ternary Operator
            _Mode = (_ApplicationID < 0) ? enMode.AddNew : enMode.Update;
            if (_Mode == enMode.AddNew)
            {
                this.Text = "FrmAddNewLocalDrivingLicenseApplication";
                lblTitle.Text = "Add New Local Driving License Application";
            }
            else
            {
                ctrlPersonCardWithFilter1.gbFilter.Enabled = false;
                this.Text = "FrmUpdateLocalDrivingLicenseApplication";
                lblTitle.Text = "Update Local Driving License Application";
            }
            // Not Implemented Yet :-(
        }

       
        // Issue We Need To Test The Functionality Of The Form User Control Person With Filter!!!
        
        Dictionary<string, int> CheckValidityFees = new Dictionary<string , int>{
            { "1 - Small Motorcycle"  , 1} , { "2 - Heavy Motorcycle Application" , 2},
            {"3 - Ordinary driving license" , 3 } , {"4 - Commercial" , 4}
            , {"5 - Agricultural" , 5} , {"6 - Small and medium bus" , 6}
            , {"7 - Truck and heavy vehicle" , 7}
        };
      
        private void _FillComboBox()
        {
            foreach (KeyValuePair<string, int> kv in CheckValidityFees)
                cbClasses.Items.Add(kv.Key);
        }
        private void FrmAddNewApplication_Load(object sender, EventArgs e)
        {
            _FillComboBox();
        }
        private void _FillApplicationObjects()
        {
            // I Think That We Need Some Of Objects That Filled With The Properities only in the Presentation 
            // Layer
            CurrentLocalDrivingLicenseApplication.PaidFees = Convert.ToDecimal(lblFees.Text);

            // Another Trial
            //CurrentLocalDrivingLicenseApplication.LicenseClassID = FlagIndexer;
            // Trial
            CurrentLocalDrivingLicenseApplication.LicenseClassInfo = CurrentLicenseClass;
            CurrentLocalDrivingLicenseApplication.ApplicationID = _ApplicationID;
            // Notice That Status Text is a Get Property Only You Cannot Assign it 
            // Status Text Get The Application Status Enum 

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // We Need To Know Current Application ID!!!
            // And We Need To Know The LicenseClass ID
            _FillApplicationObjects();
            if (CurrentLocalDrivingLicenseApplication.Save())
            {
                MessageBox.Show("Error in Adding Application :-(", "Error :-(",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Application Added Successfully :-)", "Success :-)",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void cbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClasses.SelectedItem == null) return;

            string selectedText = cbClasses.SelectedItem.ToString();

            if (CheckValidityFees.ContainsKey(selectedText))
            {
                FlagIndexer = CheckValidityFees[selectedText];

                CurrentLicenseClass = clsLicenseClass.FindLicenseClassByLicenseClassID(FlagIndexer);
                if (CurrentLicenseClass != null)
                {
                    lblFees.Text = CurrentLicenseClass.Fees.ToString();
                }
                else
                {
                    MessageBox.Show("Not Found Application Type With ID = " + FlagIndexer, "Error !",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
