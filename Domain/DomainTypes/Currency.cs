namespace Domain.DomainTypes;

public record Currency(Dollars Dollars, Cents Cents) {

    public static Currency Of(DecimalString value) {
        return new Currency(Dollars.Of(value.BeforePointValue), Cents.Of(value.AfterPointValue));
    }
}