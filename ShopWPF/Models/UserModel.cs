using ShopWPF.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopWPF.Models
{
    internal class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public UserRoles UserRole { get; set; }

        public virtual ICollection<ShoppingCartEntryModel> ShoppingCart { get; set; }

        public bool IsPasswordValid(string password)
        {
            if (Password == password) return true;

            return false;
        }
    }
}
