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
        private DataContext _context;
        private Random random;

        public UsersManagerService(DataContext context)
        {
            _context = context;

            random = new Random();
        }

        public void AddStandardUser(UserModel user)
        {
            user.Id = GenerateId();
            
            _context.Users.Add(user);
        }

        public void DeleteUser(int id)
        {
            _context.Users.Remove(GetUser(id));
        }

        public void EditUser(int id, UserModel user)
        {
            var editedUser = GetUser(id);
            editedUser.Name = user.Name;
            editedUser.Password = user.Password;
        }

        public ICollection<UserModel> GetAllUsers()
        {
            return _context.Users;
        }

        public UserModel GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public UserModel GetUser(string? username)
        {
            if (username == null) return null;
            
            UserModel user = null;

            foreach(var u in _context.Users)
            {
                if (u.Name == username) user = u;
            }

            return user;
        }


        private int GenerateId()
        {
            int id;

            bool isIdValid = true;
            do
            {
                id = random.Next();

                _context.Users.ForEach(p =>
                {
                    if (p.Id == id) isIdValid = false;
                });
            }
            while (!isIdValid);

            return id;
        }
    }
}
