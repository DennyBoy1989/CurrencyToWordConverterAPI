namespace Domain.DomainTypes;

public class DecimalString {

    public IntString BeforePointValue { get; }
    public IntString AfterPointValue { get; }

    private DecimalString(IntString beforePointValue, IntString afterPointValue) {
        BeforePointValue = beforePointValue;
        AfterPointValue = afterPointValue;
    }

    public static DecimalString Of(string value, int decimalPlacesCount) {

        if (!value.Contains(',')) {
            return new DecimalString(IntString.Of(value), IntString.Of("0"));
        }
        else {
            var sanitizedStringValue = value.RemoveWhitespace();
            var stringParts = sanitizedStringValue.Split(",");

            var beforePointValue = stringParts[0];
            var afterPointValue = stringParts[1];

            afterPointValue = afterPointValue + new string('0', decimalPlacesCount - afterPointValue.Length);

            return new DecimalString(IntString.Of(beforePointValue), IntString.Of(afterPointValue));
        }

    }
}
