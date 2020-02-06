using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TransformerToWords
{
    /// <summary>Provides methods to transform numbers to its string representation.</summary>
    public abstract class Transformer
    {
        /// <summary>Space symbol.</summary>
        public const char SpaceSymbol = ' ';

        /// <summary>Gets the special values dictionary.</summary>
        /// <value>Special values dictionary.</value>
        protected abstract Dictionary<double, string> SpecialValuesDictionary { get; }

        /// <summary>Gets the symbols dictionary.</summary>
        /// <value>Symbols dictionary.</value>
        protected abstract Dictionary<char, string> SymbolsDictionary { get; }

        /// <summary>Transforms double to its string representation.</summary>
        /// <param name="number">Number.</param>
        /// <returns>Returns number's string representation.</returns>
        public string TransformToWords(double number)
        {
            if (double.IsNaN(number))
            {
                return this.SpecialValuesDictionary[number] ?? throw new NullReferenceException("Value cannot be null.");
            }

            if (double.IsNegativeInfinity(number))
            {
                return this.SpecialValuesDictionary[number] ?? throw new NullReferenceException("Value cannot be null.");
            }

            if (double.IsPositiveInfinity(number))
            {
                return this.SpecialValuesDictionary[number] ?? throw new NullReferenceException("Value cannot be null.");
            }

            if (number == double.Epsilon)
            {
                return this.SpecialValuesDictionary[number] ?? throw new NullReferenceException("Value cannot be null.");
            }

            var result = new StringBuilder();
            var numberString = number.ToString(CultureInfo.CurrentCulture);
            foreach (char letter in numberString)
            {
                if (this.SymbolsDictionary[letter] != null)
                {
                    result.Append(this.SymbolsDictionary[letter] + SpaceSymbol);
                }
                else
                {
                    throw new NullReferenceException("Value cannot be null.");
                }
            }

            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }
    }
}
