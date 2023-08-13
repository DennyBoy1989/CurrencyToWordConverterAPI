namespace Domain.DomainErrors;

/// <summary>
/// Error, that indicates that a string cannot parsed to a currency, because it contains an invalid notation or invalid characters.
/// </summary>
public class InvalidCurrencyNotationError : Exception {

    public InvalidCurrencyNotationError() : base() {
    }

    public InvalidCurrencyNotationError(string message) : base(message) {
    }

    public InvalidCurrencyNotationError(string? message, Exception e) : base(message, e) {
    }
}
