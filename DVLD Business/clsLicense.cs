using Driving_License_Management_System.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Driving_License_Management_System.DVLD_Business
{
    public class clsLicense
    {
        public int ApplicationID { get; set; }
        public int LicenseID { get; set; }

        public int LicenseClass { get; set; }

        public int CreatedByUserID { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Notes { get; set; }
        public int PersonID { get; set; }
        
        public clsDriver DriverInfo { get; set; }
        public int DriverID { get; set; }

        public decimal PaidFees { get; set; }

        public bool IsActive { get; set; }
        
        public enum enReason { FirstTime = 1 , RenewDrivingLicense = 2, 
        ReplacementForLost = 3 , ReplacementForDamaged = 4 ,ReleaseDetained = 5}
        public byte IssueReason { get; set; }
        private enReason _Reason;
        public string IssueReasonText {
            get
            {

                switch (_Reason)
                {
                    case enReason.FirstTime:
                        return "New Driving License";
                    case enReason.RenewDrivingLicense:
                        return "Renew Driving License";
                    case enReason.ReplacementForLost:
                        return "Replacement For Lost";
                    case enReason.ReleaseDetained:
                        return "Released From Detained";
                    default:
                        return "Un Known";
                }
              
            }
        }

        public clsLicense()
        {

        }
        private clsLicense(int LicenseID , int ApplicationID ,
        int DriverID , int LicenseClass , DateTime IssueDate , DateTime ExpirationDate , 
        decimal PaidFees , bool IsActive , byte IssueReason , int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            
        }
        public bool Activate(int LicenseID)
        {
            return clsLicenseData.UpdateLicenseState(LicenseID, 1);
        }

        
        public bool DeActivate(int LicenseID)
        {
            return !Activate(LicenseID);
        }

    }
}
