using Domain.DomainTypes;
using Domain.DomainTypes.Primitives;
using Domain.Methods;

namespace Domain.Test.Methods;

[TestFixture]
public class DollarsMethodsTest {

    [TestCase("0", "zero dollars")]
    [TestCase("20 000", "twenty thousand dollars")]
    [TestCase("999 999 999", "nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine dollars")]
    public void OnDollars_GetWordRepresentation_WhenNotOne_ThenReturnValueWithSuffixCents(string input, string expectedWordRepresentation) {
        var dollars = Dollars.Of(UnsignedIntString.Of(input));

        var result = dollars.GetWordRepresentation();
        Assert.That(result, Is.EqualTo(expectedWordRepresentation));
    }

    [Test]
    public void OnDollars_GetWordRepresentation_WhenNotOne_ThenReturnValueWithSuffixCents() {
        var dollars = Dollars.Of(UnsignedIntString.Of("1"));

        var result = dollars.GetWordRepresentation();
        Assert.That(result, Is.EqualTo("one dollar"));
    }
}
