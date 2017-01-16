using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairCore
{
    public class Order
    {
        private int quantity;

        public int OrderId { get; set; }
        public int OrderDate { get; set; }
        public int DeliveryDate { get; set; }
        public int WareNumber { get; set; }
        public int CustomerNumber { get; set; }
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (value < 1)
                    quantity = 1;
                else
                    quantity = value;
            }
        }

        public Order(int customerNumber, int orderDate, int deliveryDate, int wareNumber)
        {
            CustomerNumber = customerNumber;
            OrderDate = orderDate;
            DeliveryDate = deliveryDate;
            WareNumber = wareNumber;
            quantity = 1;
        }

        public Order(int customerNumber, int orderDate, int deliveryDate, int wareNumber, int quantity)
            :this(customerNumber, orderDate, deliveryDate, wareNumber)
        {
            this.quantity = quantity;
        }

        public Order(int orderId, int customerNumber, int orderDate, int deliveryDate, int wareNumber, int quantity)
            :this(customerNumber, orderDate, deliveryDate, wareNumber, quantity)
        {
            OrderId = orderId;
        }

        public override string ToString()
        {
            return "ware: " + WareNumber;
        }
    }
}
