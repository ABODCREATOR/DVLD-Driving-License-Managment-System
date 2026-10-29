//using Driving_License_Management_System.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using DT = System.Data.DataTable;

namespace Driving_License_Management_System.DataAccess
{
    public class clsCountryData
    {
        public static bool GetCountryInfoByID(int ID,ref String CountryName ,  string query
         = "Select * From Countries Where CountryID = @CountryID")
        {
            bool found = false;
            SqlConnection connection = new SqlConnection(clsConfig.connectionString);

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CountryID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    found = true;
                    CountryName = (String)reader["CountryName"];
                    ID = (int)reader["CountryID"];
                }
                else found = false;
                    reader.Close();
            }
            catch (Exception ex)
            {
                found = false;
                connection.Close();
            }
            finally
            {
                connection.Close();
            }
            return found;
        }

        public static bool GetCountryInfoByName(ref int ID,  String CountryName
         , string query = "Select * From Countries Where CountryName = @CountryName")
        {
            bool found = false;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    found = true;
                    ID = (int)reader["CountryID"];
                    CountryName = (string)reader["CountryName"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                found = false;
                conn.Close();
            }
            finally { conn.Close(); }
            return found;
        }

        public static DT GetAllCountries()
        {
            DT dt = new DT();

            SqlConnection conn = new SqlConnection(clsConfig.connectionString);

            string query = "SELECT CountryName FROM Countries ORDER BY CountryName";

            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) dt.Load(reader);

                conn.Close();
            }
            catch(Exception ex) {
            
                
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
    }
}
