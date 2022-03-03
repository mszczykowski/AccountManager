using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Context;

namespace AccountManager.Services
{
    internal class UsersManagerService : IUsersManagerService
    {
        DataContext _context;

        public UsersManagerService(DataContext context)
        {
            _context = context;
        }

        public void AddUser(UserModel user)
        {
            _context.Users.Add(user);
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public void EditUser(int userId, UserModel user)
        {
            throw new NotImplementedException();
        }

        public ICollection<UserModel> GetAllUsers()
        {
            return _context.Users;
        }

        public UserModel GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public UserModel GetUser(string username)
        {
            UserModel user = null;

            foreach(var u in _context.Users)
            {
                if (u.Name == username) user = u;
            }

            return user;
        }
    }
}
