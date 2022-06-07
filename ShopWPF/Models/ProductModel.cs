using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWPF.Enums;

namespace ShopWPF.Models
{
    internal class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public int CategoryId { get; set; }

        private CategoryModel _category;
        public CategoryModel Category 
        { 
            get => _category; 
            set
            {
                _category = value;
                CategoryId = _category.CategoryId;
            }
        }
        public bool IsDeleted { get; set; }

        public ProductModel(string name, double price, int quantity, int categoryId)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            CategoryId = categoryId;
        }

        public ProductModel(string name, double price, int quantity, CategoryModel category)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
        }

        public ProductModel(int id, string name, double price, int quantity, bool isDeleted, int categoryId)
        {
            ProductId = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            IsDeleted = isDeleted;
            CategoryId = categoryId;
        }

        public void CopyData(ProductModel product)
        {
            Name = product.Name;
            Price = product.Price;
            Quantity = product.Quantity;
            CategoryId = product.CategoryId;
        }

        public override bool Equals(object? obj)
        {
            return obj is ProductModel model &&
                   ProductId == model.ProductId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductId);
        }
    }
}
