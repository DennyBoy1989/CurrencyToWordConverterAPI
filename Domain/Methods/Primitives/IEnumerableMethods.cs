namespace Domain.Methods.Primitives;

public static class IEnumerableMethods {

    public static TSource ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, int index, TSource @default) {
        return index >= 0 && index < source.Count() ? source.ElementAt(index) : @default;
    }

    public static TSource? ElementAtCountedBackwardsOrDefault<TSource>(this IEnumerable<TSource> source, int index, TSource @default) {
        return source.ElementAtOrDefault(source.Count() - 1 - index, @default);
    }

    public static IEnumerable<TSource> TakeCountedBackwards<TSource>(this IEnumerable<TSource> source, Range range) {
        var newStartIndex = Math.Max(source.Count() - range.End.Value, 0);
        var newEndIndex = Math.Max(source.Count() - range.Start.Value, 0);
        var inversedRange = new Range(newStartIndex, newEndIndex);
        return source.Take(inversedRange);
    }
}