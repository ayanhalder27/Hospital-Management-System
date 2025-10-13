using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


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

        public List<object> GetUsers(bool isPatientView, int? roleId = null, string searchText = null)
        {
            try
            {
                var query = context.Users.AsQueryable();
                if (isPatientView)
                {
                    query = query.Where(u => u.RoleID == 5 && u.Status == true);
                }
                else
                {
                    query = query.Where(u => u.RoleID != 5 && u.Status == true);
                    if (roleId.HasValue)
                    {
                        query = query.Where(u => u.RoleID == roleId.Value);
                    }
                }

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

        public string SaveProfilePicture(string sourceFilePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sourceFilePath) || !File.Exists(sourceFilePath))
                    return null;

                string fileName = Path.GetFileName(sourceFilePath);

                // Set destination folder inside your project Documents
                string photoFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Documents");

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

        public (string username, string password) GenerateCredentials(string fullName, string email, string phone)
        {
            int nextId = (context.Users.Any() ? context.Users.Max(u => u.UserID) : 1000) + 1;
            string username = fullName.ToLower().Replace(" ", "") + nextId;

            string emailPrefix = email.Split('@')[0];
            string phoneSuffix = phone.Length >= 5 ? phone.Substring(phone.Length - 5) : phone;
            string password = emailPrefix + phoneSuffix;

            return (username, password);
        }

        public bool IsEmailUnique(string email)
        {
            return !context.Users.Any(u => u.Email == email);
        }

        public bool IsPhoneUnique(string phone)
        {
            return !context.Users.Any(u => u.PhoneNumber == phone);
        }

        public string ValidateUserInput(string fullName, string email, string phone, string address, string gender, DateTime? dob)
        {
            if (string.IsNullOrWhiteSpace(fullName) ||string.IsNullOrWhiteSpace(email) ||string.IsNullOrWhiteSpace(phone) ||string.IsNullOrWhiteSpace(address) ||string.IsNullOrWhiteSpace(gender) || !dob.HasValue)
            {
                return "All fields are required.";
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                return "Invalid email format.";
            }

            if (!Regex.IsMatch(phone, @"^0\d{10}$"))
            {
                return "Phone number must be 11 digits, start with '0', and contain only numbers.";
            }

            return null;
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            
        }

        public (bool Success, string ErrorMessage) CreateUser(string fullName, string email, string phone, string address,string gender, DateTime dob, int roleId, string specialization = null, double? visitFee = null, string photoPath = null)
        {
            string validationError = ValidateUserInput(fullName, email, phone, address, gender, dob);
            if (validationError != null)
            {
                return (false, validationError);
            }
            if (!IsEmailUnique(email))
            {
                return (false, "Email already exists.");
            }
            if (!IsPhoneUnique(phone))
            {
                return (false, "Phone number already exists.");
            }

            var (username, password) = GenerateCredentials(fullName, email, phone);

            var user = new User
            {
                FullName = fullName,
                Username = username,
                Email = email,
                PhoneNumber = phone,
                Address = address,
                Gender = gender,
                DOB = dob,
                Password = password,
                Status = true,
                RoleID = roleId,
                Specialization = specialization,
                Visit_Fee = visitFee,
                Photo = photoPath
            };
            AddUser(user);

            return (true, null);
        }

        public (bool Success, string ErrorMessage) UpdateUsers(int userId, string fullName, string email, string phone, string address,string gender, DateTime dob, string specialization = null, double? visitFee = null, string photoPath = null)
        {
            var user = context.Users.FirstOrDefault(u => u.UserID == userId && u.Status == true);
            if (user == null)
                return (false, "User not found.");

            string validationError = ValidateUserInput(fullName, email, phone, address, gender, dob);
            if (validationError != null)
                return (false, validationError);


            if (context.Users.Any(u => u.Email == email && u.UserID != userId))
                return (false, "Email already exists.");


            if (context.Users.Any(u => u.PhoneNumber == phone && u.UserID != userId))
                return (false, "Phone number already exists.");


            user.FullName = fullName;
            user.Email = email;
            user.PhoneNumber = phone;
            user.Address = address;
            user.Gender = gender;
            user.DOB = dob;
            user.Specialization = specialization;
            user.Visit_Fee = visitFee;


            if (!string.IsNullOrEmpty(photoPath))
            {
                user.Photo = photoPath;
            }

            context.SaveChanges();
            return (true, null);
        }

        public (bool Success, string ErrorMessage) DeleteUser(int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.UserID == userId && u.Status == true);
            if (user == null)
                return (false, "User not found or already deleted.");

            user.Status = false;  
            context.SaveChanges();

            return (true, null);
        }

        public User GetUserById(int userId)
        {
            return context.Users.FirstOrDefault(u => u.UserID == userId && u.Status == true);
        }
    }
}
