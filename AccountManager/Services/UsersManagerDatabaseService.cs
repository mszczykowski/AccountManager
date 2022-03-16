using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Context;

namespace AccountManager.Services
{
    internal class UsersManagerDatabaseService : IUsersManagerService
    {
        private DatabaseConnection _databaseConnection;

        public UsersManagerDatabaseService(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public void AddUser(UserModel user)
        {
            string query = "insert into [User] (Name, Password, Role)"
                + "values ('" + user.Name + "', '" + user.Password + "', '0');";

            _databaseConnection.ExecuteDML(query);
        }

        public void DeleteUser(string name)
        {
            throw new NotImplementedException();
        }

        public void EditUser(string name, UserModel user)
        {
            throw new NotImplementedException();
        }

        public ICollection<UserModel> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserModel GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public UserModel GetUser(string? username)
        {
            throw new NotImplementedException();
        }
    }
}
