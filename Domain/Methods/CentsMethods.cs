using Domain.DomainTypes;
using Domain.Methods.Primitives;

namespace Domain.Methods;

public static class CentsMethods {

    public static string GetWordRepresentation(this Cents cents) {

        var numberAsWords = cents.Value.GetWordRepresentation();
        if (cents.Value.IntValue == 1) {
            return $"{numberAsWords} cent";
        }
        return $"{numberAsWords} cents";
    }
}
