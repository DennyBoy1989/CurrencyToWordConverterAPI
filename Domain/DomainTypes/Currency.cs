using Domain.DomainTypes.Primitives;

namespace Domain.DomainTypes;

/// <summary>
/// Domain object representing a currency.
/// </summary>
public record Currency(Dollars Dollars, Cents Cents) {

    /// <summary>
    /// Factory method to instantiate a new <see cref="Currency"/> instance by a given <see cref="CurrencyString"/>. Throws domain errors, when the given string exceeds the ranges.
    /// </summary>
    /// <exception cref="DomainErrors.InvalidRangeError"></exception>
    public static Currency Of(CurrencyString value) {
        return new Currency(Dollars.Of(value.BeforePointValue), Cents.Of(value.AfterPointValue));
    }
}