using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainTypes; 
public static class CurrencyMethods {

    public static CurrencyWordRepresentation GetWordRepresentation(this Currency currency) {
        string hundredsTensAndOnes = GetWordRepresentationOfDollars(currency.Dollars);
        return new CurrencyWordRepresentation(hundredsTensAndOnes);
    }

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
