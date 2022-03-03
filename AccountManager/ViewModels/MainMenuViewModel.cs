using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountManager.Commands;
using AccountManager.Stores;
using AccountManager.Services;

namespace AccountManager.ViewModels
{
    internal class MainMenuViewModel : ViewModelBase
    {
        public ICommand LogInCommand { get; }
        public ICommand ExitCommand { get; }

        public MainMenuViewModel(NavigationService logInViewNavigationService)
        {
            LogInCommand = new NavigateCommand(logInViewNavigationService);

            ExitCommand = new ExitCommand();
        }
    }
}
