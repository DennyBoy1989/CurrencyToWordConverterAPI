using Domain.DomainErrors;
using Domain.DomainTypes;
using Domain.DomainTypes.Primitives;

namespace Domain.Test.DomainTypes;

[TestFixture]
public class CurrencyTest {

    [TestCase("", 0, "0", 0, "0")]
    [TestCase("1", 1, "1", 0, "0")]
    [TestCase("999999999,1", 999999999, "999999999", 10, "10")]
    [TestCase("999999999,99", 999999999, "999999999", 99, "99")]
    public void Of_WhenValidCurrencyString_ThenReturnNewCurrency(string input, int expectedDollarsIntValue, IEnumerable<char> expectedDollarsChars, int expectedCentsIntValue, IEnumerable<char> expectedCentsChars) {

        var result = Currency.Of(CurrencyString.Of(input));

        Assert.That(result.Dollars.Value.IntValue, Is.EqualTo(expectedDollarsIntValue));
        Assert.That(result.Dollars.Value.Digits, Is.EqualTo(expectedDollarsChars));
        Assert.That(result.Cents.Value.IntValue, Is.EqualTo(expectedCentsIntValue));
        Assert.That(result.Cents.Value.Digits, Is.EqualTo(expectedCentsChars));
    }

    [TestCase("1000000000,99")]
    [TestCase("999999999,100")]
    public void Of_WhenInvalidIntegerString_ThenThrowInvalidRangeError(string input) {

        Assert.That(() => Currency.Of(CurrencyString.Of(input)), Throws.Exception.InstanceOf<InvalidRangeError>());
    }
}
