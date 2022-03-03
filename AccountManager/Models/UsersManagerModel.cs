using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Models
{
    internal class UsersManagerModel
    {
        public List<UserModel> Users { get; set; }
        public UsersManagerModel()
        {
            Users = new List<UserModel>
            {
                new UserModel("admin", "admin")
            };
        }

        public bool IsPasswordCorrect(UserModel user)
        {
            foreach (var u in Users)
            {
                if (string.Equals(u.Name, user.Name, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(u.Password, user.Password, StringComparison.Ordinal)) return true;
            }
            return false;
        }
    }
}
