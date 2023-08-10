namespace Domain.DomainTypes;

public static class UnsignedIntDec3Methods {

    public static char GetUnitsDigit(this UnsignedIntDec3 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(0);
    }
    public static char GetTensDigit(this UnsignedIntDec3 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(1);
    }
    public static char GetHundredsDigit(this UnsignedIntDec3 number) {
        return number.Digits.ElementAtCountedBackwardsOrDefault(2);
    }
    public static bool HasUnitsDigit(this UnsignedIntDec3 number) {
        return number.Digits.Count() >= 1;
    }
    public static bool HasTensDigit(this UnsignedIntDec3 number) {
        return number.Digits.Count() >= 2;
    }
    public static bool HasHundredsDigit(this UnsignedIntDec3 number) {
        return number.Digits.Count() >= 3;
    }

    public static UnsignedIntDec2 GetTensPart(this UnsignedIntDec3 number) {
        return UnsignedIntDec2.Of(IntString.Of(number.Digits.TakeCountedBackwards(new Range(0, 2))));
    }

    public static string GetWordRepresentationOfMillionsNumber(this UnsignedIntDec3 number) {

        if (number.IntValue == 0) {
            return "";
        }

        var hundredsTensAndOnes = number.GetWordRepresentationOfHundredsNumber();
        return $"{hundredsTensAndOnes} million";
    }

    public static string GetWordRepresentationOfThousandsNumber(this UnsignedIntDec3 number) {

        if (number.IntValue == 0) {
            return "";
        }

        var hundredsTensAndOnes = number.GetWordRepresentationOfHundredsNumber();
        return $"{hundredsTensAndOnes} thousand";
    }

    public static string GetWordRepresentationOfHundredsNumber(this UnsignedIntDec3 number) {

        if (number.IntValue == 0) {
            return '0'.GetWordRepresentationOfUnitsDigit();
        }

        if(number.IntValue % 100 == 0) {
            return number.GetWordRepresentationOfHundredsDigit();
        }

        string hundredsDigitAsWord = number.GetWordRepresentationOfHundredsDigit().ConcatWithSequenceWhenNotEmpty(" ");
        string tensAndUnitsDigitsAsWords = number.GetTensPart().GetWordRepresentationOfDigitOfTensAndDigitOfUnits();
        return $"{hundredsDigitAsWord}{tensAndUnitsDigitsAsWords}";
        
    }

    public static string GetWordRepresentationOfHundredsDigit(this UnsignedIntDec3 number) {

        if (number.HasHundredsDigit()) {
            var hundredDigit = number.GetHundredsDigit();
            return hundredDigit.GetWordRepresentationOfHundredsDigit();
        }
        else {
            return "";
        }
    }

}
