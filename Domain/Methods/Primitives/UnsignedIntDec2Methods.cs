using Domain.DomainTypes.Primitives;

namespace Domain.Methods.Primitives;

/// <summary>
/// Extensions methods for <see cref="UnsignedIntDec2"/> objects with the focus on getting a certain place or the word representation of a number.
/// </summary>
public static class UnsignedIntDec2Methods {

    /// <summary>
    /// Gets the first digit from the right of a number.
    /// </summary>
    public static char GetUnitsDigit(this UnsignedIntDec2 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(0, '0');
    }

    /// <summary>
    /// Gets the second digit from the right of a number. If the the number has no second digit, then 0 is returned.
    /// </summary>
    public static char GetTensDigit(this UnsignedIntDec2 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(1, '0');
    }

    /// <summary>
    /// Gets the english word representation of a number betwenn 0 and 99.
    /// </summary>
    public static string GetWordRepresentation(this UnsignedIntDec2 number) {

        if(number.GetTensDigit() == '0') {
            return number.GetUnitsDigit().GetWordRepresentationOfUnitsDigit();
        }
        if (number.GetTensDigit() == '1') {
            return number.GetUnitsDigit().GetWordRepresentationOfNumberBetweenTenAndNineTeen();
        }
        if (number.GetUnitsDigit() == '0') {
            return number.GetTensDigit().GetWordRepresentationOfTensDigit();
        }

        string tensDigitAsWord = number.GetTensDigit().GetWordRepresentationOfTensDigit();
        string unitDigitAsWord = number.GetUnitsDigit().GetWordRepresentationOfUnitsDigit();

        return $"{tensDigitAsWord}-{unitDigitAsWord}";

    }
}
