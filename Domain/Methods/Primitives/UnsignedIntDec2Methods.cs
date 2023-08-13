using Domain.DomainTypes.Primitives;

namespace Domain.Methods.Primitives;

public static class UnsignedIntDec2Methods {

    public static char GetUnitsDigit(this UnsignedIntDec2 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(0, '0');
    }
    public static char GetTensDigit(this UnsignedIntDec2 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(1, '0');
    }

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
