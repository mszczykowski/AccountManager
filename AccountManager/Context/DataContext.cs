using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Models;
using AccountManager.Enums;

namespace AccountManager.Context
{
    internal class DataContext
    {
        public List<UserModel> Users { get; private set; }

        public List<ProductModel> Products { get; private set; }

        public List<OrderModel> Orders { get; private set; }


        public DataContext()
        {
            Initialize();
        }

        public void Initialize()
        {
            Users = new List<UserModel>
            {
                new AdminModel(0, "admin", "admin"),
                new StandardUserModel(1, "user1", "user1"),
                new StandardUserModel(2, "user2", "user1"),
                new StandardUserModel(3, "user3", "user1")
            };

            Products = new List<ProductModel>
            {
                new ProductModel(1, "Lenovo y700", 2399.99, 200, Categories.Notebooks),
                new ProductModel(2, "Dell Inspiron 420", 3099.99, 150, Categories.Notebooks),
                new ProductModel(3, "Lenovo Thinkpad 900", 2099.99, 120, Categories.Notebooks),
                new ProductModel(4, "HP Pavilion 1200", 2799.99, 80, Categories.Notebooks),

                new ProductModel(5, "Samsung Galaxy S7", 2399.99, 200, Categories.Smartphones),
                new ProductModel(6, "Motorola Moto X Style", 1099.99, 150, Categories.Smartphones),
                new ProductModel(7, "Sony Ericsson Xperia X8", 500.00, 120, Categories.Smartphones),
                new ProductModel(8, "Sony Xperia M", 399.99, 80, Categories.Smartphones),

                new ProductModel(9, "LG ProDisplay 144Hz", 3000.99, 200, Categories.Displays),

                new ProductModel(10, "IPad Pro 13'", 3099.99, 150, Categories.Tablets),
                new ProductModel(11, "IPad Air", 2099.99, 120, Categories.Tablets),

                new ProductModel(12, "Logitech G120 Ligthsync", 120.10, 80, Categories.Accesories),

                new ProductModel(13, "Sony Vaio", 699.99, 80, Categories.Notebooks),
            };

            Orders = new List<OrderModel>();
        }
    }
}
