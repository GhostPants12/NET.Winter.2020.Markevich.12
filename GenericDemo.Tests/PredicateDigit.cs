using System;

namespace NumberExtension
{
    public sealed class PredicateDigit
    {
        private int digit;

        /// <summary>Gets or sets the digit.</summary>
        /// <value>The digit.</value>
        /// <exception cref="ArgumentOutOfRangeException">Value is less than 0 or greater than 9.</exception>
        public int Digit
        {
            get => this.digit;
            set
            {
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} cannot be less than 0 or greater than 9.");
                }

                this.digit = value;
            }
        }

        /// <summary>Determines whether the specified value contains key.</summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value contains key; otherwise, <c>false</c>.</returns>
        public bool ContainsKey(int value)
        {
            do
            {
                if (Math.Abs(value % 10) == this.digit)
                {
                    return true;
                }

                value /= 10;
            }
            while (value != 0);

            return false;
        }
    }
}