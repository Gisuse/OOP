using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class User
    {
        public int id { get; set; }

        public int role { get; set; }

        public string email { get; set; }
        public string password { get; set; }
        public string login { get; set; }

        public User() { }

        public User(string email, string password, string login)
        {
            this.role = role;
            this.email = email;
            this.password = password;
            this.login = login;
            this.role= 0;
        }
    }
}
