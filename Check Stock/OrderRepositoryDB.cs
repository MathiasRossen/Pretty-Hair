using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PrettyHairCore
{
    public class OrderRepositoryDB : IOrderRepository
    {
        private string connectionString;
             
        public OrderRepositoryDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Order> GetOrders()
        {
            List<Order> orderList = new List<Order>();

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("GetAllOrders", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int orderId = int.Parse(reader["OrderId"].ToString());
                        int wareId = int.Parse(reader["WareId"].ToString());
                        int customerId = int.Parse(reader["CustomerId"].ToString());
                        int orderDate = int.Parse(reader["OrderDate"].ToString());
                        int deliveryDate = int.Parse(reader["DeliveryDate"].ToString());
                        int quantity = int.Parse(reader["Quantity"].ToString());

                        orderList.Add(new Order(customerId, orderId, orderDate, deliveryDate, wareId, quantity));
                    }
                }
                catch (Exception e)
                {
                    // Error message goes here
                }
            }

            return orderList;
        }

        public List<Order> GetPackableOrders(IWareRepository wr)
        {
            throw new NotImplementedException();
        }

        public void PackOrder(int orderId, IWareRepository wr)
        {
            throw new NotImplementedException();
        }

        public void RegisterOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
