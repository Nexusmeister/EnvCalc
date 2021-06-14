using System.Collections.Generic;
using System.Threading.Tasks;
using EnvCalc.BusinessObjects;
using EnvCalc.BusinessObjects.ProduktManager;
using Prozess = EnvCalc.BusinessObjects.Prozess;

namespace EnvCalc.Tools
{
    public interface IBackendDataAccess
    {
        Task<List<Exchange>> GetAllExchangesAsync();
        Task<List<Prozess>> GetAllProzessberechnungen();
        Task<List<Produkt>> GetAllProdukteAsync();
    }
}