using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Models;
using AccountManager.Enums;

namespace AccountManager.Stores
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

        public ProductStore()
        {
            
        }

        public ProductStore(string name, double price, int quantity, Categories category)
        {
            _product = new ProductModel(name, price, quantity, category);
        }

        public event EventHandler? CurrentUserChanged;

        private void OnCurrentUserChanged()
        {
            CurrentUserChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
