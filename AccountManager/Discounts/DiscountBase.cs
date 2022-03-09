using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Models;

namespace AccountManager.Discounts
{
    internal abstract class DiscountBase
    {
        public abstract double GetDiscountValue(ICollection<ShoppingCartEntryModel> shoppingCart);
    }
}
