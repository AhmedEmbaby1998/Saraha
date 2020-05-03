using System.Collections.Generic;
using SimpleSaraha.Models.Entities;

namespace Embaby.Models.Repositeries
{
    public interface IUserRepo
    {
        bool AddNewUser(User user);
        void UpdateUser(User user);
        bool DeleteUser(int id);
        bool DeleteUser(string email);
        IEnumerable<User> GetAllUsers();
        IEnumerable<User> GetLastUsers(uint days);
        User GetUser(int id);
        User GetUser(string email);
        IEnumerable<Messaging> GetReceivedMessage(int id);
        IEnumerable<Messaging> GetReceivedMessage(string email);
    }
}