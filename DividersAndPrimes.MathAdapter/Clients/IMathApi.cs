using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace DividersAndPrimes.MathAdapter.Clients
{
    internal interface IMathApi
    {
        /// <summary>        
        /// This interface represents the Math API client.
        /// Its implementation is automatically generated based on the decorations.
        /// The Refit library is responsible for generating the code         
        /// (https://github.com/reactiveui/refit).
        /// </summary>
        [Get("/api/math/getdividers")]
        Task<IEnumerable<int>> GetDividers(
            [Query] int maxValue);

        [Get("/api/math/getprimes")]
        Task<IEnumerable<int>> GetPrimes(
            [Query] int maxValue);
    }
}
