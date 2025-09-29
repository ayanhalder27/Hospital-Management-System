using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;


namespace Hospital_Management_System
{
    public class UserService
    {
        private readonly HospitalContext context = new HospitalContext();
        private readonly string photoFolder;
        private readonly string RoleName;

        public UserService()
        {
            photoFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Users");
            // Ensure folder exists
            if (!Directory.Exists(photoFolder))
            {
                Directory.CreateDirectory(photoFolder);
            }
        }
        public void UpdateUser(User updatedUser)
        {
            try
            {
                var existingUser = context.Users.FirstOrDefault(u => u.UserID == updatedUser.UserID);
                if (existingUser != null)
                {
                    existingUser.FullName = updatedUser.FullName;
                    existingUser.Username = updatedUser.Username;
                    existingUser.Email = updatedUser.Email;
                    existingUser.PhoneNumber = updatedUser.PhoneNumber;
                    existingUser.Address = updatedUser.Address;
                    existingUser.Gender = updatedUser.Gender;
                    existingUser.DOB = updatedUser.DOB;
                    existingUser.Photo = updatedUser.Photo;

                    if (existingUser.RoleID == 4) // Doctor
                    {
                        existingUser.Specialization = updatedUser.Specialization;
                        existingUser.Visit_Fee = updatedUser.Visit_Fee;
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating user profile: " + ex.Message);
            }
        }

        public List<Role> GetRoles()
        {
            return context.Roles.Where(r => r.RoleID != 5).ToList();
        }
        // Get users (with optional filters)
        public List<object> GetUsers(bool isPatientView, int? roleId = null, string searchText = null)
        {
            try
            {
                var query = context.Users.AsQueryable();
                // Patient view
                if (isPatientView)
                {
                    query = query.Where(u => u.RoleID == 5 && u.Status == true);
                }
                else
                {
                    // Always exclude patients in employee view
                    query = query.Where(u => u.RoleID != 5 && u.Status == true);

                    // Role filter (only apply if roleId is provided)
                    if (roleId.HasValue)
                    {
                        query = query.Where(u => u.RoleID == roleId.Value);
                    }
                }

                // Search filter
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    searchText = searchText.ToLower();

                    query = query.Where(u =>
                        u.UserID.ToString().Contains(searchText) ||
                        u.Username.ToLower().Contains(searchText) ||
                        u.FullName.ToLower().Contains(searchText) ||
                        u.PhoneNumber.ToLower().Contains(searchText) ||
                        u.Email.ToLower().Contains(searchText) ||
                        u.Address.ToLower().Contains(searchText) ||
                        u.Role.RoleName.ToLower().Contains(searchText) ||
                        u.Gender.ToLower().Contains(searchText) ||
                        u.DOB.ToString().Contains(searchText) ||
                        (u.Specialization != null && u.Specialization.ToLower().Contains(searchText))
                    );
                }
                return query.Select(u => new
                {
                    u.UserID, RoleName = u.Role.RoleName,u.Username,u.FullName,u.Email,u.PhoneNumber,u.Address,u.Gender,u.DOB,u.Specialization,u.Visit_Fee}).ToList<object>();
                }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving users: " + ex.Message);
            }
        }

        public bool IsEmailExists(string email, int? excludeUserId = null)
        {
            return context.Users.Any(u => u.Email == email && (!excludeUserId.HasValue || u.UserID != excludeUserId.Value));
        }

        public bool IsPhoneExists(string phone, int? excludeUserId = null)
        {
            return context.Users.Any(u => u.PhoneNumber == phone && (!excludeUserId.HasValue || u.UserID != excludeUserId.Value));
        }

        public string SaveProfilePicture(string sourceFilePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sourceFilePath) || !File.Exists(sourceFilePath))
                    return null;

                string fileName = Path.GetFileName(sourceFilePath);

                // Set destination folder inside your project Resources/Users
                string photoFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Users");

                // Make sure the folder exists
                if (!Directory.Exists(photoFolder))
                    Directory.CreateDirectory(photoFolder);

                string destPath = Path.Combine(photoFolder, fileName);

                // Handle duplicate file names
                int count = 1;
                string fileNameOnly = Path.GetFileNameWithoutExtension(fileName);
                string extension = Path.GetExtension(fileName);

                while (File.Exists(destPath))
                {
                    string newFileName = $"{fileNameOnly}({count}){extension}";
                    destPath = Path.Combine(photoFolder, newFileName);
                    count++;
                }

                // Copy file
                File.Copy(sourceFilePath, destPath);

                // Easy relative path for .NET Framework: remove BaseDirectory part manually
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string relativePath = destPath.StartsWith(baseDir) ? destPath.Substring(baseDir.Length) : destPath;

                return relativePath.Replace("\\", "/"); // normalize slashes
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving profile picture: " + ex.Message);
            }
        }


    }
}
