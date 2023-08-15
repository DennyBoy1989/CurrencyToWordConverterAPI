using Domain.DomainTypes.Primitives;

namespace Domain.Methods.Primitives;

public static class UnsignedIntDec3Methods {

    public static char GetUnitsDigit(this UnsignedIntDec3 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(0, '0');
    }
    public static char GetTensDigit(this UnsignedIntDec3 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(1, '0');
    }
    public static char GetHundredsDigit(this UnsignedIntDec3 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(2, '0');
    }

    public static UnsignedIntDec2 GetTensPart(this UnsignedIntDec3 number) {
        return UnsignedIntDec2.Of(UnsignedIntString.Of(number.Digits.TakeCountedBackwards(new Range(0, 2))));
    }

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

    private static string GetWordRepresentationOfHundredsDigit(this UnsignedIntDec3 number) {

        var hundredDigit = number.GetHundredsDigit();
        return hundredDigit.GetWordRepresentationOfHundredsDigit();
    }

}
