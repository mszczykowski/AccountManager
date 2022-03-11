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
        public int Quantity { get; set; }
        public Categories Category { get; set; }

        public ProductModel(string name, double price, int quantity, Categories category)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
        }

        public ProductModel(int id, string name, double price, int quantity, Categories category)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
        }

        public void CopyData(ProductModel product)
        {
            Name = product.Name;
            Price = product.Price;
            Quantity = product.Quantity;
            Category = product.Category;
        }

        public override bool Equals(object? obj)
        {
            return obj is ProductModel model &&
                   Id == model.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
