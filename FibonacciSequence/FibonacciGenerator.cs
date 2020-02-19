using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace FibonacciSequence
{
    public static class FibonacciGenerator
    {
        /// <summary>Gets first n elements from the Fibonacci series.</summary>
        /// <param name="n">The n.</param>
        /// <returns>Array of Fibonacci numbers.</returns>
        /// <exception cref="ArgumentException">n is less than 2.</exception>
        public static IEnumerable<BigInteger> GetFibonacciArray(int n)
        {
            if (n < 2)
            {
                throw new ArgumentException($"{nameof(n)} cannot be less than 2");
            }

            return GetArray();

            IEnumerable<BigInteger> GetArray()
            {
                BigInteger previousNum, num;
                yield return previousNum = 0;
                yield return num = 1;
                for (int i = 2; i < n; i++)
                {
                    var buf = previousNum;
                    previousNum = num;
                    yield return num = buf + previousNum;
                }
            }
        }
    }
}
