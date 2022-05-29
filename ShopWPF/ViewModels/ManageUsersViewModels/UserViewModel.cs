using ShopWPF.Models.UserModels;

namespace ShopWPF.ViewModels
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
