using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairCore
{
    public interface IOrderRepository
    {
        void RegisterOrder(Order order);
        List<Order> GetOrders();
        void PackOrder(int orderId, IWareRepository wr);
        List<Order> GetPackableOrders(IWareRepository wr);
    }
}
