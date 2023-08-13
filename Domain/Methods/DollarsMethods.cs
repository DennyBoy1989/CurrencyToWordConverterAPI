using Domain.DomainTypes;
using Domain.Methods.Primitives;

namespace Domain.Methods;

public static class DollarsMethods {

    public static string GetWordRepresentationOfDollars(this Dollars dollars) {

        if (dollars.Value.IntValue == 0) {
            return $"{'0'.GetWordRepresentationOfUnitsDigit()} dollars";
        }

        if (dollars.Value.IntValue == 1) {
            return $"{'1'.GetWordRepresentationOfUnitsDigit()} dollar";
        }

        if (dollars.Value.IntValue % 1000 == 0) {
            string millionsNumber = dollars.Value.GetMillionsHundredPart().GetWordRepresentationOfMillionsNumber().ConcatWithSequenceWhenNotEmpty(" ");
            string thousandsNumber = dollars.Value.GetThousandsHundredPart().GetWordRepresentationOfThousandsNumber().ConcatWithSequenceWhenNotEmpty(" ");
            return $"{millionsNumber}{thousandsNumber}dollars";
        }
        else {
            string millionsNumber = dollars.Value.GetMillionsHundredPart().GetWordRepresentationOfMillionsNumber().ConcatWithSequenceWhenNotEmpty(" ");
            string thousandsNumber = dollars.Value.GetThousandsHundredPart().GetWordRepresentationOfThousandsNumber().ConcatWithSequenceWhenNotEmpty(" ");
            string hundredsNumber = dollars.Value.GetHundredPart().GetWordRepresentationOfHundredsNumber().ConcatWithSequenceWhenNotEmpty(" ");
            return $"{millionsNumber}{thousandsNumber}{hundredsNumber}dollars";
        }
    }
}
