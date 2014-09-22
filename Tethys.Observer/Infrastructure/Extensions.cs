using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tethys.Observer.Infrastructure
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
    }
}