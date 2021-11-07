using System.Collections.Generic;
using System.Threading.Tasks;
using DividersAndPrimes.Domain.Services;
using Microsoft.Extensions.Logging;
using Xunit;

namespace DividersAndPrimes.Application.Tests
{
    public class DivisorsServiceTests
    {
        private readonly IDivisorsService divisorsService;        

        public DivisorsServiceTests()
        {
            divisorsService = new DivisorsService(new LoggerFactory());
        }

        [Fact]
        [Trait(nameof(IDivisorsService.GetDivisors), "Sucess")]
        public async Task GetDivisors()
        {
            var expected = new List<int>();
            expected.AddRange(new[] { 1, 3, 5, 9, 15, 45 });

            var divisorNumbers = await divisorsService.GetDivisors(45);

            Assert.Equal(expected, divisorNumbers);
        }
    }    
}
