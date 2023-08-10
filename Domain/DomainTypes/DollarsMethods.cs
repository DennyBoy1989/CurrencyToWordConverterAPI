namespace Domain.DomainTypes; 

public static class DollarsMethods {

    public static string GetWordRepresentationOfDollars(this Dollars dollars) {

        string millionsNumber = dollars.Value.GetMillionsHundredPart().GetWordRepresentationOfMillionsNumber();
        string thousandsNumber = dollars.Value.GetThousandsHundredPart().GetWordRepresentationOfThousandsNumber();
        string hundredsNumber = dollars.Value.GetHundredPart().GetWordRepresentationOfHundredsNumber();
        if (dollars.Value.IntValue == 1) {
            return $"{hundredsNumber} dollar";
        }
        return $"{millionsNumber}{thousandsNumber}{hundredsNumber} dollars";
    }
}
