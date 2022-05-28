using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPF.Models.UserModels
{
    internal abstract class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public ICollection<ShoppingCartEntryModel> ShoppingCart { get; set; }

        public UserModel(string name, string password)
        {
            Name = name;
            Password = password;

            ShoppingCart = new HashSet<ShoppingCartEntryModel>();
        }

        public UserModel(int id, string name, string password)
        {
            UserId = id;
            Name = name;
            Password = password;

            ShoppingCart = new HashSet<ShoppingCartEntryModel>();
        }

        public bool IsPasswordValid(string password)
        {
            if (Password == password) return true;

            return false;
        }

        public abstract bool HasAdminPermissions();
    }
}
