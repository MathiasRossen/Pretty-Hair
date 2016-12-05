using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_Stock
{
    public class OrderRepository
    {
        List<Order> orderList;

        public OrderRepository()
        {
            orderList = new List<Order>();

            orderList.Add(new Order(0, 1231, 1235, 30));
            orderList.Add(new Order(1, 1232, 1236, 40));
            orderList.Add(new Order(3, 1232, 1238, 50));
            orderList.Add(new Order(3, 1232, 1239, 40));
            orderList.Add(new Order(2, 1233, 1238, 50));
            orderList.Add(new Order(1, 1233, 1235, 40));
            orderList.Add(new Order(3, 1234, 1232, 20));
        }

        public void RegisterOrder(Order order)
        {
            orderList.Add(order);
        }

        public List<Order> GetOrders()
        {
            return orderList;
        } 
    }
}
