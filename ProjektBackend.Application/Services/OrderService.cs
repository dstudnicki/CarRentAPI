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

        public void AddOrder(Orders order)
        {
            _orderRepository.AddOrder(order);
        }
    }
}
