namespace Domain.DomainTypes;

public class UnsignedIntDec2 {

    public int IntValue { get;}
    public IEnumerable<char> Digits { get;}

    private UnsignedIntDec2(int intValue, IEnumerable<char> digits) {
        IntValue = intValue;
        Digits = digits;
    }

    public static UnsignedIntDec2 Of(IntString value) {

        if(value.IntValue < 0) {
            throw new ArgumentException();
        }

        if (value.IntValue > 99) {
            throw new ArgumentException();
        }

        return new UnsignedIntDec2(value.IntValue, value.Digits);
    }
}
