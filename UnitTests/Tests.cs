using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Check_Stock;
namespace UnitTests
{
    [TestClass]
    public class WareTests
    {
        [TestMethod]
        public void CanGetWares()
        {
            ItemRepository ir = new ItemRepository();

            List<Ware> wareList = ir.GetWares();

            Assert.AreEqual(7, wareList.Count);
        }

        [TestMethod]
        public void CanDeleteUnsellableWares()
        {
            ItemRepository ir = new ItemRepository();
            List<Ware> wareList = ir.GetWares();

            Assert.AreEqual(7, wareList.Count);

            ir.DeleteUnsellableWares();
            wareList = ir.GetWares();

            Assert.AreEqual(4, wareList.Count);
        }

        [TestClass]
        public class OrderTests
        {
            [TestMethod]
            public void CanGetOrders()
            {
                OrderRepository or = new OrderRepository();
                List<Order> orderList = or.GetOrders();

                Assert.AreEqual(7, orderList.Count);
            }

            [TestMethod]
            public void CanRegisterOrder()
            {
                OrderRepository or = new OrderRepository();
                List<Order> orderList = or.GetOrders();

                Assert.AreEqual(7, orderList.Count);

                or.RegisterOrder(new Order(2, 1111, 1112, 2));
                orderList = or.GetOrders();

                Assert.AreEqual(8, orderList.Count);
            }

            [TestMethod]
            public void CanRegisterCustomer()
            {
                CustomerRepository cr = new CustomerRepository();
                List<Customer> customerList = cr.FindAllCustomers();

                Assert.AreEqual(5, customerList.Count);

                cr.RegisterCustomer(new Customer(5, "Joakim", "somewhere"));
                customerList = cr.FindAllCustomers();

                Assert.AreEqual(6, customerList.Count);
            }

            [TestMethod]
            public void CanSendMail()
            {
                MailSender ms = new MailSender();
                ms.ConsiderToSendMail(ms.SendMail);

                Assert.AreEqual(true, ms.SentMail);
            }

            [TestMethod]
            public void 
        }
    }
}
