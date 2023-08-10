using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainTypes; 
public static class IEnumerableMethods {
    public static TSource? ElementAtCountedBackwardsOrDefault<TSource>(this IEnumerable<TSource> source, int index) {
        return source.ElementAtOrDefault(source.Count() - 1 - index);
    }

    public static IEnumerable<TSource> TakeCountedBackwards<TSource>(this IEnumerable<TSource> source, Range range) {
        var newStartIndex = Math.Max(source.Count() - range.End.Value, 0);
        var newEndIndex = Math.Max(source.Count() - range.Start.Value, 0);
        var inversedRange = new Range(newStartIndex, newEndIndex);
        return source.Take(inversedRange);
    }
}