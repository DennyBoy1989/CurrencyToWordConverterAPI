namespace Domain.DomainTypes;

public class IntString {

    public string StringValue { get; }
    public int IntValue { get; }

    private IntString(string stringValue, int intValue) {
        StringValue = stringValue;
        IntValue = intValue;
    }

    public static IntString Of(string value) {

        var sanitizedStringValue = value.RemoveWhitespace()
            .TrimStart('0');

        if (sanitizedStringValue.Count() == 0) {
            return new IntString("0", 0);
        }

        var intValue = int.Parse(sanitizedStringValue);
        return new IntString(sanitizedStringValue, intValue);
    }
}
