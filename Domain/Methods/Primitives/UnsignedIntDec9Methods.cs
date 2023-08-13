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
        return number.Digits.Reverse().ElementAtCountedBackwardsOrDefault(8, '0');
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
}
