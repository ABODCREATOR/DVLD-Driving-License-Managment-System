using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Management_System.DataAccess
{
    public class clsLocalDrivingLicenseApplicationData
    {

        public static bool GetLocalDrivingLicenseApplicationInfoByID(int 
        LocalDrivingLicenseApplicationID , ref int ApplicationID , ref int LicenseClassID,
        string query = @"select * from LocalDrivingLicenseApplications Where 
            LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID")
        {
            bool found = false;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            ;
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID"
                , LocalDrivingLicenseApplicationID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    found = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error !", MessageBoxButtons.OK,
            MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return found;
        }
        public static bool GetLocalDrivingLicenseApplicationInfoByApplicationID( int ApplicationID , 
        ref int LocalDrivingLicenseApplicationID , ref int LicenseClassID)
        {
            bool found = false;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"select * from LocalDrivingLicenseApplications Where 
            ApplicationID = @ApplicationID";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@ApplicationID"
                , ApplicationID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    found = true;
                    //ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error !", MessageBoxButtons.OK,
            MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return found;
        }
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {

            // Local Driving License Process is a view in my local database machine 
            // Which abstracts a long block of query 
            return clsPersonData.GetAllPeople(@"select * from LocalDrivingLicenseProcess 
            order by ApplicationDate Desc");
        }
        
        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID , 
        int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationID = -1;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"Insert into LocalDrivingLicenseApplications
            (ApplicationID , LicenseClassID) Values (@ApplicationID , @LicenseClassID);
            SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query , conn);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                conn.Open();
                object res = cmd.ExecuteScalar();
                if (res != null && int.TryParse(res.ToString() , out int inserted))
                    LocalDrivingLicenseApplicationID = inserted;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error !", MessageBoxButtons.OK,
          MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return LocalDrivingLicenseApplicationID;
        }
        public static bool UpdateLocalDrivingLicenseApplication(int ApplicationID, int LocalDrivingLicenseApplicationID,
        int LicenseClassID)
        {
            int rowsAffected = 0;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"UPDATE LocalDrivingLicenseApplications
            SET ApplicationID = @AppID , LicenseClassID = @LicenseClassID Where
            LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@AppID", ApplicationID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                conn.Open(); rowsAffected += cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error !", MessageBoxButtons.OK,
      MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return rowsAffected > 0;
        }
        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            int rowsAffected = 0;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"Delete From LocalDrivingLicenseApplications where 
            LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                conn.Open(); rowsAffected += cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error !", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return rowsAffected > 0;
        }
    }
}