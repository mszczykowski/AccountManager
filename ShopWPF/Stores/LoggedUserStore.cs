using ShopWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPF.Stores
{
    internal class LoggedUserStore
    {
        private UserModel _user;

        public UserModel User
        {
            get => _user;
            set
            {
                _user = value;
                OnCurrentUserChanged();
            }
        }

        public void Clear()
        {
            _user = null;
        }

        public event EventHandler? CurrentUserChanged;

        private void OnCurrentUserChanged()
        {
            CurrentUserChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
