using Domain.DomainErrors;
using Domain.Methods.Primitives;

namespace Domain.DomainTypes.Primitives;

/// <summary>
/// Primitiv domain object, that represents a number with the range 0 to 4294967295.
/// </summary>
public class UnsignedIntString {

    public IEnumerable<char> Digits { get; }
    public uint IntValue { get; }

    private UnsignedIntString(IEnumerable<char> digits, uint intValue) {
        Digits = digits;
        IntValue = intValue;
    }

    /// <summary>
    /// Factory method to instantiate a new <see cref="UnsignedIntString"/> by a given string. Throws domain errors, when the given string exceeds the ranges or has an invalid format.
    /// </summary>
    /// <exception cref="InvalidNumberNotationError"></exception>
    /// <exception cref="InvalidRangeError"></exception>
    public static UnsignedIntString Of(IEnumerable<char> digits) {

        var digitString = new string(digits.ToArray());
        var sanitizedStringValue = digitString.RemoveWhitespace()
            .TrimStart('0');

        if (sanitizedStringValue.Count() == 0) {
            return new UnsignedIntString("0", 0);
        }

        try {
            uint intValue = uint.Parse(sanitizedStringValue);
            return new UnsignedIntString(sanitizedStringValue, intValue);
        }
        catch (OverflowException ex) {
            throw new InvalidRangeError($"Number string {digitString} is either too large or too small for an unsigned int value", ex);
        }
        catch(Exception ex) {
            throw new InvalidNumberNotationError($"Could not parse {digitString} to an int value", ex);
        }
    }
}
