using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IEcommerceRepository<Order> _orderRepo;
        private readonly IEcommerceRepository<DeliveryMethod> _deliveryMethodRepo;
        private readonly IEcommerceRepository<Product> _productRepo;
        private readonly IBasketRepository _basketRepository;

        public OrderService(
                 IEcommerceRepository<Order> orderRepo,
                 IEcommerceRepository<DeliveryMethod> deliveryMethodRepo,
                 IEcommerceRepository<Product> productRepo,
                 IBasketRepository basketRepository)
        {
            _orderRepo = orderRepo;
            _deliveryMethodRepo = deliveryMethodRepo;
            _productRepo = productRepo;
            _basketRepository = basketRepository;
        }

     

        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            // get basket from the repo
            var basket = await _basketRepository.GetBasketAsync(basketId);
           
            // get items from product repo
            var items = new List<OrderItem>();

            foreach (var item in basket.Items)
            {
                var productItem = await _productRepo.GetByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }

            var deliveryMethod = await _deliveryMethodRepo.GetByIdAsync(deliveryMethodId);
            var subTotal = items.Sum(item => item.Price * item.Quantity);
            var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subTotal);

            return order;
        }

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int Id, string buyerEmail)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrderForUserAsync(string buyerEmail)
        {
            throw new System.NotImplementedException();
        }
    }
}