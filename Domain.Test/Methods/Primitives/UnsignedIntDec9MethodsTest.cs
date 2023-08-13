using Domain.DomainTypes.Primitives;
using Domain.Methods.Primitives;

namespace Domain.Test.Methods.Primitives;

[TestFixture]
public class UnsignedIntDec9MethodsTest {

    [Test]
    public void OnUnsignedIntDec9_GetUnitsDigit_ThenReturnUnitsDigit() {

        var number = UnsignedIntDec9.Of(IntString.Of("12"));


        var result = number.GetUnitsDigit();
        Assert.That(result, Is.EqualTo('2'));
    }

    [Test]
    public void OnUnsignedIntDec9_GetTensDigit_WhenNumberSmallerThenTen_ThenReturnZero() {

        var number = UnsignedIntDec9.Of(IntString.Of("9"));


        var result = number.GetTensDigit();
        Assert.That(result, Is.EqualTo('0'));
    }

    [Test]
    public void OnUnsignedIntDec9_GetTensDigit_WhenNumberGreaterThenTen_ThenReturnTensDigit() {

        var number = UnsignedIntDec9.Of(IntString.Of("37"));


        var result = number.GetTensDigit();
        Assert.That(result, Is.EqualTo('3'));
    }

    [Test]
    public void OnUnsignedIntDec9_GetHundredsDigit_WhenNumberSmallerThenOnehundred_ThenReturnZero() {

        var number = UnsignedIntDec9.Of(IntString.Of("64"));


        var result = number.GetHundredsDigit();
        Assert.That(result, Is.EqualTo('0'));
    }

    [Test]
    public void OnUnsignedIntDec9_GetHundredsDigit_WhenNumberGreaterThenNinetynine_ThenReturnTensDigit() {

        var number = UnsignedIntDec9.Of(IntString.Of("245"));


        var result = number.GetHundredsDigit();
        Assert.That(result, Is.EqualTo('2'));
    }

    [TestCase("0", "zero")]
    [TestCase("1", "one")]
    [TestCase("11", "eleven")]
    [TestCase("30", "thirty")]
    [TestCase("99", "ninety-nine")]
    [TestCase("100", "one hundred")]
    [TestCase("312", "three hundred twelve")]
    [TestCase("759", "seven hundred fifty-nine")]
    [TestCase("860", "eight hundred sixty")]
    [TestCase("1000", "one thousand")]
    [TestCase("45100", "forty-five thousand one hundred")]
    [TestCase("250360", "two hundred fifty thousand three hundred sixty")]
    [TestCase("200300", "two hundred thousand three hundred")]
    [TestCase("1000000", "one million")]
    [TestCase("100000100", "one hundred million one hundred")]
    [TestCase("999999999", "nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine")]
    [TestCase("123456789", "one hundred twenty-three million four hundred fifty-six thousand seven hundred eighty-nine")]
    [TestCase("110111112", "one hundred ten million one hundred eleven thousand one hundred twelve")]
    public void OnUnsignedIntDec9_GetWordRepresentation_ThenReturnWordRepresentationOfTwoDigitNumber(string input, string expectedWordRepresentation) {

        var number = UnsignedIntDec9.Of(IntString.Of(input));


        var result = number.GetWordRepresentation();
        Assert.That(result, Is.EqualTo(expectedWordRepresentation));
    }
}
