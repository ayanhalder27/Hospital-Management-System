using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System
{
    public class Check_login_authorization
    {
        private readonly HospitalContext context;
        public Check_login_authorization() 
        {
            context = new HospitalContext();
        }
        public User Login(string userInput, string password)
        {
            try
            {
                var user = context.Users.FirstOrDefault(u =>(u.UserID.ToString() == userInput ||u.Username == userInput ||u.Email == userInput ||u.PhoneNumber == userInput) && u.Password == password);
                if (user != null && user.Status == true)
                {
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while logging in: " + ex.Message);
            }
        }
    }
}
