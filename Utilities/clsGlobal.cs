using Driving_License_Management_System.DVLD_Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Configuration.Internal;
namespace Driving_License_Management_System.Utilities
{
    internal static class clsGlobal
    {
        public static clsUser CurrentUser;

        public static bool RememberUserNameAndPassword(string UserName, string Password)
        {
            try
            {
                // This Will Get Current Directory Of This File 
                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();
                string filepath = CurrentDirectory + "\\data.txt";
                // In Case Of Empty User Name Delete The Text File
                if (UserName == "" && File.Exists(filepath))
                {
                    File.Delete(filepath); return true;
                }
                string datatosave = UserName + "#//#" + Password;

                using (StreamWriter wr = new StreamWriter(filepath))
                {
                    wr.WriteLine(datatosave);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error!", $"An Error Occured : {ex.Message}", MessageBoxButtons.OK,
                    MessageBoxIcon.Error); return false;
            }
        }
        public static bool GetStoredCredential(ref string UserName, ref String Password)
        {
            try
            {
                string CurrentDirectory = Directory.GetCurrentDirectory();
                string filepath = CurrentDirectory + "\\data.txt";

                if (File.Exists(filepath))
                {
                    using (StreamReader reader = new StreamReader(filepath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                            string[] res = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            UserName = res[0]; Password = res[1];
                        }
                        return true;
                    }

                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error!", $"An Error Occured : {ex.Message}", MessageBoxButtons.OK,
                   MessageBoxIcon.Error); return false;
            }
        }
        public static string GenerateGUID()
        {
            Guid newGuid = Guid.NewGuid();
            return newGuid.ToString();
        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath); return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error!", $"An Error Occured : {ex.Message}", MessageBoxButtons.OK,
                  MessageBoxIcon.Error); return false;
                }
            }
            else
                return false;
        }
        public static string ReplaceFileNameWithGuid(string SourceFile)
        {
            string FileName = SourceFile;
            FileInfo fi = new FileInfo(FileName);
            string extn = fi.Extension; 
            return GenerateGUID() + extn;
        }

        public static bool CopyFileImageToProjectFolder(ref String SourceFile)
        {
            string DestinationFolder = @"C:Driving License Management System\People\Images";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }
            string destinationfile = DestinationFolder + ReplaceFileNameWithGuid(SourceFile);
            // To Be Achieved in The UI File Name Not In The Scope Of The Program
            try
            {
                File.Copy(SourceFile, destinationfile, true);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error!", $"An Error Occured : {ex.Message}", MessageBoxButtons.OK,
                MessageBoxIcon.Error); return false;
            }
            SourceFile = destinationfile;
            return true;
        }
    }
}
