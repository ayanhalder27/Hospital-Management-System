using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System
{
    public class UserService
    {
        private readonly HospitalContext context;

        public UserService()
        {
            context = new HospitalContext();
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
    }
}
