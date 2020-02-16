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

            BigInteger[] returnArray = new BigInteger[n];
            returnArray[0] = 0;
            returnArray[1] = 1;
            for (int i = 2; i < n; i++)
            {
                returnArray[i] = returnArray[i - 2] + returnArray[i - 1];
            }

            return returnArray;
        }
    }
}
