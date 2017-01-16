using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairCore
{
    public interface ICustomerRepository
    {
        Customer FindCustomer(int customerId);
        List<Customer> FindAllCustomers();
        void RegisterCustomer(Customer customer);
    }
}
