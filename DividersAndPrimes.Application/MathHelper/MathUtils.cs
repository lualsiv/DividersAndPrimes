using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DividersAndPrimes.Application.MathHelper
{
    public class MathUtils
    {
        public static async Task<IEnumerable<int>> DivisorNumbers(int maxValue)
        {
            List<int> divisors = new List<int>();

            // We cannot proceed with negative numbers
            maxValue = maxValue < 0 ? -maxValue : maxValue;

            int raiz = (int)Math.Sqrt(maxValue);

            // Searches only up to the square root of maxValue
            // and does not divide odd numbers by even numbers
            for (int i = 1, step = (int)(maxValue % 2 == 0 ? 1 : 2); i <= raiz; i += step)
            {
                // add 2 divisors at a time, i and maxValue/i
                if (maxValue % i == 0)
                {
                    divisors.Add(i);
                    divisors.Add((int)maxValue / i);
                }
            }
            // add root in case of perfect square
            if (raiz * raiz == maxValue)
                divisors.Add(raiz);

            divisors.Sort();

            return divisors;
        }

        public static async Task<IEnumerable<int>> PrimeNumbers(IEnumerable<int> list)
        {
            List<int> ret = new List<int>();

            foreach (int numero in list)
            {
                if (IsPrime(numero))
                    ret.Add(numero);
            }

            return ret;
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;
            var max = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 3; i <= max; i += 2) if (number % i == 0) return false;
            return true;
        }
    }
}
