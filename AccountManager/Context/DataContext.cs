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
            Users = new List<UserModel>
            {
                new AdminModel("admin", "admin")
            };
        }
    }
}
