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
        private static DiscountManager _instance;

        private ICollection<DiscountBase> _discounts;

        public IReadOnlyCollection<DiscountBase> Discounts 
        { 
            get => (IReadOnlyCollection<DiscountBase>)_discounts; 
        }

        private DiscountManager()
        {
            _discounts = new List<DiscountBase>();
        }

        public static DiscountManager GetInstance()
        {
            if( _instance == null ) _instance = new DiscountManager();
            return _instance;
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
