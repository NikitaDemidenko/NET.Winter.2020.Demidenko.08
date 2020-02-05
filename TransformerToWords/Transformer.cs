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
        private readonly Dictionary<double, string> specialValuesDictionary = new Dictionary<double, string>
        {
            [double.NaN] = null,
            [double.NegativeInfinity] = null,
            [double.PositiveInfinity] = null,
            [double.Epsilon] = null,
        };

        private readonly Dictionary<char, string> symbolsDictionary = new Dictionary<char, string>
        {
            ['0'] = null,
            ['1'] = null,
            ['2'] = null,
            ['3'] = null,
            ['4'] = null,
            ['5'] = null,
            ['6'] = null,
            ['7'] = null,
            ['8'] = null,
            ['9'] = null,
            ['-'] = null,
            ['+'] = null,
            ['E'] = null,
            ['.'] = null,
        };

        /// <summary>Transforms double to its string representation.</summary>
        /// <param name="number">Number.</param>
        /// <returns>Returns number's string representation.</returns>
        public string TransformToWords(double number)
        {
            this.SetSpecialValuesStringRepresentation(this.specialValuesDictionary);
            if (double.IsNaN(number))
            {
                return this.specialValuesDictionary[number] ?? throw new NullReferenceException();
            }

            if (double.IsNegativeInfinity(number))
            {
                return this.specialValuesDictionary[number] ?? throw new NullReferenceException();
            }

            if (double.IsPositiveInfinity(number))
            {
                return this.specialValuesDictionary[number] ?? throw new NullReferenceException();
            }

            if (number == double.Epsilon)
            {
                return this.specialValuesDictionary[number] ?? throw new NullReferenceException();
            }

            this.SetSymbolsStringRepresentation(this.symbolsDictionary);
            var result = new StringBuilder();
            var numberString = number.ToString(CultureInfo.InvariantCulture);
            foreach (char letter in numberString)
            {
                if (this.symbolsDictionary[letter] == null)
                {
                    throw new NullReferenceException();
                }

                result.Append(this.symbolsDictionary[letter] + SpaceSymbol);
            }

            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }

        /// <summary>Sets special values' string representation.</summary>
        /// <param name="specialValuesDictionary">Special values dictionary.</param>
        protected abstract void SetSpecialValuesStringRepresentation(Dictionary<double, string> specialValuesDictionary);

        /// <summary>Sets symbols' string representation.</summary>
        /// <param name="symbolsDictionary">Symbols dictionary.</param>
        protected abstract void SetSymbolsStringRepresentation(Dictionary<char, string> symbolsDictionary);
    }
}
