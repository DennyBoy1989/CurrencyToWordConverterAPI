using Domain.DomainTypes.Primitives;

namespace Domain.DomainTypes;

/// <summary>
/// Domain object representing dollars.
/// </summary>
public record Dollars(UnsignedIntDec9 Value) {

    /// <summary>
    /// Factory method to instantiate a new <see cref="Dollars"/> instance by a given <see cref="UnsignedIntString"/>. Throws domain errors, when the given string exceeds the ranges.
    /// </summary>
    /// <exception cref="DomainErrors.InvalidRangeError"></exception>
    public static Dollars Of(UnsignedIntString value) {
        return new Dollars(UnsignedIntDec9.Of(value));
    }
};
