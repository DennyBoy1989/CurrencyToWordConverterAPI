namespace Domain.DomainTypes;
public static class UnsignedIntDec9Methods {

    public static char GetUnitsDigit(this UnsignedIntDec9 number) {
        return number.StringValue.Reverse().ElementAtOrDefault(0);
    }
    public static char GetTensDigit(this UnsignedIntDec9 number) {
        return number.StringValue.Reverse().ElementAtOrDefault(1);
    }
    public static char GetHundredsDigit(this UnsignedIntDec9 number) {
        return number.StringValue.Reverse().ElementAtOrDefault(2);
    }
    public static char GetThousandsDigit(this UnsignedIntDec9 number) {
        return number.StringValue.Reverse().ElementAtOrDefault(3);
    }
    public static char GetTenThousandsDigit(this UnsignedIntDec9 number) {
        return number.StringValue.Reverse().ElementAtOrDefault(4);
    }
    public static char GetHundredThousandsDigit(this UnsignedIntDec9 number) {
        return number.StringValue.Reverse().ElementAtOrDefault(5);
    }
    public static char GetMillionssDigit(this UnsignedIntDec9 number) {
        return number.StringValue.Reverse().ElementAtOrDefault(6);
    }
    public static char GetTenMillionssDigit(this UnsignedIntDec9 number) {
        return number.StringValue.Reverse().ElementAtOrDefault(7);
    }
    public static char GetHundredMillionssDigit(this UnsignedIntDec9 number) {
        return number.StringValue.Reverse().ElementAtOrDefault(8);
    }

    public static UnsignedIntDec3 GetMillionsHundredPart(this UnsignedIntDec9 number) {
       return  UnsignedIntDec3.Of(IntString.Of(new string(number.StringValue.Reverse().Take(new Range(6, 9)).Reverse().ToArray())));
    }
    public static UnsignedIntDec3 GetThousandsHundredPart(this UnsignedIntDec9 number) {
        return UnsignedIntDec3.Of(IntString.Of(new string(number.StringValue.Reverse().Take(new Range(3, 6)).Reverse().ToArray())));
    }
    public static UnsignedIntDec3 GetHundredPart(this UnsignedIntDec9 number) {
        return UnsignedIntDec3.Of(IntString.Of(new string(number.StringValue.Reverse().Take(new Range(0, 3)).Reverse().ToArray())));
    }
}
