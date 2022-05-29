using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.Models;
using ShopWPF.Models.UserModels;

namespace ShopWPF.Services.Interfaces
{
    internal interface IUserManagerService
    {
        Task AddStandardUser(UserModel user);
        Task DeleteUser(int id);
        Task EditUser(int id, UserModel user);
        Task<UserModel> GetUser(int userId);
        Task<UserModel> GetUser(string? username);
        Task<ICollection<UserModel>> GetAllUsers();
    }
}
