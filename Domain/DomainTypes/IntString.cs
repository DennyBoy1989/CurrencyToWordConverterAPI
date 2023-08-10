namespace Domain.DomainTypes;

public class IntString {

    public IEnumerable<char> Digits { get; }
    public int IntValue { get; }

    private IntString(IEnumerable<char> digits, int intValue) {
        Digits = digits;
        IntValue = intValue;
    }

    public static IntString Of(IEnumerable<char> digits) {

        var digitString = new string(digits.ToArray());
        var sanitizedStringValue = digitString.RemoveWhitespace()
            .TrimStart('0');

        if (sanitizedStringValue.Count() == 0) {
            return new IntString("0", 0);
        }

        var intValue = int.Parse(sanitizedStringValue);
        return new IntString(sanitizedStringValue, intValue);
    }
}
