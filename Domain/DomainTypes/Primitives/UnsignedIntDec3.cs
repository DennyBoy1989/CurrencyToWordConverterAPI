using Domain.DomainErrors;

namespace Domain.DomainTypes.Primitives;

public class UnsignedIntDec3 {

    public uint IntValue { get; }
    public IEnumerable<char> Digits { get; }

    private UnsignedIntDec3(uint intValue, IEnumerable<char> digits) {
        IntValue = intValue;
        Digits = digits;
    }

    public static UnsignedIntDec3 Of(UnsignedIntString value) {

        if (value.IntValue > 999) {
            throw new InvalidRangeError($"Number string {value.IntValue} is bigger then 999");
        }

        return new UnsignedIntDec3(value.IntValue, value.Digits);
    }
}
