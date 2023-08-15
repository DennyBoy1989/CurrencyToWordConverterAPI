using Domain.DomainTypes.Primitives;
using Domain.Methods.Primitives;

namespace Domain.Test.Methods.Primitives;

[TestFixture]
public class UnsignedIntDec2MethodsTest {

    [Test]
    public void OnUnsignedIntDec2_GetUnitsDigit_ThenReturnUnitsDigit() {

        var number = UnsignedIntDec2.Of(UnsignedIntString.Of("12"));


        var result = number.GetUnitsDigit();
        Assert.That(result, Is.EqualTo('2'));
    }

    [Test]
    public void OnUnsignedIntDec2_GetTensDigit_WhenNumberSmallerThenTen_ThenReturnZero() {

        var number = UnsignedIntDec2.Of(UnsignedIntString.Of("9"));


        var result = number.GetTensDigit();
        Assert.That(result, Is.EqualTo('0'));
    }

    [Test]
    public void OnUnsignedIntDec2_GetTensDigit_WhenNumberGreaterThenTen_ThenReturnTensDigit() {

        var number = UnsignedIntDec2.Of(UnsignedIntString.Of("37"));


        var result = number.GetTensDigit();
        Assert.That(result, Is.EqualTo('3'));
    }

    [TestCase("0", "zero")]
    [TestCase("1", "one")]
    [TestCase("11", "eleven")]
    [TestCase("30", "thirty")]
    [TestCase("99", "ninety-nine")]
    public void OnUnsignedIntDec2_GetWordRepresentation_ThenReturnWordRepresentationOfTwoDigitNumber(string input, string expectedWordRepresentation) {

        var number = UnsignedIntDec2.Of(UnsignedIntString.Of(input));


        var result = number.GetWordRepresentation();
        Assert.That(result, Is.EqualTo(expectedWordRepresentation));
    }
}
