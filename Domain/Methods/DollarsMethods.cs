using Domain.DomainTypes;
using Domain.Methods.Primitives;

namespace Domain.Methods;

public static class DollarsMethods {

    public static string GetWordRepresentationOfDollars(this Dollars dollars) {

        var numberAsWords = dollars.Value.GetWordRepresentation();
        if (dollars.Value.IntValue == 1) {
            return $"{numberAsWords} dollar";
        }
        return $"{numberAsWords} dollars";
    }
}
