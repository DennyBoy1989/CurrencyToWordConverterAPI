using Domain.DomainErrors;
using Domain.DomainTypes.Primitives;

namespace Domain.Test.DomainTypes.Primitives;

[TestFixture]
public class UnsignedIntStringTest {

    [TestCase("", 0, "0")]
    
    [TestCase("100", 100, "100")]
    [TestCase("0037", 37, "37")]
    [TestCase(" 5 4  3  ", 543, "543")]
    [TestCase("2 147 483 647", int.MaxValue, "2147483647")]
    public void Of_WhenValidIntegerString_ThenReturnNewIntString(string input, int expectedIntValue, IEnumerable<char> expectedChars) {

        var result = UnsignedIntString.Of(input);
        
        Assert.That(result.IntValue, Is.EqualTo(expectedIntValue));
        Assert.That(result.Digits, Is.EquivalentTo(expectedChars));
    }

    [TestCase("10,00")]
    [TestCase("1/000")]
    [TestCase("2147483648")]
    [TestCase("foobar")]
    [TestCase("__100")]
    public void Of_WhenInValidIntegerString_ThenThrowInvalidNumberNotationError(string input) {

        Assert.That(() => UnsignedIntString.Of(input), Throws.Exception.InstanceOf<InvalidNumberNotationError>());
    }

    [TestCase("-1")]
    [TestCase("- 2147483647")]
    public void Of_WhenIntegerStringSmallerThenZero_ThenThrowInvalidRangeError(string input) {

        Assert.That(() => UnsignedIntString.Of(input), Throws.Exception.InstanceOf<InvalidRangeError>());
    }
}
