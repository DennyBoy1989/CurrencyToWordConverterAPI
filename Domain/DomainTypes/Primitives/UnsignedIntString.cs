using Domain.DomainErrors;
using Domain.Methods.Primitives;

namespace Domain.DomainTypes.Primitives;

public class UnsignedIntString {

    public IEnumerable<char> Digits { get; }
    public uint IntValue { get; }

    private UnsignedIntString(IEnumerable<char> digits, uint intValue) {
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

        uint intValue;
        try {
            
            intValue = uint.Parse(sanitizedStringValue);

        }
        catch (OverflowException ex) {
            throw new InvalidRangeError($"Number string {digitString} is either too large or too small for an unsigned int value", ex);
        }
        catch(Exception ex) {
            throw new InvalidNumberNotationError($"Could not parse {digitString} to an int value", ex);
        }

        return new UnsignedIntString(sanitizedStringValue, intValue);
    }
}
