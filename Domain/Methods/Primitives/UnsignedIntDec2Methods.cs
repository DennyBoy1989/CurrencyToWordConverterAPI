using Domain.DomainTypes.Primitives;

namespace Domain.Methods.Primitives;

public static class UnsignedIntDec2Methods {

    public static char GetUnitsDigit(this UnsignedIntDec2 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(0);
    }
    public static char GetTensDigit(this UnsignedIntDec2 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(1);
    }

    public static bool HasUnitsDigit(this UnsignedIntDec2 number) {
        return number.Digits.Count() >= 1;
    }
    public static bool HasTensDigit(this UnsignedIntDec2 number) {
        return number.Digits.Count() >= 2;
    }

    public static string GetWordRepresentationOfDigitOfTensAndDigitOfUnits(this UnsignedIntDec2 number) {

        if (number.HasTensDigit() && number.GetTensDigit() == '1') {
            return number.GetUnitsDigit().GetWordRepresentationOfNumberBetweenTenAndNineTeen();
        }
        if (number.GetUnitsDigit() == '0') {
            return number.GetTensDigit().GetWordRepresentationOfTensDigit();
        }

        string tensDigitAsWord = number.GetTensDigit().GetWordRepresentationOfTensDigit().ConcatWithSequenceWhenNotEmpty("-");
        string unitDigitAsWord = number.GetUnitsDigit().GetWordRepresentationOfUnitsDigit();

        return $"{tensDigitAsWord}{unitDigitAsWord}";

    }
}
