namespace Domain.Methods.Primitives;

/// <summary>
/// Extensions methods for <see cref="IEnumerable{T}"/> objects.
/// </summary>
public static class IEnumerableMethods {

    /// <summary>
    /// Returns the element at the specified position in the source sequencce or a specified default value, if the there is not element.
    /// </summary>
    public static TSource ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, int index, TSource @default) {
        return index >= 0 && index < source.Count() ? source.ElementAt(index) : @default;
    }

    /// <summary>
    /// Returns the element at the specified position in the source sequencce or a specified default value, if the there is not element. The specified position
    /// is counted backwards. So the last element of the sequence is 0, the second last is 1 and so on.
    /// </summary>
    public static TSource? ElementAtCountedBackwardsOrDefault<TSource>(this IEnumerable<TSource> source, int index, TSource @default) {
        return source.ElementAtOrDefault(source.Count() - 1 - index, @default);
    }

    /// <summary>
    /// Returns a specified range of contiguous elements from a sequence. The range is counted backward. So the range (0,3) tries to get the last three elements of a list.
    /// </summary>
    public static IEnumerable<TSource> TakeCountedBackwards<TSource>(this IEnumerable<TSource> source, Range range) {
        var newStartIndex = Math.Max(source.Count() - range.End.Value, 0);
        var newEndIndex = Math.Max(source.Count() - range.Start.Value, 0);
        var inversedRange = new Range(newStartIndex, newEndIndex);
        return source.Take(inversedRange);
    }
}