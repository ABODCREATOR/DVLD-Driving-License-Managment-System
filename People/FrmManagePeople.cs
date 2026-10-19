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

namespace Driving_License_Management_System.People
{
    public partial class FrmManagePeople : Form
    {

        private DataTable _dtAllpeople;
        private DataTable _dtpeopleshow;
        public Action<int> OnPersonSelected;

        private void _RefreshGrid()
        {
            _dtAllpeople = clsPerson.GetAllPeople();

            _dtpeopleshow = _dtAllpeople.DefaultView.ToTable(
                false,
                "PersonID",
                "NationalNo",
                "FirstName",
                "SecondName",
                "ThirdName",
                "LastName",
                "DateOfBirth",
                "Gendor",
                "Address",
   
                "Phone"
            );

            dgvListPeople.DataSource = _dtpeopleshow;

            lblrecordscount.Text = dgvListPeople.Rows.Count.ToString();
        }
        public FrmManagePeople()
        {
            InitializeComponent();
            _RefreshGrid();
        }

        private void FrmManagePeople_Load(object sender, EventArgs e)
        {
            _FillComboBox();
            _RefreshGrid();
            cbPeople.SelectedIndex = 0;
            lblrecordscount.Text = dgvListPeople.Rows.Count.ToString();


            if (dgvListPeople.Rows.Count > 0)
            {
                dgvListPeople.Columns[0].HeaderText = "PersonID";
                dgvListPeople.Columns[0].Width = 110;

                dgvListPeople.Columns[1].HeaderText = "NationalNo";
                dgvListPeople.Columns[1].Width = 120;

                dgvListPeople.Columns[2].HeaderText = "FirstName";
                dgvListPeople.Columns[2].Width = 120;

                dgvListPeople.Columns[3].HeaderText = "SecondName";
                dgvListPeople.Columns[3].Width = 120;

                dgvListPeople.Columns[4].HeaderText = "ThirdName";
                dgvListPeople.Columns[4].Width = 120;
                dgvListPeople.Columns[5].HeaderText = "LastName";
                dgvListPeople.Columns[5].Width = 140;


                dgvListPeople.Columns[6].HeaderText = "DateOfBirth";
                dgvListPeople.Columns[6].Width = 120;

                dgvListPeople.Columns[7].HeaderText = "Gendor";
                dgvListPeople.Columns[7].Width = 140;


                dgvListPeople.Columns[8].HeaderText = "Address";
                dgvListPeople.Columns[8].Width = 120;


                dgvListPeople.Columns[9].HeaderText = "Phone";
                dgvListPeople.Columns[9].Width = 140;

               

            }
        }

        private void cbPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtfilter.Visible = (cbPeople.Text != "None");
            if (txtfilter.Visible)
            {
                txtfilter.Text = "";
                txtfilter.Focus();
            }
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbPeople.Text)
            {
                case "PersonID":
                    FilterColumn = "PersonID";
                    break;
                case "NationalNo":
                    FilterColumn = "NationalNo";
                    break;
                case "FirstName":
                    FilterColumn = "FirstName";
                    break;
                case "SecondName":
                    FilterColumn = "SecondName";
                    break;
                case "ThirdName":
                    FilterColumn = "ThirdName";
                    break;
                case "LastName":
                    FilterColumn = "LastName";
                    break;
                case "Nationality":
                    FilterColumn = "Nationality";
                    break;
                case "Gendor":
                    FilterColumn = "Gendor";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "Email":
                    FilterColumn = "Email";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtfilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtpeopleshow.DefaultView.RowFilter = "";
                lblrecordscount.Text = dgvListPeople.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID")
                _dtpeopleshow.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtfilter.Text.Trim());
            else
                _dtpeopleshow.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtfilter.Text.Trim());
            lblrecordscount.Text = dgvListPeople.Rows.Count.ToString();
        }

        private void _FillComboBox()
        {
            cbPeople.Items.Clear();
            foreach (DataColumn col in _dtpeopleshow.Columns)
            {
                cbPeople.Items.Add(col.ColumnName);
            }
        }

        private void txtfilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            // We Allow Numbers In Case Person ID is Selected 
            if (cbPeople.Text == "PersonID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btn_AddNewPerson_Click(object sender, EventArgs e)
        {
            FrmAddEdit frm = new FrmAddEdit();
            frm.ShowDialog();
        }

        

        private void updatePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvListPeople.SelectedRows.Count == 0) return;
                FrmAddEdit frm = new FrmAddEdit((int)dgvListPeople.SelectedRows[0].Cells["PersonID"].Value);
            frm.ShowDialog();
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure you Want to Delete That Person ! " , "Warning !",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            int selectedPersonId = (int)dgvListPeople.SelectedRows[0].Cells["PersonID"].Value;

            if (res == DialogResult.Yes)
            {
                if (clsPerson.DeletePerson(selectedPersonId))
                {
                    MessageBox.Show("Person Deleted Successfully :-)", "Success !",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshGrid();
                }
                else
                    MessageBox.Show("Error in Deleting Person :-(", "Error !",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                return;
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Method isn't Implemented Yet :-(" , "Comming Soon " , MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            return;
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Method isn't Implemented Yet :-(", "Comming Soon ", MessageBoxButtons.OK,
               MessageBoxIcon.Information);
            return;
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ctrlPersonCardInfo ctrl = new ctrlPersonCardInfo();
            int selectedPersonId = (int)dgvListPeople.SelectedRows[0].Cells["PersonID"].Value;
            ctrl.LoadPersonInfo(selectedPersonId);
        }
    }


}
