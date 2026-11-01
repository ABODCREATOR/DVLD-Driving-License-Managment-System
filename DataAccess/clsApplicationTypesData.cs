using System;
using System.Data;
using System.Data.SqlClient;

namespace Driving_License_Management_System.DataAccess
{
    public class clsApplicationTypesData
    {
        public static bool GetApplicationInfoByID(int ApplicationTypeID, ref string ApplicationTypeTitle, ref float ApplicationFees)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsConfig.connectionString))
            {
                string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                                ApplicationFees = Convert.ToSingle(reader["ApplicationFees"]);
                            }
                            else
                            {
                                isFound = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsConfig.connectionString))
            {
                string query = @"SELECT ApplicationTypeID, ApplicationTypeTitle, ApplicationFees 
                                 FROM ApplicationTypes 
                                 ORDER BY ApplicationTypeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception if needed
                    }
                }
            }

            return dt;
        }

        public static int AddNewApplicationType(string Title, float fees)
        {
            int ApplicationTypeID = -1;

            using (SqlConnection connection = new SqlConnection(clsConfig.connectionString))
            {
                string query = @"INSERT INTO ApplicationTypes (ApplicationTypeTitle, ApplicationFees)
                                 VALUES (@Title, @Fees);
                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Fees", fees);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            ApplicationTypeID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        ApplicationTypeID = -1;
                    }
                }
            }

            return ApplicationTypeID;
        }

        public static bool UpdateApplicationType(int ApplicationTypeID, string Title, float fees)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsConfig.connectionString))
            {
                string query = @"UPDATE ApplicationTypes
                                 SET ApplicationTypeTitle = @Title,
                                     ApplicationFees = @Fees
                                 WHERE ApplicationTypeID = @ApplicationTypeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Fees", fees);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        rowsAffected = 0;
                    }
                }
            }

            return (rowsAffected > 0);
        }
    }
}
