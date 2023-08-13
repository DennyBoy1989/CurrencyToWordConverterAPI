using Domain.DomainTypes.Primitives;
using Domain.DomainTypes;
using Domain.Methods.Primitives;

namespace Domain.Test.Methods.Primitives;

[TestFixture]
public class DigitCharMethodsTest {

    [TestCase('0', "zero")]
    [TestCase('1', "one")]
    [TestCase('2', "two")]
    [TestCase('3', "three")]
    [TestCase('4', "four")]
    [TestCase('5', "five")]
    [TestCase('6', "six")]
    [TestCase('7', "seven")]
    [TestCase('8', "eight")]
    [TestCase('9', "nine")]
    public void OnChar_GetWordRepresentationOfUnitsDigit_WhenGivenValidDigit_ThenReturnUnitValueAsString(char input, string expectedOutput) {

        var result = input.GetWordRepresentationOfUnitsDigit();

        Assert.That(result, Is.EqualTo(expectedOutput));
    }


    [TestCase('a')]
    [TestCase(';')]
    [TestCase('\0')]
    public void OnChar_GetWordRepresentationOfUnitsDigit_WhenGivenANonDigit_ThenReturnEmptyString(char input) {

        var result = input.GetWordRepresentationOfUnitsDigit();

        Assert.That(result, Is.EqualTo(""));
    }


    [TestCase('0', "ten")]
    [TestCase('1', "eleven")]
    [TestCase('2', "twelve")]
    [TestCase('3', "thirteen")]
    [TestCase('4', "fourteen")]
    [TestCase('5', "fifteen")]
    [TestCase('6', "sixteen")]
    [TestCase('7', "seventeen")]
    [TestCase('8', "eighteen")]
    [TestCase('9', "nineteen")]
    public void OnChar_GetWordRepresentationOfNumberBetweenTenAndNineTeen_WhenGivenValidDigit_ThenReturnNumberValueBetweenTenAndNineTennAsString(char input, string expectedOutput) {

        var result = input.GetWordRepresentationOfNumberBetweenTenAndNineTeen();

        Assert.That(result, Is.EqualTo(expectedOutput));
    }

    [TestCase('a')]
    [TestCase(';')]
    [TestCase('\0')]
    public void OnChar_GetWordRepresentationOfNumberBetweenTenAndNineTeen_WhenGivenANonDigit_ThenReturnEmptyString(char input) {

        var result = input.GetWordRepresentationOfNumberBetweenTenAndNineTeen();

        Assert.That(result, Is.EqualTo(""));
    }


    [TestCase('0', "")]
    [TestCase('1', "ten")]
    [TestCase('2', "twenty")]
    [TestCase('3', "thirty")]
    [TestCase('4', "forty")]
    [TestCase('5', "fifty")]
    [TestCase('6', "sixty")]
    [TestCase('7', "seventy")]
    [TestCase('8', "eighty")]
    [TestCase('9', "ninety")]
    public void OnChar_GetWordRepresentationOfTensDigit_WhenGivenValidDigit_ThenReturnTensDigitValueAsString(char input, string expectedOutput) {

        var result = input.GetWordRepresentationOfTensDigit();

        Assert.That(result, Is.EqualTo(expectedOutput));
    }

    [TestCase('a')]
    [TestCase(';')]
    [TestCase('\0')]

    public void OnChar_GetWordRepresentationOfTensDigit_WhenGivenANonDigit_ThenReturnEmptyString(char input) {

        var result = input.GetWordRepresentationOfTensDigit();

        Assert.That(result, Is.EqualTo(""));
    }


    [TestCase('0', "")]
    [TestCase('1', "one hundred")]
    [TestCase('2', "two hundred")]
    [TestCase('3', "three hundred")]
    [TestCase('4', "four hundred")]
    [TestCase('5', "five hundred")]
    [TestCase('6', "six hundred")]
    [TestCase('7', "seven hundred")]
    [TestCase('8', "eight hundred")]
    [TestCase('9', "nine hundred")]
    public void OnChar_GetWordRepresentationOfHundredsDigit_WhenGivenValidDigit_ThenReturnHundredsDigitValueAsString(char input, string expectedOutput) {

        var result = input.GetWordRepresentationOfHundredsDigit();

        Assert.That(result, Is.EqualTo(expectedOutput));
    }

    [TestCase('a')]
    [TestCase(';')]
    [TestCase('\0')]

    public void OnChar_GetWordRepresentationOfHundredsDigitt_WhenGivenANonDigit_ThenReturnEmptyString(char input) {

        var result = input.GetWordRepresentationOfHundredsDigit();

        Assert.That(result, Is.EqualTo(""));
    }
}
