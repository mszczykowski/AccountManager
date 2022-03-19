using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Models;

namespace AccountManager.Services
{
    internal interface IUsersManagerService
    {
        public void AddUser(UserModel user);
        public void DeleteUser(int id);
        public void EditUser(int id, UserModel user);
        public UserModel GetUser(int userId);
        public UserModel GetUser(string? username);
        public ICollection<UserModel> GetAllUsers();
    }
}
