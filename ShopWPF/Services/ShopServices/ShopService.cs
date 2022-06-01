using ShopWPF.Enums;
using ShopWPF.Models;
using ShopWPF.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWPF.Services.ShopServices
{
    internal class ShopService : IShopService
    {
        private readonly IProductManagerService _productManagerService;
        private readonly IOrderManagerService _orderManagerService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IDiscountManagerService _discountManagerService;

        public ShopService(IProductManagerService productManagerService, IOrderManagerService orderManagerService, 
            IShoppingCartService shoppingCartService,
            IDiscountManagerService discountManagerService)
        {
            _productManagerService = productManagerService;
            _orderManagerService = orderManagerService;
            _shoppingCartService = shoppingCartService;
            _discountManagerService = discountManagerService;
        }

        public async Task CancelOrder(OrderModel order)
        {
            await _orderManagerService.UpdateStatus(order.OrderId, OrderStatuses.Canceled);

            order.Products.ToList().ForEach(p =>
            {
                _productManagerService.ChangeQuantity(p.ProductId, p.Product.Quantity - p.Quantity);
            }); 
        }

        public async Task PlaceOrder(UserModel customer)
        {
            double fullPrice = 0;
            double discountValue = 0;

            customer.ShoppingCart.ToList().ForEach(entry =>
            {
                fullPrice += entry.Product.Price * entry.Quantity;
            });

            var discounts = await _discountManagerService.GetDiscounts();

            discounts.ToList().ForEach(discount =>
            {
                discountValue += discount.GetDiscountValue(customer.ShoppingCart);
            });

            var order = new OrderModel(customer.UserId, fullPrice, discountValue);

            customer.ShoppingCart.ToList().ForEach(entry =>
            {
                _productManagerService.ChangeQuantity(entry.ProductId, entry.Product.Quantity - entry.Quantity);

                order.AddProduct(new OrderProductModel(entry.ProductId, entry.Product.Price, entry.Quantity));
            });

            await _orderManagerService.AddOrder(order);

            await _shoppingCartService.ClearCart(customer.UserId);
        }
    }
}
