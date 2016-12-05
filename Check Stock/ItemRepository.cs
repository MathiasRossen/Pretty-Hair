using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_Stock
{
    public class ItemRepository
    {
        private List<Ware> listOfWares = new List<Ware>();

        public ItemRepository()
        {
            listOfWares.Add(new Ware(0, 10, 1, "Somewhere", true));
            listOfWares.Add(new Ware(1, 8, 5, "Somewhere", false));
            listOfWares.Add(new Ware(2, 11, 0, "Somewhere", false));
            listOfWares.Add(new Ware(3, 5, 4, "Somewhere", false));
            listOfWares.Add(new Ware(4, 50, 1, "Somewhere", true));
            listOfWares.Add(new Ware(5, 10, 2, "Somewhere", false));
            listOfWares.Add(new Ware(6, 11, 1, "Somewhere", true));
        }

        public void DeleteWareById(int id)
        {
            listOfWares.RemoveAt(id);
        }

        public void DeleteUnsellableWares()
        {
            listOfWares.RemoveAll(item => item.Unsellable == true);
        }

        public void UpdateWare(Ware ware)
        {

        }

        public List<Ware> GetWares()
        {
            return listOfWares;
        }

        public Ware GetWareById(int id)
        {
            return new Ware();
        }
    }
}
