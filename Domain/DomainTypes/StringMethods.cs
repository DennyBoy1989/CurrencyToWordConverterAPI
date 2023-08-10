namespace Domain.DomainTypes;

public static class StringMethods {
    public static string RemoveWhitespace(this string value) {
        return new string(value
            .Where(c => !Char.IsWhiteSpace(c))
            .ToArray());
    }
}
