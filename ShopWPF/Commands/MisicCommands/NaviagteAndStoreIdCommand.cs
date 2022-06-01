using ShopWPF.Services.Common;
using ShopWPF.Stores;
using ShopWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPF.Commands.MisicCommands
{
    internal class NaviagteAndStoreIdCommand<TViewModel> : NavigateCommand<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly IdStore _idStore;
        public NaviagteAndStoreIdCommand(NavigationService<TViewModel> navigationService, IdStore idStore) : base(navigationService)
        {
            _idStore = idStore;
        }

        public override void Execute(object? parameter)
        {
            var id = parameter as int?;
            _idStore.Id = id;

            base.Execute(parameter);
        }
    }
}
