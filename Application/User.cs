using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Application
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }

        public int Role { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }

        public string Name { get; set; }
        public string SName{ get; set; }
        public string AboutMe { get; set; }

        

        //public User() { }

        public User(string email, string password, string login, string name, string sName)
        {
            Email = email;
            Password = password;
            Login = login;
            Role = 0;
            Name = name;
            SName = sName;
            AboutMe = AboutMe;
        }

        public User()
        {
            Id = TemporaryUser.Id;
            Email = TemporaryUser.Email;
            Password = TemporaryUser.Password;
            Login = TemporaryUser.Login;
            Role = TemporaryUser.Role;
            Name = TemporaryUser.Name;
            SName = TemporaryUser.SName;
            AboutMe = TemporaryUser.AboutMe;
        }
    }
}
