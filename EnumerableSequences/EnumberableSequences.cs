using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using GenericsDemo;

namespace GenericsDemo
{
    public static class EnumberableSequences
    {
        /// <summary>Filters array by filter.</summary>
        /// <typeparam name="TSource">Type of source array.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The filter.</param>
        /// <returns>Filtered array.</returns>
        public static IEnumerable<TSource> FilterBy<TSource>(this IEnumerable<TSource> source, IPredicate<TSource> predicate)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

            if (source.GetEnumerator().MoveNext() == false)
            {
                throw new ArgumentException($"{nameof(source)} cannot be empty.");
            }

            source.GetEnumerator().Reset();

            if (predicate is null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} cannot be null.");
            }

            var filteredSource = new TSource[source.Length()];
            int i = 0;

            foreach (var item in source)
            {
                if (predicate.IsMatch(item))
                {
                    filteredSource[i] = item;
                    i++;
                }
            }

            Array.Resize(ref filteredSource, i);

            return filteredSource;
        }

        /// <summary>Transforms source array into array of the specified type following specified rule.</summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="transformer">The transformer.</param>
        /// <returns>Transformed array.</returns>
        /// <exception cref="ArgumentNullException">Source array is null or transforming rule is null.</exception>
        /// <exception cref="ArgumentException">Source array is empty.</exception>
        public static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> source, ITransformer<TSource, TResult> transformer)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

            if (source.GetEnumerator().MoveNext() == false)
            {
                throw new ArgumentException($"{nameof(source)} cannot be empty.");
            }

            source.GetEnumerator().Reset();

            if (transformer is null)
            {
                throw new ArgumentNullException($"{nameof(transformer)} cannot be null.");
            }

            var filteredSource = new TResult[source.Length()];
            int i = 0;

            foreach (var element in source)
            {
                filteredSource[i] = transformer.Transform(element);
                i++;
            }

            return filteredSource;
        }

        /// <summary>Orders the array according to some rule.</summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="comparer">The comparing rule.</param>
        /// <returns>Transformed array.</returns>
        /// <exception cref="ArgumentNullException">Source array is null or comparing rule is null.</exception>
        /// <exception cref="ArgumentException">Source array is empty.</exception>
        public static IEnumerable<TSource> OrderAccordingTo<TSource>(this IEnumerable<TSource> source, IComparer<TSource> comparer)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

            if (source.GetEnumerator().MoveNext() == false)
            {
                throw new ArgumentException($"{nameof(source)} cannot be empty.");
            }

            source.GetEnumerator().Reset();

            if (comparer is null)
            {
                throw new ArgumentNullException($"{nameof(comparer)} cannot be null.");
            }

            TSource element;

            var returnArray = new TSource[source.Length()];
            int i = 0;

            foreach (var sourceElement in source)
            {
                returnArray[i] = sourceElement;
                i++;
            }

            for (i = 0; i < returnArray.Length; i++)
            {
                for (int j = i; j < returnArray.Length; j++)
                {
                    if (comparer.Compare(returnArray[i], returnArray[j]) < 0)
                    {
                        element = returnArray[i];
                        returnArray[i] = returnArray[j];
                        returnArray[j] = element;
                    }
                }
            }

            return returnArray;
        }

        /// <summary>  Returns source array's elements of the specified type.</summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>Returns the array of specified type.</returns>
        /// <exception cref="ArgumentNullException">Source is null.</exception>
        public static IEnumerable<TSource> TypeOf<TSource>(this IEnumerable<object> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

            List<TSource> returnArray = new List<TSource>();
            foreach (var element in source)
            {
                if (ReferenceEquals(element.GetType(), typeof(TSource)))
                {
                    returnArray.Add((TSource)element);
                }
            }

            return returnArray;
        }

        /// <summary>Reverses the specified source.</summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>Reversed array.</returns>
        /// <exception cref="ArgumentNullException">Source array is null.</exception>
        public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

            TSource[] returnArray = new TSource[source.Length()];
            int i = source.Length() - 1;
            foreach (var element in source)
            {
                returnArray[i] = element;
                i--;
            }

            return returnArray;
        }

        public static int Length<TSource>(this IEnumerable<TSource> enumerable)
        {
            int length = 0;
            foreach (var element in enumerable)
            {
                length++;
            }

            return length;
        }
    }
}