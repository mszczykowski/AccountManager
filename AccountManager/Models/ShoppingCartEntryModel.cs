using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Models
{
    internal class ShoppingCartEntryModel
    {
        

        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public ShoppingCartEntryModel(int productId)
        {
            ProductId = productId;
            Quantity = 1;
        }

        public override bool Equals(object? obj)
        {
            return obj is ShoppingCartEntryModel model &&
                   ProductId == model.ProductId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductId);
        }
    }
}
