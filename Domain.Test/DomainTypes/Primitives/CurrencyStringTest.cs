using Domain.DomainErrors;
using Domain.DomainTypes.Primitives;

namespace Domain.Test.DomainTypes.Primitives;

[TestFixture]
public class CurrencyStringTest {

    [TestCase("", 0, "0", 0, "0")]
    [TestCase(",", 0, "0", 0, "0")]
    [TestCase("1,1", 1, "1", 10, "10")]
    [TestCase("0,10001", 0, "0", 10001, "10001")]
    [TestCase("13,37", 13, "13", 37, "37")]
    [TestCase("00 13 , ", 13, "13", 0, "0")]
    [TestCase("0 123 000 , 0 9 ", 123000, "123000", 9, "9")]
    [TestCase("2 147 483 647 , 2 147 483 647 ", int.MaxValue, "2147483647", 2147483647, "2147483647")]
    public void Of_WhenValidString_ThenReturnNewCurrencyString(string input, int expectedIntValueBeforePoint, IEnumerable<char> expectedCharsBeforePoint, int expectedIntValueAfterPoint, IEnumerable<char> expectedCharsAfterPoint) {

        var result = CurrencyString.Of(input);
        
        Assert.That(result.BeforePointValue.IntValue, Is.EqualTo(expectedIntValueBeforePoint));
        Assert.That(result.BeforePointValue.Digits, Is.EqualTo(expectedCharsBeforePoint));

        Assert.That(result.AfterPointValue.IntValue, Is.EqualTo(expectedIntValueAfterPoint));
        Assert.That(result.AfterPointValue.Digits, Is.EqualTo(expectedCharsAfterPoint));
    }


    [TestCase("10.00")]
    [TestCase("1/000")]
    [TestCase("1,-1")]
    [TestCase("1,+1")]
    [TestCase("21474836+48")]
    [TestCase("foobar")]
    [TestCase("__100")]
    public void Of_WhenInValidString_ThenThrowInvalidNumberNotationError(string input) {

        Assert.That(() => CurrencyString.Of(input), Throws.Exception.InstanceOf<InvalidNumberNotationError>());
    }
    
    [TestCase("-10,00")]
    public void Of_WhenCurrencyStringIsNegative_ThenThrowInvalidRangeError(string input) {

        Assert.That(() => CurrencyString.Of(input), Throws.Exception.InstanceOf<InvalidRangeError>());
    }
}
