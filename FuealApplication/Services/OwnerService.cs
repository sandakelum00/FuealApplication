using FuealApplication.Models;
using MongoDB.Driver;
using static System.Collections.Specialized.BitVector32;

namespace FuealApplication.Services
{
    public class OwnerService : IOwnerServices
    {
        private readonly IMongoCollection<Owner> _owners;

        public OwnerService(IStationStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _owners = database.GetCollection<Owner>(settings.CollectionName2);
        }

        public Owner CreateOwner(Owner owner)
        {
            //throw new NotImplementedException();
            owner.Password = BCrypt.Net.BCrypt.HashPassword(owner.Password);
            _owners.InsertOne(owner);
            return owner;
        }

        public Owner AuthenticatePassword(string password)
        {
            //throw new NotImplementedException();
            return _owners.Find(owner => owner.Password == password).FirstOrDefault();
        }

        public Owner AuthenticateUsername(string username)
        {
            //throw new NotImplementedException();
            return _owners.Find(owner => owner.UserName == username).FirstOrDefault();
        }

        public Owner GetOwner(string id)
        {
            //throw new NotImplementedException();
            return _owners.Find(owner => owner.Id == id).FirstOrDefault();
        }

        public List<Owner> GetOwners()
        {
            //throw new NotImplementedException();
            return _owners.Find(owner => true).ToList();
        }

        public void RemoveOwner(string id)
        {
            //throw new NotImplementedException();
            _owners.DeleteOne(owner => owner.Id == id);
        }

        public void UpdateOwner(string id, Owner owner)
        {
            //throw new NotImplementedException();
            _owners.ReplaceOne(owner => owner.Id == id, owner);
        }

    }
}
