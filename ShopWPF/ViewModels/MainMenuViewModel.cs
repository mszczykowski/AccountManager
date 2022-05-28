using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ShopWPF.Commands;
using ShopWPF.Stores;
using ShopWPF.Services;
using ShopWPF.Commands.MisicCommands;

namespace ShopWPF.ViewModels
{
    internal class MainMenuViewModel : ViewModelBase
    {
        public ICommand LogInCommand { get; }
        public ICommand ExitCommand { get; }

        public MainMenuViewModel(NavigationService<LogInViewModel> logInViewNavigationService)
        {
            LogInCommand = new NavigateCommand<LogInViewModel>(logInViewNavigationService);

            ExitCommand = new ExitCommand();
        }
    }
}
