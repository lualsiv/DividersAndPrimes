using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DividersAndPrimes.Domain.Adapters;
using DividersAndPrimes.MathAdapter.Clients;

namespace DividersAndPrimes.MathAdapter
{
    internal class MathAdapter : IMathAdapter
    {
        private readonly IMathApi _mathApi;

        public MathAdapter(IMathApi mathApi)
        {
            this._mathApi = mathApi ??
                throw new ArgumentNullException(nameof(mathApi));
        }

        public async Task<IEnumerable<int>> GetDivisors(int maxValue)
        {
            try
            {
                IEnumerable<int> result = await _mathApi.GetDividers(maxValue);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<IEnumerable<int>> GetPrimes(int maxValue)
        {
            IEnumerable<int> result = await _mathApi.GetPrimes(maxValue);

            return result;
        }
    }
}
