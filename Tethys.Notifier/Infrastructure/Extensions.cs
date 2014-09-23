using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tethys.Notifier.Infrastructure
{
    public static class Extensions
    {
        public static IEnumerable<SelectListItem> AsSelectList<T>(this IEnumerable<T> collection, Func<T, string> selector, string selected, string defaultValue = "-- Please select --")
        {
            yield return new SelectListItem
            {
                Text = defaultValue,
                Value = string.Empty,
                Selected = string.IsNullOrEmpty(selected)
            };

            foreach (var item in collection)
            {
                var propertyValue = selector(item);

                yield return new SelectListItem
                {
                    Text = propertyValue,
                    Value = propertyValue,
                    Selected = propertyValue == selected
                };
            }
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return source.DistinctBy(keySelector, null);
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (keySelector == null) throw new ArgumentNullException("keySelector");

            return DistinctByImpl(source, keySelector, comparer);
        }

        private static IEnumerable<TSource> DistinctByImpl<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            var knownKeys = new HashSet<TKey>(comparer);
            foreach (var element in source)
            {
                if (knownKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}