using ShopWPF.Commands.OrderManagerCommands;
using ShopWPF.Stores;
using ShopWPF.ViewModels.OrdersViewModels;
using ShopWPF.Commands.MisicCommands;
using ShopWPF.Services.Interfaces;
using ShopWPF.Services.Common;

namespace ShopWPF.ViewModels.ManageOrdersViewModels
{
    internal class ManageUserOrdersViewModel : OrdersListViewModel
    {

        public string CustomerName => _customer.Name;

        public ManageUserOrdersViewModel(NavigationService<EditUserViewModel> editUserViewNavigationService,
            IOrderManagerService orderManagerService, IdStore idStore,
            NavigationService<ManageUserOrderDetailsViewModel> manageUserOrderDetailsViewNavigationService,
            IUserManagerService userManagerService)
            : base(orderManagerService)
        {
            LoadCustomer(idStore.Id, userManagerService);

            BackCommand = new NavigateCommand<EditUserViewModel>(editUserViewNavigationService);
            UpdateOrdersCollection();

            OrderOnClickCommand =
                new NaviagteAndStoreIdCommand<ManageUserOrderDetailsViewModel>(manageUserOrderDetailsViewNavigationService, idStore);
        }

        private async void LoadCustomer(int id, IUserManagerService userManagerService)
        {
            _customer = await userManagerService.GetUser(id);
        }
    }
}
