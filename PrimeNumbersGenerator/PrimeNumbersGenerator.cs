using System;

namespace PrimeNumbers
{
    public static class PrimeNumbersGenerator
    {
        /// <summary>Gets the first n prime numbers.</summary>
        /// <param name="n">The number of the prime numbers to be returned.</param>
        /// <exception cref="ArgumentException">Thrown when n is less or equal to zero.</exception>
        /// <returns>Returns array of prime numbers.</returns>
        public static int[] GetPrimeNumbers(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException($"{nameof(n)} is less or equal to zero.");
            }

            int[] resultArray = new int[n];
            int arrayLength = 0;
            int number = 0;
            while (arrayLength != n)
            {
                number++;
                if (number.IsPrimeNumber())
                {
                    resultArray[arrayLength] = number;
                    arrayLength++;
                }
            }

            return resultArray;
        }

        /// <summary>Determines whether [is prime number].</summary>
        /// <param name="n">The number to be determined.</param>
        /// <returns>
        ///   <c>true</c> if [is prime number] [the specified n]; otherwise, <c>false</c>.</returns>
        private static bool IsPrimeNumber(this int n)
        {
            var result = true;
            n = Math.Abs(n);

            if (n > 1)
            {
                for ( int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}
