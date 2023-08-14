using Domain.DomainTypes.Primitives;
using Domain.Methods.Primitives;

namespace Domain.Test.Methods.Primitives;

[TestFixture]
public class UnsignedIntDec9MethodsTest {

    [TestCase("0", "")]
    [TestCase("123456", "")]
    [TestCase("1000000", "one million")]
    [TestCase("101000000", "one hundred one million")]
    [TestCase("786193245", "seven hundred eighty-six million")]
    public void OnUnsignedIntDec9_GetWordRepresentationOfMillionsNumber_ThenReturnTheWordRepresentationOfTheMillionsSection(string input, string expectedWordRepresentation) {
        var number = UnsignedIntDec9.Of(IntString.Of(input));

        var result = number.GetWordRepresentationOfMillionsNumber();
        Assert.That(result, Is.EqualTo(expectedWordRepresentation));
    }

    [TestCase("0", "")]
    [TestCase("123456", "one hundred twenty-three thousand")]
    [TestCase("1000000", "")]
    [TestCase("101202000", "two hundred two thousand")]
    [TestCase("786193245", "one hundred ninety-three thousand")]
    [TestCase("14245", "fourteen thousand")]
    public void OnUnsignedIntDec9_GetWordRepresentationOfThousandsNumber_ThenReturnTheWordRepresentationOfTheThousandsSection(string input, string expectedWordRepresentation) {
        var number = UnsignedIntDec9.Of(IntString.Of(input));

        var result = number.GetWordRepresentationOfThousandsNumber();
        Assert.That(result, Is.EqualTo(expectedWordRepresentation));
    }

