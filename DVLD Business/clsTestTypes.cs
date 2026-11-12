using System;
using System.Data;
using Driving_License_Management_System.DataAccess;

namespace Driving_License_Management_System.DVLD_Business
{
    public class clsTestType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enTestTypes { Vision = 1 , Written  = 2 , Street = 3};

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Fees { get; set; }

        public clsTestType()
        {
            this.ID = -1;
            this.Title = "";
            this.Description = "";
            this.Fees = 0;
            Mode = enMode.AddNew;
        }

        private clsTestType(int ID, string Title, string Description, float Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
            Mode = enMode.Update;
        }

        public static clsTestType Find(int ID)
        {
            string Title = "", Description = "";
            float Fees = 0F;

            if (clsTestTypeData.GetTestTypeByID(ID, ref Title, ref Description, ref Fees))
                return new clsTestType(ID, Title, Description, Fees);
            else
                return null;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypes();
        }

        private bool _UpdateTestType()
        {
            return clsTestTypeData.UpdateTestType(this.ID, this.Title, this.Description, this.Fees);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    return false;

                case enMode.Update:
                    return _UpdateTestType();
            }

            return false;
        }
    }
}