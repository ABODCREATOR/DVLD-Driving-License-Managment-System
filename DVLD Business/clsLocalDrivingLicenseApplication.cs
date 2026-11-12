using Driving_License_Management_System.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Driving_License_Management_System.DVLD_Business
{
    public class clsLocalDrivingLicenseApplication : clsApplications
    {
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClassInfo { get; set; }

        public string PersonFullName
        {
            get
            {
                if (base.PersonInfo == null) return "";
                return base.PersonInfo.FullName;
            }
        }
        public enum enMode { AddNew  , Update}
        private enMode _Mode = enMode.AddNew;


        public clsLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.ApplicationID = -1;
            _Mode = enMode.AddNew;
        }

        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID , 
        int ApplicationID , int ApplicationTypeID , int ApplicantPersonID , enApplicationStatus ApplicationStatus , 
        DateTime ApplicationDate , DateTime LastStatusDate , decimal PaidFees , int CreatedByUserID
        , int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationStatus = ApplicationStatus;
            this.ApplicationDate = ApplicationDate;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID; 
            this.LicenseClassID = LicenseClassID;
            _Mode = enMode.Update;
        }

        public static clsLocalDrivingLicenseApplication FindByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1, LicenseClassID = -1;
            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID,
                ref ApplicationID, ref LicenseClassID);

            if (IsFound)
            {
                clsApplications CurrentApplication = clsApplications.Find(ApplicationID);
                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID, CurrentApplication.ApplicationTypeID,
                    CurrentApplication.ApplicantPersonID, CurrentApplication.ApplicationStatus, CurrentApplication.ApplicationDate,
                    CurrentApplication.LastStatusDate, CurrentApplication.PaidFees, CurrentApplication.CreatedByUserID,
                    LicenseClassID);

            }
            else
                return null;
        }
        private bool _AddNewLocalDrivingLicenseApplication()
        {

            // This Check Ensure That The Base Application Class Must Be Saved 
            // Successfully in his Businsess Layer
            if (!base.Save())return false;

            
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(
                this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }
        public bool Delete()
        {
            bool IsLocalDrivingLiceneApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;
            // First We Find The Local DrivingLicsene Application ID and If Exists Then We Will Delete It.

            // If Not Existed You Cannot Implement That Method cuz The LocalDrivingLicenseApplication inherites information 
            // About Base Application Class
            IsLocalDrivingLiceneApplicationDeleted = clsLocalDrivingLicenseApplicationData.
                DeleteLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID);
            if (!IsLocalDrivingLiceneApplicationDeleted) return false;
            IsBaseApplicationDeleted = base.Delete();

            return IsBaseApplicationDeleted;
        }
        private bool _UpdateLocalDrivingLicenseApplication()
        {
            if (!base.Save())return false;

            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication
                (this.ApplicationID , this.LocalDrivingLicenseApplicationID , this.LicenseClassID);
        }
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }

        public bool Save()
        {
            if (!base.Save()) return false;
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateLocalDrivingLicenseApplication();
            }
            return false;
        }
    }
}
