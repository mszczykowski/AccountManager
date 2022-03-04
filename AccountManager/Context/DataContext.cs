using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Models;

namespace AccountManager.Context
{
    internal class DataContext
    {
        public List<UserModel> Users { get; set; }
        public DataContext()
        {
            Initialize();
        }

        public void Initialize()
        {
            Users = new List<UserModel>
            {
                new AdminModel("admin", "admin"),
                new StandarUser("user1", "user1"),
                new StandarUser("user2", "user1"),
                new StandarUser("user3", "user1")
            };
        }
    }
}
