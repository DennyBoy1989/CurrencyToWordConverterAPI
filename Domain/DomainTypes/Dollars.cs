using Domain.DomainTypes.Primitives;

namespace Domain.DomainTypes;

public record Dollars(UnsignedIntDec9 Value) {
    public static Dollars Of(UnsignedIntString value) {
        return new Dollars(UnsignedIntDec9.Of(value));
    }
};
