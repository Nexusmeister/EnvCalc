using System.Collections.Generic;
using System.Threading.Tasks;
using EnvCalc.BusinessObjects;
using EnvCalc.BusinessObjects.ProduktManager;
using Prozess = EnvCalc.BusinessObjects.Prozess;

namespace EnvCalc.Tools
{
    public interface IBackendDataAccess
    {
        /// <summary>
        /// Ruft alle Exchanges ab
        /// </summary>
        /// <returns>Liste mit allen Exchanges</returns>
        Task<List<Exchange>> GetAllExchangesAsync();
        /// <summary>
        /// Ruft alle Prozesse ab, die im Backend liegen
        /// </summary>
        /// <returns>Liste mit Prozessen</returns>
        Task<List<Prozess>> GetAllProzessberechnungen();
        /// <summary>
        /// Ruft alle Produkte ab, die die Anwendung anzeigen soll
        /// </summary>
        /// <returns>Liste mit allen gespeicherten Produkte</returns>
        Task<List<Produkt>> GetAllProdukteAsync();
        /// <summary>
        /// Aufruf des Backends, um ein erstelltes Produkt zu speichern
        /// </summary>
        /// <param name="produkt">Produktobjekt mit allen Exchanges</param>
        /// <returns>
        /// true bei Erfolg <br/>
        /// false bei Fehler
        /// </returns>
        Task<bool> PostProduktAsync(Produkt produkt);
    }
}