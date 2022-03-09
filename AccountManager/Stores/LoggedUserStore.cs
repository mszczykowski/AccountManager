using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Stores
{
    internal class LoggedUserStore
    {
        private UserModel _loggedUser;

        public UserModel LoggedUser
        {
            get => _loggedUser;
            set
            {
                _loggedUser = value;
                OnCurrentUserChanged();
            }
        }

        public event EventHandler? CurrentUserChanged;

        private void OnCurrentUserChanged()
        {
            CurrentUserChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
