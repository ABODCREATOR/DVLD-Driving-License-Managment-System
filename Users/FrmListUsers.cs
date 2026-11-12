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

namespace Driving_License_Management_System.Users
{
    public partial class FrmListUsers : Form
    {
        private DataTable _dtAllUsers = clsUser.GetAllUsers();
        public FrmListUsers()
        {
            InitializeComponent();
            _RefreshGrid();
            _FillComboBox();
            cbFilterBy.SelectedIndex = 0;
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilterBy.Text)
            {
                case "UserID":
                    FilterColumn = "UserID";break;
                case "UserName":
                    FilterColumn = "UserName";break;
                case "PersonID":
                    FilterColumn = "PersonID"; break;
                case "FullName":
                    FilterColumn = "FullName"; break;
                default:
                    FilterColumn = "None";break;
            }
            if (txtfilter.Text == "" || FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                _RefreshGrid();                
                return;
            }

            // This Case The Filter By Only Number Digits
            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}]={1}",FilterColumn,txtfilter.Text);
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}]LIKE'{1}%'" , FilterColumn,txtfilter.Text);
            _RefreshGrid();        }
        private void _FillComboBox()
        {
            cbFilterBy.Items.Add("None");
            foreach(DataColumn dc  in _dtAllUsers.Columns)
                cbFilterBy.Items.Add((string)dc.ColumnName);
        }
        private void _RefreshGrid()
        {
            dgvList.DataSource = _dtAllUsers;
            lblrecordscount.Text = dgvList.Rows.Count.ToString();
        }
        private void FrmListUsers_Load(object sender, EventArgs e)
        {

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtfilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "PersonID" || cbFilterBy.Text == "UserID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
