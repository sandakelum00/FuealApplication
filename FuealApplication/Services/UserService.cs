using FuealApplication.Models;
using MongoDB.Driver;

namespace FuealApplication.Services
{
    public class UserService : IUserServices
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IStationStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.CollectionName3);
        }
        public User CreateUser(User user)
        {
            //throw new NotImplementedException();
            _users.InsertOne(user);
            return user;
        }

        public User GetUser(string id)
        {
            //throw new NotImplementedException();
            return _users.Find(user => user.Id == id).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            //throw new NotImplementedException();
            return _users.Find(user => true).ToList();
        }

        public void RemoveUser(string id)
        {
            //throw new NotImplementedException();
            _users.DeleteOne(user => user.Id == id);
        }

        public void UpdateUser(string id, User user)
        {
            //throw new NotImplementedException();
            _users.ReplaceOne(user => user.Id == id, user);
        }
    }
}
