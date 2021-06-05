using System.Collections.Generic;
using System.Threading.Tasks;
using EnvCalc.BusinessObjects;

namespace EnvCalc.Tools
{
    public interface IBackendDataAccess
    {
        Task<List<Exchange>> GetAll();
    }
}