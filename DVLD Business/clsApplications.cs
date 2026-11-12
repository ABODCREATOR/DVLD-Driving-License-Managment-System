using Driving_License_Management_System.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Management_System.DVLD_Business
{
    public class clsApplications
    {
        public enum enMode { AddNew = 0 , Update = 1 }
        public enum enApplicationType { NewDrivingLicense = 1, RenewDrivingLicense = 2 , 
        ReplaceForLostOrDamaged = 3 , ReplaceDamagedDrivingLicense = 4 , ReleaseDetainedDrivingLicense = 5 , 
        NewInternationalLicense = 6 , RetakeTest = 7}

        public enMode Mode = enMode.AddNew;
        public enum enApplicationStatus { New = 1 , Cancelled = 2 , Completed = 3}
        public int ApplicationTypeID {get; set;}
        public int ApplicationID {  get; set; }
        public int ApplicantPersonID { get; set; }
        public clsApplicationTypes ApplicationTypeInfo;
        public enApplicationStatus ApplicationStatus { get; set; }

        public clsPerson PersonInfo;

        public string FullName
        {
            get
            {
                return PersonInfo.FirstName + " " + PersonInfo.LastName;
            }
        }
        public static clsApplications Find(int ApplicationID)
        {
            int ApplicantPersonID = -1, CreatedByUserID = -1, ApplicationTypeID = -1;
            DateTime ApplicationDate = DateTime.Now , LastStatusDate = DateTime.Now ;
            decimal Fees = 0; byte state = 0;
            bool found = clsApplicationData.GetApplicationInfoByApplicationID(ApplicationID,
            ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID, ref state,
            ref LastStatusDate, ref Fees, ref CreatedByUserID);

            if (found)
                return new clsApplications(ApplicationID, ApplicantPersonID,
                ApplicationDate, ApplicationTypeID, (enApplicationStatus)state
                , LastStatusDate, CreatedByUserID, Fees);
            else
                return null;

        }
        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";

                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "UnKnown";
                }

            }
        }
        public DateTime LastStatusDate { get; set; }
        public DateTime ApplicationDate { get; set; }   
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo;
        public clsApplications()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.CreatedByUserID = -1;
            this.PaidFees = 0;
            this.LastStatusDate = DateTime.Now;
            this.ApplicationDate = DateTime.Now;
            PersonInfo = null;
        }
        private clsApplications(int ApplicationID , int ApplicantPersonID ,
            DateTime ApplicationDate , int ApplicationTypeID , 
            enApplicationStatus ApplicationStatus,DateTime LastStatusDate,
            int CreatedByUserID , decimal PaidFees)
        {
            this.ApplicationID = ApplicationID;
            PersonInfo = clsPerson.Find(ApplicationID);
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.LastStatusDate = LastStatusDate;
            this.ApplicationStatus = ApplicationStatus;
            this.CreatedByUserID = CreatedByUserID;
            this.PaidFees = PaidFees;
            Mode = enMode.Update;
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(this.ApplicantPersonID,
            this.ApplicationDate, this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, (decimal)this.PaidFees,
            this.CreatedByUserID);

            return this.ApplicationID != -1;
        }
        private bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(this.ApplicationID, this.ApplicantPersonID,
            this.ApplicationDate, this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, 
            this.CreatedByUserID, this.PaidFees);
        }
        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID)
        {
            return DoesPersonHaveActiveApplication(this.ApplicationID, ApplicationTypeID);
        }
        public static bool DoesPersonHaveActiveApplication(int PersonID , int ApplicationID)
        {
            return clsApplicationData.DoesPersonHaveActiveApplication(PersonID, ApplicationID);
        }
        public bool Cancel()
        {
            // The States like This 1 - New  , 2 - Cancel , 3 - Completed
            return clsApplicationData.UpdateState(this.ApplicationID, 2);
        }
        public bool SetComplete()
        {
            return clsApplicationData.UpdateState(this.ApplicationID, 3);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        Mode = enMode.Update;                     
                    }
                    else
                        return false;
                    break;
                case enMode.Update:
                    return _UpdateApplication();
            }
            return false;   
        }
        public bool Delete()
        {
            return clsApplicationData.DeleteApplication(this.ApplicationID);
        }
        public static bool IsApplicationExist(int ApplicationID)
        {
            return clsApplicationData.IsApplicationExist(ApplicationID);
        }

        
        public static int GetActiveApplicationID(int PersonID , clsApplications.enApplicationType ApplicationTypeID)
        {
            return clsApplicationData.GetActiveApplicationID(PersonID, (int)ApplicationTypeID);
        }
        
        public static int GetActiveApplicationForLicenseClass(int PersonID , clsApplications.enApplicationType ApplicationTypeID , 
        int LicenseClassID)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClass((int)ApplicationTypeID, PersonID, LicenseClassID);
        }
        public int GetActiveApplicationID(clsApplications.enApplicationType ApplicationTypeID)
        {
           return GetActiveApplicationID(this.ApplicantPersonID, ApplicationTypeID);
        }
        
          
    }
}
