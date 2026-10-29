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
    public class clsPerson
    {
        public enum enMode { AddNew = 0 , Update = 1};
        public enMode Mode = enMode.AddNew;
        public int PersonID { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }

        public string ThirdName { set; get; }
        public string LastName { set; get; }

        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;  }
        }
        public string NationalNo { set; get; }
        public DateTime DateOfBirth { set; get; }
        public short Gendor { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int NationalityCountryID { set; get; }

        public clsCountry CountryInfo;
        private string _ImagePath;
        public string ImagePath
        {
            get { return _ImagePath; } set { _ImagePath = value; }
        }
        public  clsPerson()
        {
            this.PersonID = -1;
            this.FirstName = "";this.SecondName = "";
            this.ThirdName = "";this.LastName = "";this.NationalNo = ""; this.Gendor = 1;
            this.DateOfBirth = DateTime.Now;this.Address = "";this.Phone = "";
            this.Email = ""; this.ImagePath = "";
            this.CountryInfo = null;
            Mode = enMode.AddNew;
            
        }
        private clsPerson(int PersonID , string FirstName , string SecondName , string ThirdName,
        String LastName , string NationalNo , DateTime DateOfBirth , short Gendor , string Address,
        string Phone , string Email , int NationalityCountryID , string ImagePath)
        {
            this.PersonID = PersonID;this.FirstName = FirstName; this.SecondName = SecondName;
            this.ThirdName = ThirdName; this.LastName = LastName; this.NationalNo = NationalNo;
            this.DateOfBirth =DateOfBirth; this.Gendor = (byte)Gendor; this.Address = Address; 
            this.Phone = Phone; this.Email = Email; this.NationalityCountryID = NationalityCountryID; 
            this.ImagePath = ImagePath;
            this.CountryInfo = clsCountry.Find(NationalityCountryID);Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            // Calling DataAccess Layer
            this.PersonID = clsPersonData.AddNewPerson(this.FirstName,
                this.SecondName, this.ThirdName, this.LastName,this.NationalNo,this.DateOfBirth , this.Gendor, this.Address,
                this.Phone, this.Email,this.NationalityCountryID , this.ImagePath);
            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            // Calling DataAccess Layer
            return clsPersonData.UpdatePerson(this.PersonID, this.FirstName,
                this.SecondName, this.ThirdName, this.LastName, this.NationalNo, this.DateOfBirth, this.Gendor, this.Address,
                this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public static clsPerson Find(int PersonID)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", NationalNo = "";
            DateTime DateOfBirth = DateTime.Now; short Gendor = 0;string Email = "", Address = "", Phone = "",
            ImagePath = ""; int NationalityCountryID = -1;
            bool IsFound = clsPersonData.GetPeopleInfoByID( PersonID , ref FirstName , ref SecondName,
            ref ThirdName , ref LastName , ref NationalNo , ref DateOfBirth , ref Gendor , ref Address , ref Phone , 
            ref Email , ref NationalityCountryID , ref ImagePath);
            if (IsFound)

                return new clsPerson(PersonID , FirstName , SecondName , ThirdName , LastName
                , NationalNo , DateOfBirth , Gendor , Address , Phone , Email , NationalityCountryID , ImagePath);
            else 
                return null;
        }
        public static clsPerson Find(string NationalNo) {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            DateTime DateOfBirth = DateTime.Now; short Gendor = 0; string Email = "", Address = "", Phone = "",
            ImagePath = ""; int NationalityCountryID = -1; int PersonID = -1;
            bool IsFound = clsPersonData.GetPersonInfoByNationalNo(NationalNo,ref PersonID, ref FirstName, ref SecondName,
            ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone,
            ref Email, ref NationalityCountryID, ref ImagePath);
            if (IsFound)
                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName
                , NationalNo, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;
        }
        public bool _Save()
        {
            switch (Mode) {
                
                case enMode.AddNew:
                    if (_AddNewPerson()) { Mode = enMode.Update; return true; } else return false;
                case enMode.Update:
                    return _UpdatePerson();
            }
            return false;
        }
        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }
        public static bool DeletePerson(int ID)
        {
            return clsPersonData.DeletePerson(ID);
        }
        public static bool IsPersonExist(int ID)
        {
            return clsPersonData.IsPersonExist(ID);
        }
        public static bool IsPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }
    }
}
