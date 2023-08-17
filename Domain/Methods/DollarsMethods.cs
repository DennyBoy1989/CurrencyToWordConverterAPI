using Domain.DomainTypes;
using Domain.Methods.Primitives;

namespace Domain.Methods;

/// <summary>
/// Extensions methods for <see cref="Dollars"/> objects.
/// </summary>
public static class DollarsMethods {

    /// <summary>
    /// Gets the english word representation of a <see cref="Dollars"/> object.
    /// </summary>
    public static string GetWordRepresentation(this Dollars dollars) {

        var numberAsWords = dollars.Value.GetWordRepresentation();
        if (dollars.Value.IntValue == 1) {
            return $"{numberAsWords} dollar";
        }
        return $"{numberAsWords} dollars";
    }
}
