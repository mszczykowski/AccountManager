using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Discounts;

namespace AccountManager.Discounts
{
    internal class DiscountManager
    { 

        private ICollection<DiscountBase> _discounts;

        public IReadOnlyCollection<DiscountBase> Discounts 
        { 
            get => (IReadOnlyCollection<DiscountBase>)_discounts; 
        }

        public DiscountManager()
        {
            _discounts = new List<DiscountBase>();
        }

        public void AddDiscount(DiscountBase discount)
        {
            _discounts.Add( discount );
        }

        public void DeleteDiscount(DiscountBase discount)
        {
            _discounts.Remove(discount);
        }
    }
}
