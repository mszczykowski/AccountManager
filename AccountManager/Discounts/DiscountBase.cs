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
        private int _id;
        public int Id => _id;

        public DiscountBase(int id)
        {
            _id = id;
        }

        public abstract double GetDiscountValue(ICollection<ShoppingCartEntryModel> shoppingCart);
    }
}
