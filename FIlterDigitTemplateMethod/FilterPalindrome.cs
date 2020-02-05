using System;
using System.Collections.Generic;
using System.Text;
using static NumbersExtensions.NumbersExtension;

namespace FilterTemplateMethod
{
    /// <summary>Provides methods for filter array by palindrome numbers.</summary>
    /// <seealso cref="FilterTemplateMethod.Filter" />
    public sealed class FilterPalindrome : Filter
    {
        /// <summary>Determines whether the specified number is palindrome.</summary>
        /// <param name="number">Number.</param>
        /// <returns>
        ///   <c>true</c> if the specified number is palindrome; otherwise, <c>false</c>.</returns>
        protected override bool IsMatch(int number)
        {
            return IsPalindrome(number);
        }
    }
}
