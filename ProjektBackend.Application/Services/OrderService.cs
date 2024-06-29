using ProjektBackend.Core.Entities;
using ProjektBackend.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektBackend.Core.Interfaces;


namespace ProjektBackend.Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Orders> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public Orders GetOrderById(int orderId)
        {
            return _orderRepository.GetOrderById(orderId);
        }

        public void AddOrder(Orders order)
        {
            _orderRepository.AddOrder(order);
        }
    }
}
