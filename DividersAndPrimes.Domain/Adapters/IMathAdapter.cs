using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DividersAndPrimes.Domain.Adapters
{
    public interface IMathAdapter
    {
        public Task<IEnumerable<int>> GetDivisors(int maxValue);
        public Task<IEnumerable<int>> GetPrimes(int maxValue);
    }
}
