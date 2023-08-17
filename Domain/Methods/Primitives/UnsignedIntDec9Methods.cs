using Domain.DomainTypes.Primitives;

namespace Domain.Methods.Primitives;

/// <summary>
/// Extensions methods for <see cref="UnsignedIntDec9"/> objects with the focus on getting a certain place or the word representation of a number.
/// </summary>
public static class UnsignedIntDec9Methods {

    /// <summary>
    /// Gets the first digit from the right of a number.
    /// </summary>
    public static char GetUnitsDigit(this UnsignedIntDec9 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(0, '0');
    }

    /// <summary>
    /// Gets the second digit from the right of a number. If the the number has no second digit, then 0 is returned.
    /// </summary>
    public static char GetTensDigit(this UnsignedIntDec9 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(1, '0');
    }

    /// <summary>
    /// Gets the third digit from the right of a number. If the the number has no third digit, then 0 is returned.
    /// </summary>
    public static char GetHundredsDigit(this UnsignedIntDec9 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(2, '0');
    }

    /// <summary>
    /// Gets the fourth digit from the right of a number. If the the number has no fourth digit, then 0 is returned.
    /// </summary>
    public static char GetThousandsDigit(this UnsignedIntDec9 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(3, '0');
    }

    /// <summary>
    /// Gets the fifth digit from the right of a number. If the the number has no fifth digit, then 0 is returned.
    /// </summary>
    public static char GetTenThousandsDigit(this UnsignedIntDec9 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(4, '0');
    }

    /// <summary>
    /// Gets the sixth digit from the right of a number. If the the number has no sixth digit, then 0 is returned.
    /// </summary>
    public static char GetHundredThousandsDigit(this UnsignedIntDec9 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(5, '0');
    }

    /// <summary>
    /// Gets the seventh digit from the right of a number. If the the number has no seventh digit, then 0 is returned.
    /// </summary>
    public static char GetMillionssDigit(this UnsignedIntDec9 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(6, '0');
    }

    /// <summary>
    /// Gets the eighth digit from the right of a number. If the the number has no eighth digit, then 0 is returned.
    /// </summary>
    public static char GetTenMillionssDigit(this UnsignedIntDec9 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(7, '0');
    }

    /// <summary>
    /// Gets the ninth digit from the right of a number. If the the number has no ninth digit, then 0 is returned.
    /// </summary>
    public static char GetHundredMillionssDigit(this UnsignedIntDec9 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(8, '0');
    }

    /// <summary>
    /// Gets a sub-number containing the seventh to ninth number from the right of the given number. E.g. 123456789 returns 123. If the number has no millions part, the returned value is 0.
    /// </summary>
    public static UnsignedIntDec3 GetMillionsHundredPart(this UnsignedIntDec9 number) {
        return UnsignedIntDec3.Of(UnsignedIntString.Of(number.Digits.TakeCountedBackwards(new Range(6, 9))));
    }

    /// <summary>
    /// Gets a sub-number containing the fourth to sixth number from the right of the given number. E.g. 123456789 returns 456. If the number has no thousand part, the returned value is 0.
    /// </summary>
    public static UnsignedIntDec3 GetThousandsHundredPart(this UnsignedIntDec9 number) {
        return UnsignedIntDec3.Of(UnsignedIntString.Of(number.Digits.TakeCountedBackwards(new Range(3, 6))));
    }

    /// <summary>
    /// Gets a sub-number containing the firsth to third number from the right of the given number. E.g. 123456789 returns 789.
    /// </summary>
    public static UnsignedIntDec3 GetHundredPart(this UnsignedIntDec9 number) {
        return UnsignedIntDec3.Of(UnsignedIntString.Of(number.Digits.TakeCountedBackwards(new Range(0, 3))));
    }

    /// <summary>
    /// Gets the english word representation of a number betwenn 0 and 999999999.
    /// </summary>
    public static string GetWordRepresentation(this UnsignedIntDec9 number) {

        if (number.IntValue == 0) {
            return $"{'0'.GetWordRepresentationOfUnitsDigit()}";
        }

        if (number.IntValue % 1000000 == 0) {
            string millionsNumber = number.GetWordRepresentationOfMillionsNumber();
            return $"{millionsNumber}";
        }
        if (number.IntValue % 1000 == 0) {
            string millionsNumber = number.GetWordRepresentationOfMillionsNumber().ConcatWithSequenceWhenNotEmpty(" ");
            string thousandsNumber = number.GetWordRepresentationOfThousandsNumber();
            return $"{millionsNumber}{thousandsNumber}";
        }
        else {
            string millionsNumber = number.GetWordRepresentationOfMillionsNumber().ConcatWithSequenceWhenNotEmpty(" ");
            string thousandsNumber = number.GetWordRepresentationOfThousandsNumber().ConcatWithSequenceWhenNotEmpty(" ");
            string hundredsNumber = number.GetWordRepresentationOfHundredsNumber();
            return $"{millionsNumber}{thousandsNumber}{hundredsNumber}";
        }
    }

    /// <summary>
    /// Gets the english word representation of a number betwenn 0 and 999999999 ignoring the first six digits from the right. E.g. 123456789 will be translated as 123000000.
    /// </summary>
    public static string GetWordRepresentationOfMillionsNumber(this UnsignedIntDec9 number) {

        var millionsPart = number.GetMillionsHundredPart();
        if (millionsPart.IntValue == 0) {
            return "";
        }

        var hundredsTensAndOnes = millionsPart.GetWordRepresentation();
        return $"{hundredsTensAndOnes} million";
    }

    /// <summary>
    /// Gets the english word representation of a number betwenn 0 and 999999999 ignoring the first three digits and the last three digits from the right.  E.g. 123456789 will be translated as 456000.
    /// </summary>
    public static string GetWordRepresentationOfThousandsNumber(this UnsignedIntDec9 number) {

        var thousandsPart = number.GetThousandsHundredPart();
        if (thousandsPart.IntValue == 0) {
            return "";
        }

        var hundredsTensAndOnes = thousandsPart.GetWordRepresentation();
        return $"{hundredsTensAndOnes} thousand";
    }

    /// <summary>
    /// Gets the english word representation of a number betwenn 0 and 999999999 ignoring the last six digits from the right. E.g. 123456789 will be translated as 789.
    /// </summary>
    public static string GetWordRepresentationOfHundredsNumber(this UnsignedIntDec9 number) {

        return number.GetHundredPart().GetWordRepresentation();
    }
}
