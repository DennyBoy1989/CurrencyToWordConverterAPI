namespace Domain.DomainTypes;

public static class CurrencyMethods {

    public static CurrencyWordRepresentation GetWordRepresentation(this Currency currency) {
        string dollarString = currency.Dollars.GetWordRepresentationOfDollars();
        if(currency.Cents.Value.IntValue == 0 ) {
            return new CurrencyWordRepresentation(dollarString);
        }
        else {
            string centString = currency.Cents.GetWordRepresentationOfCents();
            return new CurrencyWordRepresentation($"{dollarString} and {centString}");
        }
    }
}
