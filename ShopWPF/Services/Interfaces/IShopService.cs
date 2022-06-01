using ShopWPF.Models;
using System.Threading.Tasks;

namespace ShopWPF.Services.Interfaces
{
    internal interface IShopService
    {
        Task PlaceOrder(UserModel customer);
        Task CancelOrder(OrderModel order);
    }
}
