namespace Domain.DomainTypes;
public class UnsignedIntDec9 {

    public int IntValue { get;}
    public IEnumerable<char> Digits { get;}

    private UnsignedIntDec9(int intValue, IEnumerable<char> digits) {
        IntValue = intValue;
        Digits = digits;
    }

    public static UnsignedIntDec9 Of(IntString value) {

        if (value.IntValue < 0) {
            throw new ArgumentException();
        }

        if (value.IntValue > 999999999) {
            throw new ArgumentException();
        }

        return new UnsignedIntDec9(value.IntValue, value.Digits);
    }
}
