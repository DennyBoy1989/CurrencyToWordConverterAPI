using Domain.DomainTypes.Primitives;

namespace Domain.DomainTypes;

/// <summary>
/// Domain object representing cents.
/// </summary>
public record Cents(UnsignedIntDec2 Value) {

    /// <summary>
    /// Factory method to instantiate a new <see cref="Cents"/> instance by a given <see cref="UnsignedIntString"/>. Throws domain errors, when the given string exceeds the ranges.
    /// </summary>
    /// <exception cref="DomainErrors.InvalidRangeError"></exception>
    public static Cents Of(UnsignedIntString value) {
        return new Cents(UnsignedIntDec2.Of(value));
    }
};
