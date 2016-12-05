using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_Stock
{
    public class CustomerRepository
    {
        List<Customer> customerList;

        public CustomerRepository()
        {
            customerList = new List<Customer>();

            customerList.Add(new Customer(0, "Jonna", "somewhere"));
            customerList.Add(new Customer(1, "Hans", "somewhere"));
            customerList.Add(new Customer(2, "Lone", "somewhere"));
            customerList.Add(new Customer(3, "Peter", "somewhere"));
            customerList.Add(new Customer(4, "Kim", "somewhere"));
        }

        public Customer FindCustomer(int id)
        {
            return customerList.Find(x => x.CustomerNumber == id);
        }

        public List<Customer> FindAllCustomers()
        {
            return customerList;
        }

        public void RegisterCustomer(Customer customer)
        {
            customerList.Add(customer);
        }
    }
}
