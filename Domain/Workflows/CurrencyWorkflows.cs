using Domain.DomainTypes;
using Domain.DomainTypes.Primitives;
using Domain.Methods;

namespace Domain.Workflows;

public class CurrencyWorkflows {

    public CurrencyWordRepresentation GetCurrencyWordRepresentation(string currencyString) {
        var currencyDecimalString = DecimalString.Of(currencyString, 2);
        var currency = Currency.Of(currencyDecimalString);
        return currency.GetWordRepresentation();
    }
}
