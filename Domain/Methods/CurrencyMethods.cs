using Domain.DomainTypes;

namespace Domain.Methods;

/// <summary>
/// Extensions methods for <see cref="Currency"/> objects.
/// </summary>
public static class CurrencyMethods {

    /// <summary>
    /// Gets the english word representation of a <see cref="Currency"/> object.
    /// </summary>
    public static CurrencyWordRepresentation GetWordRepresentation(this Currency currency) {

        string dollarString = currency.Dollars.GetWordRepresentation();
        if (currency.Cents.Value.IntValue == 0) {

            return new CurrencyWordRepresentation(dollarString);
        }
        else {

            string centString = currency.Cents.GetWordRepresentation();
            return new CurrencyWordRepresentation($"{dollarString} and {centString}");
        }
    }
}
