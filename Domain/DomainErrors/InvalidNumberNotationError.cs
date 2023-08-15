namespace Domain.DomainErrors;

/// <summary>
/// Error, that indicates that a string cannot parsed to a currency, because it contains an invalid notation or invalid characters.
/// </summary>
public class InvalidNumberNotationError : Exception {

    public InvalidNumberNotationError() : base() {
    }

    public InvalidNumberNotationError(string message) : base(message) {
    }

    public InvalidNumberNotationError(string? message, Exception e) : base(message, e) {
    }
}
