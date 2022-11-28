using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class TemporaryUser
    {
        public static string Id;

        public static int Role;

        public static string Email;
        public static string Password;
        public static string Login;

        public static string Name;
        public static string SName;
        public static string AboutMe;

        public static string ImagePath;

        public TemporaryUser() { }

        public TemporaryUser(User user)
        {
            Email = user.Email;
            Password = user.Password;
            Login = user.Login;
            Role = user.Role;
            Name = user.Name;
            SName = user.SName;
            AboutMe = user.AboutMe;
        }
    }
}
