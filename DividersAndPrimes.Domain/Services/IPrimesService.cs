using System.Collections.Generic;
using System.Threading.Tasks;

namespace DividersAndPrimes.Domain.Services
{
    public interface IPrimesService
    {
        Task<IEnumerable<int>> GetPrimes(int maxValue);
        Task<IEnumerable<int>> GetPrimes(IEnumerable<int> list);
    }
}
