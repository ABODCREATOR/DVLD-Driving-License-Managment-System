using Driving_License_Management_System.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driving_License_Management_System.DVLD_Business
{
    public class clsUser 
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        
        public int UserID { get; set; }
        public enum enMode { AddNew = 0 , Update = 1}

        private enMode _Mode;
        public bool IsActive { get; set; }
        public int PersonID { get;set; }

        private clsPerson _Person;

        public clsPerson PersonInfo
        {
            get { return _Person; }
        }
        public clsUser()
        {
            this.UserName = ""; this.Password = "";
            this.UserID = -1;
            this.PersonID = -1;_Mode = enMode.AddNew;
            this.IsActive = false;
        }
        private clsUser(int UserID,string userName, string password, bool isActive, int PersonID)
        {
            UserName = userName;
            Password = password;
            IsActive = isActive;
            this.UserID = (int)UserID;
            this.PersonID = PersonID;_Mode = enMode.Update;
            _Person = clsPerson.Find(PersonID);
        }
        public static bool IsUserExists(string UserName , string Password)
        {
            return clsUserData.isUserExists(UserName, Password);
        }
        public static bool isUserNameExists(string UserName)
        {
            return clsUserData.isUserNameExists(UserName);
        }
        
        public static clsUser FindUserByUserNameAndPassword(string UserName, string Password)
        {
            int UserID = -1, PersonID = -1;
            bool isActive = false;

            if (clsUserData.GetUserInfoByUserNameANDPassword(UserName , Password,ref UserID,ref PersonID , ref isActive))
                return new clsUser(UserID , UserName,Password,isActive,PersonID);
            else 
                return null;
        }
        public static  bool AddNewUser(string UserName , string Password , int PersonID)
        {
            int UserID = clsUserData.AddNewUser(UserName, Password, PersonID);
            return UserID != -1;
        }
        public static bool UpdateUserPassword(string UserName , string Password)
        {
            return clsUserData.ChangePassword(UserName, Password);
        }
        public static bool DeleteUser(int UserId)
        {
            return clsUserData.DeleteUser(UserId);
        }
        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }
        public static int GetUsersCount()
        {
            return clsUserData.GetCountOfUsers();
        }

        //public bool Save(string UserName , string Password , int PersonID)
        //{
        //    switch (_Mode)
        //    {
        //        case enMode.AddNew:
        //            if (_AddNewPerson(UserName , Password, PersonID))
        //            {
        //                _Mode = enMode.Update;
        //            }
        //            return true;
        //        case enMode.Update:
        //            return false;

        //    }
        //    return false;

        //}
    }
}
