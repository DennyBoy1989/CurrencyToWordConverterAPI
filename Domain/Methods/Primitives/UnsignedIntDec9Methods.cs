using Domain.DomainTypes;
using Domain.DomainTypes.Primitives;

namespace Domain.Methods.Primitives;
public static class UnsignedIntDec9Methods {

    public static char GetUnitsDigit(this UnsignedIntDec9 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(0, '0');
    }
    public static char GetTensDigit(this UnsignedIntDec9 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(1, '0');
    }
    public static char GetHundredsDigit(this UnsignedIntDec9 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(2, '0');
    }
    public static char GetThousandsDigit(this UnsignedIntDec9 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(3, '0');
    }
    public static char GetTenThousandsDigit(this UnsignedIntDec9 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(4, '0');
    }
    public static char GetHundredThousandsDigit(this UnsignedIntDec9 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(5, '0');
    }
    public static char GetMillionssDigit(this UnsignedIntDec9 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(6, '0');
    }
    public static char GetTenMillionssDigit(this UnsignedIntDec9 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(7, '0');
    }
    public static char GetHundredMillionssDigit(this UnsignedIntDec9 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(8, '0');
    }

    public static UnsignedIntDec3 GetMillionsHundredPart(this UnsignedIntDec9 number) {
        return UnsignedIntDec3.Of(IntString.Of(number.Digits.TakeCountedBackwards(new Range(6, 9))));
    }
    public static UnsignedIntDec3 GetThousandsHundredPart(this UnsignedIntDec9 number) {
        return UnsignedIntDec3.Of(IntString.Of(number.Digits.TakeCountedBackwards(new Range(3, 6))));
    }
    public static UnsignedIntDec3 GetHundredPart(this UnsignedIntDec9 number) {
        return UnsignedIntDec3.Of(IntString.Of(number.Digits.TakeCountedBackwards(new Range(0, 3))));
    }


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


    public static string GetWordRepresentationOfMillionsNumber(this UnsignedIntDec9 number) {

        var millionsPart = number.GetMillionsHundredPart();
        if (millionsPart.IntValue == 0) {
            return "";
        }

        var hundredsTensAndOnes = millionsPart.GetWordRepresentation();
        return $"{hundredsTensAndOnes} million";
    }

    public static string GetWordRepresentationOfThousandsNumber(this UnsignedIntDec9 number) {

        var thousandsPart = number.GetThousandsHundredPart();
        if (thousandsPart.IntValue == 0) {
            return "";
        }

        var hundredsTensAndOnes = thousandsPart.GetWordRepresentation();
        return $"{hundredsTensAndOnes} thousand";
    }

    public static string GetWordRepresentationOfHundredsNumber(this UnsignedIntDec9 number) {

        return number.GetHundredPart().GetWordRepresentation();
    }
}
