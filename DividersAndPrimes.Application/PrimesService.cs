using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DividersAndPrimes.Application.MathHelper;
using DividersAndPrimes.Domain.Services;
using Microsoft.Extensions.Logging;

namespace DividersAndPrimes.Application
{
    public class PrimesService : IPrimesService
    {
        private readonly ILogger logger;

        public PrimesService(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory?.CreateLogger<PrimesService>() ??
                throw new ArgumentNullException(nameof(loggerFactory));
        }

        public async Task<IEnumerable<int>> GetPrimes(int maxValue)
        {
            logger.LogInformation("search for prime numbers among divisors " +
                "of a maximum value",
               new { MaxValue = maxValue });

            IEnumerable<int> dividers = await MathUtils.PrimeNumbers(
                                            await MathUtils.DivisorNumbers(maxValue));

            return dividers;
        }

        public async Task<IEnumerable<int>> GetPrimes(IEnumerable<int> list)
        {
            logger.LogInformation("returns the prime numbers from the list" +
                " {@List}",
               new { List = list });

            IEnumerable<int> dividers = await MathUtils.PrimeNumbers(list);

            return dividers;
        }
    }
}
