using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Models
{
    internal abstract class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public ICollection<OrderProductModel> ShoppingCart { get; set; }

        public UserModel(string name, string password)
        {
            Name = name;
            Password = password;

            ShoppingCart = new List<OrderProductModel>();
        }

        public UserModel(int id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;

            ShoppingCart = new List<OrderProductModel>();
        }

        public bool IsPasswordValid(string password)
        {
            if (Password == password) return true;

            return false;
        }

        public abstract bool HasAdminPermissions();
    }
}
