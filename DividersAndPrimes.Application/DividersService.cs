using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DividersAndPrimes.Application.MathHelper;
using DividersAndPrimes.Domain.Services;
using Microsoft.Extensions.Logging;

namespace DividersAndPrimes.Application
{
    public class DivisorsService : IDivisorsService
    {
        private readonly ILogger logger;

        public DivisorsService(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory?.CreateLogger<DivisorsService>() ??
                throw new ArgumentNullException(nameof(loggerFactory));
        }

        public async Task<IEnumerable<int>> GetDivisors(int maxValue)
        {
            logger.LogInformation("Performing the calculation of divisors " +
                "with the following value {@MaxValue}",
               new { MaxValue = maxValue });

            IEnumerable<int> dividers = await MathUtils.DivisorNumbers(maxValue);            

            return dividers;
        }
    }
}
