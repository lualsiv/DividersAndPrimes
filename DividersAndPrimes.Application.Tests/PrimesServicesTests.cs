using System.Collections.Generic;
using System.Threading.Tasks;
using DividersAndPrimes.Domain.Services;
using Microsoft.Extensions.Logging;
using Xunit;

namespace DividersAndPrimes.Application.Tests
{
    public class PrimesServicesTests
    {
        private readonly IPrimesService primesService;
        private readonly IDivisorsService divisorsService;

        public PrimesServicesTests()
        {
            divisorsService = new DivisorsService(new LoggerFactory());
            primesService = new PrimesService(new LoggerFactory());
        }

        [Fact]
        [Trait(nameof(IPrimesService.GetPrimes), "Sucess")]
        public async Task GetPrimes()           
        {
            var expected = new List<int>();
            expected.AddRange(new[] { 3, 5 });
            
            var primes = await primesService.GetPrimes(45);
            Assert.Equal(expected, primes);
        }
    }
}
