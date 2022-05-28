using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.Models;

namespace ShopWPF.Services
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
