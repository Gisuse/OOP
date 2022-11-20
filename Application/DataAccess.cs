using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Application
{
    public class DataAccess
    {
        private const string ConnectionString = "mongodb+srv://root:root@cluster0.s5psbuq.mongodb.net/test";
        private const string DBName = "Chemistry";
        private const string UserConnection = "users";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DBName);

            return db.GetCollection<T>(collection);
        }

        private async Task<List<User>> GetAllUsers()
        {
            var UserCollection = ConnectToMongo<User>(UserConnection);
            var results = await UserCollection.FindAsync(_ => true);

            return results.ToList();
        }

        public Task CreateUser(User user)
        {
            var UserCollection = ConnectToMongo<User>(UserConnection);
            return UserCollection.InsertOneAsync(user);
        }

        public Task CreateMaterials(Materials materials)
        {
            var UserCollection = ConnectToMongo<Materials>("Materials");
            return UserCollection.InsertOneAsync(materials);
        }

        public async Task<List<User>> FindUser(string email, string password)
        {
            var UserCollection = ConnectToMongo<User>(UserConnection);
            var people = await UserCollection.Find(user => user.Email == email && user.Password == password).ToListAsync();
            return people;
        }

        public Task UpdateUser(User user)
        {
            var UserCollection = ConnectToMongo<User>(UserConnection);
            var filter = Builders<User>.Filter.Eq("Id", user.Id);

            return UserCollection.ReplaceOneAsync(filter, user);
        }
    }
}
