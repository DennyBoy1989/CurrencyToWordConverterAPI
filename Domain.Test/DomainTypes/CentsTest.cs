using Domain.DomainErrors;
using Domain.DomainTypes;
using Domain.DomainTypes.Primitives;

namespace Domain.Test.DomainTypes;

[TestFixture]
public class CentsTest {

    [TestCase("", 0, "0")]
    [TestCase("1", 1, "1")]
    [TestCase("99", 99, "99")]
    public void Of_WhenValidIntegerString_ThenReturnNewCents(string input, int expectedIntValue, IEnumerable<char> expectedChars) {

        var result = Cents.Of(UnsignedIntString.Of(input));

        Assert.That(result.Value.IntValue, Is.EqualTo(expectedIntValue));
        Assert.That(result.Value.Digits, Is.EquivalentTo(expectedChars));
    }

    [TestCase("100")]
    public void Of_WhenInvalidIntegerString_ThenThrowInvalidRangeError(string input) {

        Assert.That(() => Cents.Of(UnsignedIntString.Of(input)), Throws.Exception.InstanceOf<InvalidRangeError>());
    }
}
