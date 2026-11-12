using Driving_License_Management_System.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Driving_License_Management_System.DVLD_Business
{
    public class clsLicenseClass
    {


        // I Think That The Function That Get All License Classes Commented It Cuz 
        // The Dictionary Will Help Me Alo In Finding The Real Assigned Key To The LicenseClass
        // That I Will Map It With The License Class ID Then I Will Have The Whole Data in The BLL
        
        // I Will Use Dictionary To Store Hard Coded The Class Name With It's Keys int That 
        // Represents The LicenseClassID

        //public static DataTable GetAllClasses()
        //{
        //    return clsLicenseClassData.GetAllLicenseClasses();
        //}

        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public int MinimumAllowedAge { get; set; }
        public int DefaultValidityLength {  get; set; }
        public decimal Fees { get; set; }


        public clsLicenseClass()
        {
            this.LicenseClassID = -1;this.DefaultValidityLength = 5; this.MinimumAllowedAge = 18;
            this.Fees = 0; this.ClassName = ""; this.ClassDescription = "";
        }

        private clsLicenseClass(int LicenseClassID  , string ClassName , string ClassDescription , 
        int MinimumAllowedAge , int DefaultValidityLength , decimal Fees)
        {
            this.LicenseClassID = LicenseClassID;this.ClassName = ClassName; this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge; this.DefaultValidityLength = DefaultValidityLength;
            this.Fees = Fees;
        }

        public static clsLicenseClass FindLicenseClassByLicenseClassID(int LicenseClassID)
        {
            string ClassName = "", ClassDescription = ""; 
            int MinimumAllowedAge = 18 , DefaultValidityLength = 5 ;
            decimal Fees = 0;

            bool Found = clsLicenseClassData.GetLicenseClassInfoByLicenseClassID(LicenseClassID,
            ref ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength,
            ref Fees);
            
            if(Found)
                return new clsLicenseClass(LicenseClassID,ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, Fees);
            else
                return null;
        }
   
    }
}
