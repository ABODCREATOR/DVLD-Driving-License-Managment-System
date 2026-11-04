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
    public partial class FrmAddNewApplication : Form
    {

        private clsApplicationTypes CurrentApplicationType;
        private clsLicenseClass CurrentLicenseClass;
        int _PersonID = -1;
        int FlagIndexer = -1; // This Flag Checks The Current IDs in The Dictionary 
        // With It's Assigned Class Name Values

        // After Inserting Event Selected Index Changed in The Combo Box
        // We Will Assign Current Key Dictionary To The Flag Indexer and Push it
        // as Application Type ID To Find it From The Class clsApplicationTypes
        public FrmAddNewApplication(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            // Not Implemented Yet :-(
            ctrlPersonCardInfo1.LoadPersonInfo(PersonID);
        }
        // Fuck User Controls
        // Issue We Need To Test The Functionality Of The Form User Control Person With Filter!!!
        
      

        Dictionary<string, int> CheckValidityFees = new Dictionary<string , int>{
            { "1 - Small Motorcycle"  , 1} , { "2 - Heavy Motorcycle Application" , 2},
            {"3 - Ordinary driving license" , 3 } , {"4 - Commercial" , 4}
            , {"5 - Agricultural" , 5} , {"6 - Small and medium bus" , 6}
            , {"7 - Truck and heavy vehicle" , 7}
        };
        private void _AssignClassFeesInDictionary()
        {
            
        }
        private void _FillComboBox()
        {
            foreach (KeyValuePair<string, int> kv in CheckValidityFees)
                cbClasses.Items.Add(kv.Key);
        }
        private void FrmAddNewApplication_Load(object sender, EventArgs e)
        {
            _FillComboBox();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool found = false;
            if (found)
            {

            }
            else
                MessageBox.Show("Error In Adding New Application = " + FlagIndexer, "Error !",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
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
