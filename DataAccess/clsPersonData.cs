using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driving_License_Management_System.DataAccess
{
    public static class clsPersonData
    {
        public static DataTable GetAllPeople(
            String Query = @"SELECT PersonID, NationalNo , FirstName , SecondName , ThirdName , LastName ,  DateOfBirth , 
                             CASE WHEN Gendor = 0 THEN 'Male' ELSE 'Female' End as Gendor ,Address , Phone , Email FROM 
                            People Order by FirstName")
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);

            

            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    if(reader.HasRows)
                    dt.Load(reader);
                    
                    reader.Close();
                }
                catch (Exception ex)
                {
                    conn.Close();
                }
                finally
                {
                    conn.Close();
                }
            }

            return dt;
        }
        public static bool GetPeopleInfoByID(int PersonID, ref string FirstName, ref string SecondName
 , ref string ThirdName, ref String LastName, ref String NationalNo, ref DateTime DateOfBirth, ref short Gendor,
 ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref String ImagePath
 )
        {
            bool found = false;
            using (SqlConnection conn = new SqlConnection(clsConfig.connectionString))
            {
                String Query = "SELECT * FROM People Where PersonID = @Pid";
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.Parameters.AddWithValue("@Pid", PersonID);
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            found = true;
                            FirstName = (string)reader["FirstName"];
                            SecondName = (string)reader["SecondName"];

                            if (reader["ThirdName"] != DBNull.Value)
                                ThirdName = (string)reader["ThirdName"];
                            else
                                ThirdName = "";

                            LastName = (string)reader["LastName"];
                            NationalNo = (string)reader["NationalNo"];

                            DateOfBirth = (DateTime)reader["DateOfBirth"];

                            Gendor = Convert.ToInt16(reader["Gendor"]);
                            Address = (string)reader["Address"];
                            Phone = (string)reader["Phone"];

                            if (reader["Email"] != DBNull.Value)
                                Email = (string)reader["Email"];
                            else
                                Email = "";

                            NationalityCountryID = (int)reader["NationalityCountryID"];

                            if (reader["ImagePath"] != DBNull.Value)
                                ImagePath = (string)reader["ImagePath"];
                            else
                                ImagePath = "";
                        }
                        else
                        {
                            found = false;
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        found = false;
                    }
                }
            }
            return found;
        }
        public static bool GetPersonInfoByNationalNo(String NationalNo, ref int PersonID, ref String FirstName,
        ref string SecondName, ref String ThirdName, ref String LastName, ref DateTime DateOfBirth, ref short Gendor, ref String Address,
        ref string Phone, ref String Email,ref int NationalityCountryID, ref String ImagePath)
        {
            bool found = false;
            using (SqlConnection conn = new SqlConnection(clsConfig.connectionString))
            {

                String Query = "SELECT * FROM People Where NationalNo = @NNo";
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.Parameters.AddWithValue("@NNo", NationalNo);
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            // If That Condititon is True The Query Finds The Person and Mark Flag of Found = 1
                            found = true;
                            // Every Implicit Assignment With DataReader Without Check Condition 
                            // To Make Sure That The Entities Doesn't Accept Any Null Values in The DataBase
                            FirstName = (string)reader["FirstName"];
                            SecondName = (string)reader["SecondName"];
                            if (reader["ThirdName"] != DBNull.Value)
                            {
                                ThirdName = (string)reader["ThirdName"];
                            }
                            else ThirdName = "";
                            LastName = (string)reader["LastName"];
                            NationalNo = (string)reader["NationalNo"];
                            DateOfBirth = (DateTime)reader["DateTime"];
                            Gendor = (byte)reader["Gendor"];
                            Address = (string)reader["Address"];
                            Phone = (string)reader["Phone"];
                            if (reader["Email"] != DBNull.Value)
                            {
                                Email = (string)reader["Email"];
                            }
                            else Email = "";
                            NationalityCountryID = (int)reader["NationalityCountryID"];
                            if (reader["ImagePath"] != DBNull.Value)
                            {
                                ImagePath = (string)reader["ImagePath"];
                            }
                            else ImagePath = "";
                            reader.Close();
                        }
                        else found = false;
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return found;
        }
        // not completed
        public static int AddNewPerson(string FirstName, string SecondName, string ThirdName, string LastName,
        string NationalNo, DateTime DateOfBirth, short Gendor, string Address, string Phone, string Email,
        int NationalityCountryId, string ImagePath)
        {

            // This Function Will Return a Person ID if succeeded and -1 if not.
            int PersonID = -1;
            using (SqlConnection conn = new SqlConnection(clsConfig.connectionString))
            {
                string Query = @"Insert into People(NationalNo,FirstName , SecondName , ThirdName , LastName , DateOfBirth,
                                Gendor , Address , Phone , Email , NationalityCountryID , ImagePath)
                Values(@NNo,@Fn,@Sn,@Tn,@Ln,@DOB,@Gen,@Add,@Ph,@Em,@NCid,@img);
                SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.Parameters.AddWithValue("@NNo", NationalNo);
                    cmd.Parameters.AddWithValue("@Fn", FirstName);
                    cmd.Parameters.AddWithValue("@Sn", SecondName);
                    if (ThirdName != "" && ThirdName != null)
                        cmd.Parameters.AddWithValue("@Tn", ThirdName);
                    else
                        cmd.Parameters.AddWithValue("@Tn", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Ln", LastName);
                    cmd.Parameters.AddWithValue("@DOB", DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gen", Gendor);
                    cmd.Parameters.AddWithValue("@Add", Address);
                    cmd.Parameters.AddWithValue("@Ph", Phone);
                    cmd.Parameters.AddWithValue("@Em", Email);
                    cmd.Parameters.AddWithValue("@NCid", NationalityCountryId);

                    if (ImagePath != "" && ImagePath != null)
                        cmd.Parameters.AddWithValue("@img", ImagePath);
                    else
                        cmd.Parameters.AddWithValue("@img", DBNull.Value);

                    try
                    {
                        conn.Open();

                        object res = cmd.ExecuteScalar();
                        if (res != null && int.TryParse(res.ToString(), out int InsertedId))
                            PersonID = InsertedId;
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return PersonID;
        }
        public static bool UpdatePerson(int PersonID, string FirstName, string SecondName, string ThirdName,
 string LastName, string NationalNo, DateTime DateOfBirth, short Gendor, string Address, string Phone
 , string Email, int NationalityCountryId, string ImagePath)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = new SqlConnection(clsConfig.connectionString))
            {
                String Query = @"Update People Set FirstName = @Fn,
                        SecondName = @Sn, 
                        ThirdName = @Tn, 
                        LastName = @Ln,
                        NationalNo = @NNo, 
                        DateOfBirth = @DOB, 
                        Gendor = @Gen, 
                        Address = @Add, 
                        Phone = @Ph,
                        Email = @Em, 
                        NationalityCountryID = @NCid, 
                        ImagePath = @img
                        Where PersonID = @Pid";

                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.Parameters.AddWithValue("@Pid", PersonID);
                    cmd.Parameters.AddWithValue("@Fn", FirstName);
                    cmd.Parameters.AddWithValue("@Sn", SecondName);

                    if (ThirdName != "" && ThirdName != null)
                        cmd.Parameters.AddWithValue("@Tn", ThirdName);
                    else
                        cmd.Parameters.AddWithValue("@Tn", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Ln", LastName);
                    cmd.Parameters.AddWithValue("@NNo", NationalNo);
                    cmd.Parameters.AddWithValue("@DOB", DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gen", Gendor);
                    cmd.Parameters.AddWithValue("@Add", Address); 
                    cmd.Parameters.AddWithValue("@Ph", Phone);
                    cmd.Parameters.AddWithValue("@Em", Email);
                    cmd.Parameters.AddWithValue("@NCid", NationalityCountryId);

                    if (ImagePath != "" && ImagePath != null)
                        cmd.Parameters.AddWithValue("@img", ImagePath);
                    else
                        cmd.Parameters.AddWithValue("@img", DBNull.Value);

                    try
                    {
                        conn.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        rowsAffected = 0;
                    }
                }
            }
            return rowsAffected > 0;
        }
        public static bool DeletePerson(int Id)
        {
            int rowsAffected = 0;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string Query = "Delete From People Where PersonID = @Pid";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@Pid", Id);

            try
            {
                conn.Open();

                rowsAffected += cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return rowsAffected > 0;   
    }
        public static bool IsPersonExist(int PersonID)
        {
            bool found = false;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string Query = "Select Found = 1 From People Where PersonID = @Pid";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@Pid", PersonID);

            try
            {
                conn.Open() ;SqlDataReader reader = cmd.ExecuteReader();
                found = reader.HasRows;
                reader.Close();
            }
            catch(Exception ex) { found = false; }
            finally
            {
                conn.Close();
            }
            return found;
        }
        public static bool IsPersonExist(string NationalNo)
        {
            bool found = false;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string Query = "Select Found = 1 From People Where NationalNo = @NNo";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@NNo", NationalNo);

            try
            {
                conn.Open(); SqlDataReader reader = cmd.ExecuteReader();
                found = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { found = false; }
            finally
            {
                conn.Close();
            }
            return found;
        }
    }
}
