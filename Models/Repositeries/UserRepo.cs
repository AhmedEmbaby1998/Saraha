using System;
using System.Collections.Generic;
using System.Linq;
using Embaby.Models.BusinessLogic.Accounts;
using Microsoft.EntityFrameworkCore;
using SimpleSaraha.Models.Entities;

namespace Embaby.Models.Repositeries
{
    public class UserRepo:IUserRepo
    {
        private readonly SarahaContext _context;
        private readonly  ValidateUser _validateUser;

        public UserRepo(SarahaContext context, ValidateUser validateUser)
        {
            _context = context;
            _validateUser = validateUser;
        }
        
        public bool AddNewUser(User user)
        {
            _validateUser.Validate(user);
            return !_validateUser.IsValid ? _validateUser.IsValid : _context.InsertNewUser(user.Name, user.Email, user.Password);
        }
        
        public void  UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public bool DeleteUser(int id)=>_context.DeleteUser(id);
      
        public bool DeleteUser(string email)=>_context.DeleteUser(email);

        public IEnumerable<User> GetAllUsers()=>_context.Users.AsNoTracking().ToList()
            .OrderByDescending(user=>user.RegisteringDateTime);

        public IEnumerable<User> GetLastUsers(uint days) =>
            _context.Users.Where(user => user.RegisteringDateTime.AddDays(days)>=(DateTime.Now));

        public User GetUser(int id)=>_context.Users.Find(id);

        public User GetUser(string email) => _context.Users.Where(user => user.Email == email).FirstOrDefault();
        public IEnumerable<Messaging> GetReceivedMessage(int id)
        {
            return _context.Messagings
                .Include(messaging => messaging.Message)
                .Include(messaging => messaging.Receiver)
                .Where(messaging => messaging.Receiver.Id==id)
                .OrderByDescending(messaging => messaging.DateSending);
        }

        public IEnumerable<Messaging> GetReceivedMessage(string email)
        {
            return _context.Messagings
                .Include(messaging => messaging.Message)
                .Include(messaging => messaging.Receiver)
                .Where(messaging => messaging.Receiver.Email==email)
                .OrderByDescending(messaging => messaging.DateSending);
        }
    }
}