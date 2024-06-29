using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjektBackend.Application.Services;
using ProjektBackend.Core.Entities;

namespace ProjektBackend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult GetAll()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult GetDetails(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create(Orders order)
        {
            _orderService.AddOrder(order);
            return Ok();
        }
    }
}
