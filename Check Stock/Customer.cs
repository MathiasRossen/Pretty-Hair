using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairCore
{
    public class Customer
    {
        int customerNumber;
        string name;
        string address;

        public int CustomerNumber
        {
            get
            {
                return customerNumber;
            }
            set
            {
                customerNumber = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public Customer(int customerNumber, string name, string address)
        {
            this.customerNumber = customerNumber;
            this.name = name;
            this.address = address;
        }

    }
}
