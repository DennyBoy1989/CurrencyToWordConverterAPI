using Domain.DomainErrors;

namespace Domain.DomainTypes.Primitives;

/// <summary>
/// Primitiv domain object, that represents a number with the range 0 to 99.
/// </summary>
public class UnsignedIntDec2 {

    public uint IntValue { get; }
    public IEnumerable<char> Digits { get; }

    private UnsignedIntDec2(uint intValue, IEnumerable<char> digits) {
        IntValue = intValue;
        Digits = digits;
    }

    /// <summary>
    /// Factory method to instantiate a new <see cref="UnsignedIntDec2"/> by a given <see cref="UnsignedIntString"/>. Throws domain errors, when the given string exceeds the ranges.
    /// </summary>
    /// <exception cref="InvalidRangeError"></exception>
    public static UnsignedIntDec2 Of(UnsignedIntString value) {

        if (value.IntValue > 99) {
            throw new InvalidRangeError($"Number string {value.IntValue} is bigger then 99");
        }

        return new UnsignedIntDec2(value.IntValue, value.Digits);
    }
}
