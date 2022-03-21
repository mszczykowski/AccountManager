using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Discounts
{
    internal class TenEveryHundredDiscount : TotalPriceDiscount
    {
        public TenEveryHundredDiscount(int id) : base(id)
        {
        }

        public override double GetDiscountValue(ICollection<ShoppingCartEntryModel> shoppingCart)
        {
            double total = 0;
            shoppingCart.ToList().ForEach(shoppingCartEntry =>
            {
                total += shoppingCartEntry.Product.Price * shoppingCartEntry.Quantity;
            });

            return Math.Floor(total/100) * 10;
        }

        public override string ToString()
        {
            return "-10 every 100 spent";
        }
    }
}
