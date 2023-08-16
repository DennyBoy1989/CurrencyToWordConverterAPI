using Domain.DomainErrors;

namespace Domain.DomainTypes.Primitives;

public class UnsignedIntDec9 {

    public uint IntValue { get; }
    public IEnumerable<char> Digits { get; }

    private UnsignedIntDec9(uint intValue, IEnumerable<char> digits) {
        IntValue = intValue;
        Digits = digits;
    }

    public static UnsignedIntDec9 Of(UnsignedIntString value) {

        if (value.IntValue > 999999999) {
            throw new InvalidRangeError($"Number string {value.IntValue} is bigger then 999999999");
        }

        return new UnsignedIntDec9(value.IntValue, value.Digits);
    }
}
