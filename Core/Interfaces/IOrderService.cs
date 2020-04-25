using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.OrderAggregate;

namespace Core.Interfaces
{
    public interface IOrderService
    {
         Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress);
         Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);
         Task<Order> GetOrderByIdAsync(int Id, string buyerEmail);
         Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();
    }
}