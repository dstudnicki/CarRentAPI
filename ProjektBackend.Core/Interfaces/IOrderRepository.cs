using ProjektBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBackend.Core.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Orders> GetAllOrders();
        Orders GetOrderById(int orderId);
        void AddOrder(Orders order);
    }
}
