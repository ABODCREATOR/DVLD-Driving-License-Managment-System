using Driving_License_Management_System.ApplicationTypes;
using Driving_License_Management_System.Drivers;
using Driving_License_Management_System.Local_Driving_License_Applications;
using Driving_License_Management_System.Login___Assets;
using Driving_License_Management_System.People;
using Driving_License_Management_System.Tests;
using Driving_License_Management_System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Management_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmListLocalDrivingLicenseApplications());
        }
    }
}
