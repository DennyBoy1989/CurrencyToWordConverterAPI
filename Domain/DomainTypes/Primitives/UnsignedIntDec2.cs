using Domain.DomainErrors;

namespace Domain.DomainTypes.Primitives;

public class UnsignedIntDec2 {

    public uint IntValue { get; }
    public IEnumerable<char> Digits { get; }

    private UnsignedIntDec2(uint intValue, IEnumerable<char> digits) {
        IntValue = intValue;
        Digits = digits;
    }

    public static UnsignedIntDec2 Of(UnsignedIntString value) {

        if (value.IntValue > 99) {
            throw new InvalidRangeError($"Number string {value.IntValue} is bigger then 99");
        }

        return new UnsignedIntDec2(value.IntValue, value.Digits);
    }
}
