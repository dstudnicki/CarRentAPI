using ProjektBackend.Core.Entities;
using ProjektBackend.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBackend.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDBContext _context;

        public OrderRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public void AddOrder(Orders order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
