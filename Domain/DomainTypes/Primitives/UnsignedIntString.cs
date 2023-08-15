using Domain.DomainErrors;
using Domain.Methods.Primitives;

namespace Domain.DomainTypes.Primitives;

public class UnsignedIntString {

    public IEnumerable<char> Digits { get; }
    public int IntValue { get; }

    private UnsignedIntString(IEnumerable<char> digits, int intValue) {
        Digits = digits;
        IntValue = intValue;
    }

    /// <exception cref="InvalidNumberNotationError"></exception>
    /// <exception cref="InvalidRangeError"></exception>
    public static UnsignedIntString Of(IEnumerable<char> digits) {

        var digitString = new string(digits.ToArray());
        var sanitizedStringValue = digitString.RemoveWhitespace()
            .TrimStart('0');

        if (sanitizedStringValue.Count() == 0) {
            return new UnsignedIntString("0", 0);
        }

        int intValue;
        try {
            intValue = int.Parse(sanitizedStringValue);

        }
        catch(Exception ex) {
            throw new InvalidNumberNotationError($"Could not parse {digitString} to an int value", ex);
        }

        if (intValue < 0) {
            throw new InvalidRangeError($"Number string {digitString} is smaller then zero");
        }

        return new UnsignedIntString(sanitizedStringValue, intValue);
    }
}
