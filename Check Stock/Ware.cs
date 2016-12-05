using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_Stock
{
    public class Ware
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public string Designation { get; set; }  
        public bool Unsellable { get; set; }
        public string Description { get; set; }

        public Ware()
        {

        }

        public Ware(int id, int price, int amount, string designation, bool unsellable)
        {
            Id = id;
            Price = price;
            Amount = amount;
            Designation = designation;
            Unsellable = unsellable;
        }

        public override string ToString()
        {
            return "id: " + Id + " quantity: " + Amount + " description:" + Description;
        }
    }
}
