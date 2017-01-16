using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairCore
{
    public class Ware
    {
        public int WareId { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public string Designation { get; set; }  
        public bool Unsellable { get; set; }
        //public string Description { get; set; }

        public Ware()
        {

        }

        public Ware(int wareId, int price, int amount, string designation, bool unsellable)
        {
            WareId = wareId;
            Price = price;
            Amount = amount;
            Designation = designation;
            Unsellable = unsellable;
        }

        public override string ToString()
        {
            return "id: " + WareId;// + " quantity: " + Amount + " description:" + Description;
        }

        public override bool Equals(object obj)
        {
            if (obj.ToString() == ToString())
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
