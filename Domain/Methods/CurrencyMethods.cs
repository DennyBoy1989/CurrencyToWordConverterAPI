using Domain.DomainTypes;

namespace Domain.Methods;

public static class CurrencyMethods {

    public static CurrencyWordRepresentation GetWordRepresentation(this Currency currency) {

        string dollarString = currency.Dollars.GetWordRepresentation();
        if (currency.Cents.Value.IntValue == 0) {

            return new CurrencyWordRepresentation(dollarString);
        }
        else {

            string centString = currency.Cents.GetWordRepresentation();
            return new CurrencyWordRepresentation($"{dollarString} and {centString}");
        }
    }
}
