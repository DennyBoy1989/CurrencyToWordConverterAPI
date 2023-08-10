namespace Domain.DomainTypes;
public class UnsignedIntDec3 {

    public int IntValue { get;}
    public string StringValue { get;}

    private UnsignedIntDec3(int intValue, string stringValue) {
        IntValue = intValue;
        StringValue = stringValue;
    }

    public static UnsignedIntDec3 Of(IntString value) {

        if (value.IntValue < 0) {
            throw new ArgumentException();
        }

        if (value.IntValue > 999) {
            throw new ArgumentException();
        }

        return new UnsignedIntDec3(value.IntValue, value.StringValue);
    }
}
