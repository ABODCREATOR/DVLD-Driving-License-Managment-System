using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driving_License_Management_System.DataAccess
{
    public class clsDriverData
    {
        public static DataTable GetAllDrivers()
        {
            return clsPersonData.GetAllPeople(@"select Drivers.CreatedDate , CONCAT_WS(' ' , People.FirstName , People.LastName) as DriverName ,
            Drivers.DriverID , Drivers.PersonID , Drivers.CreatedByUserID From Drivers
            join People On Drivers.PersonID = People.PersonID");
        }

        
    }
}
