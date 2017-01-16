using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairCore
{
    public class WareRepository : IWareRepository
    {
        private List<Ware> listOfWares = new List<Ware>();

        public WareRepository()
        {
            listOfWares.Add(new Ware(0, 10, 1, "Somewhere", true));
            listOfWares.Add(new Ware(1, 8, 5, "Somewhere", false));
            listOfWares.Add(new Ware(2, 11, 0, "Somewhere", false));
            listOfWares.Add(new Ware(3, 5, 4, "Somewhere", false));
            listOfWares.Add(new Ware(4, 50, 1, "Somewhere", true));
            listOfWares.Add(new Ware(5, 10, 2, "Somewhere", false));
            listOfWares.Add(new Ware(6, 11, 1, "Somewhere", true));
        }

        public void AddWare(Ware ware)
        {
            if (!listOfWares.Exists(x => x.WareId == ware.WareId))
                listOfWares.Add(ware);
            else
                listOfWares.Find(x => x.WareId == ware.WareId).Amount += ware.Amount;
        }

        public void DeleteWareById(int id)
        {
            listOfWares.RemoveAt(id);
        }

        public void DeleteUnsellableWares()
        {
            listOfWares.RemoveAll(item => item.Unsellable == true);
        }

        public void UpdateWare(int wareId, int newPrice)
        {
            UpdateWare(wareId, newPrice, listOfWares.Find(x => x.WareId == wareId).Designation);
        }

        public void UpdateWare(int wareId, int newPrice, string newDesignation)
        {
            Ware wareToEdit = listOfWares.Find(x => x.WareId == wareId);
            wareToEdit.Price = newPrice;
            wareToEdit.Designation = newDesignation;
        }

        public void RemoveWare(int wareId, int amountToRemove)
        {
            listOfWares.Find(x => x.WareId == wareId).Amount -= amountToRemove;
        }

        public List<Ware> GetWares()
        {
            return listOfWares;
        }

        public Ware GetWareById(int wareId)
        {
            return listOfWares.Find(x => x.WareId == wareId);
        }

        public void MarkUnsellable(int wareId)
        {
            throw new NotImplementedException();
        }
    }
}
