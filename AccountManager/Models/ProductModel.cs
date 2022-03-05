using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Enums;

namespace AccountManager.Models
{
    internal class ProductModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public Categories Category { get; set; }

        public ProductModel(int id, string name, double price, int amount, Categories category)
        {
            Id = id;
            Name = name;
            Price = price;
            Amount = amount;
            Category = category;
        }
    }
}
