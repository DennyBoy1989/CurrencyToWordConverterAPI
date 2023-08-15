using Domain.DomainErrors;
using Domain.Methods.Primitives;

namespace Domain.DomainTypes.Primitives;

public class CurrencyString {

    public UnsignedIntString BeforePointValue { get; }
    public UnsignedIntString AfterPointValue { get; }

    private CurrencyString(UnsignedIntString beforePointValue, UnsignedIntString afterPointValue) {
        BeforePointValue = beforePointValue;
        AfterPointValue = afterPointValue;
    }

    public static CurrencyString Of(string value) {

        if (!value.Contains(',')) {
            return new CurrencyString(UnsignedIntString.Of(value), UnsignedIntString.Of("0"));
        }
        else {
            var sanitizedStringValue = value.RemoveWhitespace();
            var stringParts = sanitizedStringValue.Split(",");

            var beforePointValue = stringParts[0];
            var afterPointValue = stringParts[1];

            if(afterPointValue.Contains('+') || afterPointValue.Contains("-")) {
                throw new InvalidNumberNotationError($"The string '{value}' is not a valid currency value, because its after point part contains a sign.");
            }

            afterPointValue = afterPointValue + new string('0', Math.Max(0, 2 - afterPointValue.Length));
            
            return new CurrencyString(UnsignedIntString.Of(beforePointValue), UnsignedIntString.Of(afterPointValue));
        }
    }
}
