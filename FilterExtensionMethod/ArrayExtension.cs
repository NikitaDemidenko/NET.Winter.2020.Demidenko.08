using System;
using FilterTemplateMethod;

namespace FilterExtensionMethod
{
    /// <summary>Provides extension method to filter array by specified sign.</summary>
    public static class ArrayExtension
    {
        /// <summary>Filters array by specified sign.</summary>
        /// <param name="array">Array.</param>
        /// <param name="filter">Specified filter.</param>
        /// <returns>Returns new filtered array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <em>filter</em> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static int[] FilterBy(this int[] array, Filter filter)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.");
            }

            return filter.FilterArrayByKey(array);
        }
    }
}
