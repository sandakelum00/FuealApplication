using FuealApplication.Models;

namespace FuealApplication.Services
{
    public interface IUserServices
    {
        List<User> GetUsers();
        User GetUser(string id);
        User CreateUser(User user);
        void UpdateUser(string id, User user);
        void RemoveUser(string id);
    }
}
