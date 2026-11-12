using Driving_License_Management_System.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT = System.Data.DataTable;
namespace Driving_License_Management_System.DVLD_Business
{
    public class clsCountry
    {
        public int ID {  get; set; }
        public string CountryName { get; set; } 
        public clsCountry()
        {
            this.ID = -1; this.CountryName = "";
        }
        public clsCountry(int ID , string CountryName)
        {
            this.ID = ID; this.CountryName = CountryName;
        }

        public static clsCountry Find(int ID)
        {
            string CountryName = "";
            if (clsCountryData.GetCountryInfoByID(ID, ref CountryName))
                return new clsCountry(ID , CountryName);
            else 
                return null;
        }

        public static clsCountry Find(string Name)
        {
            int ID = -1;
            if (clsCountryData.GetCountryInfoByName(ref ID, Name))
                return new clsCountry(ID, Name);
            else
                return null;
        }

        public static DT GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }

    }
}
