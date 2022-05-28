using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.Models;

namespace ShopWPF.Models.Discounts
{
    internal abstract class DiscountBaseModel
    {
        [Key]
        public int DiscountId { get; set; }

        public abstract double GetDiscountValue(ICollection<ShoppingCartEntryModel> shoppingCart);
    }
}
