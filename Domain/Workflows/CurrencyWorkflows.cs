using Domain.DomainTypes;
using Domain.DomainTypes.Primitives;
using Domain.Methods;

namespace Domain.Workflows;

public class CurrencyWorkflows {

    public CurrencyWordRepresentation GetCurrencyWordRepresentation(string currencyString) {
        var currencyDecimalString = CurrencyString.Of(currencyString);
        var currency = Currency.Of(currencyDecimalString);
        return currency.GetWordRepresentation();
    }
}
