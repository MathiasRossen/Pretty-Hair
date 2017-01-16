using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairCore
{
    public class OrderRepository : IOrderRepository
    {
        List<Order> orderList;

        public OrderRepository()
        {
            orderList = new List<Order>();

            orderList.Add(new Order(0, 0, 1231, 1235, 0, 1));
            orderList.Add(new Order(1, 1, 1232, 1236, 1, 1));
            orderList.Add(new Order(2, 3, 1232, 1238, 2, 1));
            orderList.Add(new Order(3, 3, 1232, 1239, 4, 1));
            orderList.Add(new Order(4, 2, 1233, 1238, 2, 1));
            orderList.Add(new Order(5, 1, 1233, 1235, 5, 1));
            orderList.Add(new Order(6, 3, 1234, 1232, 4, 1));
        }

        public void RegisterOrder(Order order)
        {
            order.OrderId = orderList.Last().OrderId += 1;
            orderList.Add(order);
        }

        public List<Order> GetOrders()
        {
            return orderList;
        }

        public void PackOrder(int orderId, IWareRepository wr)
        {
            Order orderToPack = orderList.Find(x => x.OrderId == orderId);
            wr.RemoveWare(orderToPack.WareNumber, orderToPack.Quantity);
            orderList.RemoveAll(x => x.OrderId == orderId);
        }

        public List<Order> GetPackableOrders(IWareRepository wr)
        {
            return orderList.FindAll(x => x.Quantity <= wr.GetWares().Find(y => x.WareNumber == y.WareId).Amount);
        }
    }
}
