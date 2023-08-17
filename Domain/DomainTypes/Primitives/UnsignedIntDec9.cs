using Domain.DomainErrors;

namespace Domain.DomainTypes.Primitives;

/// <summary>
/// Primitiv domain object, that represents a number with the range 0 to 999999999.
/// </summary>
public class UnsignedIntDec9 {

    public uint IntValue { get; }
    public IEnumerable<char> Digits { get; }

    private UnsignedIntDec9(uint intValue, IEnumerable<char> digits) {
        IntValue = intValue;
        Digits = digits;
    }

    /// <summary>
    /// Factory method to instantiate a new <see cref="UnsignedIntDec9"/> by a given <see cref="UnsignedIntString"/> . Throws domain errors, when the given string exceeds the ranges.
    /// </summary>
    /// <exception cref="InvalidRangeError"></exception>
    public static UnsignedIntDec9 Of(UnsignedIntString value) {

        if (value.IntValue > 999999999) {
            throw new InvalidRangeError($"Number string {value.IntValue} is bigger then 999999999");
        }

        return new UnsignedIntDec9(value.IntValue, value.Digits);
    }
}
