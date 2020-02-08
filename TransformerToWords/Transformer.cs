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
            if (this.SpecialValuesDictionary.TryGetValue(number, out string specialValueResult))
            {
                return specialValueResult;
            }

            var result = new StringBuilder();
            var numberString = number.ToString(CultureInfo.CurrentCulture);
            string symbolStringRepresentation;
            foreach (char symbol in numberString)
            {
                if (this.SymbolsDictionary.TryGetValue(symbol, out symbolStringRepresentation))
                {
                    if (symbolStringRepresentation == null)
                    {
                        throw new InvalidOperationException("Value is null.");
                    }

                    result.Append(symbolStringRepresentation + SpaceSymbol);
                }
                else
                {
                    throw new InvalidOperationException("Key not found.");
                }
            }

            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }
    }
}
