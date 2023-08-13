namespace Domain.DomainErrors;

/// <summary>
/// Error, that indicates that a given number string is bigger, then the supported range.
/// </summary>
public class InvalidRangeError : Exception {

    public InvalidRangeError() : base() {
    }

    public InvalidRangeError(string message) : base(message) {
    }

    public InvalidRangeError(string? message, Exception e) : base(message, e) {
    }
}
