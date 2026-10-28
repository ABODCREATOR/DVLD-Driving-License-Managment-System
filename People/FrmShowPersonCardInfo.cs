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
    public partial class ShowPersonCard : Form
    {
        // This Form Will Show The Current Information Of The Person Stored
        // Without Editing It
        int _personID = -1;
        public ShowPersonCard(int PersonID)
        {
            InitializeComponent();
            _personID = PersonID;
        }
        private void ShowPersonCard_Load(object sender, EventArgs e)
        {
            ctrlPersonCardInfo1.LoadPersonInfo(_personID);
        }
    }
}
