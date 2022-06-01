using ShopWPF.Enums;
using System.ComponentModel.DataAnnotations;

namespace ShopWPF.Models.Discounts
{
    internal class DiscountDatabaseModel
    {
        [Key]
        public int Id{ get; set; }
        public DiscountTypes Type { get; set; }

        public int? ProductId { get; set; }
        private ProductModel? _product;
        public ProductModel? Product 
        { 
            get => _product; 
            set
            {
                _product = value;
                ProductId = _product.ProductId;
            }
        }

        public int? CategoryId { get; set; }

        private CategoryModel? _category;

        public CategoryModel? Category 
        {
            get => _category;
            set
            {
                _category = value;
                CategoryId = _category.CategoryId;
            }
        }
    }
}
