using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;


namespace Domain.Infrastructure
{
    public static class ExtensionMethods
    {
        public static dynamic Cast(this Type Type, object data)
        {
            var DataParam = Expression.Parameter(typeof(object), "data");
            var Body = Expression.Block(Expression.Convert(Expression.Convert(DataParam, data.GetType()), Type));

            var Run = Expression.Lambda(Body, DataParam).Compile();
            dynamic ret = Run.DynamicInvoke(data);
            return ret;
        }



        public delegate void Func<TArg0>(TArg0 element);

        /// <summary>
        /// Executes an Update statement block on all elements in an IEnumerable<T> sequence.
        /// </summary>
        /// <typeparam name="TSource">The source element type.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="update">The update statement to execute for each element.</param>
        /// <returns>The numer of records affected.</returns>
        public static int Update<TSource>(this IEnumerable<TSource> source, Func<TSource> update)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (update == null) throw new ArgumentNullException("update");
            if (typeof(TSource).IsValueType)
                throw new NotSupportedException("value type elements are not supported by update.");

            int count = 0;
            foreach (TSource element in source)
            {
                update(element);
                count++;
            }
            return count;
        }

        public static IEnumerable<IEnumerable<T>> SplitIntoSections<T>(this IEnumerable<T> source,
    Func<T, bool> sectionDivider)
        {
            // The items in the current group.
            IList<T> currentGroup = new List<T>();

            // Cycle through the items.
            foreach (T item in source)
            {
                // Check to see if it is a section divider, if
                // it is, then return the previous section.
                // Also, only return if there are items.
                if (sectionDivider(item) && currentGroup.Count > 0)
                {
                    // Return the list.
                    yield return currentGroup;

                    // Reset the list.
                    currentGroup = new List<T>();
                }

                // Add the item to the list.
                currentGroup.Add(item);
            }

            // If there are items in the list, yield it.
            if (currentGroup.Count > 0) yield return currentGroup;
        }

        internal static bool HasColumn(this IDataRecord dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}
