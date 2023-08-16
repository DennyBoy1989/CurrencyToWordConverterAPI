using Domain.DomainTypes;
using Domain.DomainTypes.Primitives;
using Domain.Methods;
using Microsoft.Extensions.Logging;

namespace Domain.Workflows;

public class CurrencyWorkflows {

    private ILogger<CurrencyWorkflows> logger;

    public CurrencyWorkflows(ILogger<CurrencyWorkflows> logger) {
        this.logger = logger;
    }

    public CurrencyWordRepresentation GetCurrencyWordRepresentation(string currencyString) {

        logger.LogTrace($"Starting to generate word representation for currency string '{currencyString}'");

        var currencyDecimalString = CurrencyString.Of(currencyString);
        var currency = Currency.Of(currencyDecimalString);
        var wordRepresentation =  currency.GetWordRepresentation();

        logger.LogTrace($"Finished to generate word representation for currency string '{currencyString}'. Result ist {wordRepresentation.Value} ");
        return wordRepresentation;
    }
}
