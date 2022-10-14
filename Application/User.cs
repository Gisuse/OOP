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

        public User() { }

        public User(string email, string password, string login)
        {
            this.Email = email;
            this.Password = password;
            this.Login = login;
            this.Role = 0;
        }
    }
}
