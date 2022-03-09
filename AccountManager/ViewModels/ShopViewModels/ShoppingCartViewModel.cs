using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountManager.ViewModels.ShopViewModels
{
    internal class ShoppingCartViewModel : ViewModelBase
    {
        
        
        private ObservableCollection<ShoppingCartEntryViewModel> _shoppingCartEntries;

        public IEnumerable<ShoppingCartEntryViewModel> ShoppingCartEntries => _shoppingCartEntries;

        public ICommand BackCommand { get; }

        public ICommand ClearCartCommand { get; }

        public ICommand PlaceOrder { get; }

        public string FullPrice { get; set; }


    }
}
