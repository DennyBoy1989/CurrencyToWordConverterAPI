using Domain.DomainErrors;
using Domain.DomainTypes;
using Domain.DomainTypes.Primitives;

namespace Domain.Test.DomainTypes;

[TestFixture]
public class DollarsTest {

    [TestCase("", 0, "0")]
    [TestCase("1", 1, "1")]
    [TestCase("999999999", 999999999, "999999999")]
    public void Of_WhenValidIntegerString_ThenReturnNewDollars(string input, int expectedIntValue, IEnumerable<char> expectedChars) {

        var result = Dollars.Of(UnsignedIntString.Of(input));

        Assert.That(result.Value.IntValue, Is.EqualTo(expectedIntValue));
        Assert.That(result.Value.Digits, Is.EquivalentTo(expectedChars));
    }

    [TestCase("1000000000")]
    public void Of_WhenInvalidIntegerString_ThenThrowInvalidRangeError(string input) {

        Assert.That(() => Dollars.Of(UnsignedIntString.Of(input)), Throws.Exception.InstanceOf<InvalidRangeError>());
    }
}
