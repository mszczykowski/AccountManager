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
        private static DiscountManager _insance;

        private ICollection<DiscountBase> _discounts;

        public ICollection<DiscountBase> Discounts { get => _discounts; }

        private DiscountManager()
        {
            _discounts = new List<DiscountBase>();
        }

        public static DiscountManager GetInstance()
        {
            if( _insance == null ) _insance = new DiscountManager();
            return _insance;
        }

        public void AddDiscount(DiscountBase discount)
        {
            _discounts.Add( discount );
        }
    }
}
