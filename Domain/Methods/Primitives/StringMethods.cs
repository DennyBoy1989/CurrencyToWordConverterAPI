namespace Domain.Methods.Primitives;

/// <summary>
/// Extensions methods for <see cref="string"/> objects.
/// </summary>
public static class StringMethods {

    /// <summary>
    /// Removes all spaces, tabs and linebreaks from a given string. The original string is not changed.
    /// </summary>
    public static string RemoveWhitespace(this string value) {
        return new string(value
            .Where(c => !char.IsWhiteSpace(c))
            .ToArray());
    }

    /// <summary>
    /// Concatenate a given string with a given string, but only if it's not empty. The original string is not changed.
    /// </summary>
    public static string ConcatWithSequenceWhenNotEmpty(this string value, string sequenceToConcat) {
        if (!string.IsNullOrWhiteSpace(value)) {
            return value + sequenceToConcat;
        }
        return value;
    }
}
