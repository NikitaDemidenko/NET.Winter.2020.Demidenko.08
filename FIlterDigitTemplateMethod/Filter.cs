using System;
using System.Collections.Generic;

namespace FilterTemplateMethod
{
    /// <summary>Provides methods for filter array by specified sign.</summary>
    public abstract class Filter
    {
        /// <summary>Filters the array by specified sign.</summary>
        /// <param name="array">An array.</param>
        /// <returns>Returns new filtered array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public int[] FilterArrayByKey(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.");
            }

            var resultArray = new List<int>();
            foreach (int number in array)
            {
                if (this.IsMatch(number))
                {
                    resultArray.Add(number);
                }
            }

            return resultArray.ToArray();
        }

        /// <summary>Determines whether the specified number satisfies specified sign.</summary>
        /// <param name="number">Number.</param>
        /// <returns>
        ///   <c>true</c> if the specified number is match; otherwise, <c>false</c>.</returns>
        protected abstract bool IsMatch(int number);
    }
}
