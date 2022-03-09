using AccountManager.Services;
using AccountManager.ViewModels.ProductsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.ViewModels.OrdersViewModels
{
    internal class OrderDetailsViewModel : ProductsListViewModel
    {
        public OrderDetailsViewModel(NavigationService adminMenuViewModelNavigationService, IProductsManagerService productManagerService) 
            : base(adminMenuViewModelNavigationService, productManagerService)
        {

        }
    }
}
