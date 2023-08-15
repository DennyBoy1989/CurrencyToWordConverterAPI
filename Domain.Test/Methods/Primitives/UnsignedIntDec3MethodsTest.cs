using Domain.DomainTypes.Primitives;
using Domain.Methods.Primitives;

namespace Domain.Test.Methods.Primitives;

[TestFixture]
public class UnsignedIntDec3MethodsTest {

    [Test]
    public void OnUnsignedIntDec3_GetUnitsDigit_ThenReturnUnitsDigit() {

        var number = UnsignedIntDec3.Of(UnsignedIntString.Of("12"));


        var result = number.GetUnitsDigit();
        Assert.That(result, Is.EqualTo('2'));
    }

    [Test]
    public void OnUnsignedIntDec3_GetTensDigit_WhenNumberSmallerThenTen_ThenReturnZero() {

        var number = UnsignedIntDec3.Of(UnsignedIntString.Of("9"));


        var result = number.GetTensDigit();
        Assert.That(result, Is.EqualTo('0'));
    }

    [Test]
    public void OnUnsignedIntDec3_GetTensDigit_WhenNumberGreaterThenTen_ThenReturnTensDigit() {

        var number = UnsignedIntDec3.Of(UnsignedIntString.Of("37"));


        var result = number.GetTensDigit();
        Assert.That(result, Is.EqualTo('3'));
    }

    [Test]
    public void OnUnsignedIntDec3_GetHundredsDigit_WhenNumberSmallerThenOnehundred_ThenReturnZero() {

        var number = UnsignedIntDec3.Of(UnsignedIntString.Of("64"));


        var result = number.GetHundredsDigit();
        Assert.That(result, Is.EqualTo('0'));
    }

    [Test]
    public void OnUnsignedIntDec3_GetHundredsDigit_WhenNumberGreaterThenNinetynine_ThenReturnHundredsDigit() {

        var number = UnsignedIntDec3.Of(UnsignedIntString.Of("245"));


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
    public void OnUnsignedIntDec3_GetWordRepresentation_ThenReturnWordRepresentationOfTwoDigitNumber(string input, string expectedWordRepresentation) {

        var number = UnsignedIntDec3.Of(UnsignedIntString.Of(input));


        var result = number.GetWordRepresentation();
        Assert.That(result, Is.EqualTo(expectedWordRepresentation));
    }
}
