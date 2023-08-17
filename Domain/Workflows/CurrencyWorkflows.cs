using Domain.DomainTypes;
using Domain.DomainTypes.Primitives;
using Domain.Methods;
using Microsoft.Extensions.Logging;

namespace Domain.Workflows;

/// <summary>
/// Object that represents domain workflows for currency in the context of the CurrencyToWordConverterAPI
/// </summary>
public class CurrencyWorkflows {

    private ILogger<CurrencyWorkflows> logger;

    public CurrencyWorkflows(ILogger<CurrencyWorkflows> logger) {
        this.logger = logger;
    }

    /// <summary>
    /// The workflow for validating a given string that contain a currency and calculating the english word representation of that string.
    /// </summary>
    /// <exception cref="DomainErrors.InvalidNumberNotationError"></exception>
    /// <exception cref="DomainErrors.InvalidRangeError"></exception>
    public CurrencyWordRepresentation GetCurrencyWordRepresentation(string currencyString) {

        logger.LogTrace($"Starting to generate word representation for currency string '{currencyString}'");

        var currencyDecimalString = CurrencyString.Of(currencyString);
        var currency = Currency.Of(currencyDecimalString);
        var wordRepresentation =  currency.GetWordRepresentation();

        logger.LogTrace($"Finished to generate word representation for currency string '{currencyString}'. Result ist {wordRepresentation.Value} ");
        return wordRepresentation;
    }
}
