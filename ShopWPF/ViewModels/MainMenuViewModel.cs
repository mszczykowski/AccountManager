using System.Windows.Input;
using ShopWPF.Commands.MisicCommands;
using ShopWPF.Services.Common;

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
