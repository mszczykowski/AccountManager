using ShopWPF.Commands.MisicCommands;
using ShopWPF.Services.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopWPF.ViewModels.ManageUsersViewModels
{
    internal class UserFormViewModel : ViewModelBase
    {
        private string _userName;
        public string Username
        {
            get => _userName;
            set
            {
                _userName = value;
                ValidateName();
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                ValidatePassword();
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand CancelCommand { get; }

        private readonly ErrorsViewModel _errorsViewModel;


        

        public UserFormViewModel(NavigationService<ManageUsersViewModel> userManagerViewNavigationService)
        {
            CancelCommand = new NavigateCommand<ManageUsersViewModel>(userManagerViewNavigationService);

            _errorsViewModel = new ErrorsViewModel();

            _errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;
        }

        public UserFormViewModel(NavigationService<SearchUserViewModel> searchUserViewNavigationService)
        {
            CancelCommand = new NavigateCommand<SearchUserViewModel>(searchUserViewNavigationService);

            _errorsViewModel = new ErrorsViewModel();

            _errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;
        }


        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public bool HasErrors => _errorsViewModel.HasErrors;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsViewModel.GetErrors(propertyName);
        }

        private void ErrorsViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
        }

        public void ValidateForm()
        {
            ValidateName();
            ValidatePassword();
        }

        private void ValidateName()
        {
            _errorsViewModel.ClearErrors(nameof(Username));

            if (string.IsNullOrEmpty(Username)) _errorsViewModel.AddError(nameof(Username), "Name can't be empty");

            else if (Username.Length > 30)
                _errorsViewModel.AddError(nameof(Username), "Name must be shorter than 30 characters");
        }

        private void ValidatePassword()
        {
            _errorsViewModel.ClearErrors(nameof(Password));

            if (string.IsNullOrEmpty(Password)) _errorsViewModel.AddError(nameof(Password), "Password can't be empty");

            else if (Password.Length > 30)
                _errorsViewModel.AddError(nameof(Password), "Pasword must be shorter than 30 characters");
        }
    }
}
