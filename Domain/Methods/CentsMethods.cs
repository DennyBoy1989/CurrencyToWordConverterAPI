using Domain.DomainTypes;
using Domain.Methods.Primitives;

namespace Domain.Methods;

/// <summary>
/// Extensions methods for <see cref="Cents"/> objects.
/// </summary>
public static class CentsMethods {

    /// <summary>
    /// Gets the english word representation of a <see cref="Cents"/> object.
    /// </summary>
    public static string GetWordRepresentation(this Cents cents) {

        var numberAsWords = cents.Value.GetWordRepresentation();
        if (cents.Value.IntValue == 1) {
            return $"{numberAsWords} cent";
        }
        return $"{numberAsWords} cents";
    }
}
