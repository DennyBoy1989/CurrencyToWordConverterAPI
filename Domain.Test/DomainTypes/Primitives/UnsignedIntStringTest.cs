using Domain.DomainErrors;
using Domain.DomainTypes.Primitives;

namespace Domain.Test.DomainTypes.Primitives;

[TestFixture]
public class UnsignedIntStringTest {

    [TestCase("", 0u, "0")]
    [TestCase("100", 100u, "100")]
    [TestCase("0037", 37u, "37")]
    [TestCase(" 5 4  3  ", 543u, "543")]
    [TestCase("4 294 967 295", uint.MaxValue, "4294967295")]
    public void Of_WhenValidIntegerString_ThenReturnNewIntString(string input, uint expectedIntValue, IEnumerable<char> expectedChars) {

        var result = UnsignedIntString.Of(input);
        
        Assert.That(result.IntValue, Is.EqualTo(expectedIntValue));
        Assert.That(result.Digits, Is.EquivalentTo(expectedChars));
    }

    [TestCase("10,00")]
    [TestCase("1/000")]
    [TestCase("foobar")]
    [TestCase("__100")]
    public void Of_WhenInValidIntegerString_ThenThrowInvalidNumberNotationError(string input) {

        Assert.That(() => UnsignedIntString.Of(input), Throws.Exception.InstanceOf<InvalidNumberNotationError>());
    }

    [TestCase("4294967296")]
    [TestCase("-1")]
    [TestCase("- 2147483647")]
    public void Of_WhenIntegerStringSmallerThenZero_ThenThrowInvalidRangeError(string input) {

        Assert.That(() => UnsignedIntString.Of(input), Throws.Exception.InstanceOf<InvalidRangeError>());
    }
}
