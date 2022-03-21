using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Context;
using System.Data.SqlClient;

namespace AccountManager.Services
{
    internal class UsersManagerDatabaseService : IUsersManagerService
    {
        private DatabaseConnection _databaseConnection;

        public UsersManagerDatabaseService(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public void AddStandardUser(UserModel user)
        {
            
            string query = "insert into [User] (Name, Password, Role)"
                + "values ('" + user.Name + "', '" + user.Password + "', '1');";

            _databaseConnection.ExecuteDML(query);
        }

        public void DeleteUser(int id)
        {
            string query = "delete from [User] "
                + "where id = '" + id + "'";

            _databaseConnection.ExecuteDML(query);
        }

        public void EditUser(int id, UserModel user)
        {
            string query = "update [User] "
                         + "set name = '" + user.Name + "', password = '" + user.Password + "' "
                         + "where id = '" + id + "'";

            _databaseConnection.ExecuteDML(query);
        }

        public ICollection<UserModel> GetAllUsers()
        {
            string query = "select * "
                          + "from [User];";

            List<UserModel> users = new List<UserModel>();

            List<object[]> dbResult = _databaseConnection.ExecuteDQL(query);

            dbResult.ForEach(result =>
            {
                users.Add(CreateUserModel(result));
            });

            return users;
        }

        public UserModel GetUser(int userId)
        {
            string query = "select * "
                          + "from [User] u "
                          + "where u.id = '" + userId + "'";

            List<object[]> dbResult = _databaseConnection.ExecuteDQL(query);

            return (CreateUserModel(dbResult[0]));
        }

        public UserModel GetUser(string? username)
        {
            string query = "select * "
                          + "from [User] u "
                          + "where upper(u.name) = '" + username + "'";

            List<object[]> dbResult = _databaseConnection.ExecuteDQL(query);

            if (dbResult.Count <= 0) return null;

            return (CreateUserModel(dbResult[0]));
        }

        private UserModel CreateUserModel(object[] row)
        {
            if (Convert.ToInt32(row[row.Length - 1]) == 2)
            {
                return new AdminModel(Convert.ToInt32(row[0]),
                    row[1].ToString(), row[2].ToString());
            }
            else
            {
                return new StandardUserModel(Convert.ToInt32(row[0]),
                    row[1].ToString(), row[2].ToString());
            }

            return null;
        }
    }
}
