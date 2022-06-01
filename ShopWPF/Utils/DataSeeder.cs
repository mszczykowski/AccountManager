using ShopWPF.Data;
using System;
using System.Linq;
using ShopWPF.Enums;
using ShopWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace ShopWPF.Utils
{
    internal class DataSeeder
    {
        private readonly ShopDBContext _context;

        public DataSeeder(ShopDBContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();
            SeedAdmin();
            SeedOrderStatuses();
        }

        private void SeedOrderStatuses()
        {
            if(!_context.OrderStatuses.Any())
            {
                foreach(var status in Enum.GetValues(typeof(OrderStatuses)))
                {
                    _context.Add(new OrderStatusModel
                    {
                        Id = (int)status,
                        Status = status.ToString()
                    });
                }

                _context.SaveChanges();
            }
        }

        private void SeedAdmin()
        {
            if(!_context.Users.Any())
            {
                _context.Add(new UserModel
                {
                    Name = "admin",
                    Password = "admin",
                    UserRole = UserRoles.Admin
                });
                _context.SaveChanges();
            }
        }
    }
}
