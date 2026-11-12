using Driving_License_Management_System.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driving_License_Management_System.DVLD_Business
{
    public class clsDriver
    {
        public static DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }
    }
}
