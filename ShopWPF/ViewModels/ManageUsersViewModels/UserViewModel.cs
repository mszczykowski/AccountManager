using ShopWPF.Models;
using ShopWPF.ViewModels.Intefraces;

namespace ShopWPF.ViewModels
{
    internal class UserViewModel : ViewModelBase, ViewModelWithId
    {
        public int Id => _user.UserId;

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
