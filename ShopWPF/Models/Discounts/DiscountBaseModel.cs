using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.Models;

namespace ShopWPF.Models.Discounts
{
    abstract class DiscountBaseModel
    {
        public int DiscountId { get; set; }

        public DiscountBaseModel(int id)
        {
            DiscountId = id;
        }

        public abstract double GetDiscountValue(ICollection<ShoppingCartEntryModel> shoppingCart);
    }
}
