using Driving_License_Management_System.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driving_License_Management_System.DVLD_Business
{
    public  class clsApplicationTypes
    {
        public int ID { get; set; }
       
        public float Fees { get; set; }
        public string Title { get; set; }

        public clsApplicationTypes()
        {
            this.ID = -1; this.Fees = 0F;
            this.Title = "";
        }
        public clsApplicationTypes(int ApplicationTypeID , string Title , float Fees)
        {
            this.ID = ApplicationTypeID;this.Title = Title;this.Fees = Fees;
        }
        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
        }

        // Implemented Yet
        public static clsApplicationTypes Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = ""; float Fees = 0F;
            bool Found = clsApplicationTypesData.GetApplicationInfoByID(ApplicationTypeID, ref 
            ApplicationTypeTitle , ref Fees);

            if (Found)
                return new clsApplicationTypes(ApplicationTypeID , ApplicationTypeTitle,Fees);
            else
                return null;
        }
        public  bool _AddNewApplicationType(string Title , float fees)
        {
            int ID = clsApplicationTypesData.AddNewApplicationType(Title , fees);
            return ID != -1;
        }

        public static bool UpdateApplicationType(int ApplicationTypeID , string Title , float fees)
        {
            return clsApplicationTypesData.UpdateApplicationType(ApplicationTypeID, Title, fees);
        }

    }
}
