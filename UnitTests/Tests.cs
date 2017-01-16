using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrettyHairCore;
namespace UnitTests
{
    [TestClass]
    public class WareTests
    {
        private IWareRepository wr;
        private OrderRepository or;

        [TestInitialize]
        public void Setup()
        {
            wr = new WareRepository();
            or = new OrderRepository();
        }

        [TestMethod]
        public void CanGetWares()
        {
            List<Ware> wareList = wr.GetWares();

            Assert.AreEqual(7, wareList.Count);
        }

        [TestMethod]
        public void CanDeleteUnsellableWares()
        {
            List<Ware> wareList = wr.GetWares();

            Assert.AreEqual(7, wareList.Count);

            wr.DeleteUnsellableWares();
            wareList = wr.GetWares();

            Assert.AreEqual(4, wareList.Count);
        }

        [TestClass]
        public class OrderTests
        {
            ICustomerRepository cr;
            OrderRepository or;
            IWareRepository wr;

            [TestInitialize]
            public void Setup()
            {
                cr = new CustomerRepository();
                or = new OrderRepository();
                wr = new WareRepository();
            }

            [TestMethod]
            public void CanGetOrders()
            {
                List<Order> orderList = or.GetOrders();

                Assert.AreEqual(7, orderList.Count);
            }

            [TestMethod]
            public void CanRegisterOrder()
            {
                List<Order> orderList = or.GetOrders();

                Assert.AreEqual(7, orderList.Count);

                or.RegisterOrder(new Order(2, 1111, 1112, 2));
                orderList = or.GetOrders();

                Assert.AreEqual(8, orderList.Count);
            }

            [TestMethod]
            public void CanRegisterCustomer()
            {
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
            public void CanPackOrder()
            {
                or.PackOrder(3, wr);

                Assert.AreEqual(0, wr.GetWareById(4).Amount);
            }

            [TestMethod]
            public void CanGetPackableOrders()
            {
                List<Order> packableOrders = or.GetPackableOrders(wr);

                Assert.AreEqual(5, packableOrders.Count);
            }
        }
        /*
        [TestClass]
        public class DBTests
        {
            ICustomerRepository cr;
            IOrderRepository or;
            IWareRepository wr;

            [TestInitialize]
            public void Setup()
            {
                string connectionString = "Server=ealdb1.eal.local; Database=ejl10_db; User Id=ejl10_usr; Password=Baz1nga10;";
                cr = new CustomerRepositoryDB(connectionString);
                wr = new WareRepositoryDB(connectionString);
                or = new OrderRepositoryDB(connectionString);
            }

            [TestMethod]
            public void CanGetAllCustomers()
            {
                List<Customer> customers = cr.FindAllCustomers();

                Customer frank = customers[0];
                Customer lone = customers[1];

                Assert.AreEqual("Frank Hansen", frank.Name);
                Assert.AreEqual("Lone Petersen", lone.Name);
            }

            [TestMethod]
            public void CanGetCustomerById()
            {
                Customer frank;
                Customer lone;

                frank = cr.FindCustomer(1);
                lone = cr.FindCustomer(2);

                Assert.AreEqual("Frank Hansen", frank.Name);
                Assert.AreEqual("Lone Petersen", lone.Name);
            }

            [TestMethod]
            public void CanInsertNewCustomer()
            {
                Customer kasper = new Customer(0, "Kasper Jørgensen", "Another Place");

                //cr.RegisterCustomer(kasper);
                kasper = cr.FindAllCustomers().Last();

                Assert.AreEqual("Kasper Jørgensen", kasper.Name);
            }

            [TestMethod]
            public void CanGetAllWares()
            {
                List<Ware> wares = wr.GetWares();
                Ware firstWare = wares.First();

                Assert.AreEqual(1, firstWare.WareId);
                Assert.AreEqual(10, firstWare.Price);
                Assert.AreEqual(4, firstWare.Amount);
                Assert.AreEqual("Somewhere", firstWare.Designation);
            }

            [TestMethod]
            public void CanGetWareById()
            {
                Ware actualWare = wr.GetWareById(1);

                Assert.AreEqual(1, actualWare.WareId);
                Assert.AreEqual(10, actualWare.Price);
                Assert.AreEqual(4, actualWare.Amount);
                Assert.AreEqual("Somewhere", actualWare.Designation);
                //Assert.AreEqual(false, actualWare.Unsellable); // Conflict with test below. Reset in Database to test.
            }

            [TestMethod]
            public void CanMarkWareUnsellable()
            {
                Ware actualWare;

                wr.MarkUnsellable(1);
                actualWare = wr.GetWareById(1);

                Assert.AreEqual(true, actualWare.Unsellable);
            }

            [TestMethod]
            public void CanUpdateWare()
            {
                Ware actualWare = wr.GetWareById(1);

                actualWare.Price = 100;
                actualWare.Designation = "A new place";
                wr.UpdateWare(actualWare.WareId, actualWare.Price, actualWare.Designation);
                actualWare = wr.GetWareById(1);

                Assert.AreEqual(100, actualWare.Price);
                Assert.AreEqual("A new place", actualWare.Designation);

                //Reset test
                wr.UpdateWare(1, 10, "Somewhere");
            }

            [TestMethod]
            public void CanUpdateWarePriceOnly()
            {
                Ware actualWare = wr.GetWareById(1);

                actualWare.Price = 200;
                wr.UpdateWare(actualWare.WareId, actualWare.Price);
                actualWare = wr.GetWareById(1);

                Assert.AreEqual(200, actualWare.Price);

                //Reset test
                wr.UpdateWare(1, 10);
            }

            [TestMethod]
            public void CanAddNewWare()
            {
                Ware wareToAdd = new Ware(2, 50, 5, "A place", false);

                //wr.AddWare(wareToAdd); //Passed
                Ware actualWare = wr.GetWareById(2);

                Assert.AreEqual(2, actualWare.WareId);
                Assert.AreEqual(50, actualWare.Price);
                Assert.AreEqual(5, actualWare.Amount);
                Assert.AreEqual("A place", actualWare.Designation);
                Assert.AreEqual(false, actualWare.Unsellable);
            }
        }
        */
    }
}
