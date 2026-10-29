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
    public static class clsUserData
    {
        // This Function Will Be Reusabled in the whole of DALs
        public static DataTable GetAllUsers()
        {
            return clsPersonData.GetAllPeople(@"Select u.UserID , p.PersonID , 
            CONCAT_WS( ' ', p.FirstName,p.LastName) as FullName , UserName , Password , IsActive 
            From Users u Inner Join People p on p.PersonID = u.PersonID");
        }

        public static int AddNewUser(string UserName , string Password ,int PersonID)
        {
            int newID = -1;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string Query = @"Insert Into Users (PersonID , UserName , Password) Values 
                            (@PersonID ,@UserName , @Password)
                            SELECT SCOPE_IDENTITY();";


            SqlCommand cmd = new SqlCommand(Query, conn);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);

            try
            {
                conn.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                    newID = Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :-( ", "Error " + ex.Message, MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            return newID;
        }

        // This Method Will Be Reusabled in the whole of the project classes in DAL

        public static int GetCountOfUsers(string query = "SELECT COUNT(*) FROM Users")
        {
            int cnt = 0;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cnt += (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :-( " , "Error " + ex.Message , MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            }
            finally
            {
                conn.Close();
            }

            return cnt;
        }
        public static bool ChangePassword(string UserName, string Password)
        {
            int rowsAffected = 0;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = "Update Users Set Password = @pass where UserName = @uname";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@pass", Password);
            cmd.Parameters.AddWithValue("@uname", UserName);
            try
            {
                conn.Open();
                rowsAffected += cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return rowsAffected > 0;
        }
        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"Delete From Users Where UserID = @uid";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@uid", UserID);
            try
            {
                conn.Open();
                rowsAffected += cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
            finally
            {
                conn.Close();
            }
            return rowsAffected > 0;
        }
        public static bool GetUserInfoByUserNameANDPassword(string UserName, string Password,
        ref int UserID , ref int PersonID , ref bool isActive)
        {
            bool found = false;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string Query = @"Select * From Users Where UserName = @uname AND Password = @pass";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@uname", UserName);
            cmd.Parameters.AddWithValue("@pass", Password);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    found = true;
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    isActive = (bool)reader["IsActive"];
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
        public static bool GetUserInfoByUserID(int UserID , ref string UserName , 
            ref string Password , ref bool IsActive , ref int PersonID)
        {
            bool found = false;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            String Query = @"Select * From Users Where UserID = @UserID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    found = true;
                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];
                }
            }
            catch(Exception ex)
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
        public static bool isUserNameExists(string UserName)
        {
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"SELECT FOUND = 1 From Users Where UserName = @un";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@un", UserName);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error " + ex.Message , "Error !" , MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public static bool isUserExists(string UserName, string Password)
        {
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"Select Found = 1 From Users Where UserName = @uname AND Password = @pass AND isActive = 1";
            SqlCommand cmd = new SqlCommand(query, conn);cmd.Parameters.AddWithValue("@uname", UserName);
            cmd.Parameters.AddWithValue("@pass", Password);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public static bool ChangePermissions(int UserID , byte val)
        {
            int rowsAffected = 0;
            SqlConnection conn = new SqlConnection(clsConfig.connectionString);
            string query = @"Update Users Set IsActive = @val Where UserID = @uid";
            SqlCommand cmd = new SqlCommand(query, conn);cmd.Parameters.AddWithValue("@val", val);
            cmd.Parameters.AddWithValue("@uid", UserID);

            try
            {
                conn.Open();
                rowsAffected += cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();   
            }
            return rowsAffected > 0;
        }
    }
}
