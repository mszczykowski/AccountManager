using ShopWPF.Models;
using ShopWPF.Models.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPF.Services.Interfaces
{
    internal interface IDiscountManagerService
    {
        Task AddDiscount(CategoryModel category);
        Task AddDiscount(ProductModel product);
        Task AddDiscount();

        Task DeleteDiscount(int id);

        Task<ICollection<DiscountBaseModel>> GetDiscounts();
    }
}
