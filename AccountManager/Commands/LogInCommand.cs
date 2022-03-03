using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.ViewModels;
using AccountManager.Models;
using System.Windows;

namespace AccountManager.Commands
{
    internal class LogInCommand : CommandBase
    {
        private readonly LogInViewModel _logInViewModel;
        private readonly UsersManagerModel _usersManagerModel;

        public LogInCommand(LogInViewModel logInViewModel, UsersManagerModel usersManagerModel)
        {
            _logInViewModel = logInViewModel;
            _usersManagerModel = usersManagerModel;
            _logInViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_logInViewModel.Username) && !string.IsNullOrEmpty(_logInViewModel.Password) 
                && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if(_usersManagerModel.IsPasswordCorrect(new UserModel(_logInViewModel.Username, _logInViewModel.Password)))
            {
                MessageBox.Show("Password correct!");
            }
            else MessageBox.Show("Password incorrect!");
        }
    }
}
