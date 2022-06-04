/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.Models;
using ShopWPF.Enums;

namespace ShopWPF.Stores
{
    internal class ProductStore
    {
        private ProductModel _product;

        public ProductModel Product
        {
            get => _product;
            set
            {
                _product = value;
                OnCurrentUserChanged();
            }
        }

        public event EventHandler? CurrentUserChanged;

        private void OnCurrentUserChanged()
        {
            CurrentUserChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}*/
