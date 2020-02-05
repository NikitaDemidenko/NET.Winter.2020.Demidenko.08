using System;
using System.Collections.Generic;
using System.Text;

namespace FilterTemplateMethod
{
    /// <summary>Provides methods for filter array by digit.</summary>
    /// <seealso cref="FilterTemplateMethod.Filter" />
    public sealed class FilterDigit : Filter
    {
        /// <summary>The maximum value of digit.</summary>
        public const byte MaxValueOfDigit = 9;

        private byte digit;

        /// <summary>Gets or sets the digit.</summary>
        /// <value>Digit.</value>
        public byte Digit
        {
            get => this.digit;

            set
            {
                if (value > MaxValueOfDigit)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this.digit = value;
            }
        }

        /// <summary>Determines whether the specified number has specified digit.</summary>
        /// <param name="number">Number.</param>
        /// <returns>
        ///   <c>true</c> if the specified number has digit; otherwise, <c>false</c>.</returns>
        protected override bool IsMatch(int number)
        {
            return this.HasDigit(number);
        }

        private bool HasDigit(int number)
        {
            uint absNumber = (uint)Math.Abs((long)number);
            uint remainder = absNumber;
            while (absNumber > 0 && remainder != this.Digit)
            {
                remainder = absNumber % 10;
                absNumber /= 10;
            }

            return remainder == this.Digit;
        }
    }
}
