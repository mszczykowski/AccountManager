using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Models;

namespace AccountManager.ViewModels
{
    internal class UserViewModel : ViewModelBase
    {
        private UserModel _user;

        public UserModel User { get => _user; }
        public string Name => _user.Name;
        public string Password => _user.Password;

        public UserViewModel(UserModel user)
        {
            _user = user;
        }
    }
}
