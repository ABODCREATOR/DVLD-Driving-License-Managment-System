using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Management_System.DataAccess
{
    public static  class clsLicenseClassData
    {
        public static DataTable GetAllLicenseClasses()
        {
            return clsPersonData.GetAllPeople("Select * From LicenseClasses");
        }

        public static bool GetLicenseClassInfoByLicenseClassID(int LicenseClassID , ref string ClassName,
        ref string ClassDescription , ref int MinimumAllowedAge , ref int DefaultValidityLength , ref decimal Fees)
        {
            bool found = false;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"Select * From LicenseClasses Where LicenseClassID = @LicenseClassID";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    found = true;
                    LicenseClassID = (int)dr["LicenseClassID"];
                    ClassName = (string)dr["ClassName"];
                    ClassDescription = (string)dr["ClassDescription"];
                    MinimumAllowedAge = (int)dr["MinimumAllowedAge"];
                    DefaultValidityLength = (int)dr["DefaultValidityLength"];
                    Fees = (decimal)dr["ClassFees"];
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message , "Error ! " , MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                conn.Close();
            }
            finally
            {
                conn.Close();
            }
            return found;
        }
    }
}
