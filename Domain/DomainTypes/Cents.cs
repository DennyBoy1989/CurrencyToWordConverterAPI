using Domain.DomainTypes.Primitives;

namespace Domain.DomainTypes;

public record Cents(UnsignedIntDec2 Value) {

    public static Cents Of(UnsignedIntString value) {
        return new Cents(UnsignedIntDec2.Of(value));
    }
};
