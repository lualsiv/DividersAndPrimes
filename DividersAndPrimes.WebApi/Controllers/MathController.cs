using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DividersAndPrimes.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DividersAndPrimes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        private readonly IPrimesService _primesService;
        private readonly IDivisorsService _divisorsService;

        public MathController(IPrimesService primesService,
            IDivisorsService divisorsService)
        {
            this._primesService = primesService;
            this._divisorsService = divisorsService;
        }

        [HttpGet("getDividers")]
        [ProducesResponseType(typeof(IEnumerable<int>), 200)]                
        public async Task<IActionResult> GetDividersAsync(
            [FromQuery] int maxValue)
        {
            IEnumerable<int> result;

            result = await _divisorsService.GetDivisors(maxValue);

            return Ok(result);
        }

        [HttpGet("getPrimes")]
        [ProducesResponseType(typeof(IEnumerable<int>), 200)]
        public async Task<IActionResult> GetPrimesAsync(
            [FromQuery] int maxValue)
        {
            IEnumerable<int> result;

            result = await _primesService.GetPrimes(maxValue);

            return Ok(result);
        }
    }
}