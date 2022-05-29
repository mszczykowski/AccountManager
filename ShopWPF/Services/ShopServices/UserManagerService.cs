using Microsoft.EntityFrameworkCore;
using ShopWPF.Data;
using ShopWPF.Models.UserModels;
using ShopWPF.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopWPF.Services.ShopServices
{
    internal class UserManagerService : IUserManagerService
    {
        private readonly ShopDBContext _context;

        public UserManagerService(ShopDBContext context)
        {
            _context = context;
        }

        public async Task AddStandardUser(UserModel user)
        {
            await _context.Users.AddAsync(new StandardUserModel(user.Name, user.Password));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task EditUser(int id, UserModel user)
        {
            var userToModify = await _context.Users.FindAsync(id);
            userToModify.Name = user.Name;
            userToModify.Password = user.Password;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<UserModel>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserModel> GetUser(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<UserModel> GetUser(string? username)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Name == username);
        }
    }
}
