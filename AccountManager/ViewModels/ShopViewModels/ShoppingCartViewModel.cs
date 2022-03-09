using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.ViewModels.ShopViewModels
{
    internal class ShoppingCartViewModel : ViewModelBase
    {
        
        
        private ObservableCollection<ShoppingCartEntryViewModel> _sho;

        public IEnumerable<ShoppingCartEntryViewModel> Products => _products;
    }
}
