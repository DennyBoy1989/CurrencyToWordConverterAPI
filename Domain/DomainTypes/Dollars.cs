namespace Domain.DomainTypes;

public record Dollars(UnsignedIntDec9 Value) {
    public static Dollars Of(IntString value) {
        return new Dollars(UnsignedIntDec9.Of(value));
    }
};
