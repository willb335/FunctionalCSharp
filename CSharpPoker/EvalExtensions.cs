using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpPoker
{
    public static class EvalExtensions
    {
        public static IEnumerable<TResult> SelectConsecutive<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TSource, TResult> selector)
        {
            int index = -1;
            foreach (TSource element in source.Take(source.Count() - 1)) // skip the last, it will be evaluated by source.ElementAt(index + 1)
            {
                checked { index++; } // explicitly enable overflow checking
                yield return selector(element, source.ElementAt(index + 1)); // delegate element and element[+1] to Func<TSource, TSource, TResult>
            }
        }
    }
}
