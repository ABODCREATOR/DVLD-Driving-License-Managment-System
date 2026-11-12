using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Driving_License_Management_System.DataAccess.clsCountryData;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Driving_License_Management_System.DataAccess
{
    public class clsLicenseData
    {
        public static bool GetLicenseInfoByID(int LicenseID, ref int ApplicationID, ref int DriverID,
        ref int LicenseClassID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
        ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool found = false;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"Select * from Licenses Where LicenseID = @LicenseID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    found = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (byte)reader["IssueReason"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
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
        public static DataTable GetAllLicense()
        {
            return clsPersonData.GetAllPeople("Select * From Licenses");
        }

        // The Only method To Get Licenses For Each Driver is By it's ID
        public static DataTable GetAllLicensesForDriver(int DriverID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"Select Licenses.LicenseID , Licenses.ApplicationID , LicenseClasses.ClassName , 
            Licenses.IssueDate , Licenses.ExpirationDate , Licenses.IsActive 
            From Licenses
            join LicenseClasses on Licenses.LicenseClass = 
            LicenseClasses.LicenseClassID
            Where DriverID = @DriverID 
            Order By IsActive , ExpirationDate Desc";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
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
            return dt;
        }
        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass,
        DateTime IssueDate, DateTime ExpirationDate, string Notes,
        decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int NewID = -1;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"INSERT INTO Licenses(
                        ApplicationID,
                        DriverID,
                        LicenseClass,
                        IssueDate,
                        ExpirationDate,
                        Notes,
                        PaidFees,
                        IsActive,
                        IssueReason,
                        CreatedByUserID)
                    VALUES
                    (
    @ApplicationID ,  @DriverID , @LicenseClass, @IssueDate , @ExpirationDate , 
	@Notes , @PaidFees , @IsActive , @IssueReason , @CreatedByUserID
                    ); SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            cmd.Parameters.AddWithValue("@IssueDate", ApplicationID);
            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            if (Notes != null)
                cmd.Parameters.AddWithValue("@Notes", Notes);
            else
                cmd.Parameters.AddWithValue("@Notes", DBNull.Value);


            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                conn.Open();
                object res = cmd.ExecuteScalar();
                if (res != null && int.TryParse(res.ToString(), out int InsertedID))
                    NewID = InsertedID;
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
            return NewID;
        }

        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID,
        int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
        bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = new SqlConnection(clsConfig.connectionString))
            {
                //string Query = @"Insert into People(FirstName , SecondName , ThirdName , LastName , NationalNo , DateOfBirth,
                //                Gendor , Address , Phone , Email , NationalityCountryID , ImagePath)
                //Values(@Fn,@Sn,@Tn,@Ln,@NNo,@DOB,@Gen,@Add,@Ph,@Em,@NCid,@img);
                //SELECT SCOPE_IDENTITY();";

                String Query = @"Update Licenses Set ApplicationID = @ApplicationID ,
                DriverID = @DriverID , LicenseClass = @LicenseClass , 
                IssuseDate = @IssueDate  , ExpirationDate = @ExpirationDate , Notes = @Notes,
                IsActive = @IsActive , IssueReason = @IssueReason , 
                PaidFees = @PaidFees , CreatedByUserID = @CreatedByUserID 
                Where LicenseID = @LicenseID";
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                    cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    cmd.Parameters.AddWithValue("@DriverID", DriverID);
                    cmd.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                    cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
                    cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    if (Notes != null)
                        cmd.Parameters.AddWithValue("@Notes", Notes);
                    else
                        cmd.Parameters.AddWithValue("@Notes", DBNull.Value);


                    cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);
                    cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        conn.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex.Message, "Error !",
                        MessageBoxButtons.OK,MessageBoxIcon.Error);
                        conn.Close();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

            }
            return rowsAffected > 0;
        }
        public static bool DeleteLicense(int LicenseID)
        {
            int rowsAffected = 0;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string Query = "Delete From Licenses Where LicenseID = @LicenseID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                conn.Open();

                rowsAffected += cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error !", MessageBoxButtons.OK,
MessageBoxIcon.Error);
                conn.Close();
            }
            finally
            {
                conn.Close();
            }
            return rowsAffected > 0;
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            int LicenseID = -1;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"Select LicenseID from Licenses join
            Drivers on Licenses.DriverID = Drivers.DriverID
            Where Drivers.PersonID = @PersonID AND Licenses.LicenseClass = @LicenseClassID";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                conn.Open();
                object res = cmd.ExecuteScalar();
                if (res != null && int.TryParse(res.ToString(), out int InsertedID))
                    LicenseID = InsertedID;
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

            return LicenseID;
        }

        // This is Generic Method To Update The Activation State Of License By Activation 
        // Or DeActivation 
        public static bool UpdateLicenseState(int LicenseID , byte state)
        {
            int rowsAffected = 0;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"Update Licenses Set IsActive = @state 
            Where LicenseID = @LicenseID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@state" , state);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

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
    }

}
