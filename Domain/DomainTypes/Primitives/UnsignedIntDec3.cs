namespace Domain.DomainTypes.Primitives;

public class UnsignedIntDec3 {

    public int IntValue { get; }
    public IEnumerable<char> Digits { get; }

    private UnsignedIntDec3(int intValue, IEnumerable<char> digits) {
        IntValue = intValue;
        Digits = digits;
    }

    public static UnsignedIntDec3 Of(IntString value) {

        if (value.IntValue < 0) {
            throw new ArgumentException();
        }

        if (value.IntValue > 999) {
            throw new ArgumentException();
        }

        return new UnsignedIntDec3(value.IntValue, value.Digits);
    }
}
