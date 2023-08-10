namespace Domain.DomainTypes;

public record Cents(UnsignedIntDec2 Value) {
    public static Cents Of(IntString value) {
        return new Cents(UnsignedIntDec2.Of(value));
    }
};
