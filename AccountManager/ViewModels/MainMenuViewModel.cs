using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountManager.Commands;
using AccountManager.Stores;
using AccountManager.Services;
using AccountManager.Commands.MisicCommands;

namespace AccountManager.ViewModels
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
