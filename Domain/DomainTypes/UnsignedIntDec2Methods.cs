namespace Domain.DomainTypes;

public static class UnsignedIntDec2Methods {

    public static char GetUnitsDigit(this UnsignedIntDec2 number) {
        return number.StringValue.Reverse().ElementAtOrDefault(0);
    }
    public static char GetTensDigit(this UnsignedIntDec2 number) {
        return number.StringValue.Reverse().ElementAtOrDefault(1);
    }


    public static bool HasUnitsDigit(this UnsignedIntDec2 number) {
        return number.StringValue.Count() >= 1;
    }
    public static bool HasTensDigit(this UnsignedIntDec2 number) {
        return number.StringValue.Count() >= 2;
    }


    public static string GetWordRepresentationOfDigitOfTensAndDigitOfUnits(this UnsignedIntDec2 number) {


        if (!number.HasTensDigit()) {
            return number.GetUnitsDigit().GetUnitDigitsWordRepresentation();
        }
        if (number.GetTensDigit() == '1') {
            return number.GetUnitsDigit().GetWordRepresentationOfNumberBetweenTenAndNineTeen();
        }
        if (number.GetUnitsDigit() == '0') {
            return number.GetTensDigit().GetTensDigitWordRepresentation();
        }

        string tensDigitAsWord = number.GetTensDigit().GetTensDigitWordRepresentation();
        string unitDigitAsWord = number.GetUnitsDigit().GetUnitDigitsWordRepresentation();

        return $"{tensDigitAsWord}-{unitDigitAsWord}";

    }
}
