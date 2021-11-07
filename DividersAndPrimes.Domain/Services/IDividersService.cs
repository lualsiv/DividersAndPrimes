using System.Collections.Generic;
using System.Threading.Tasks;

namespace DividersAndPrimes.Domain.Services
{
    public interface IDivisorsService
    {
        Task<IEnumerable<int>> GetDivisors(int maxValue);
    }
}
