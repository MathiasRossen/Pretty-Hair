using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairCore
{
    public interface IWareRepository
    {
        void AddWare(Ware ware);
        List<Ware> GetWares();
        Ware GetWareById(int wareId);
        void DeleteUnsellableWares();
        void UpdateWare(int wareId, int newPrice);
        void UpdateWare(int wareId, int newPrice, string newDesignation);
        void MarkUnsellable(int wareId);
        void RemoveWare(int wareId, int amountToRemove);
    }
}