    [TestCase("0", "zero")]
    [TestCase("123456", "four hundred fifty-six")]
    [TestCase("1000000", "zero")]
    [TestCase("101202303", "three hundred three")]
    [TestCase("786193016", "sixteen")]
    public void OnUnsignedIntDec9_GetWordRepresentationOfHundredsNumber_ThenReturnTheWordRepresentationOfTheHundredsSection(string input, string expectedWordRepresentation) {
        var number = UnsignedIntDec9.Of(IntString.Of(input));

        var result = number.GetWordRepresentationOfHundredsNumber();
        Assert.That(result, Is.EqualTo(expectedWordRepresentation));
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
    public void OnUnsignedIntDec9_GetHundredsDigit_WhenNumberGreaterThenNinetynine_ThenReturnHundredsDigit() {
        var number = UnsignedIntDec9.Of(IntString.Of("245"));

        var result = number.GetHundredsDigit();
        Assert.That(result, Is.EqualTo('2'));
    }

    [Test]
    public void OnUnsignedIntDec9_GetThousandsDigit_WhenNumberSmallerThenOneThousand_ThenReturnZero() {
        var number = UnsignedIntDec9.Of(IntString.Of("64"));

        var result = number.GetThousandsDigit();
        Assert.That(result, Is.EqualTo('0'));
    }

    [Test]
    public void OnUnsignedIntDec9_GetThousandsDigit_WhenNumberGreaterOrEqualOneThousand_ThenReturnThousandsDigit() {
        var number = UnsignedIntDec9.Of(IntString.Of("3245"));

        var result = number.GetThousandsDigit();
        Assert.That(result, Is.EqualTo('3'));
    }

    [Test]
    public void OnUnsignedIntDec9_GetTenThousandsDigit_WhenNumberSmallerThenTenThousand_ThenReturnZero() {
        var number = UnsignedIntDec9.Of(IntString.Of("64"));

        var result = number.GetTenThousandsDigit();
        Assert.That(result, Is.EqualTo('0'));
    }

    [Test]
    public void OnUnsignedIntDec9_GetTenThousandsDigit_WhenNumberGreaterOrEqualTenThousand_ThenReturnTenThousandsDigit() {
        var number = UnsignedIntDec9.Of(IntString.Of("93245"));

        var result = number.GetTenThousandsDigit();
        Assert.That(result, Is.EqualTo('9'));
    }

    [Test]
    public void OnUnsignedIntDec9_GetHundredThousandsDigit_WhenNumberSmallerThenOneHundredThousand_ThenReturnZero() {
        var number = UnsignedIntDec9.Of(IntString.Of("64"));

        var result = number.GetHundredThousandsDigit();
        Assert.That(result, Is.EqualTo('0'));
    }

    [Test]
    public void OnUnsignedIntDec9_GetHundredThousandsDigit_WhenNumberGreaterOrEqualOneHundredThousand_ThenReturnHundredThousandsDigit() {
        var number = UnsignedIntDec9.Of(IntString.Of("193245"));

        var result = number.GetHundredThousandsDigit();
        Assert.That(result, Is.EqualTo('1'));
    }

    [Test]
    public void OnUnsignedIntDec9_GetMillionssDigit_WhenNumberSmallerThenOneMillion_ThenReturnZero() {
        var number = UnsignedIntDec9.Of(IntString.Of("64"));

        var result = number.GetMillionssDigit();
        Assert.That(result, Is.EqualTo('0'));
    }

    [Test]
    public void OnUnsignedIntDec9_GetMillionssDigit_WhenNumberGreaterOrEqualOneMillion_ThenReturnMillionsDigit() {
        var number = UnsignedIntDec9.Of(IntString.Of("6193245"));
        
        var result = number.GetMillionssDigit();
        Assert.That(result, Is.EqualTo('6'));
    }

    [Test]
    public void OnUnsignedIntDec9_GetTenMillionssDigit_WhenNumberSmallerThenTenMillion_ThenReturnZero() {
        var number = UnsignedIntDec9.Of(IntString.Of("64"));

        var result = number.GetTenMillionssDigit();
        Assert.That(result, Is.EqualTo('0'));
    }

    [Test]
    public void OnUnsignedIntDec9_GetTenMillionssDigit_WhenNumberGreaterOrEqualTenMillion_ThenReturnTenMillionsDigit() {
        var number = UnsignedIntDec9.Of(IntString.Of("86193245"));

        var result = number.GetTenMillionssDigit();
        Assert.That(result, Is.EqualTo('8'));
    }

    [Test]
    public void OnUnsignedIntDec9_GetHundredMillionssDigit_WhenNumberSmallerThenOneHundredMillion_ThenReturnZero() {
        var number = UnsignedIntDec9.Of(IntString.Of("64"));

        var result = number.GetHundredMillionssDigit();
        Assert.That(result, Is.EqualTo('0'));
    }

    [Test]
    public void OnUnsignedIntDec9_GetHundredMillionssDigit_WhenNumberGreaterOrEqualOneHundredMillion_ThenReturnHundredMillionsDigit() {
        var number = UnsignedIntDec9.Of(IntString.Of("786193245"));

        var result = number.GetHundredMillionssDigit();
        Assert.That(result, Is.EqualTo('7'));
    }

    [Test]
    public void OnUnsignedIntDec9_GetMillionsHundredPart_ThenReturnHundredsPartOfTheMillionsSection() {
        var number = UnsignedIntDec9.Of(IntString.Of("786193245"));

        var result = number.GetMillionsHundredPart();
        Assert.That(result.IntValue, Is.EqualTo(786));
    }

    [Test]
    public void OnUnsignedIntDec9_GetThousandsHundredPart_ThenReturnHundredsPartOfTheThousandsSection() {
        var number = UnsignedIntDec9.Of(IntString.Of("786193245"));

        var result = number.GetThousandsHundredPart();
        Assert.That(result.IntValue, Is.EqualTo(193));
    }

    [Test]
    public void OnUnsignedIntDec9_GetHundredPart_ThenReturnHundredsPartOfTheHundredsSection() {
        var number = UnsignedIntDec9.Of(IntString.Of("786193245"));

        var result = number.GetHundredPart();
        Assert.That(result.IntValue, Is.EqualTo(245));
    }

}
