using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Driving_License_Management_System.DataAccess
{
    public static class clsApplicationData
    {
        public static DataTable GetAllActiveApplications()
        {
            return clsPersonData.GetAllPeople(@"SELECT * FROM Applications 
            Where ApplicationStatus = 1");
        }
        public static DataTable GetAllApplications()
        {
            return clsPersonData.GetAllPeople(@"Select ApplicationID , ApplicantPersonID , ApplicationDate , ApplicationTypeID , Case
When ApplicationStatus = 0 THEN 'New' WHEN ApplicationStatus = 1 Then 'Completed' ELSE 'Cancelled'
END As StatusName ,ApplicationStatus ,  LastStatusDate , PaidFees , CreatedByUserID From Applications");
        }

        // To Be Continued :-(


        public static bool GetApplicationInfoByApplicationID(int ApplicationID, ref int ApplicantPersonID,
            ref DateTime ApplicationDate, ref int ApplicationTypeID
            , ref byte status, ref DateTime LastStatusDate, ref decimal Fees, ref int CreatedByUserID)
        {
            bool found = false;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"Select * From Applications Where ApplicationID = @AppId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@AppId", ApplicationID);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    found = true;
                    ApplicationID = (int)dr["ApplicationID"];
                    ApplicantPersonID = (int)dr["ApplicantPersonID"];
                    CreatedByUserID = (int)dr["CreatedByUserID"];
                    ApplicationTypeID = (int)dr["ApplicationTypeID"];
                    ApplicationDate = (DateTime)dr["ApplicationDate"];
                    Fees = (decimal)dr["PaidFees"];
                    LastStatusDate = (DateTime)dr["LastStatusDate"];
                    status = (byte)dr["ApplicationStatus"];


                }
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
        public static bool UpdateState(int ApplicationID, byte state)
        {
            int rowsAffected = 0;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"Update Applications Set ApplicationStatus = 
            @state Where ApplicationID = @ApplicationID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                conn.Open();
                rowsAffected += cmd.ExecuteNonQuery();
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
        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate,
        int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, decimal Fees,
        int CreatedByUserID)
        {
            int NewID = -1;

            string query = @"INSERT INTO Applications(ApplicantPersonID,
            ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate,
            PaidFees,CreatedByUserID)
            VALUES(
            @ApplicantPersonID,@ApplicationDate,@ApplicationTypeID,
            @ApplicationStatus,@LastStatusDate,@PaidFees,
            @CreatedByUserID);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection conn = new SqlConnection(clsConfig.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue(
                    "@ApplicantPersonID", ApplicantPersonID);

                cmd.Parameters.AddWithValue(
                    "@ApplicationDate", ApplicationDate);

                cmd.Parameters.AddWithValue(
                    "@ApplicationTypeID", ApplicationTypeID);

                cmd.Parameters.AddWithValue(
                    "@ApplicationStatus", ApplicationStatus);

                cmd.Parameters.AddWithValue(
                    "@LastStatusDate", LastStatusDate);

                cmd.Parameters.AddWithValue(
                    "@PaidFees", Fees);

                cmd.Parameters.AddWithValue(
                    "@CreatedByUserID", CreatedByUserID);

                conn.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                    NewID = Convert.ToInt32(result);
            }

            return NewID;
        }
        public static bool IsApplicationExist(int ApplicationID)
        {
            bool found = false;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"Select Found = 1 From Applications Where 
            ApplicationID = @AppID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@AppID", ApplicationID);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                found = dr.HasRows;
                dr.Close();
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


        // That Method Validates That The Person Mustn't Have More Than One Application 
        // For The Same License Class with ApplicationTypeID
        public static bool DoesPersonHaveActiveApplication(int PersonID , int ApplicationTypeID)
        {
            // Incase The Active Application Not Equal to -1 Return True
            return (GetActiveApplicationID(PersonID, ApplicationTypeID) != -1);
        }

        public static bool UpdateApplication(int ApplicationID ,int ApplicantPersonID,
        DateTime ApplicationDate , int ApplicationTypeID ,byte ApplicationStatus ,DateTime LastStatusDate,
        int CreatedByUserID , decimal Fees)
        {
            int rowsAffected = 0;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"Update Applications Set ApplicantPersonID = 
            @ApplicantPersonID , ApplicationDate = @ApplicationDate , 
            ApplicationTypeID = @ApplicationTypeID ,ApplicationStatus = @ApplicationStatus ,LastStatusDate = DateTime.Now ,
            PaidFees = @PaidFees , CreatedByUserID = @CreatedByUserID 
            Where ApplicationID = @ApplicationID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicantPersonID" , ApplicantPersonID);
            cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@CreatedByUserID ", CreatedByUserID);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@PaidFees", Fees);

            try
            {
                conn.Open();
                rowsAffected += cmd.ExecuteNonQuery();
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

        public static bool DeleteApplication(int ApplicationID)
        {
            int rowsAffected = 0;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"Delete From Applications Where ApplicationID = @AppID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@AppID", ApplicationID);
            try
            {
                conn.Open();
                rowsAffected += cmd.ExecuteNonQuery();
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

        // The States Are 1 - New , 2 - Completed , 3 - Cancelled That is Tiny int The Data Base
        // That Function Check The Number Of Current Active Applications For The Same Person
        // That Method Ensures That Every Person Can Have More Application In Progress
        public static int GetActiveApplicationID(int PersonID, int ApplicationTypeID)
        {
            int Active = -1;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"Select ApplicationID as ActiveApplicationID From 
            Applications Where ApplicantPersonID = @AppicantPersonID AND ApplicationID = @ApplicationID
            And ApplicationStatus = 1";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicantPersonID" , PersonID);
            cmd.Parameters.AddWithValue("@ApplicationTypeID",ApplicationTypeID);


            try
            {
                conn.Open();
                object res = cmd.ExecuteScalar();
                if (res != null && int.TryParse(res.ToString(), out int AppID))
                        Active = AppID;
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

            return Active;
        }
        public static int GetActiveApplicationIDForLicenseClass(int ApplicationTypeID , int PersonID , 
        int LicenseClassID)
        {
            int Active = -1;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"Select ApplicationID as ActiveApplicationID From Applications
            Inner Join LocalDrivingLicenseApplications On Applications.ApplicationID  
            = LocalDrivingLicenseApplications.ApplicationID Where Applications.ApplicationTypeID 
            = @ApplicationTypeID AND LocalDrivingLicenseApplications.LicenseClassID = 
            @LocalDrivingLicenseClassID AND Applications.ApplicantPersonID = @PersonID
            AND Applications.ApplicationStatus = 1";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseClassID", LicenseClassID);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            try
            {
                conn.Open();
                object res = cmd.ExecuteScalar();
                if (res != null && int.TryParse(res.ToString(), out int AppID))
                    Active = AppID;
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
            return Active;
        }
    }
}
