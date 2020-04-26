using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DTOs;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class OrdersController : BaseAPIController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDTO orderDTO)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            var address = _mapper.Map<AddressDTO, Address>(orderDTO.ShipToAddress);
            var order = await _orderService.CreateOrderAsync(email, orderDTO.DeliveryMethodId, orderDTO.BasketId, address);

            if(order == null) return BadRequest(new APIResponse(400, "Problem creating order"));

            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderDTO>>> GetOrdersForUser()
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            var orders = await _orderService.GetOrdersForUserAsync(email);

            return Ok(_mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderToReturnDTO>>(orders));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDTO>> GetOrderForUser(int id)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            var order = await _orderService.GetOrderByIdAsync(id, email);
            if(order == null) return NotFound(new APIResponse(404));

            return _mapper.Map<Order, OrderToReturnDTO>(order);
        }

        [HttpGet("deliveryMethods")]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
        {
            return Ok(await _orderService.GetDeliveryMethodsAsync());
        }
    }
}