using FuealApplication.Models;

namespace FuealApplication.Services
{
    public interface IOwnerServices
    {
        List<Owner> GetOwners();
        Owner GetOwner(string id);
        Owner CreateOwner(Owner owner);
        void UpdateOwner(string id, Owner owner);
        void RemoveOwner(string id);
        Owner AuthenticateUsername(string username);
        Owner AuthenticatePassword(string password);
    }
}
