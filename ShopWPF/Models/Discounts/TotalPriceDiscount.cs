using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.Models;

namespace ShopWPF.Models.Discounts
{
    internal abstract class TotalPriceDiscount : DiscountBaseModel
    {
        public abstract override double GetDiscountValue(ICollection<ShoppingCartEntryModel> shoppingCart);
    }
}
