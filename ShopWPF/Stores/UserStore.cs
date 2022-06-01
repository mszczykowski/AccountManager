using ShopWPF.Models;
using System;


namespace ShopWPF.Stores
{
    internal class UserStore
    {
        private UserModel _user;

        public UserModel User {
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
