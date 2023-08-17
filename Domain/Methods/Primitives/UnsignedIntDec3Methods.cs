using Domain.DomainTypes.Primitives;

namespace Domain.Methods.Primitives;

/// <summary>
/// Extensions methods for <see cref="UnsignedIntDec3"/> objects with the focus on getting a certain place or the word representation of a number.
/// </summary>
public static class UnsignedIntDec3Methods {

    /// <summary>
    /// Gets the first digit from the right of a number.
    /// </summary>
    public static char GetUnitsDigit(this UnsignedIntDec3 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(0, '0');
    }

    /// <summary>
    /// Gets the second digit from the right of a number. If the the number has no second digit, then 0 is returned.
    /// </summary>
    public static char GetTensDigit(this UnsignedIntDec3 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(1, '0');
    }

    /// <summary>
    /// Gets the third digit from the right of a number. If the the number has no third digit, then 0 is returned.
    /// </summary>
    public static char GetHundredsDigit(this UnsignedIntDec3 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(2, '0');
    }

    /// <summary>
    /// Gets a sub-number containing the first to second number from the right of the given number. E.g. 123 returns 23.
    /// </summary>
    public static UnsignedIntDec2 GetTensPart(this UnsignedIntDec3 number) {
        return UnsignedIntDec2.Of(UnsignedIntString.Of(number.Digits.TakeCountedBackwards(new Range(0, 2))));
    }

    /// <summary>
    /// Gets the english word representation of a number betwenn 0 and 999.
    /// </summary>
    public static string GetWordRepresentation(this UnsignedIntDec3 number) {

        if (number.IntValue == 0) {
            return '0'.GetWordRepresentationOfUnitsDigit();
        }

        if (number.IntValue % 100 == 0) {
            return number.GetWordRepresentationOfHundredsDigit();
        }

        string hundredsDigitAsWord = number.GetWordRepresentationOfHundredsDigit().ConcatWithSequenceWhenNotEmpty(" ");
        string tensAndUnitsDigitsAsWords = number.GetTensPart().GetWordRepresentation();
        return $"{hundredsDigitAsWord}{tensAndUnitsDigitsAsWords}";

    }

    /// <summary>
    /// Gets the english word representation of a number betwenn 0 and 999 ignoring the first two digits from the right. E.g. 123 will be translated as 100.
    /// </summary>
    private static string GetWordRepresentationOfHundredsDigit(this UnsignedIntDec3 number) {

        var hundredDigit = number.GetHundredsDigit();
        return hundredDigit.GetWordRepresentationOfHundredsDigit();
    }

}
