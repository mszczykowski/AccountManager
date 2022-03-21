using AccountManager.Services;
using AccountManager.Stores;
using AccountManager.ViewModels.OrdersViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.ViewModels.UserViews
{
    internal class UserOrderDetailsViewModel : OrderDetailsViewModel
    {
        public UserOrderDetailsViewModel(IProductsManagerService productManagerService, 
            NavigationService<UserOrdersViewModel> userOrdersViewNavigationService,
            OrderStore orderStore, IOrderManagerService orderManagerService) : base(productManagerService, userOrdersViewNavigationService, orderStore, orderManagerService)
        {
        }
    }
}
